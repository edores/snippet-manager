/*
 * SNIPPET MANAGER
 * 
 * MODIFICATION LOG:
 * 
 * 22-FEB-2012 -- INITIAL CREATION
 * 23-FEB-2012 --
 *             -- BUGFIX -- Name of saved collection is not appeared in status bar
 *             -- BUGFIX -- Add Folder > Add Folder Dialog -> include subfolders = true; -> extensions = .cs
 *                          => Files from root folder are not selected, only from subfolders;
 *             -- BUGFIX -- Tags > Move Up/Down buttons are not wired;
 *             -- BUGFIX -- File Selector > Dbl-Click > Adds a new content tab with file, even, if this file is already
 *                          opened;
 *             -- BUGFIX -- Content > Delete Tab => Tag list is not refreshed;
 *             
 *             -- ENHANCEMENT -- Status Bar > Click > Status message appears as SELECTABLE text
 *             -- ENHANCEMENT -- Add Folder > Show statistic in status bar: How many files were added / removed / total 
 *                               number of files in collection
 *             -- ENHANCEMENT -- Tags List > when txtAddTag is in focus => Handle ENTER key as "add new tag";
 *             -- ENHANCEMENT -- File selector populated > Adjust "File Name" Column width automatically;
 *             -- ENHANCEMENT -- Distribution and .doc created
 *             
 * 24-FEB-2012 -- 
 *             -- BUGFIX -- Add Folder Dialog > User manually enters path with wrong letter case => collection will be also
 *                          saved with whong letter case paths;
 *             -- BUGFIX -- Add Folder Dialog > extension = .txt, but File in Folder has .TXT => the file is ignored;
 *             -- ENHANCEMENT -- File selector > Dbl-click > Content > If file is already opened => Select it's tab;
 *             -- ENHANCEMENT -- Add Folder > Some files were deleted, but enlisted in collection => remove them from 
 *                               collection (from dictionary)
 * 28-FEB-2012 -- 
 *             -- BUGFIX -- Content > opened File; Removed file is not in Collection after Add Folder => Orphaned 
 *                          content file; If this tab is deselcted, and then selected back => Runtime Error
 *             -- ENHANCEMENT -- Content > Some file tab is selected > Move focus to File Selector => File should
 *                               be highlihted in File Selector;
 *             -- ENHANCEMENT -- User pressed Ctrl-S => Status Bar > Message: File saved at <timestmp>
 *             -- ENHANCEMENT -- Search Mini Form => "Refined" checkbox -- Search in search results
 * 06-MAR-2012 --
 *             -- ENHANCEMENT -- Search Mini Form > No tags serach -- find all files without tags;
 *                               
 * 08-MAR-2012 
 *             -- ENHANCEMENT -- Application Unhandled exceptions handler implemented;
 * 09-MAR-2012    
 *             -- BUGFIX -- Add New Tag => Apply Trim() before saving in collection;
 *             -- ENHANCEMENT -- All bottom tabs in tab panels looks ugly; Need to implement custom drawing;
 *             -- ENHANCEMENT -- Content Tabs > Context menu : Close All Tabs; Close All Other Tags; Close This Tab;
 * 14-MAR-2012    
 *             -- ENHANCEMENT -- Content Tabs > Context menu > Save File => Save all changes to file. (Override it)
 * 16-MAR-2012    
 *             -- ENHANCEMENT -- Most Recent Used (MRU) file menu added
 *             -- ENHANCEMENT -- Add Folder > .Folders and .files -- are invisible (StartsWith('.') == true)
 * 17-MAR-2012    
 *             -- ENHANCEMENT -- Content > If file is a picture or Text > show it;
 *             -- BUGFIX -- Search > Text Search => Enable only for text files      
 * 21-MAR-2012    
 *             -- ENHANCEMENT -- Search > Tags => substring matching (not whole word)
 *             -- ENHANCEMENT -- Search Mini Form > when txtSearch is in focus => ENTER key pressed submits the search
 *             -- ENHANCEMENT -- Add Folder > Dialog > Make "OK" - default button; "Cancel" - Esc button;
 * 23-MAR-2012    
 *             -- BUGFIX -- Open file in content => Content is empty, if file is not .txt, .sc, .sql extension; (DF)
 *             
 * TODO (Planned enhancements, bugfixes, and ideas):                              
 * 
 * -- ENHANCEMENT -- Open Collection => Open collection INCREMENTALLY;
 * -- ENHANCEMENT -- File Selector > Search Results => Save as new collection
 * -- ENHANCEMENT -- Opened files => Save as new collection
 * -- ENHANCEMENT -- Content > Opened file; Search (Ctrl-F, Edit, Save);
 * -- ENHANCEMENT -- Installation application to be created. (Install.exe / Uninstall.exe)
 * -- ENHANCEMENT -- File Selector => Sort files
 * -- ENHANCEMENT -- File Selector > Icon may show status (Untagged, Saved, Modified, Type of file, etc.)
 * -- ENHANCEMENT -- Content tabs > reordering using drag & drop
 * -- ENHANCEMENT -- Opened File > TextBox > R-Click => Context Menu > Save File
 * -- ENHANCEMENT -- File Selector > R-Click > Context Menu => Delete From Collection
 * -- ENHANCEMENT -- Search > Match whole word flag
 * -- ENHANCEMENT -- Content > If file is a picture > show it;
 * -- ENHANCEMENT -- Configuration settings => keep them as JSON file
 * -- ENHANCEMENT -- Add Folder => MRU Selected folders; => MRU extensions
 * -- ENHANCEMENT -- Tag List > Check for duplicates;
 * -- ENHANCEMENT -- Refresh() => Reload the same collection to reflect file system changes. (DF)
 * -- ENHANCEMENT -- Content > Tab with "dirty" file => Mark with '*' and/or BOLD font. (DF)
 * -- ENHANCEMENT -- Search > textbox; Tags > Textbox => Autocomplete (DF)
 * -- ENHANCEMENT -- Add Folder > Extension = EMPTY => Should get ALL extensions (DF)
 * 
 * -- IDEA -- Make a Personal Organizer with multiple functions: Scheduler, Back-count Timer, ToDo lists, File Viewer (Images,
 *            .htm, other file types)
 * -- IDEA -- Content > Opened file; Syntax highlite;
 * -- IDEA -- Options > Add Folder = Recent folder; Save collection = Resent Folder; Open Collection - Recent folder
 *            Other recent and default options;
 * -- IDEA -- Unicode support; >> Flashcard application >> Transliteration for French, Germany, Russian languages;
 * -- IDEA -- Tag List > Reorder using DRAG and DROP;
 * -- IDEA -- Tag List > Tag family id: [tag1, tag2, tag3]; Entering id => enters whole family;
 * -- IDEA -- Tag List > User types a tag => List of recent tags (hints) by first letters typed appers ready to select.
 * -- IDEA -- Rewrite application using MODEL-VIEW-CONTROLLER pattern. (More reliable, easy to support)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace Snippet
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // Adds the event handler to catch any exceptions that happen in the main UI thread.
            Application.ThreadException += new ThreadExceptionEventHandler(OnThreadException);

            // Add the event handler for all threads in the appdomain except for the main UI thread.
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(OnUnhandledException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        // Handles the exception event for all other threads
        static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show("CurrentDomain_UnhandledException: " +
                        e.ExceptionObject.ToString(), "Critical Error: Unhandled Exception");
        }

        // Handles the exception event from a UI thread
        static void OnThreadException(object sender, ThreadExceptionEventArgs t)
        {
            MessageBox.Show("OnThreadException: " + t.Exception.ToString(), "Critical Error: ThreadException");
        }
    }
}
