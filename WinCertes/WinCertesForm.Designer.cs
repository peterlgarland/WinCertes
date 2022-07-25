
namespace WinCertes
{
    partial class WinCertesForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinCertesForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.standaloneGroupBox = new System.Windows.Forms.GroupBox();
            this.httpPortNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.checkPortButton = new System.Windows.Forms.Button();
            this.inUseLabel = new System.Windows.Forms.Label();
            this.challangeLabel = new System.Windows.Forms.Label();
            this.portLabel = new System.Windows.Forms.Label();
            this.settingsGroupBox = new System.Windows.Forms.GroupBox();
            this.registeredLabel = new System.Windows.Forms.Label();
            this.iisRadioButton = new System.Windows.Forms.RadioButton();
            this.standaloneRadioButton = new System.Windows.Forms.RadioButton();
            this.serverLabel = new System.Windows.Forms.Label();
            this.serviceComboBox = new System.Windows.Forms.ComboBox();
            this.serviceLabel = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.iisGroupBox = new System.Windows.Forms.GroupBox();
            this.iisPortNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.iisCheckBox = new System.Windows.Forms.CheckBox();
            this.iisPortLabel = new System.Windows.Forms.Label();
            this.sniCheckBox = new System.Windows.Forms.CheckBox();
            this.sitesListBox = new System.Windows.Forms.ListBox();
            this.webRootLabel = new System.Windows.Forms.Label();
            this.bindingsListBox = new System.Windows.Forms.ListBox();
            this.webChallengeLabel = new System.Windows.Forms.Label();
            this.siteBindingsLabel = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.domainsGroupBox = new System.Windows.Forms.GroupBox();
            this.domainsLabel = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.domainTextBox = new System.Windows.Forms.TextBox();
            this.newDomainlabel = new System.Windows.Forms.Label();
            this.removeButton = new System.Windows.Forms.Button();
            this.domainsListBox = new System.Windows.Forms.ListBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.taskGroupBox = new System.Windows.Forms.GroupBox();
            this.renewalNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.renewLabel = new System.Windows.Forms.Label();
            this.taskCheckBox = new System.Windows.Forms.CheckBox();
            this.psGroupBox = new System.Windows.Forms.GroupBox();
            this.psExecComboBox = new System.Windows.Forms.ComboBox();
            this.psExecCheckBox = new System.Windows.Forms.CheckBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.psScriptTextBox = new System.Windows.Forms.TextBox();
            this.psScriptCheckBox = new System.Windows.Forms.CheckBox();
            this.browseOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.issueButton = new System.Windows.Forms.Button();
            this.revokeButton = new System.Windows.Forms.Button();
            this.certButton = new System.Windows.Forms.Button();
            this.configLabel = new System.Windows.Forms.Label();
            this.configsComboBox = new System.Windows.Forms.ComboBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.newConfigButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.actionToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.actionToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.standaloneGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.httpPortNumericUpDown)).BeginInit();
            this.settingsGroupBox.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.iisGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iisPortNumericUpDown)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.domainsGroupBox.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.taskGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.renewalNumericUpDown)).BeginInit();
            this.psGroupBox.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControl1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tabControl1.Location = new System.Drawing.Point(12, 63);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(24, 12);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1269, 601);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.standaloneGroupBox);
            this.tabPage1.Controls.Add(this.settingsGroupBox);
            this.tabPage1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPage1.Location = new System.Drawing.Point(8, 62);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1253, 531);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // standaloneGroupBox
            // 
            this.standaloneGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.standaloneGroupBox.Controls.Add(this.httpPortNumericUpDown);
            this.standaloneGroupBox.Controls.Add(this.checkPortButton);
            this.standaloneGroupBox.Controls.Add(this.inUseLabel);
            this.standaloneGroupBox.Controls.Add(this.challangeLabel);
            this.standaloneGroupBox.Controls.Add(this.portLabel);
            this.standaloneGroupBox.Location = new System.Drawing.Point(7, 186);
            this.standaloneGroupBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.standaloneGroupBox.Name = "standaloneGroupBox";
            this.standaloneGroupBox.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.standaloneGroupBox.Size = new System.Drawing.Size(1239, 177);
            this.standaloneGroupBox.TabIndex = 42;
            this.standaloneGroupBox.TabStop = false;
            this.standaloneGroupBox.Text = "Standalone HTTP Server Settings";
            // 
            // httpPortNumericUpDown
            // 
            this.httpPortNumericUpDown.Location = new System.Drawing.Point(259, 36);
            this.httpPortNumericUpDown.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.httpPortNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.httpPortNumericUpDown.Name = "httpPortNumericUpDown";
            this.httpPortNumericUpDown.Size = new System.Drawing.Size(152, 39);
            this.httpPortNumericUpDown.TabIndex = 5;
            this.httpPortNumericUpDown.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.httpPortNumericUpDown.ValueChanged += new System.EventHandler(this.httpPortNumericUpDown_ValueChanged);
            // 
            // checkPortButton
            // 
            this.checkPortButton.Location = new System.Drawing.Point(1042, 25);
            this.checkPortButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.checkPortButton.Name = "checkPortButton";
            this.checkPortButton.Size = new System.Drawing.Size(189, 47);
            this.checkPortButton.TabIndex = 4;
            this.checkPortButton.Text = "Check Port";
            this.checkPortButton.UseVisualStyleBackColor = true;
            this.checkPortButton.Visible = false;
            this.checkPortButton.Click += new System.EventHandler(this.checkPortButton_Click);
            // 
            // inUseLabel
            // 
            this.inUseLabel.AutoSize = true;
            this.inUseLabel.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.inUseLabel.ForeColor = System.Drawing.Color.Red;
            this.inUseLabel.Location = new System.Drawing.Point(475, 40);
            this.inUseLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.inUseLabel.Name = "inUseLabel";
            this.inUseLabel.Size = new System.Drawing.Size(160, 32);
            this.inUseLabel.TabIndex = 3;
            this.inUseLabel.Text = "PORT IN USE";
            this.inUseLabel.Visible = false;
            // 
            // challangeLabel
            // 
            this.challangeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.challangeLabel.Location = new System.Drawing.Point(6, 94);
            this.challangeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.challangeLabel.Name = "challangeLabel";
            this.challangeLabel.Size = new System.Drawing.Size(1225, 72);
            this.challangeLabel.TabIndex = 2;
            this.challangeLabel.Text = "All Challenges are processed on Port 80, if you use a different port above you mu" +
    "st set Port Forwarding on your Router accordingly.";
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.portLabel.Location = new System.Drawing.Point(7, 40);
            this.portLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(150, 32);
            this.portLabel.TabIndex = 0;
            this.portLabel.Text = "Server Port:";
            // 
            // settingsGroupBox
            // 
            this.settingsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsGroupBox.Controls.Add(this.registeredLabel);
            this.settingsGroupBox.Controls.Add(this.iisRadioButton);
            this.settingsGroupBox.Controls.Add(this.standaloneRadioButton);
            this.settingsGroupBox.Controls.Add(this.serverLabel);
            this.settingsGroupBox.Controls.Add(this.serviceComboBox);
            this.settingsGroupBox.Controls.Add(this.serviceLabel);
            this.settingsGroupBox.Controls.Add(this.emailTextBox);
            this.settingsGroupBox.Controls.Add(this.emailLabel);
            this.settingsGroupBox.Location = new System.Drawing.Point(7, 5);
            this.settingsGroupBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.settingsGroupBox.Name = "settingsGroupBox";
            this.settingsGroupBox.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.settingsGroupBox.Size = new System.Drawing.Size(1239, 177);
            this.settingsGroupBox.TabIndex = 41;
            this.settingsGroupBox.TabStop = false;
            this.settingsGroupBox.Text = "Settings";
            // 
            // registeredLabel
            // 
            this.registeredLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.registeredLabel.AutoSize = true;
            this.registeredLabel.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.registeredLabel.Location = new System.Drawing.Point(1913, 33);
            this.registeredLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.registeredLabel.Name = "registeredLabel";
            this.registeredLabel.Size = new System.Drawing.Size(153, 32);
            this.registeredLabel.TabIndex = 33;
            this.registeredLabel.Text = "REGISTERED";
            this.registeredLabel.Visible = false;
            // 
            // iisRadioButton
            // 
            this.iisRadioButton.AutoSize = true;
            this.iisRadioButton.Location = new System.Drawing.Point(627, 116);
            this.iisRadioButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.iisRadioButton.Name = "iisRadioButton";
            this.iisRadioButton.Size = new System.Drawing.Size(205, 36);
            this.iisRadioButton.TabIndex = 31;
            this.iisRadioButton.TabStop = true;
            this.iisRadioButton.Text = "Local IIS Server";
            this.iisRadioButton.UseVisualStyleBackColor = true;
            this.iisRadioButton.CheckedChanged += new System.EventHandler(this.iisRadioButton_CheckedChanged);
            // 
            // standaloneRadioButton
            // 
            this.standaloneRadioButton.AutoSize = true;
            this.standaloneRadioButton.Location = new System.Drawing.Point(152, 120);
            this.standaloneRadioButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.standaloneRadioButton.Name = "standaloneRadioButton";
            this.standaloneRadioButton.Size = new System.Drawing.Size(301, 36);
            this.standaloneRadioButton.TabIndex = 30;
            this.standaloneRadioButton.TabStop = true;
            this.standaloneRadioButton.Text = "Standalone HTTP Server";
            this.standaloneRadioButton.UseVisualStyleBackColor = true;
            this.standaloneRadioButton.CheckedChanged += new System.EventHandler(this.standaloneRadioButton_CheckedChanged);
            // 
            // serverLabel
            // 
            this.serverLabel.AutoSize = true;
            this.serverLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.serverLabel.Location = new System.Drawing.Point(7, 120);
            this.serverLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.serverLabel.Name = "serverLabel";
            this.serverLabel.Size = new System.Drawing.Size(95, 32);
            this.serverLabel.TabIndex = 29;
            this.serverLabel.Text = "Server:";
            // 
            // serviceComboBox
            // 
            this.serviceComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serviceComboBox.FormattingEnabled = true;
            this.serviceComboBox.Location = new System.Drawing.Point(152, 74);
            this.serviceComboBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.serviceComboBox.Name = "serviceComboBox";
            this.serviceComboBox.Size = new System.Drawing.Size(1079, 40);
            this.serviceComboBox.TabIndex = 28;
            // 
            // serviceLabel
            // 
            this.serviceLabel.AutoSize = true;
            this.serviceLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.serviceLabel.Location = new System.Drawing.Point(5, 77);
            this.serviceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.serviceLabel.Name = "serviceLabel";
            this.serviceLabel.Size = new System.Drawing.Size(103, 32);
            this.serviceLabel.TabIndex = 27;
            this.serviceLabel.Text = "Service:";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.emailTextBox.Location = new System.Drawing.Point(152, 31);
            this.emailTextBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(1079, 39);
            this.emailTextBox.TabIndex = 26;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.emailLabel.Location = new System.Drawing.Point(7, 33);
            this.emailLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(104, 32);
            this.emailLabel.TabIndex = 25;
            this.emailLabel.Text = "e-mail*:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.iisGroupBox);
            this.tabPage2.Location = new System.Drawing.Point(8, 62);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1253, 531);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "IIS Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // iisGroupBox
            // 
            this.iisGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iisGroupBox.Controls.Add(this.iisPortNumericUpDown);
            this.iisGroupBox.Controls.Add(this.iisCheckBox);
            this.iisGroupBox.Controls.Add(this.iisPortLabel);
            this.iisGroupBox.Controls.Add(this.sniCheckBox);
            this.iisGroupBox.Controls.Add(this.sitesListBox);
            this.iisGroupBox.Controls.Add(this.webRootLabel);
            this.iisGroupBox.Controls.Add(this.bindingsListBox);
            this.iisGroupBox.Controls.Add(this.webChallengeLabel);
            this.iisGroupBox.Controls.Add(this.siteBindingsLabel);
            this.iisGroupBox.Location = new System.Drawing.Point(7, 5);
            this.iisGroupBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.iisGroupBox.Name = "iisGroupBox";
            this.iisGroupBox.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.iisGroupBox.Size = new System.Drawing.Size(1230, 521);
            this.iisGroupBox.TabIndex = 35;
            this.iisGroupBox.TabStop = false;
            this.iisGroupBox.Text = "IIS Settings";
            // 
            // iisPortNumericUpDown
            // 
            this.iisPortNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iisPortNumericUpDown.Location = new System.Drawing.Point(1108, 462);
            this.iisPortNumericUpDown.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.iisPortNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.iisPortNumericUpDown.Name = "iisPortNumericUpDown";
            this.iisPortNumericUpDown.Size = new System.Drawing.Size(108, 39);
            this.iisPortNumericUpDown.TabIndex = 43;
            this.iisPortNumericUpDown.Value = new decimal(new int[] {
            443,
            0,
            0,
            0});
            this.iisPortNumericUpDown.ValueChanged += new System.EventHandler(this.iisPortNumericUpDown_ValueChanged);
            // 
            // iisCheckBox
            // 
            this.iisCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iisCheckBox.AutoSize = true;
            this.iisCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.iisCheckBox.Location = new System.Drawing.Point(1004, 82);
            this.iisCheckBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.iisCheckBox.Name = "iisCheckBox";
            this.iisCheckBox.Size = new System.Drawing.Size(214, 36);
            this.iisCheckBox.TabIndex = 42;
            this.iisCheckBox.Text = "Bind to IIS Site";
            this.iisCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iisCheckBox.UseVisualStyleBackColor = true;
            this.iisCheckBox.CheckedChanged += new System.EventHandler(this.iisCheckBox_CheckedChanged);
            // 
            // iisPortLabel
            // 
            this.iisPortLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.iisPortLabel.AutoSize = true;
            this.iisPortLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.iisPortLabel.Location = new System.Drawing.Point(483, 464);
            this.iisPortLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.iisPortLabel.Name = "iisPortLabel";
            this.iisPortLabel.Size = new System.Drawing.Size(227, 32);
            this.iisPortLabel.TabIndex = 40;
            this.iisPortLabel.Text = "IIS Port to bind to:";
            // 
            // sniCheckBox
            // 
            this.sniCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sniCheckBox.AutoSize = true;
            this.sniCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sniCheckBox.Location = new System.Drawing.Point(484, 419);
            this.sniCheckBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.sniCheckBox.Name = "sniCheckBox";
            this.sniCheckBox.Size = new System.Drawing.Size(316, 36);
            this.sniCheckBox.TabIndex = 39;
            this.sniCheckBox.Text = "Server Name Indication";
            this.sniCheckBox.UseVisualStyleBackColor = true;
            this.sniCheckBox.CheckedChanged += new System.EventHandler(this.sniCheckBox_CheckedChanged);
            // 
            // sitesListBox
            // 
            this.sitesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.sitesListBox.FormattingEnabled = true;
            this.sitesListBox.ItemHeight = 32;
            this.sitesListBox.Location = new System.Drawing.Point(6, 81);
            this.sitesListBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.sitesListBox.Name = "sitesListBox";
            this.sitesListBox.Size = new System.Drawing.Size(470, 420);
            this.sitesListBox.TabIndex = 38;
            this.sitesListBox.SelectedIndexChanged += new System.EventHandler(this.sitesListBox_SelectedIndexChanged);
            // 
            // webRootLabel
            // 
            this.webRootLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webRootLabel.Location = new System.Drawing.Point(305, 34);
            this.webRootLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.webRootLabel.Name = "webRootLabel";
            this.webRootLabel.Size = new System.Drawing.Size(911, 32);
            this.webRootLabel.TabIndex = 37;
            // 
            // bindingsListBox
            // 
            this.bindingsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bindingsListBox.FormattingEnabled = true;
            this.bindingsListBox.ItemHeight = 32;
            this.bindingsListBox.Location = new System.Drawing.Point(484, 134);
            this.bindingsListBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.bindingsListBox.Name = "bindingsListBox";
            this.bindingsListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.bindingsListBox.Size = new System.Drawing.Size(732, 260);
            this.bindingsListBox.TabIndex = 36;
            // 
            // webChallengeLabel
            // 
            this.webChallengeLabel.AutoSize = true;
            this.webChallengeLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.webChallengeLabel.Location = new System.Drawing.Point(6, 34);
            this.webChallengeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.webChallengeLabel.Name = "webChallengeLabel";
            this.webChallengeLabel.Size = new System.Drawing.Size(293, 32);
            this.webChallengeLabel.TabIndex = 35;
            this.webChallengeLabel.Text = "Web Root for Challange:";
            // 
            // siteBindingsLabel
            // 
            this.siteBindingsLabel.AutoSize = true;
            this.siteBindingsLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.siteBindingsLabel.Location = new System.Drawing.Point(484, 82);
            this.siteBindingsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.siteBindingsLabel.Name = "siteBindingsLabel";
            this.siteBindingsLabel.Size = new System.Drawing.Size(158, 32);
            this.siteBindingsLabel.TabIndex = 34;
            this.siteBindingsLabel.Text = "Site Bindings:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.domainsGroupBox);
            this.tabPage3.Location = new System.Drawing.Point(8, 62);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1253, 531);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Domains";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // domainsGroupBox
            // 
            this.domainsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.domainsGroupBox.Controls.Add(this.domainsLabel);
            this.domainsGroupBox.Controls.Add(this.addButton);
            this.domainsGroupBox.Controls.Add(this.domainTextBox);
            this.domainsGroupBox.Controls.Add(this.newDomainlabel);
            this.domainsGroupBox.Controls.Add(this.removeButton);
            this.domainsGroupBox.Controls.Add(this.domainsListBox);
            this.domainsGroupBox.Location = new System.Drawing.Point(7, 5);
            this.domainsGroupBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.domainsGroupBox.Name = "domainsGroupBox";
            this.domainsGroupBox.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.domainsGroupBox.Size = new System.Drawing.Size(1239, 521);
            this.domainsGroupBox.TabIndex = 37;
            this.domainsGroupBox.TabStop = false;
            this.domainsGroupBox.Text = "Domains*";
            // 
            // domainsLabel
            // 
            this.domainsLabel.AutoSize = true;
            this.domainsLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.domainsLabel.Location = new System.Drawing.Point(8, 36);
            this.domainsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.domainsLabel.Name = "domainsLabel";
            this.domainsLabel.Size = new System.Drawing.Size(420, 32);
            this.domainsLabel.TabIndex = 42;
            this.domainsLabel.Text = "Domains to Generate certifcate for:";
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.Location = new System.Drawing.Point(1096, 464);
            this.addButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(130, 47);
            this.addButton.TabIndex = 41;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // domainTextBox
            // 
            this.domainTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.domainTextBox.Location = new System.Drawing.Point(307, 467);
            this.domainTextBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.domainTextBox.Name = "domainTextBox";
            this.domainTextBox.Size = new System.Drawing.Size(782, 39);
            this.domainTextBox.TabIndex = 40;
            // 
            // newDomainlabel
            // 
            this.newDomainlabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.newDomainlabel.AutoSize = true;
            this.newDomainlabel.Location = new System.Drawing.Point(17, 470);
            this.newDomainlabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.newDomainlabel.Name = "newDomainlabel";
            this.newDomainlabel.Size = new System.Drawing.Size(158, 32);
            this.newDomainlabel.TabIndex = 39;
            this.newDomainlabel.Text = "New Domain:";
            // 
            // removeButton
            // 
            this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeButton.Enabled = false;
            this.removeButton.Location = new System.Drawing.Point(1096, 70);
            this.removeButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(130, 47);
            this.removeButton.TabIndex = 38;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // domainsListBox
            // 
            this.domainsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.domainsListBox.FormattingEnabled = true;
            this.domainsListBox.ItemHeight = 32;
            this.domainsListBox.Location = new System.Drawing.Point(17, 70);
            this.domainsListBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.domainsListBox.Name = "domainsListBox";
            this.domainsListBox.Size = new System.Drawing.Size(1072, 388);
            this.domainsListBox.TabIndex = 37;
            this.domainsListBox.SelectedIndexChanged += new System.EventHandler(this.domainsListBox_SelectedIndexChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.taskGroupBox);
            this.tabPage4.Controls.Add(this.psGroupBox);
            this.tabPage4.Location = new System.Drawing.Point(8, 62);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1253, 531);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Extra";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // taskGroupBox
            // 
            this.taskGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.taskGroupBox.Controls.Add(this.renewalNumericUpDown);
            this.taskGroupBox.Controls.Add(this.renewLabel);
            this.taskGroupBox.Controls.Add(this.taskCheckBox);
            this.taskGroupBox.Location = new System.Drawing.Point(7, 5);
            this.taskGroupBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.taskGroupBox.Name = "taskGroupBox";
            this.taskGroupBox.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.taskGroupBox.Size = new System.Drawing.Size(1239, 177);
            this.taskGroupBox.TabIndex = 39;
            this.taskGroupBox.TabStop = false;
            this.taskGroupBox.Text = "Scheduled Task";
            // 
            // renewalNumericUpDown
            // 
            this.renewalNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.renewalNumericUpDown.Location = new System.Drawing.Point(1071, 99);
            this.renewalNumericUpDown.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.renewalNumericUpDown.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.renewalNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.renewalNumericUpDown.Name = "renewalNumericUpDown";
            this.renewalNumericUpDown.Size = new System.Drawing.Size(160, 39);
            this.renewalNumericUpDown.TabIndex = 46;
            this.renewalNumericUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // renewLabel
            // 
            this.renewLabel.AutoSize = true;
            this.renewLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.renewLabel.Location = new System.Drawing.Point(8, 101);
            this.renewLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.renewLabel.Name = "renewLabel";
            this.renewLabel.Size = new System.Drawing.Size(364, 32);
            this.renewLabel.TabIndex = 45;
            this.renewLabel.Text = "Renew Days before Expiration:";
            // 
            // taskCheckBox
            // 
            this.taskCheckBox.AutoSize = true;
            this.taskCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.taskCheckBox.Location = new System.Drawing.Point(8, 36);
            this.taskCheckBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.taskCheckBox.Name = "taskCheckBox";
            this.taskCheckBox.Size = new System.Drawing.Size(503, 36);
            this.taskCheckBox.TabIndex = 35;
            this.taskCheckBox.Text = "Schedule a Task to Renew Automatically";
            this.taskCheckBox.UseVisualStyleBackColor = true;
            this.taskCheckBox.CheckedChanged += new System.EventHandler(this.taskCheckBox_CheckedChanged);
            // 
            // psGroupBox
            // 
            this.psGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.psGroupBox.Controls.Add(this.psExecComboBox);
            this.psGroupBox.Controls.Add(this.psExecCheckBox);
            this.psGroupBox.Controls.Add(this.browseButton);
            this.psGroupBox.Controls.Add(this.psScriptTextBox);
            this.psGroupBox.Controls.Add(this.psScriptCheckBox);
            this.psGroupBox.Location = new System.Drawing.Point(7, 186);
            this.psGroupBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.psGroupBox.Name = "psGroupBox";
            this.psGroupBox.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.psGroupBox.Size = new System.Drawing.Size(1239, 145);
            this.psGroupBox.TabIndex = 38;
            this.psGroupBox.TabStop = false;
            this.psGroupBox.Text = "PowerShell Core Script";
            // 
            // psExecComboBox
            // 
            this.psExecComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.psExecComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.psExecComboBox.FormattingEnabled = true;
            this.psExecComboBox.Location = new System.Drawing.Point(847, 90);
            this.psExecComboBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.psExecComboBox.Name = "psExecComboBox";
            this.psExecComboBox.Size = new System.Drawing.Size(379, 40);
            this.psExecComboBox.TabIndex = 34;
            this.psExecComboBox.SelectedIndexChanged += new System.EventHandler(this.psExecComboBox_SelectedIndexChanged);
            // 
            // psExecCheckBox
            // 
            this.psExecCheckBox.AutoSize = true;
            this.psExecCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.psExecCheckBox.Location = new System.Drawing.Point(6, 92);
            this.psExecCheckBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.psExecCheckBox.Name = "psExecCheckBox";
            this.psExecCheckBox.Size = new System.Drawing.Size(372, 36);
            this.psExecCheckBox.TabIndex = 33;
            this.psExecCheckBox.Text = "PowerShell Execution Policy:";
            this.psExecCheckBox.UseVisualStyleBackColor = true;
            this.psExecCheckBox.CheckedChanged += new System.EventHandler(this.psExecCheckBox_CheckedChanged);
            // 
            // browseButton
            // 
            this.browseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseButton.Location = new System.Drawing.Point(1072, 32);
            this.browseButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(154, 47);
            this.browseButton.TabIndex = 32;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // psScriptTextBox
            // 
            this.psScriptTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.psScriptTextBox.Location = new System.Drawing.Point(443, 36);
            this.psScriptTextBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.psScriptTextBox.Name = "psScriptTextBox";
            this.psScriptTextBox.Size = new System.Drawing.Size(621, 39);
            this.psScriptTextBox.TabIndex = 31;
            this.psScriptTextBox.TextChanged += new System.EventHandler(this.psScriptTextBox_TextChanged);
            // 
            // psScriptCheckBox
            // 
            this.psScriptCheckBox.AutoSize = true;
            this.psScriptCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.psScriptCheckBox.Location = new System.Drawing.Point(6, 38);
            this.psScriptCheckBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.psScriptCheckBox.Name = "psScriptCheckBox";
            this.psScriptCheckBox.Size = new System.Drawing.Size(346, 36);
            this.psScriptCheckBox.TabIndex = 30;
            this.psScriptCheckBox.Text = "Execute PowerShell Script:";
            this.psScriptCheckBox.UseVisualStyleBackColor = true;
            this.psScriptCheckBox.CheckedChanged += new System.EventHandler(this.psScriptCheckBox_CheckedChanged);
            // 
            // browseOpenFileDialog
            // 
            this.browseOpenFileDialog.FileName = "openFileDialog1";
            // 
            // issueButton
            // 
            this.issueButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.issueButton.Enabled = false;
            this.issueButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.issueButton.Location = new System.Drawing.Point(20, 669);
            this.issueButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.issueButton.Name = "issueButton";
            this.issueButton.Size = new System.Drawing.Size(256, 47);
            this.issueButton.TabIndex = 35;
            this.issueButton.Text = "Issue Certificate";
            this.issueButton.UseVisualStyleBackColor = true;
            this.issueButton.Click += new System.EventHandler(this.issueButton_Click);
            // 
            // revokeButton
            // 
            this.revokeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.revokeButton.Location = new System.Drawing.Point(1023, 669);
            this.revokeButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.revokeButton.Name = "revokeButton";
            this.revokeButton.Size = new System.Drawing.Size(256, 47);
            this.revokeButton.TabIndex = 34;
            this.revokeButton.Text = "Revoke Certificate";
            this.revokeButton.UseVisualStyleBackColor = true;
            this.revokeButton.Visible = false;
            this.revokeButton.Click += new System.EventHandler(this.revokeButton_ClickAsync);
            // 
            // certButton
            // 
            this.certButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.certButton.Location = new System.Drawing.Point(759, 669);
            this.certButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.certButton.Name = "certButton";
            this.certButton.Size = new System.Drawing.Size(256, 47);
            this.certButton.TabIndex = 32;
            this.certButton.Text = "Show Certificate";
            this.certButton.UseVisualStyleBackColor = true;
            this.certButton.Visible = false;
            this.certButton.Click += new System.EventHandler(this.certButton_Click);
            // 
            // configLabel
            // 
            this.configLabel.AutoSize = true;
            this.configLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.configLabel.Location = new System.Drawing.Point(17, 18);
            this.configLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.configLabel.Name = "configLabel";
            this.configLabel.Size = new System.Drawing.Size(181, 32);
            this.configLabel.TabIndex = 42;
            this.configLabel.Text = "Configuration:";
            // 
            // configsComboBox
            // 
            this.configsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.configsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.configsComboBox.FormattingEnabled = true;
            this.configsComboBox.Location = new System.Drawing.Point(244, 15);
            this.configsComboBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.configsComboBox.Name = "configsComboBox";
            this.configsComboBox.Size = new System.Drawing.Size(553, 40);
            this.configsComboBox.TabIndex = 43;
            this.configsComboBox.SelectedIndexChanged += new System.EventHandler(this.configsComboBox_SelectedIndexChanged);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.Location = new System.Drawing.Point(805, 11);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(150, 47);
            this.deleteButton.TabIndex = 44;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // newConfigButton
            // 
            this.newConfigButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newConfigButton.Location = new System.Drawing.Point(963, 11);
            this.newConfigButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.newConfigButton.Name = "newConfigButton";
            this.newConfigButton.Size = new System.Drawing.Size(316, 47);
            this.newConfigButton.TabIndex = 45;
            this.newConfigButton.Text = "New Configuration";
            this.newConfigButton.UseVisualStyleBackColor = true;
            this.newConfigButton.Click += new System.EventHandler(this.newConfigButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionToolStripStatusLabel,
            this.actionToolStripProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 734);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 15, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1292, 42);
            this.statusStrip1.TabIndex = 46;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // actionToolStripStatusLabel
            // 
            this.actionToolStripStatusLabel.Name = "actionToolStripStatusLabel";
            this.actionToolStripStatusLabel.Size = new System.Drawing.Size(1275, 32);
            this.actionToolStripStatusLabel.Spring = true;
            this.actionToolStripStatusLabel.Text = "WinCertes";
            this.actionToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // actionToolStripProgressBar
            // 
            this.actionToolStripProgressBar.AutoSize = false;
            this.actionToolStripProgressBar.Name = "actionToolStripProgressBar";
            this.actionToolStripProgressBar.Size = new System.Drawing.Size(301, 30);
            this.actionToolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.actionToolStripProgressBar.Visible = false;
            // 
            // WinCertesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 776);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.issueButton);
            this.Controls.Add(this.newConfigButton);
            this.Controls.Add(this.revokeButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.configsComboBox);
            this.Controls.Add(this.certButton);
            this.Controls.Add(this.configLabel);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.MinimumSize = new System.Drawing.Size(1040, 745);
            this.Name = "WinCertesForm";
            this.Text = "WinCertes";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.WinCertesForm_HelpButtonClicked);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.WinCertesForm_HelpRequested);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.standaloneGroupBox.ResumeLayout(false);
            this.standaloneGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.httpPortNumericUpDown)).EndInit();
            this.settingsGroupBox.ResumeLayout(false);
            this.settingsGroupBox.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.iisGroupBox.ResumeLayout(false);
            this.iisGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iisPortNumericUpDown)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.domainsGroupBox.ResumeLayout(false);
            this.domainsGroupBox.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.taskGroupBox.ResumeLayout(false);
            this.taskGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.renewalNumericUpDown)).EndInit();
            this.psGroupBox.ResumeLayout(false);
            this.psGroupBox.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog browseOpenFileDialog;
        private System.Windows.Forms.GroupBox iisGroupBox;
        private System.Windows.Forms.Label iisPortLabel;
        private System.Windows.Forms.CheckBox sniCheckBox;
        private System.Windows.Forms.ListBox sitesListBox;
        private System.Windows.Forms.Label webRootLabel;
        private System.Windows.Forms.ListBox bindingsListBox;
        private System.Windows.Forms.Label webChallengeLabel;
        private System.Windows.Forms.Label siteBindingsLabel;
        private System.Windows.Forms.GroupBox domainsGroupBox;
        private System.Windows.Forms.Label domainsLabel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox domainTextBox;
        private System.Windows.Forms.Label newDomainlabel;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.ListBox domainsListBox;
        private System.Windows.Forms.GroupBox psGroupBox;
        private System.Windows.Forms.ComboBox psExecComboBox;
        private System.Windows.Forms.CheckBox psExecCheckBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox psScriptTextBox;
        private System.Windows.Forms.CheckBox psScriptCheckBox;
        private System.Windows.Forms.GroupBox taskGroupBox;
        private System.Windows.Forms.CheckBox taskCheckBox;
        private System.Windows.Forms.CheckBox iisCheckBox;
        private System.Windows.Forms.Button certButton;
        private System.Windows.Forms.Button revokeButton;
        private System.Windows.Forms.Label configLabel;
        private System.Windows.Forms.ComboBox configsComboBox;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.NumericUpDown iisPortNumericUpDown;
        private System.Windows.Forms.Button issueButton;
        private System.Windows.Forms.Button newConfigButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel actionToolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar actionToolStripProgressBar;
        private System.Windows.Forms.NumericUpDown renewalNumericUpDown;
        private System.Windows.Forms.Label renewLabel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox settingsGroupBox;
        private System.Windows.Forms.Label registeredLabel;
        private System.Windows.Forms.RadioButton iisRadioButton;
        private System.Windows.Forms.RadioButton standaloneRadioButton;
        private System.Windows.Forms.Label serverLabel;
        private System.Windows.Forms.ComboBox serviceComboBox;
        private System.Windows.Forms.Label serviceLabel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.GroupBox standaloneGroupBox;
        private System.Windows.Forms.NumericUpDown httpPortNumericUpDown;
        private System.Windows.Forms.Button checkPortButton;
        private System.Windows.Forms.Label inUseLabel;
        private System.Windows.Forms.Label challangeLabel;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
    }
}

