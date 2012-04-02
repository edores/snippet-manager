using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Forms;

namespace Snippet
{
    public partial class MainForm
    {
        private void NewCollection()
        {
            // Save collection
            SaveFormDataIfDirty();

            // Reset form and data
            Reset();
        }


        private void OpenCollection(string FullFileName)
        {
            // save previous collection if it exist
            SaveFormDataIfDirty();

            // Reset Form and data
            Reset();

            // Set collection File
            string collectionFileToOpen = FullFileName;

            if (string.IsNullOrEmpty(collectionFileToOpen))
            {
                data.StatusBar.Message = "Unable to open collection file";
                UpdateStatusBar();
                return;
            }

            // Load XML
            XDocument doc = new XDocument();
            try
            {
                doc = XDocument.Load(collectionFileToOpen);
            }
            catch (Exception e)
            {
                data.IsCollectionSaved = true;
                data.StatusBar.Message = "XML ERROR: " + e.Message;
                UpdateStatusBar();
                return;
            }

            // Initialize data dictionary
            data.DataDictionary = new Dictionary<string, List<string>>();

            // Populate Dictionary
            try
            {
                var test = doc.Element("collection").Descendants("file");

            }
            catch (Exception)
            {
                data.IsCollectionSaved = true;
                data.StatusBar.Message = "XML ERROR: Cannot find tag <collection> or <file> in provided XML";
                UpdateStatusBar();
                return;
            }

            var myFiles = doc.Element("collection").Descendants("file");
            foreach (var myFile in myFiles)
            {
                var tagList = new List<string>();
                foreach (var tag in myFile.Attribute("tags").Value.Split(new char[] { ',' }))
                {
                    if (!string.IsNullOrWhiteSpace(tag))         // "".split(",") = string[0];  -- need to suppress it
                    {
                        tagList.Add(tag);
                    }
                }
                data.DataDictionary.Add(myFile.Attribute("path").Value, tagList);
            }

            // Finalize form data
            data.CollectionFileFullName = collectionFileToOpen;
            data.IsCollectionSaved = true;

            // Remove non-existant files from dictionary
            CleanDataDictionary();

            PopulateFileSelector();

            data.StatusBar.Message = string.Format("Collection has been opened; Total Files: {0}", data.DataDictionary.Count);
            if (data.NotFoundFileCounter > 0)
            {
                data.StatusBar.Message += string.Format(" Removed files: {0}", data.NotFoundFileCounter);
            }

            data.StatusBar.Collection = collectionFileToOpen;

            UpdateStatusBar();

            // Add current file to MRU List
            data.RecentCollectionsOpened.Add(FullFileName);
        }

        private void OpenCollection()
        {
            // Pick collection File
            string collectionFileToOpen = SelectFileToOpen();

            OpenCollection(collectionFileToOpen);
        }

        #region Add Folder to Collection
        private DialogResult ShowAddFolderDialog()
        {
            Form addFolderDialog = new AddFolderDialog(this);
            DialogResult result = addFolderDialog.ShowDialog();

            return result;
        }

        // Add (append) a new folder (files) to collection
        private void AddFolder()
        {
            if (ShowAddFolderDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (data.AddedFolder != null && data.AddedFolder.IsValidated)
                {
                    // Select folder to add
                    string folderToAddFullPath = data.AddedFolder.FolderPath;

                    // Initialize file list
                    data.DataFilesList = new List<string>();

                    // Traverse folder recursively and get list of files
                    DirSearch(folderToAddFullPath, data.AddedFolder.SubFolders);    // Selected files in formdata.DataFilesList

                    // Initialize Data Directory if needed
                    if (data.DataDictionary == null)
                    {
                        data.DataDictionary = new Dictionary<string, List<string>>();
                    }

                    int filesTotal = data.DataDictionary.Count;

                    // Add list of files to directory
                    foreach (var item in data.DataFilesList)
                    {
                        if (data.DataDictionary.ContainsKey(item))
                        {
                            //skip to avoid exited tags corruption
                        }
                        else
                        {
                            // Add service tags
                            var lst = new List<string>();
                            data.DataDictionary.Add(item, lst);

                            data.StatusBar.File = item;
                            UpdateStatusBar();
                        }
                    }

                    data.NewFileCounter = data.DataDictionary.Count - filesTotal;

                    // Remove non-existant files from dictionary
                    CleanDataDictionary();

                    // Populate file selector
                    PopulateFileSelector();

                    // Mark collection as "dirty"
                    MarkCollectionAsDirty();

                    // Update status bar
                    data.StatusBar.Message = string.Format("Folder {0} has been added to collection; ", folderToAddFullPath);
                    data.StatusBar.Message += string.Format("Added Files {0}; ", data.NewFileCounter);
                    data.StatusBar.Message += string.Format("Removed Files: {0}; ", data.NotFoundFileCounter);
                    data.StatusBar.Message += string.Format("Total Files in Collection: {0};", data.DataDictionary.Count);

                    data.StatusBar.File = "";
                    data.StatusBar.Collection = data.CollectionFileFullName;
                    UpdateStatusBar();
                    return;
                }
                ShowError("Add Folder > Data provided hasn't passed validation: " + data.AddedFolder.ValidationMessage);
                return;
            }
            else
            {
                ShowInfo("Add Follder to collection Dialog> Cancelled");
                return;
            }
        }





        // Traverse folder, get file list
        void DirSearch(string sDir, bool bIsRecursive)
        {
            if (Path.GetFileName(sDir).StartsWith("."))
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(sDir))
            {
                ShowError("FAILURE: Directory doesn't exist: " + data.AddedFolder);
                return;
            }

            try
            {
                if (bIsRecursive)
                {
                    GetFilesInFolder(sDir);
                    foreach (string d in Directory.GetDirectories(sDir))
                    {
                        GetFilesInFolder(d);
                        DirSearch(d, bIsRecursive);
                    }
                }
                else
                {
                    GetFilesInFolder(sDir);
                }
            }
            catch (System.Exception ex)
            {
                ShowError("FAILURE: DirSearch: " + ex.Message);
            }
        }

        // Select all files in given folder that are conform to filter
        private void GetFilesInFolder(string d)
        {

            if (Path.GetFileName(d).StartsWith("."))
            {
                return;
            }

            foreach (string f in Directory.GetFiles(d))
            {
                // skip file if begins with dot

                if (Path.GetFileName(f).StartsWith("."))
                {
                    continue;
                }

                // Get file if its extension matches
                if (FileFilter(f))
                {
                    data.DataFilesList.Add(f);
                }
            }
        }

        // Filter file by it's extention
        private bool FileFilter(string fileName)
        {
            const string ALL_FILES_FILTER = ".*";

            // Only Case-Insensitive search
            string ext = Path.GetExtension(fileName).ToLower();

            // .* meet in requested extention list
            if (data.AddedFolder.Extentions.IndexOf(ALL_FILES_FILTER) >= 0)          
            {
                return true;
            }
            else
            {
                return data.AddedFolder.Extentions.ToLower().IndexOf(ext) >= 0;
            }
        }

        // Get folder path with proper case as it appears in the file system
        // See Also: http://stackoverflow.com/a/5076517
        public string GetFileSystemCasing(string path)
        {
            if (Path.IsPathRooted(path))
            {
                // Trim ending back-slash symbol if you type c:\foo\ instead of c:\foo
                path = path.TrimEnd(Path.DirectorySeparatorChar);
                try
                {
                    string name = Path.GetFileName(path);

                    // Root is reached
                    if (name == "")
                    {
                        return path.ToUpper() + Path.DirectorySeparatorChar;
                    }

                    // retrieving parent of element to be corrected
                    string parent = Path.GetDirectoryName(path);

                    //to get correct casing on the entire string, and not only on the last element
                    parent = GetFileSystemCasing(parent);

                    DirectoryInfo diParent = new DirectoryInfo(parent);
                    FileSystemInfo[] fsiChildren = diParent.GetFileSystemInfos(name);
                    FileSystemInfo fsiChild = fsiChildren.First();

                    // Coming from GetFileSystemImfos() this has the correct case
                    return fsiChild.FullName;
                }
                catch (Exception ex)
                {
                    ShowError("FAILURE: GetFileSystemCasing: Invalid path " + ex.Message);
                }
                return "";
            }
            else
            {
                ShowError("FAILURE: GetFileSystemCasing: Absolute path needed, not relative");
                return "";
            }
        }
        #endregion

        private void Save()
        {
            if ((data != null)
                && (data.DataDictionary != null))
            {
                data.XmlDoc = XmlHelpers.CreateNewDoc();
                foreach (var item in data.DataDictionary)
                {
                    data.XmlDoc.Element("collection").Add(
                        XmlHelpers.GetFileItem(item.Key, XmlHelpers.GetTags(item.Value)));
                }

                if (!String.IsNullOrEmpty(data.CollectionFileFullName))
                {
                    data.XmlDoc.Save(data.CollectionFileFullName);
                    data.IsCollectionSaved = true;

                    ShowInfo(string.Format("Collection has been saved (at {0:HH:mm.ss})", DateTime.Now));
                }
                else
                {
                    ShowError("Failure: Please provide collection file name");
                    SaveAs();
                }
            }
            else
            {
                ShowError("Failure: Nothing to save");
            }
        }

        private void SaveAs()
        {
            if (!(data.DataDictionary != null && data.DataDictionary.Keys.Count > 0)) // There is nothing to save
            {
                ShowError("Save As: There is nothing to save");
                return;
            }

            //Get File Name to save collection to
            data.CollectionFileFullName = SelectFileToSave();
            if (!String.IsNullOrEmpty(data.CollectionFileFullName))
            {
                Save();

                // Update MRU list
                data.RecentCollectionsOpened.Add(data.CollectionFileFullName);
            }
            else
            {
                ShowError("FAILURE: Please provide a faile name to save collection");
            }
        }


        #region Tags
        // Get Selected Tag intags list
        private ListViewItem GetSelectedTag()
        {
            ListViewItem selectedListItem = null;
            foreach (ListViewItem item in lstTagsContent.Items)
            {
                //if (item.Focused)
                if (item.Selected)
                {
                    selectedListItem = item;
                    break;                                 // Satisfied by fist found item;
                }
            }

            if (selectedListItem == null)
            {
                ShowError("Failure: Cannot find a selected tag in tags list. Please Select.");
            }

            return selectedListItem;
        }

        // Add new tag for selected file, update collection
        private void AddNewTag()
        {
            // Get new tag value
            string newTag = txtNewTag.Text.Trim();
            if (string.IsNullOrWhiteSpace(newTag))
            {
                ShowError("Please provide valid tag");
                return;
            }

            // Get selected file name
            string fullFileName = GetFileNameOpenedInContentView();
            if (string.IsNullOrWhiteSpace(fullFileName))
            {
                return;
            }

            // Update Form Data > Dictionary[file].TagList 
            data.DataDictionary[fullFileName].Add(newTag);

            // Mark Form Data as Dirty
            MarkCollectionAsDirty();

            // Show updated tag list in GUI
            ShowFileTags(fullFileName);

            // Clean textbox
            txtNewTag.Text = "";

            // Set focus to textbox
            txtNewTag.Focus();
        }

        private void RemoveTag()
        {
            // Get selected tag (in Tag List)
            ListViewItem selectedListItem = GetSelectedTag();

            if (selectedListItem == null)
            {
                return;
            }

            string tagToRemove = selectedListItem.Text;

            // Get selected file name
            if (ContentFileTabs.SelectedTab == null || ContentFileTabs.SelectedTab.Tag == null)
            {
                ShowError("Failure: No File was selected to add a new tag. Please select file first");
                return;
            }

            string fullFileName = ContentFileTabs.SelectedTab.Tag as string;

            // Update Form Data > Dictionary[file].TagList 
            bool result = data.DataDictionary[fullFileName].Remove(tagToRemove);
            if (!result)
            {
                ShowError("Failure: Tag requested to be removed was not found in the tag list");
            }

            // Mark Form Data as Dirty
            MarkCollectionAsDirty();

            // Show updated tag list in GUI
            ShowFileTags(fullFileName);
        }

        // For selected file, selected tag move tag forward (Up) in tag list
        private void MoveTagUp()
        {
            // Get selected file name
            string fullFileName = GetFileNameOpenedInContentView();
            if (string.IsNullOrWhiteSpace(fullFileName))
            {
                return;
            }

            // Get selected tag (in Tag List)
            ListViewItem selectedListItem = GetSelectedTag();
            if (selectedListItem == null)
            {
                return;
            }

            // Get Tags List
            List<string> tagsList = data.DataDictionary[fullFileName];


            int selectedIndex = selectedListItem.Index;

            // Check data and UI consistency for tags list
            if (tagsList[selectedIndex] == selectedListItem.Text)
            {

                //OK -- Move tag up
                MoveElementUp(tagsList, selectedIndex);

                // Update tags list in memory and UI
                data.DataDictionary[fullFileName] = tagsList;

                // Mark Form Data as Dirty
                MarkCollectionAsDirty();

                // Show updated tag list in GUI
                ShowFileTags(fullFileName);

                // Restore selection of tag list in UI
                lstTagsContent.Items[selectedIndex - 1 >= 0 ? selectedIndex - 1 : 0].Selected = true;
                lstTagsContent.Select();
            }
            else
            {
                ShowError("FAILURE: Corruption of tag list and UI detected for the file: " + fullFileName);
                return;
            }
        }

        // For selected file, selected tag move tag backward (Down) in tag list
        private void MoveTagDn()
        {
            // Get selected file name
            string fullFileName = GetFileNameOpenedInContentView();
            if (string.IsNullOrWhiteSpace(fullFileName))
            {
                return;
            }

            // Get selected tag (in Tag List)
            ListViewItem selectedListItem = GetSelectedTag();
            if (selectedListItem == null)
            {
                return;
            }

            // Get Tags List
            List<string> tagsList = data.DataDictionary[fullFileName];

            int selectedIndex = selectedListItem.Index;
            int lastIndex = tagsList.Count - 1;

            // Check data and UI consistency for tags list
            if (tagsList[selectedIndex] == selectedListItem.Text)
            {

                //OK -- Move tag up
                MoveElementDown(tagsList, selectedIndex);

                // Update tags list in memory and UI
                data.DataDictionary[fullFileName] = tagsList;

                // Mark Form Data as Dirty
                MarkCollectionAsDirty();

                // Show updated tag list in GUI
                ShowFileTags(fullFileName);

                // Restore selection of tag list in UI
                lstTagsContent.Items[selectedIndex + 1 <= lastIndex ? selectedIndex + 1 : lastIndex].Selected = true;
                lstTagsContent.Select();
            }
            else
            {
                ShowError("FAILURE: Corruption of tag list and UI detected for the file: " + fullFileName);
                return;
            }

        }

        // Move Element up in provided List
        private void MoveElementUp(List<string> tagsList, int i)
        {
            if (tagsList == null)
            {
                ShowError("FAILURE: Provided list is null.");
                return;
            }

            if (i < 0 || i >= tagsList.Count)
            {
                ShowError("FAILURE: Index of provided list is out of index range. ");
                return;
            }

            int j = i - 1 >= 0 ? i - 1 : i;
            string temp = tagsList[j];
            tagsList[j] = tagsList[i];
            tagsList[i] = temp;
        }

        // Move Element Down in provided List
        private void MoveElementDown(List<string> tagsList, int i)
        {
            if (tagsList == null)
            {
                ShowError("FAILURE: Provided list is null.");
                return;
            }

            if (i < 0 || i >= tagsList.Count)
            {
                ShowError("FAILURE: Index of provided list is out of index range. ");
                return;
            }

            int j = i + 1 <= tagsList.Count - 1 ? i + 1 : tagsList.Count - 1;
            string temp = tagsList[j];
            tagsList[j] = tagsList[i];
            tagsList[i] = temp;
        }

        // Shows tags for selected file
        private void ShowFileTags(string FileFullName)
        {
            // Get file tags
            List<string> tagList = null;
            if (data.DataDictionary.ContainsKey(FileFullName))
            {
                tagList = data.DataDictionary[FileFullName];
            }
            else
            {
                // Orphaned opened content tab. 
                ShowError(string.Format("FAILURE: Trying to find Tags List for file that doesn't exist in collection now. ({0}); This tab is deleted also.", FileFullName));
                return;
            }

            // Clean the list
            lstTagsContent.Clear();

            // Populate list with file tags
            foreach (var item in tagList)
            {
                lstTagsContent.Items.Add(item);
            }
        }
        #endregion
        #region Reset
        // Reset Main Form UI and data to begin new collection creating
        private void Reset()
        {
            ResetFormData();
            ResetSelector();
            ResetSearchMiniForm();
            ResetContentTabs();
            ResetTagList();
            ResetTagMiniForm();
        }

        private void ResetFormData()
        {
            FormDataInit();
        }

        // Initialize selector tabs
        private void ResetSelector()
        {
            ResetFileSelector();
            ResetSearchResultsSelector();
            
            // File Selector is a default tab -- selct it
            FilesTabSelect();
        }

        private void ResetSearchResultsSelector()
        {
            if (lstSearchResultsSelector.Items != null)
            {
                lstSearchResultsSelector.Items.Clear();
            }
            else
            {
                ShowError("FAILURE: Search Results Selector cannot be properly reset");
            }
        }

        // Remove all items from file selector
        private void ResetFileSelector()
        {
            //lstFileSelector.Clear();       // Wrong: Deletes also a columns collection

            if (lstFileSelector.Items != null)
            {
                lstFileSelector.Items.Clear();
            }
            else
            {
                ShowError("FAILURE: File Selector cannot be properly reset");
            }
        }

        // Initialize search mini form
        private void ResetSearchMiniForm()
        {
            txtSearchSelector.Text = "";
            cbTag.Checked = true;
            cbText.Checked = true;
        }

        // Remove all tabs
        private void ResetContentTabs()
        {
            ContentFileTabs.TabPages.Clear();

        }

        // Remove all tags in tag list
        private void ResetTagList()
        {
            lstTagsContent.Clear();
        }

        private void ResetTagMiniForm()
        {
            txtNewTag.Text = "";
        }

        #endregion
        #region Search

        // Search collection -- show found files in file selector
        private void Search()
        {

            bool IsTagSearch = cbTag.Checked;
            bool IsTextSearch = cbText.Checked;
            bool IsMatchCase = cbMatchCase.Checked;
            bool IsRefinedSearch = cbRefine.Checked;
            bool IsNoTagsSearch = cbNoTags.Checked;

            // Validate search parameters
            if (string.IsNullOrWhiteSpace(txtSearchSelector.Text) && !IsNoTagsSearch)
            {
                ShowError("FAILURE: Please provide files or words to search in");
                // Set focus to search text box
                txtSearchSelector.Focus();
                return;
            }

            if (IsTagSearch == false && IsTextSearch == false && !IsNoTagsSearch)
            {
                ShowError("FAILURE: Either Tag search or Text search (or both) should be specified");
                return;
            }

            // Get list of Search words (tags or words in file content)
            string[] searchWords = txtSearchSelector.Text.Split();

            // Check if collection is not empty
            if (data.DataDictionary.Keys.Count < 1)
            {
                ShowError("FAILURE: Collection is empty. Nothing to search");
                return;
            }

            // Get files list
            data.DataFilesList = null;

            if (!IsRefinedSearch)
            {
                data.DataFilesList = data.DataDictionary.Keys.ToList<string>();
            }
            else
            {
                data.DataFilesList = (from ListViewItem item in lstSearchResultsSelector.Items
                                      select item.Text).ToList<string>();
            }

            // Clear Search Results Selector list (UI)
            ResetSearchResultsSelector();

            // Make Search Results tab opened
            SearchResultsTabSelect();

            int counter = 0;
            // Traverse current collection
            foreach (var item in data.DataFilesList)
            {
                string fullFileName = item;
                List<string> tagList = data.DataDictionary[item];

                // If file match
                if (IsFileMatchSeachConditions(IsTagSearch, IsTextSearch, IsMatchCase, IsNoTagsSearch, searchWords, fullFileName, tagList))
                {
                    // Add file in File Selector
                    AddFileToSearchResults(fullFileName);
                    counter++;
                }

                // Show some search progress...
                ShowInfo("Searching: " + Path.GetFileName(fullFileName));
            }


            // Column auto Resize
            lstSearchResultsSelector.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            // Report Files Found
            ShowInfo("Search: File(s) found: " + counter.ToString());
        }

        // Make Search Results Selector  Tab opened (selected)
        private void SearchResultsTabSelect()
        {
            SelectorTabs.SelectedTab = tabSearchResults;
        }

        // Make File Selector Tab opened (selected)
        private void FilesTabSelect()
        {
            SelectorTabs.SelectedTab = tabFileSelector;
        }

        // Define if file is satisfied to a search criteria
        private bool IsFileMatchSeachConditions(bool IsTagSearch, bool IsTextSearch, bool IsMatchCase, bool IsNoTags, string[] searchWords, string FullFileName, List<string> TagList)
        {
            // If NoTags mode and file with no tags found -- return found
            if (IsNoTags && TagList.Count == 0)
            {
                // Ignore other search criteria
                return true;
            }

            // If NoTags mode and file with tags found -- skip it
            if (IsNoTags && TagList.Count > 0)
            {
                // Ignore other search criteria
                return false;
            }

            // Check tag first as a least expensive operation 
            foreach (var tag in TagList)
            {
                if (IsTagSearch && FileTagMatched(tag, searchWords, IsMatchCase))
                {
                    return true;
                }
            }

            // This need to search in file -- expensive operation
            if (IsTextSearch && FileIsText(FullFileName) && FileContentMatched(FullFileName, searchWords, IsMatchCase))
            {
                return true;
            }

            return false;
        }

        // Predicate to define if file content has one of keywords
        private bool FileContentMatched(string FullFileName, string[] searchWords, bool IsMatchCase)
        {
            // Open file for read
            string fileContent = GetTextFilestring(FullFileName);

            StringComparison comparisonMode =
                IsMatchCase ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase;

            // Search for match to any of keywords
            foreach (var word in searchWords)
            {
                if (fileContent.IndexOf(word, 0, comparisonMode) > -1)
                {
                    return true;
                }
            }

            return false;
        }

        // Predicate to define if specified tag found in search keywords
        private bool FileTagMatched(string tag, string[] searchWords, bool IsMatchCase)
        {

            StringComparison comparisonMode = IsMatchCase ? StringComparison.CurrentCulture 
                : StringComparison.CurrentCultureIgnoreCase;
            // Search if tag found in keywords array
            foreach (var word in searchWords)
            {
                if (string.Compare(word, tag, !IsMatchCase) == 0)  // Strict (whole word) match found
                {
                    return true;
                }
                else if (tag.IndexOf(word, 0, comparisonMode) > -1)
                {
                    return true;
                }
            }
            return false;
        }

        // Adds a file to Search results list (UI)
        private void AddFileToSearchResults(string FullFileName)
        {
            lstSearchResultsSelector.Items.Add(FullFileName);
        }

        #endregion
        #region Status Bar
        private void ShowError(string message)
        {
            data.StatusBar.Message = message;
            data.StatusBar.Collection = data.CollectionFileFullName;
            UpdateStatusBar();
        }

        private void ShowInfo(string message)
        {
            // Currently it implemented as ShowError, but in future it may be reimplemented
            ShowError(message);
        }

        // Shows file name in status bar
        private void ShowFileInStatusLine(string FileFullName)
        {
            data.StatusBar.File = FileFullName;
            UpdateStatusBar();
        }

        private void UpdateStatusBar()
        {
            stMessage.Text = data.StatusBar.Message;
            stMessage.ToolTipText = data.StatusBar.Message;
            stFile.Text = data.StatusBar.File;
            stFile.ToolTipText = data.StatusBar.File;
            stCollection.Text = data.StatusBar.Collection;
            stCollection.ToolTipText = data.StatusBar.Collection;
        }

        #endregion
        #region Helpers

        // Marks collection as dirty, i.e. with unsaved content
        private void MarkCollectionAsDirty()
        {
            data.IsCollectionSaved = false;
        }

        // Select file to open as a collection
        private string SelectFileToOpen()
        {
            OpenFileDialog fDialog = new OpenFileDialog();

            // To set the title of window
            fDialog.Title = "Select File";

            // To apply filter, which only allows the files with the name or extension specified to be selected. 
            // in this example i m only using jpeg and GIF files
            fDialog.Filter = "All Files|*.*|TXT Files|*.txt|CS Files|*.cs|SQL Files|*.sql";

            // To set the Initial Directory property ,means which directory to show when the open file dialog windows opens
            fDialog.InitialDirectory = @"C:\";

            // if the user has clicked the OK button after choosing a file,To display a MessageBox with the path of the file:
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                return fDialog.FileName.ToString();
            }
            else
            {
                return "";
            }
        }

        // Select file where the collection will be saved
        private string SelectFileToSave()
        {
            SaveFileDialog fDialog = new SaveFileDialog();

            // To set the title of window
            fDialog.Title = "Select File";

            // To apply filter, which only allows the files with the name or extension specified to be selected. 
            // in this example i m only using jpeg and GIF files
            fDialog.Filter = "XML Files|*.xml|All Files|*.*";

            // To set the Initial Directory property ,means which directory to show when the open file dialog windows opens
            fDialog.InitialDirectory = @"C:\";

            // if the user has clicked the OK button after choosing a file,To display a MessageBox with the path of the file:
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                return fDialog.FileName.ToString();
            }
            else
            {
                ShowError("FAILURE: Unable to select file to save");
                return "";
            }
        }

        private void SaveFormDataIfDirty()
        {
            if (data != null)
            {
                if (!data.IsCollectionSaved)      // The form is dirty
                {
                    DialogResult result = MessageBox.Show("Current collection hasn't been saved. Would you like to save it?", "Save current collection", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.Yes)
                    {
                        Save();
                    }
                }
            }
        }

        // Initialize form data object
        private void FormDataInit()
        {
            const string WELCOME_MESSAGE = "Welcome!";
            const string NOFILE = "<No File>";
            const string NOCOLLECTION = "<No Collection>";

            data = new MainFormData();

            data.IsCollectionSaved = true;
            data.StatusBar.Message = WELCOME_MESSAGE;
            data.StatusBar.File = NOFILE;
            data.StatusBar.Collection = NOCOLLECTION;
            data.NotFoundFileCounter = 0;
            data.NewFileCounter = 0;
            data.RecentCollectionsOpened = new MRUFiles(this); // Send form to get access to form methods
        }

        // Add File Names from MRU list to File Main Menu
        private void PopulateFileMenuWithRecentOpenedFiles()
        {
            // Get File menu object 
            ToolStripItem fileMenu = mnuMain.Items[0];

            // Add menu separator
            (fileMenu as ToolStripMenuItem).DropDownItems.Add(new ToolStripSeparator());

            // Add recent files
            int i = 1;
            foreach (string fileName in data.RecentCollectionsOpened.MRUList)
            {
                ToolStripButton recent = new ToolStripButton(fileName);
                recent.Tag = fileName;
                recent.Text = string.Format("{0,-2} {1} ", i++, fileName);
                recent.Click += new EventHandler(recent_Click);

                // Add menu item to File menu
                (fileMenu as ToolStripMenuItem).DropDownItems.Add(recent);

            }
        }

        private void CloseForm()
        {
            this.Close();
        }

        // If in datadictionary found file that is not exit 
        // in file system - remove it from dictionary
        private void CleanDataDictionary()
        {
            // Form remove list
            List<string> removeList = new List<string>();
            foreach (var item in data.DataDictionary)
            {
                if (!File.Exists(item.Key))
                {
                    removeList.Add(item.Key);
                }
            }

            // Clean dictionary according remove list
            foreach (var item in removeList)
            {
                data.DataDictionary.Remove(item);
            }

            // Mark collection as dirty
            if (removeList.Count > 0)
            {
                MarkCollectionAsDirty();
            }

            // Store statistic
            data.NotFoundFileCounter = removeList.Count;
        }

        // Populate file selector
        private void PopulateFileSelector()
        {
            ResetFileSelector();

            if (data != null && data.DataDictionary != null)
            {
                foreach (var item in data.DataDictionary.Keys)
                {
                    lstFileSelector.Items.Add(item);
                }
            }

            // Adjust column width
            lstFileSelector.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            //DEBUG
            //lstFileSelector.Items[0].Selected = true;                // WORKS
            //lstFileSelector.Focus();
        }

        // Show file content
        private void ShowFileContent(string fileFullName)
        {
            // Store Opened file name in dictionary -- to exclude duplicates
            if (data.OpenedFilesDictionary != null && !data.OpenedFilesDictionary.ContainsKey(fileFullName))
            {
                data.OpenedFilesDictionary.Add(fileFullName, null);
            }
            else
            {
                // Select Content tab with already opened file -- Using stored tab index
                ContentFileTabs.SelectTab((int)data.OpenedFilesDictionary[fileFullName]);
                return;
            }

            // Create new TabPage
            TabPage tp = new TabPage(Path.GetFileName(fileFullName));

            if (FileIsText(fileFullName))
            {
                // Create new multiline textbox
                TextBox tb = new TextBox();
                tb.Multiline = true;
                tb.Dock = DockStyle.Fill;
                tb.WordWrap = false;
                tb.ScrollBars = ScrollBars.Both;
                tb.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                // Get text file content and populate it in textbox
                tb.Text = GetTextFilestring(fileFullName);

                // Add Multiline textbox in created tab
                tp.Controls.Add(tb); 
            }
            else if (FileIsPicture(fileFullName))
            {
                PictureBox pb = new PictureBox();
                pb.Dock = DockStyle.Fill;
                
                pb.ImageLocation = fileFullName;
                pb.Load();

                tp.Controls.Add(pb);

                // If image too small
                if ((Double)(pb.Image.Height) / ContentFileTabs.Size.Height < 0.5)
                {
                    pb.SizeMode = PictureBoxSizeMode.CenterImage;
                }
                else // Otherwise - Fit image
                {
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }

            // Store File Name in TabPage
            tp.Tag = fileFullName;

            // Add Right-Click event to tabpage
            ContentFileTabs.MouseDown += new MouseEventHandler(ContentFileTabs_MouseDown);
            ContentFileTabs.MouseUp += new MouseEventHandler(ContentFileTabs_MouseUp);

            // Add new tab in ContentFileTabs tabContainer
            ContentFileTabs.TabPages.Add(tp);

            // Store tab index
            data.OpenedFilesDictionary[fileFullName] = ContentFileTabs.TabPages.IndexOf(tp);

            // Make a new tabpage active
            ContentFileTabs.SelectedTab = tp;
        }

        // Define by its extension if file is a text 
        private bool FileIsText(string fileFullName)
        {
            return !FileIsPicture(fileFullName);
        }

        // Define by its extension if file is a picture 
        private bool FileIsPicture(string fileFullName)
        {
            const string pictureExtensions = ".jpg .png .jpeg .tif .gif .bmp .ico";

            // Get file extension
            string ext = Path.GetExtension(fileFullName);

            // Define if it is a text file extension
            return (pictureExtensions.IndexOf(ext, 0, StringComparison.CurrentCultureIgnoreCase) > -1);
        }

        // Get Text file 
        public string GetTextFilestring(string fileFullName)
        {
            TextReader reader = null;
            string sOut = "";

            try
            {
                // Open File for read
                reader = new StreamReader(fileFullName);

                // Get file lines
                sOut = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                data.StatusBar.Message = "Open File: \"" + fileFullName + "\" " + ex.Message;
            }
            finally
            {
                // Close text file
                if (reader != null)
                {
                    reader.Close();
                }
            }

            return sOut;
        }

        // Get full name of opened in content view file
        private string GetFileNameOpenedInContentView()
        {
            // Get selected file name
            if (ContentFileTabs.SelectedTab == null || ContentFileTabs.SelectedTab.Tag == null)
            {
                ShowError("No File was opened in Content View. Please select file first");
                return "";
            }
            else
            {
                return ContentFileTabs.SelectedTab.Tag as string;
            }
        }

        // User wants to delete a content tab
        private void RemoveContentTab(object sender)
        {
            // Get selected tag
            TabControl tc = ((System.Windows.Forms.TabControl)(sender));
            TabPage pg = tc.SelectedTab;

            // Define File name
            string fileFullName = pg.Tag as String;

            //Remove tab in UI
            tc.TabPages.Remove(pg);

            // Update Opened files dictionary
            data.OpenedFilesDictionary.Remove(fileFullName);

            // Correct Tab index in Opened files dictionary for the rest of tabs
            foreach (TabPage tp in tc.TabPages)
            {
                // Get Tab Full File Name
                string tpFileName = (string)tp.Tag;

                // Get tab index
                int tpTagIndex = tc.TabPages.IndexOf(tp);

                data.OpenedFilesDictionary[tpFileName] = tpTagIndex;
            }
        }

        // Remove all content tabs
        private void RemoveAllContentTabs()
        {
            TabControl tc = this.ContentFileTabs;

            // Delete all tab pages
            tc.TabPages.Clear();

            // Clear Opened files dictionary
            data.OpenedFilesDictionary.Clear();
        }

        // Remove all, but not selected tab
        private void RemoveAllOtherContentTabs()
        {
            // Get selected tag
            TabControl tc = this.ContentFileTabs;
            TabPage pg = tc.SelectedTab;

            // Define File name
            string fileFullName = pg.Tag as String;

            foreach (TabPage tp in tc.TabPages)
            {
                if (tp != pg)
                {
                    // Update Opened files dictionary
                    data.OpenedFilesDictionary.Remove(tp.Tag as String);

                    //Remove tab in UI
                    tc.TabPages.Remove(tp);
                }
            }


            // Correct Tab index in Opened files dictionary for the rest of tabs
            foreach (TabPage tp in tc.TabPages)
            {
                // Get Tab Full File Name
                string tpFileName = (string)tp.Tag;

                // Get tab index
                int tpTagIndex = tc.TabPages.IndexOf(tp);

                data.OpenedFilesDictionary[tpFileName] = tpTagIndex;
            }
        }


        // Save opened content tab (that was been changed) to a file
        private void SaveContentFile()
        {
            
            // Get Tab Page
            TabControl tc = this.ContentFileTabs;
            TabPage pg = tc.SelectedTab;

            // Get text box object
            Object oTb = pg.Controls[0];

            string lines;
            if (oTb != null && oTb is TextBox)
            {
                // Get text to save
                lines = (oTb as TextBox).Text;
            }
            else
            {
                ShowError("FAILURE: Save file from context tab");
                return;
            }

            // Get file name
            string fileFullName = pg.Tag as String;

            // Save file
            System.IO.StreamWriter file = new System.IO.StreamWriter(fileFullName);
            file.WriteLine(lines);

            // Close file
            file.Close();

            // Update status bar
            ShowInfo(string.Format("Content file:'{0}' has been saved (at {1:HH:mm.ss})", fileFullName, DateTime.Now));
        }

        // Custom message box allows copy its text
        private void CustomMessageBox(string message)
        {
            CustomMessageBox mb = new CustomMessageBox();
            mb.Message = message;
            mb.ShowDialog();
            mb.Close();
        }

        private void CustomMessageBox(string title, string message)
        {
            CustomMessageBox mb = new CustomMessageBox();
            mb.Title = title;
            mb.Message = message;
            mb.ShowDialog();
            mb.Close();
        }
        #endregion
    }
}
