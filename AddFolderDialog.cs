using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Snippet
{
    public partial class AddFolderDialog : Form
    {
        private MainForm _parent;

        private string SelectFolderToAdd()
        {
            // Open Folder Dialog
            FolderBrowserDialog fldDialog = new FolderBrowserDialog();

            fldDialog.Description = "Select folder to be added to collection";
            fldDialog.RootFolder = Environment.SpecialFolder.Desktop;


            DialogResult result = fldDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                return fldDialog.SelectedPath;
            }
            else
            {
                return "";
            }
        }


        public AddFolderDialog(Form parent)
        {
            InitializeComponent();

            this._parent = parent as MainForm;
            InitializeAddFolderDialogUI();
        }

        private void InitializeAddFolderDialogUI()
        {
            this.cbIncludeSubfolders.Checked = true;
            this.txtFolderPath.Text = "";
            this.txtExtensions.Text = "";  // TODO -- Default value from app settings
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            this.txtFolderPath.Text = SelectFolderToAdd();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ValidateDialog();
        }

        private void ValidateDialog()
        {
            if (_parent.data.AddedFolder == null)
            {
                _parent.data.AddedFolder = new AddFolderDialogData();

            }

            _parent.data.AddedFolder.FolderPath = _parent.GetFileSystemCasing(txtFolderPath.Text.Trim());
            _parent.data.AddedFolder.SubFolders = cbIncludeSubfolders.Checked;
            _parent.data.AddedFolder.Extentions = txtExtensions.Text;
            _parent.data.AddedFolder.IsValidated = false;
            _parent.data.AddedFolder.ValidationMessage = "";

            if (string.IsNullOrWhiteSpace(_parent.data.AddedFolder.FolderPath))
            {
                _parent.data.AddedFolder.IsValidated = false;
                _parent.data.AddedFolder.ValidationMessage = "wrong folder path provided: " + txtFolderPath.Text.Trim();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtExtensions.Text))
            {
                _parent.data.AddedFolder.IsValidated = true;
                _parent.data.AddedFolder.Extentions = ".*";         // default value for extensions -- All Extensions
                return;
            }

            _parent.data.AddedFolder.IsValidated = true;
        }
    }
}
