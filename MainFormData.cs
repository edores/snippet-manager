using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Forms;
using System.IO;

namespace Snippet
{
    public class MainFormData
    {
        public MainFormData()
        {
            this.DataDictionary = new Dictionary<string, List<string>>();
            this.DataFilesList = new List<string>();
            this.OpenedFilesDictionary = new Dictionary<string, object>();
            this.CollectionFileFullName = "";
            this.IsCollectionSaved = true;
            this.XmlDoc = null;
            this.StatusBar = new StatusData();
            this.NotFoundFileCounter = 0;
            this.NewFileCounter = 0;
        }

        public string CollectionFileFullName { get; set; }
        public bool IsCollectionSaved { get; set; }
        public List<String> DataFilesList { get; set; }
        public Dictionary<string, List<string>> DataDictionary { get; set; }
        public Dictionary<string,Object> OpenedFilesDictionary { get; set; }
        public XDocument XmlDoc { get; set; }
        public StatusData StatusBar { get; set; }
        public AddFolderDialogData AddedFolder { get; set; }
        public int NotFoundFileCounter { get; set; }
        public int NewFileCounter { get; set; }
        public MRUFiles RecentCollectionsOpened { get; set; }
    }

    public class StatusData
    {
        public string Message { get; set; }
        public string File { get; set; }
        public string Collection { get; set; }
    }

    public class AddFolderDialogData
    {
        public string FolderPath { get; set; }
        public bool SubFolders { get; set; }
        public string Extentions { get; set; }
        public bool IsValidated { get; set; }
        public string ValidationMessage { get; set; }
    }

    public class MRUFiles
    {
        const int MAX_FILE_NUMBER = 4;
        const string FILE_NAME = "recent.txt";

        public Queue<string> MRUList { get; set; }
        private MainForm _form;
        private string FileFullName { get; set; }

        public MRUFiles(Form form)
        {
            this._form = form as MainForm;
            this.FileFullName = Path.Combine(System.Environment.CurrentDirectory, FILE_NAME);
            this.Load();
        }

        public void Load()
        {
            // Check if file exists
            if (File.Exists(this.FileFullName))
            {
                // Get text file
                string MRUListText = _form.GetTextFilestring(this.FileFullName);

                // Populate MRU List
                var MRUArray = MRUListText.Split(Environment.NewLine.ToCharArray());
                this.MRUList = new Queue<string>();
                foreach (string f in MRUArray)
                {
                    this.Add(f);
                }
            }
            else
            {
                this.MRUList = new Queue<string>();
                //this.Save();
            }
        }

        public void Add(string fname)
        {
            if (string.IsNullOrWhiteSpace(fname) || this.MRUList.Contains(fname))
            {
                return;
            }

            this.MRUList.Enqueue(fname);

            if (this.MRUList.Count > MAX_FILE_NUMBER)
            {
                this.MRUList.Dequeue();
            }
        }

        public void Save()
        {
            // Save file
            System.IO.StreamWriter file = new System.IO.StreamWriter(this.FileFullName);
            foreach (var item in this.MRUList)
            {
                file.WriteLine(item);
            }

            // Close file
            file.Close();
        }
    }
}
