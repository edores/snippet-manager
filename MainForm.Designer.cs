namespace Snippet
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.stMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.stFile = new System.Windows.Forms.ToolStripStatusLabel();
            this.stCollection = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainSplit = new System.Windows.Forms.SplitContainer();
            this.SelectorSplit = new System.Windows.Forms.SplitContainer();
            this.SelectorTabs = new CustomTabs.FixedTabControl();
            this.tabFileSelector = new System.Windows.Forms.TabPage();
            this.lstFileSelector = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabSearchResults = new System.Windows.Forms.TabPage();
            this.lstSearchResultsSelector = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SelectorSearchGroup = new System.Windows.Forms.GroupBox();
            this.btnSearchSelector = new System.Windows.Forms.Button();
            this.cbNoTags = new System.Windows.Forms.CheckBox();
            this.cbRefine = new System.Windows.Forms.CheckBox();
            this.cbMatchCase = new System.Windows.Forms.CheckBox();
            this.cbText = new System.Windows.Forms.CheckBox();
            this.cbTag = new System.Windows.Forms.CheckBox();
            this.txtSearchSelector = new System.Windows.Forms.TextBox();
            this.ContentSplit = new System.Windows.Forms.SplitContainer();
            this.ContentFileTabs = new CustomTabs.FixedTabControl();
            this.TagSplit = new System.Windows.Forms.SplitContainer();
            this.lstTagsContent = new System.Windows.Forms.ListView();
            this.btnMoveDn = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnRemoveTag = new System.Windows.Forms.Button();
            this.btnAddTag = new System.Windows.Forms.Button();
            this.txtNewTag = new System.Windows.Forms.TextBox();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.addFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbFile = new System.Windows.Forms.ToolStrip();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddFolder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnSaveAs = new System.Windows.Forms.ToolStripButton();
            this.cmContentTab = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmiCloseAllTabs = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiCloseAllOtherTabs = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiCloseThisTab = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiSaveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer.ContentPanel.SuspendLayout();
            this.toolStripContainer.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer.SuspendLayout();
            this.statusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplit)).BeginInit();
            this.MainSplit.Panel1.SuspendLayout();
            this.MainSplit.Panel2.SuspendLayout();
            this.MainSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SelectorSplit)).BeginInit();
            this.SelectorSplit.Panel1.SuspendLayout();
            this.SelectorSplit.Panel2.SuspendLayout();
            this.SelectorSplit.SuspendLayout();
            this.SelectorTabs.SuspendLayout();
            this.tabFileSelector.SuspendLayout();
            this.tabSearchResults.SuspendLayout();
            this.SelectorSearchGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ContentSplit)).BeginInit();
            this.ContentSplit.Panel1.SuspendLayout();
            this.ContentSplit.Panel2.SuspendLayout();
            this.ContentSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TagSplit)).BeginInit();
            this.TagSplit.Panel1.SuspendLayout();
            this.TagSplit.Panel2.SuspendLayout();
            this.TagSplit.SuspendLayout();
            this.mnuMain.SuspendLayout();
            this.tbFile.SuspendLayout();
            this.cmContentTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer
            // 
            // 
            // toolStripContainer.BottomToolStripPanel
            // 
            this.toolStripContainer.BottomToolStripPanel.Controls.Add(this.statusBar);
            // 
            // toolStripContainer.ContentPanel
            // 
            this.toolStripContainer.ContentPanel.Controls.Add(this.MainSplit);
            this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(868, 419);
            this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer.Name = "toolStripContainer";
            this.toolStripContainer.Size = new System.Drawing.Size(868, 492);
            this.toolStripContainer.TabIndex = 0;
            this.toolStripContainer.Text = "toolStripContainer1";
            // 
            // toolStripContainer.TopToolStripPanel
            // 
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.mnuMain);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.tbFile);
            // 
            // statusBar
            // 
            this.statusBar.Dock = System.Windows.Forms.DockStyle.None;
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stMessage,
            this.stFile,
            this.stCollection});
            this.statusBar.Location = new System.Drawing.Point(0, 0);
            this.statusBar.Name = "statusBar";
            this.statusBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusBar.Size = new System.Drawing.Size(868, 24);
            this.statusBar.TabIndex = 0;
            // 
            // stMessage
            // 
            this.stMessage.AutoSize = false;
            this.stMessage.AutoToolTip = true;
            this.stMessage.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.stMessage.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.stMessage.Name = "stMessage";
            this.stMessage.Size = new System.Drawing.Size(453, 19);
            this.stMessage.Spring = true;
            this.stMessage.Tag = "Status > Message";
            this.stMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.stMessage.ToolTipText = "Program status (error) message\r\n";
            this.stMessage.Click += new System.EventHandler(this.StatusButton_Click);
            // 
            // stFile
            // 
            this.stFile.AutoSize = false;
            this.stFile.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.stFile.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.stFile.Name = "stFile";
            this.stFile.Size = new System.Drawing.Size(200, 19);
            this.stFile.Tag = "Status > Opened File";
            this.stFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.stFile.Click += new System.EventHandler(this.StatusButton_Click);
            // 
            // stCollection
            // 
            this.stCollection.AutoSize = false;
            this.stCollection.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.stCollection.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.stCollection.Name = "stCollection";
            this.stCollection.Size = new System.Drawing.Size(200, 19);
            this.stCollection.Tag = "Status > Opened Collection";
            this.stCollection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.stCollection.Click += new System.EventHandler(this.StatusButton_Click);
            // 
            // MainSplit
            // 
            this.MainSplit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.MainSplit.Location = new System.Drawing.Point(0, 0);
            this.MainSplit.Name = "MainSplit";
            // 
            // MainSplit.Panel1
            // 
            this.MainSplit.Panel1.Controls.Add(this.SelectorSplit);
            // 
            // MainSplit.Panel2
            // 
            this.MainSplit.Panel2.Controls.Add(this.ContentSplit);
            this.MainSplit.Size = new System.Drawing.Size(868, 419);
            this.MainSplit.SplitterDistance = 289;
            this.MainSplit.TabIndex = 0;
            // 
            // SelectorSplit
            // 
            this.SelectorSplit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SelectorSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectorSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SelectorSplit.Location = new System.Drawing.Point(0, 0);
            this.SelectorSplit.Name = "SelectorSplit";
            this.SelectorSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SelectorSplit.Panel1
            // 
            this.SelectorSplit.Panel1.Controls.Add(this.SelectorTabs);
            // 
            // SelectorSplit.Panel2
            // 
            this.SelectorSplit.Panel2.Controls.Add(this.SelectorSearchGroup);
            this.SelectorSplit.Size = new System.Drawing.Size(289, 419);
            this.SelectorSplit.SplitterDistance = 319;
            this.SelectorSplit.TabIndex = 0;
            // 
            // SelectorTabs
            // 
            this.SelectorTabs.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.SelectorTabs.Controls.Add(this.tabFileSelector);
            this.SelectorTabs.Controls.Add(this.tabSearchResults);
            this.SelectorTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectorTabs.Location = new System.Drawing.Point(0, 0);
            this.SelectorTabs.Name = "SelectorTabs";
            this.SelectorTabs.SelectedIndex = 0;
            this.SelectorTabs.Size = new System.Drawing.Size(287, 317);
            this.SelectorTabs.TabIndex = 0;
            // 
            // tabFileSelector
            // 
            this.tabFileSelector.Controls.Add(this.lstFileSelector);
            this.tabFileSelector.Location = new System.Drawing.Point(4, 4);
            this.tabFileSelector.Name = "tabFileSelector";
            this.tabFileSelector.Size = new System.Drawing.Size(279, 291);
            this.tabFileSelector.TabIndex = 0;
            this.tabFileSelector.Tag = "Files";
            this.tabFileSelector.Text = "Files";
            this.tabFileSelector.UseVisualStyleBackColor = true;
            // 
            // lstFileSelector
            // 
            this.lstFileSelector.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstFileSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFileSelector.FullRowSelect = true;
            this.lstFileSelector.Location = new System.Drawing.Point(0, 0);
            this.lstFileSelector.Name = "lstFileSelector";
            this.lstFileSelector.Size = new System.Drawing.Size(279, 291);
            this.lstFileSelector.TabIndex = 0;
            this.lstFileSelector.UseCompatibleStateImageBehavior = false;
            this.lstFileSelector.View = System.Windows.Forms.View.Details;
            this.lstFileSelector.ItemActivate += new System.EventHandler(this.lstFileSelector_ItemActivate);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "File Name";
            this.columnHeader1.Width = 268;
            // 
            // tabSearchResults
            // 
            this.tabSearchResults.Controls.Add(this.lstSearchResultsSelector);
            this.tabSearchResults.Location = new System.Drawing.Point(4, 4);
            this.tabSearchResults.Name = "tabSearchResults";
            this.tabSearchResults.Size = new System.Drawing.Size(279, 291);
            this.tabSearchResults.TabIndex = 1;
            this.tabSearchResults.Tag = "Search_Results";
            this.tabSearchResults.Text = "Search Results";
            this.tabSearchResults.UseVisualStyleBackColor = true;
            // 
            // lstSearchResultsSelector
            // 
            this.lstSearchResultsSelector.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lstSearchResultsSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSearchResultsSelector.FullRowSelect = true;
            this.lstSearchResultsSelector.Location = new System.Drawing.Point(0, 0);
            this.lstSearchResultsSelector.Name = "lstSearchResultsSelector";
            this.lstSearchResultsSelector.Size = new System.Drawing.Size(279, 291);
            this.lstSearchResultsSelector.TabIndex = 0;
            this.lstSearchResultsSelector.UseCompatibleStateImageBehavior = false;
            this.lstSearchResultsSelector.View = System.Windows.Forms.View.Details;
            this.lstSearchResultsSelector.ItemActivate += new System.EventHandler(this.lstFileSelector_ItemActivate);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "File Name";
            this.columnHeader2.Width = 275;
            // 
            // SelectorSearchGroup
            // 
            this.SelectorSearchGroup.Controls.Add(this.btnSearchSelector);
            this.SelectorSearchGroup.Controls.Add(this.cbNoTags);
            this.SelectorSearchGroup.Controls.Add(this.cbRefine);
            this.SelectorSearchGroup.Controls.Add(this.cbMatchCase);
            this.SelectorSearchGroup.Controls.Add(this.cbText);
            this.SelectorSearchGroup.Controls.Add(this.cbTag);
            this.SelectorSearchGroup.Controls.Add(this.txtSearchSelector);
            this.SelectorSearchGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectorSearchGroup.Location = new System.Drawing.Point(0, 0);
            this.SelectorSearchGroup.Name = "SelectorSearchGroup";
            this.SelectorSearchGroup.Size = new System.Drawing.Size(287, 94);
            this.SelectorSearchGroup.TabIndex = 0;
            this.SelectorSearchGroup.TabStop = false;
            this.SelectorSearchGroup.Text = "Search";
            // 
            // btnSearchSelector
            // 
            this.btnSearchSelector.Location = new System.Drawing.Point(233, 19);
            this.btnSearchSelector.Name = "btnSearchSelector";
            this.btnSearchSelector.Size = new System.Drawing.Size(50, 23);
            this.btnSearchSelector.TabIndex = 2;
            this.btnSearchSelector.Text = "Search";
            this.btnSearchSelector.UseVisualStyleBackColor = true;
            this.btnSearchSelector.Click += new System.EventHandler(this.btnSearchSelector_Click);
            // 
            // cbNoTags
            // 
            this.cbNoTags.AutoSize = true;
            this.cbNoTags.Location = new System.Drawing.Point(13, 68);
            this.cbNoTags.Name = "cbNoTags";
            this.cbNoTags.Size = new System.Drawing.Size(67, 17);
            this.cbNoTags.TabIndex = 1;
            this.cbNoTags.Text = "No Tags";
            this.cbNoTags.UseVisualStyleBackColor = true;
            // 
            // cbRefine
            // 
            this.cbRefine.AutoSize = true;
            this.cbRefine.Location = new System.Drawing.Point(206, 47);
            this.cbRefine.Name = "cbRefine";
            this.cbRefine.Size = new System.Drawing.Size(57, 17);
            this.cbRefine.TabIndex = 1;
            this.cbRefine.Text = "Refine";
            this.cbRefine.UseVisualStyleBackColor = true;
            // 
            // cbMatchCase
            // 
            this.cbMatchCase.AutoSize = true;
            this.cbMatchCase.Location = new System.Drawing.Point(117, 47);
            this.cbMatchCase.Name = "cbMatchCase";
            this.cbMatchCase.Size = new System.Drawing.Size(83, 17);
            this.cbMatchCase.TabIndex = 1;
            this.cbMatchCase.Text = "Match Case";
            this.cbMatchCase.UseVisualStyleBackColor = true;
            // 
            // cbText
            // 
            this.cbText.AutoSize = true;
            this.cbText.Location = new System.Drawing.Point(64, 47);
            this.cbText.Name = "cbText";
            this.cbText.Size = new System.Drawing.Size(47, 17);
            this.cbText.TabIndex = 1;
            this.cbText.Text = "Text";
            this.cbText.UseVisualStyleBackColor = true;
            // 
            // cbTag
            // 
            this.cbTag.AutoSize = true;
            this.cbTag.Location = new System.Drawing.Point(13, 47);
            this.cbTag.Name = "cbTag";
            this.cbTag.Size = new System.Drawing.Size(45, 17);
            this.cbTag.TabIndex = 1;
            this.cbTag.Text = "Tag";
            this.cbTag.UseVisualStyleBackColor = true;
            // 
            // txtSearchSelector
            // 
            this.txtSearchSelector.Location = new System.Drawing.Point(4, 20);
            this.txtSearchSelector.Name = "txtSearchSelector";
            this.txtSearchSelector.Size = new System.Drawing.Size(223, 20);
            this.txtSearchSelector.TabIndex = 0;
            this.txtSearchSelector.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchSelector_KeyPress);
            // 
            // ContentSplit
            // 
            this.ContentSplit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContentSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.ContentSplit.Location = new System.Drawing.Point(0, 0);
            this.ContentSplit.Name = "ContentSplit";
            this.ContentSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ContentSplit.Panel1
            // 
            this.ContentSplit.Panel1.Controls.Add(this.ContentFileTabs);
            // 
            // ContentSplit.Panel2
            // 
            this.ContentSplit.Panel2.Controls.Add(this.TagSplit);
            this.ContentSplit.Size = new System.Drawing.Size(575, 419);
            this.ContentSplit.SplitterDistance = 327;
            this.ContentSplit.TabIndex = 0;
            // 
            // ContentFileTabs
            // 
            this.ContentFileTabs.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.ContentFileTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentFileTabs.Location = new System.Drawing.Point(0, 0);
            this.ContentFileTabs.Name = "ContentFileTabs";
            this.ContentFileTabs.SelectedIndex = 0;
            this.ContentFileTabs.Size = new System.Drawing.Size(573, 325);
            this.ContentFileTabs.TabIndex = 0;
            this.ContentFileTabs.Selected += new System.Windows.Forms.TabControlEventHandler(this.ContentFileTabs_Selected);
            this.ContentFileTabs.Click += new System.EventHandler(this.ContentFileTabs_Click);
            this.ContentFileTabs.DoubleClick += new System.EventHandler(this.ContentFileTabs_DoubleClick);
            // 
            // TagSplit
            // 
            this.TagSplit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TagSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TagSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.TagSplit.Location = new System.Drawing.Point(0, 0);
            this.TagSplit.Name = "TagSplit";
            // 
            // TagSplit.Panel1
            // 
            this.TagSplit.Panel1.Controls.Add(this.lstTagsContent);
            // 
            // TagSplit.Panel2
            // 
            this.TagSplit.Panel2.Controls.Add(this.btnMoveDn);
            this.TagSplit.Panel2.Controls.Add(this.btnMoveUp);
            this.TagSplit.Panel2.Controls.Add(this.btnRemoveTag);
            this.TagSplit.Panel2.Controls.Add(this.btnAddTag);
            this.TagSplit.Panel2.Controls.Add(this.txtNewTag);
            this.TagSplit.Size = new System.Drawing.Size(575, 88);
            this.TagSplit.SplitterDistance = 410;
            this.TagSplit.TabIndex = 0;
            // 
            // lstTagsContent
            // 
            this.lstTagsContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTagsContent.Location = new System.Drawing.Point(0, 0);
            this.lstTagsContent.Name = "lstTagsContent";
            this.lstTagsContent.Size = new System.Drawing.Size(408, 86);
            this.lstTagsContent.TabIndex = 0;
            this.lstTagsContent.UseCompatibleStateImageBehavior = false;
            this.lstTagsContent.View = System.Windows.Forms.View.SmallIcon;
            // 
            // btnMoveDn
            // 
            this.btnMoveDn.Location = new System.Drawing.Point(91, 56);
            this.btnMoveDn.Name = "btnMoveDn";
            this.btnMoveDn.Size = new System.Drawing.Size(61, 23);
            this.btnMoveDn.TabIndex = 2;
            this.btnMoveDn.Text = "Move Dn";
            this.btnMoveDn.UseVisualStyleBackColor = true;
            this.btnMoveDn.Click += new System.EventHandler(this.btnMoveDn_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Location = new System.Drawing.Point(91, 29);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(61, 23);
            this.btnMoveUp.TabIndex = 2;
            this.btnMoveUp.Text = "Move Up";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnRemoveTag
            // 
            this.btnRemoveTag.Location = new System.Drawing.Point(4, 56);
            this.btnRemoveTag.Name = "btnRemoveTag";
            this.btnRemoveTag.Size = new System.Drawing.Size(81, 23);
            this.btnRemoveTag.TabIndex = 1;
            this.btnRemoveTag.Text = "Remove Tag";
            this.btnRemoveTag.UseVisualStyleBackColor = true;
            this.btnRemoveTag.Click += new System.EventHandler(this.btnRemoveTag_Click);
            // 
            // btnAddTag
            // 
            this.btnAddTag.Location = new System.Drawing.Point(4, 29);
            this.btnAddTag.Name = "btnAddTag";
            this.btnAddTag.Size = new System.Drawing.Size(81, 23);
            this.btnAddTag.TabIndex = 1;
            this.btnAddTag.Text = "Add Tag";
            this.btnAddTag.UseVisualStyleBackColor = true;
            this.btnAddTag.Click += new System.EventHandler(this.btnAddTag_Click);
            // 
            // txtNewTag
            // 
            this.txtNewTag.Location = new System.Drawing.Point(4, 3);
            this.txtNewTag.Name = "txtNewTag";
            this.txtNewTag.Size = new System.Drawing.Size(151, 20);
            this.txtNewTag.TabIndex = 0;
            this.txtNewTag.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNewTag_KeyPress);
            // 
            // mnuMain
            // 
            this.mnuMain.Dock = System.Windows.Forms.DockStyle.None;
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(868, 24);
            this.mnuMain.TabIndex = 0;
            this.mnuMain.Text = "menuStrip1";
            this.mnuMain.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnuMain_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripMenuItem1,
            this.addFolderToolStripMenuItem,
            this.toolStripSeparator3,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.newToolStripMenuItem.Text = "&New...";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.openToolStripMenuItem.Text = "&Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 6);
            // 
            // addFolderToolStripMenuItem
            // 
            this.addFolderToolStripMenuItem.AutoToolTip = true;
            this.addFolderToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addFolderToolStripMenuItem.Image")));
            this.addFolderToolStripMenuItem.Name = "addFolderToolStripMenuItem";
            this.addFolderToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.addFolderToolStripMenuItem.Text = "Add Folder...";
            this.addFolderToolStripMenuItem.Click += new System.EventHandler(this.addFolderToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(152, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveAsToolStripMenuItem.Image")));
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // tbFile
            // 
            this.tbFile.Dock = System.Windows.Forms.DockStyle.None;
            this.tbFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.btnOpen,
            this.toolStripSeparator1,
            this.btnAddFolder,
            this.toolStripSeparator2,
            this.btnSave,
            this.btnSaveAs});
            this.tbFile.Location = new System.Drawing.Point(3, 24);
            this.tbFile.Name = "tbFile";
            this.tbFile.Size = new System.Drawing.Size(139, 25);
            this.tbFile.TabIndex = 1;
            // 
            // btnNew
            // 
            this.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(23, 22);
            this.btnNew.Text = "btnOpen";
            this.btnNew.ToolTipText = "New... (Ctrl-N)";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(23, 22);
            this.btnOpen.ToolTipText = "Open... (Ctrl-O)";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddFolder.Image = ((System.Drawing.Image)(resources.GetObject("btnAddFolder.Image")));
            this.btnAddFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Size = new System.Drawing.Size(23, 22);
            this.btnAddFolder.Text = "Add Folder ...";
            this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 22);
            this.btnSave.Text = "toolStripButton1";
            this.btnSave.ToolTipText = "Save (Ctrl-S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveAs.Image")));
            this.btnSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(23, 22);
            this.btnSaveAs.Text = "Save As...";
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // cmContentTab
            // 
            this.cmContentTab.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmiCloseAllTabs,
            this.cmiCloseAllOtherTabs,
            this.cmiCloseThisTab,
            this.cmiSaveFile});
            this.cmContentTab.Name = "cmContentTab";
            this.cmContentTab.Size = new System.Drawing.Size(182, 92);
            // 
            // cmiCloseAllTabs
            // 
            this.cmiCloseAllTabs.Name = "cmiCloseAllTabs";
            this.cmiCloseAllTabs.Size = new System.Drawing.Size(181, 22);
            this.cmiCloseAllTabs.Text = "Close All Tabs";
            this.cmiCloseAllTabs.Click += new System.EventHandler(this.cmiCloseAllTabs_Click);
            // 
            // cmiCloseAllOtherTabs
            // 
            this.cmiCloseAllOtherTabs.Name = "cmiCloseAllOtherTabs";
            this.cmiCloseAllOtherTabs.Size = new System.Drawing.Size(181, 22);
            this.cmiCloseAllOtherTabs.Text = "Close All Other Tabs";
            this.cmiCloseAllOtherTabs.Click += new System.EventHandler(this.cmiCloseAllOtherTabs_Click);
            // 
            // cmiCloseThisTab
            // 
            this.cmiCloseThisTab.Name = "cmiCloseThisTab";
            this.cmiCloseThisTab.Size = new System.Drawing.Size(181, 22);
            this.cmiCloseThisTab.Text = "Close This Tab";
            this.cmiCloseThisTab.Click += new System.EventHandler(this.cmiCloseThisTab_Click);
            // 
            // cmiSaveFile
            // 
            this.cmiSaveFile.Name = "cmiSaveFile";
            this.cmiSaveFile.Size = new System.Drawing.Size(181, 22);
            this.cmiSaveFile.Text = "Save File";
            this.cmiSaveFile.Click += new System.EventHandler(this.cmiSaveFile_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 492);
            this.Controls.Add(this.toolStripContainer);
            this.Name = "MainForm";
            this.Text = "Snippet - v.1.3.1 (2012-05-08)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStripContainer.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer.ContentPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.PerformLayout();
            this.toolStripContainer.ResumeLayout(false);
            this.toolStripContainer.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.MainSplit.Panel1.ResumeLayout(false);
            this.MainSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplit)).EndInit();
            this.MainSplit.ResumeLayout(false);
            this.SelectorSplit.Panel1.ResumeLayout(false);
            this.SelectorSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SelectorSplit)).EndInit();
            this.SelectorSplit.ResumeLayout(false);
            this.SelectorTabs.ResumeLayout(false);
            this.tabFileSelector.ResumeLayout(false);
            this.tabSearchResults.ResumeLayout(false);
            this.SelectorSearchGroup.ResumeLayout(false);
            this.SelectorSearchGroup.PerformLayout();
            this.ContentSplit.Panel1.ResumeLayout(false);
            this.ContentSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ContentSplit)).EndInit();
            this.ContentSplit.ResumeLayout(false);
            this.TagSplit.Panel1.ResumeLayout(false);
            this.TagSplit.Panel2.ResumeLayout(false);
            this.TagSplit.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TagSplit)).EndInit();
            this.TagSplit.ResumeLayout(false);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.tbFile.ResumeLayout(false);
            this.tbFile.PerformLayout();
            this.cmContentTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStrip tbFile;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnSaveAs;
        private System.Windows.Forms.ToolStripStatusLabel stMessage;
        private System.Windows.Forms.ToolStripStatusLabel stFile;
        private System.Windows.Forms.ToolStripStatusLabel stCollection;
        private System.Windows.Forms.SplitContainer MainSplit;
        private System.Windows.Forms.SplitContainer SelectorSplit;
        private System.Windows.Forms.SplitContainer ContentSplit;
        private System.Windows.Forms.SplitContainer TagSplit;
        //private System.Windows.Forms.TabControl SelectorTabs;

        private CustomTabs.FixedTabControl SelectorTabs;
        private System.Windows.Forms.TabPage tabFileSelector;
        private System.Windows.Forms.GroupBox SelectorSearchGroup;
        private System.Windows.Forms.TabPage tabSearchResults;
        private System.Windows.Forms.Button btnSearchSelector;
        private System.Windows.Forms.CheckBox cbText;
        private System.Windows.Forms.CheckBox cbTag;
        private System.Windows.Forms.TextBox txtSearchSelector;
        //private System.Windows.Forms.TabControl ContentFileTabs;
        private CustomTabs.FixedTabControl ContentFileTabs;

        private System.Windows.Forms.ListView lstTagsContent;
        private System.Windows.Forms.Button btnRemoveTag;
        private System.Windows.Forms.Button btnAddTag;
        private System.Windows.Forms.TextBox txtNewTag;
        private System.Windows.Forms.ListView lstFileSelector;
        private System.Windows.Forms.ListView lstSearchResultsSelector;
        private System.Windows.Forms.Button btnMoveDn;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnAddFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem addFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.CheckBox cbMatchCase;
        private System.Windows.Forms.CheckBox cbRefine;
        private System.Windows.Forms.CheckBox cbNoTags;
        private System.Windows.Forms.ContextMenuStrip cmContentTab;
        private System.Windows.Forms.ToolStripMenuItem cmiCloseAllTabs;
        private System.Windows.Forms.ToolStripMenuItem cmiCloseAllOtherTabs;
        private System.Windows.Forms.ToolStripMenuItem cmiCloseThisTab;
        private System.Windows.Forms.ToolStripMenuItem cmiSaveFile;
    }
}

