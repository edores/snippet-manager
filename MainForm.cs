using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomTabs;


namespace Snippet
{
    public partial class MainForm : Form
    {
        public MainFormData data;

        public MainForm()
        {
            InitializeComponent();
        }

        #region ContentTab Context menu
        [Flags()]
        private enum TCHITTESTFLAGS
        {
            TCHT_NOWHERE = 1,
            TCHT_ONITEMICON = 2,
            TCHT_ONITEMLABEL = 4,
            TCHT_ONITEM = TCHT_ONITEMICON | TCHT_ONITEMLABEL
        }

        private const int TCM_HITTEST = 0x130D;

        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        private struct TCHITTESTINFO
        {
            public Point pt;
            public TCHITTESTFLAGS flags;
            public TCHITTESTINFO(int x, int y)
            {
                pt = new Point(x, y);
                flags = TCHITTESTFLAGS.TCHT_ONITEM;
            }
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hwnd, int msg, IntPtr wParam, ref TCHITTESTINFO lParam);


        private void ContentFileTabs_MouseDown(object sender, MouseEventArgs e)
        {
            TCHITTESTINFO HTI = new TCHITTESTINFO(e.X, e.Y);
            TabPage tp = ContentFileTabs.TabPages[SendMessage(ContentFileTabs.Handle, TCM_HITTEST, IntPtr.Zero, ref HTI)];
            ContentFileTabs.SelectedTab = tp;
            ContentFileTabs.ContextMenuStrip = cmContentTab;
        }

        private void ContentFileTabs_MouseUp(object sender, MouseEventArgs e)
        {
            ContentFileTabs.ContextMenuStrip = null;
        }

        #endregion


        // On form load
        private void MainForm_Load(object sender, EventArgs e)
        {
            FormDataInit();
            PopulateFileMenuWithRecentOpenedFiles();
            UpdateStatusBar();
        }

        // On form closing
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveFormDataIfDirty();
            data.RecentCollectionsOpened.Save();
        }

        // On Content Tab double-click => Ask to remove TabPage
        private void ContentFileTabs_DoubleClick(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show(
                "Confirm to close this tab. File will not be deleted.", 
                "delete tab", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Exclamation, 
                MessageBoxDefaultButton.Button2);
            if (resp == System.Windows.Forms.DialogResult.Yes)
            {
                RemoveContentTab(sender);
            }
        }

        // On Content Tab activate -- update UI tags list
        private void ContentFileTabs_Click(object sender, EventArgs e)
        {
            TabControl tc = ((System.Windows.Forms.TabControl)(sender));
            TabPage pg = tc.SelectedTab;

            string FileFullName = pg.Tag as string;
            ShowFileTags(FileFullName);
            ShowFileInStatusLine(FileFullName);
        }

        // Exit from application
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        // Menu > File > New
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewCollection();        //Create new collection from scratch
        }

        // File toolbar > New
        private void btnNew_Click(object sender, EventArgs e)
        {
            NewCollection();
        }

        // Menu > File > Open
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCollection(); // Open Collection
        }

        // File toolbar > Open
        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenCollection();
        }

        // Menu > Save
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();   // Save collection to XML file
        }

        // Toolbar
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        // Menu > Save As
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();  // Save As collection to XML file
        }

        // Toolbar > Save As
        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        // On Status Message(s) click
        private void StatusButton_Click(object sender, EventArgs e)
        {
            string title = (string)((System.Windows.Forms.ToolStripStatusLabel)sender).Tag;
            string text = ((System.Windows.Forms.ToolStripStatusLabel)sender).Text;

            // Call Custom dialog box, that allows cut and paste 
            CustomMessageBox(title, text);
        }

        // file selector > file or Search results > double-click event -- Shows file content
        private void lstFileSelector_ItemActivate(object sender, EventArgs e)
        {
            string FileFullName = (((ListView)sender).FocusedItem).Text;
            ShowFileContent(FileFullName);
            ShowFileTags(FileFullName);
            ShowFileInStatusLine(FileFullName);
        }

        // Add Tag button clicked
        private void btnAddTag_Click(object sender, EventArgs e)
        {
            AddNewTag();
        }

        // Remove Tag button clicked
        private void btnRemoveTag_Click(object sender, EventArgs e)
        {
            RemoveTag();
        }

        // Main Menu > File > Add Folder
        private void addFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddFolder();
        }

        // ToolBar > Add Folder
        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            AddFolder();
        }

        // Content Selector > Search Mini Form > Search button
        private void btnSearchSelector_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void mnuMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        // Tag Move Up Button clicked
        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            MoveTagUp();
        }

        private void btnMoveDn_Click(object sender, EventArgs e)
        {
            MoveTagDn();
        }

        private void ContentFileTabs_Selected(object sender, TabControlEventArgs e)
        {
            // Show Tags and highlite selector list
            if (((TabControl)sender).TabPages != null && ((TabControl)sender).SelectedIndex > -1)
            {
                // Get file name
                string fullFileName = ((TabControl)sender).TabPages[((TabControl)sender).SelectedIndex].Tag as String;

                // If file is orphaned -- delete tab
                if (!data.DataDictionary.ContainsKey(fullFileName))
                {
                    // Ask to delete
                    DialogResult result = MessageBox.Show("Current tab contains file that doesn't exist. Would you like to delete this tab?", "Delete orphaned tab", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.Yes)
                    {
                        TabPage tp = ((TabControl)sender).TabPages[((TabControl)sender).SelectedIndex];
                        if (tp != null)
                        {
                            ((TabControl)sender).TabPages.Remove(tp);
                            
                            // Remove from opened files dictionary
                            data.OpenedFilesDictionary.Remove(fullFileName);
                        }
                        return;
                    }
                }

                // Show Content Tags
                ShowFileTags(fullFileName);

                // Get current selector list
                if (SelectorTabs.SelectedTab != null)
                {
                    TabPage tp = SelectorTabs.SelectedTab;

                    ListView myList = null;
                    ListViewItem curItem = null;
                    int itemIndex = 0;
                    foreach (var ctrl in tp.Controls)
                    {
                        if (ctrl is System.Windows.Forms.ListView)
                        {
                            myList = ctrl as ListView;

                            // Search List Item with requested file name
                            curItem = myList.FindItemWithText(fullFileName);
                            if (curItem != null)
                            {
                                itemIndex = curItem.Index;
                                break;
                            }
                        }
                    }

                    // Select file name in list
                    if (curItem != null)
                    {
                        myList.SelectedItems.Clear();
                        myList.EnsureVisible(itemIndex);
                        myList.Items[itemIndex].Selected = true;
                        myList.Focus();          // DOESN'T WORK becauses list looses focus, and tab in content acquires.
                        myList.Refresh();
                    }
                }
            }
            else
            {
                // Clean tags if last tab was deleted
                lstTagsContent.Items.Clear();

                // Delete current content file name in status bar
                ShowFileInStatusLine("");
            }
        }

        // User entered new tag name and pressed ENTER
        private void txtNewTag_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                AddNewTag();
                e.Handled = true;
            }
        }

        // User entered search text and press ENTER
        private void txtSearchSelector_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                Search();
                e.Handled = true;
            }
        }

        // Content Tab > Context Menu > Close This Tab
        private void cmiCloseThisTab_Click(object sender, EventArgs e)
        {
            RemoveContentTab(this.ContentFileTabs);
        }

        // Content Tab > Context Menu > Close All Tags
        private void cmiCloseAllTabs_Click(object sender, EventArgs e)
        {
            RemoveAllContentTabs();
        }

        // Content Tab > Context Menu > Close All Other Tags
        private void cmiCloseAllOtherTabs_Click(object sender, EventArgs e)
        {
            RemoveAllOtherContentTabs();
        }

        // Content Tab > Context Menu > Save File
        private void cmiSaveFile_Click(object sender, EventArgs e)
        {
            SaveContentFile();
        }

        // Main Menu > File > Recent file clicked
        private void recent_Click(object sender, EventArgs e)
        {
            OpenCollection(((sender as ToolStripButton).Tag as string));
        }
    }
}
