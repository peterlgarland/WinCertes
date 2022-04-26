
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
            this.browseOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.iisGroupBox = new System.Windows.Forms.GroupBox();
            this.iisPortNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.iisCheckBox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.sniCheckBox = new System.Windows.Forms.CheckBox();
            this.sitesListBox = new System.Windows.Forms.ListBox();
            this.webRootLabel = new System.Windows.Forms.Label();
            this.bindingsListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.domainsGroupBox = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.domainTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.removeButton = new System.Windows.Forms.Button();
            this.domainsListBox = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.psExecComboBox = new System.Windows.Forms.ComboBox();
            this.psExecCheckBox = new System.Windows.Forms.CheckBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.psScriptTextBox = new System.Windows.Forms.TextBox();
            this.psScriptCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.taskCheckBox = new System.Windows.Forms.CheckBox();
            this.renewalNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.settingsGroupBox = new System.Windows.Forms.GroupBox();
            this.registeredLabel = new System.Windows.Forms.Label();
            this.iisRadioButton = new System.Windows.Forms.RadioButton();
            this.standaloneRadioButton = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.serviceComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.issueButton = new System.Windows.Forms.Button();
            this.revokeButton = new System.Windows.Forms.Button();
            this.certButton = new System.Windows.Forms.Button();
            this.standaloneGroupBox = new System.Windows.Forms.GroupBox();
            this.httpPortNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.checkPortButton = new System.Windows.Forms.Button();
            this.inUseLabel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.configsComboBox = new System.Windows.Forms.ComboBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.newConfigButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.actionToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.actionToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.iisGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iisPortNumericUpDown)).BeginInit();
            this.domainsGroupBox.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.renewalNumericUpDown)).BeginInit();
            this.settingsGroupBox.SuspendLayout();
            this.standaloneGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.httpPortNumericUpDown)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // browseOpenFileDialog
            // 
            this.browseOpenFileDialog.FileName = "openFileDialog1";
            // 
            // iisGroupBox
            // 
            this.iisGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iisGroupBox.Controls.Add(this.iisPortNumericUpDown);
            this.iisGroupBox.Controls.Add(this.iisCheckBox);
            this.iisGroupBox.Controls.Add(this.label7);
            this.iisGroupBox.Controls.Add(this.sniCheckBox);
            this.iisGroupBox.Controls.Add(this.sitesListBox);
            this.iisGroupBox.Controls.Add(this.webRootLabel);
            this.iisGroupBox.Controls.Add(this.bindingsListBox);
            this.iisGroupBox.Controls.Add(this.label3);
            this.iisGroupBox.Controls.Add(this.label2);
            this.iisGroupBox.Location = new System.Drawing.Point(6, 248);
            this.iisGroupBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.iisGroupBox.Name = "iisGroupBox";
            this.iisGroupBox.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.iisGroupBox.Size = new System.Drawing.Size(714, 181);
            this.iisGroupBox.TabIndex = 35;
            this.iisGroupBox.TabStop = false;
            this.iisGroupBox.Text = "IIS Settings";
            // 
            // iisPortNumericUpDown
            // 
            this.iisPortNumericUpDown.Location = new System.Drawing.Point(398, 147);
            this.iisPortNumericUpDown.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.iisPortNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.iisPortNumericUpDown.Name = "iisPortNumericUpDown";
            this.iisPortNumericUpDown.Size = new System.Drawing.Size(82, 23);
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
            this.iisCheckBox.Location = new System.Drawing.Point(591, 38);
            this.iisCheckBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.iisCheckBox.Name = "iisCheckBox";
            this.iisCheckBox.Size = new System.Drawing.Size(109, 19);
            this.iisCheckBox.TabIndex = 42;
            this.iisCheckBox.Text = "Bind to IIS Site";
            this.iisCheckBox.UseVisualStyleBackColor = true;
            this.iisCheckBox.CheckedChanged += new System.EventHandler(this.iisCheckBox_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(272, 147);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 15);
            this.label7.TabIndex = 40;
            this.label7.Text = "IIS Port to bind to:";
            // 
            // sniCheckBox
            // 
            this.sniCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sniCheckBox.AutoSize = true;
            this.sniCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sniCheckBox.Location = new System.Drawing.Point(549, 148);
            this.sniCheckBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.sniCheckBox.Name = "sniCheckBox";
            this.sniCheckBox.Size = new System.Drawing.Size(158, 19);
            this.sniCheckBox.TabIndex = 39;
            this.sniCheckBox.Text = "Server Name Indication";
            this.sniCheckBox.UseVisualStyleBackColor = true;
            this.sniCheckBox.CheckedChanged += new System.EventHandler(this.sniCheckBox_CheckedChanged);
            // 
            // sitesListBox
            // 
            this.sitesListBox.FormattingEnabled = true;
            this.sitesListBox.ItemHeight = 15;
            this.sitesListBox.Location = new System.Drawing.Point(3, 38);
            this.sitesListBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.sitesListBox.Name = "sitesListBox";
            this.sitesListBox.Size = new System.Drawing.Size(262, 139);
            this.sitesListBox.TabIndex = 38;
            this.sitesListBox.SelectedIndexChanged += new System.EventHandler(this.sitesListBox_SelectedIndexChanged);
            // 
            // webRootLabel
            // 
            this.webRootLabel.Location = new System.Drawing.Point(164, 16);
            this.webRootLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.webRootLabel.Name = "webRootLabel";
            this.webRootLabel.Size = new System.Drawing.Size(522, 15);
            this.webRootLabel.TabIndex = 37;
            // 
            // bindingsListBox
            // 
            this.bindingsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bindingsListBox.FormattingEnabled = true;
            this.bindingsListBox.ItemHeight = 15;
            this.bindingsListBox.Location = new System.Drawing.Point(272, 63);
            this.bindingsListBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.bindingsListBox.Name = "bindingsListBox";
            this.bindingsListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.bindingsListBox.Size = new System.Drawing.Size(436, 79);
            this.bindingsListBox.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(3, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 15);
            this.label3.TabIndex = 35;
            this.label3.Text = "Web Root for Challange:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(272, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 15);
            this.label2.TabIndex = 34;
            this.label2.Text = "Site Bindings:";
            // 
            // domainsGroupBox
            // 
            this.domainsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.domainsGroupBox.Controls.Add(this.label4);
            this.domainsGroupBox.Controls.Add(this.addButton);
            this.domainsGroupBox.Controls.Add(this.domainTextBox);
            this.domainsGroupBox.Controls.Add(this.label5);
            this.domainsGroupBox.Controls.Add(this.removeButton);
            this.domainsGroupBox.Controls.Add(this.domainsListBox);
            this.domainsGroupBox.Location = new System.Drawing.Point(6, 432);
            this.domainsGroupBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.domainsGroupBox.Name = "domainsGroupBox";
            this.domainsGroupBox.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.domainsGroupBox.Size = new System.Drawing.Size(714, 145);
            this.domainsGroupBox.TabIndex = 37;
            this.domainsGroupBox.TabStop = false;
            this.domainsGroupBox.Text = "Domains*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(9, 16);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(207, 15);
            this.label4.TabIndex = 42;
            this.label4.Text = "Domains to Generate certifcate for:";
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.Location = new System.Drawing.Point(637, 118);
            this.addButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(70, 22);
            this.addButton.TabIndex = 41;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // domainTextBox
            // 
            this.domainTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.domainTextBox.Location = new System.Drawing.Point(104, 116);
            this.domainTextBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.domainTextBox.Name = "domainTextBox";
            this.domainTextBox.Size = new System.Drawing.Size(531, 23);
            this.domainTextBox.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 121);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 15);
            this.label5.TabIndex = 39;
            this.label5.Text = "New Domain:";
            // 
            // removeButton
            // 
            this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeButton.Enabled = false;
            this.removeButton.Location = new System.Drawing.Point(637, 33);
            this.removeButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(70, 22);
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
            this.domainsListBox.ItemHeight = 15;
            this.domainsListBox.Location = new System.Drawing.Point(9, 33);
            this.domainsListBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.domainsListBox.Name = "domainsListBox";
            this.domainsListBox.Size = new System.Drawing.Size(626, 79);
            this.domainsListBox.TabIndex = 37;
            this.domainsListBox.SelectedIndexChanged += new System.EventHandler(this.domainsListBox_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.psExecComboBox);
            this.groupBox3.Controls.Add(this.psExecCheckBox);
            this.groupBox3.Controls.Add(this.browseButton);
            this.groupBox3.Controls.Add(this.psScriptTextBox);
            this.groupBox3.Controls.Add(this.psScriptCheckBox);
            this.groupBox3.Location = new System.Drawing.Point(6, 579);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox3.Size = new System.Drawing.Size(714, 68);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "PowerShell Core Script";
            // 
            // psExecComboBox
            // 
            this.psExecComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.psExecComboBox.FormattingEnabled = true;
            this.psExecComboBox.Location = new System.Drawing.Point(207, 42);
            this.psExecComboBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.psExecComboBox.Name = "psExecComboBox";
            this.psExecComboBox.Size = new System.Drawing.Size(206, 23);
            this.psExecComboBox.TabIndex = 34;
            this.psExecComboBox.SelectedIndexChanged += new System.EventHandler(this.psExecComboBox_SelectedIndexChanged);
            // 
            // psExecCheckBox
            // 
            this.psExecCheckBox.AutoSize = true;
            this.psExecCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.psExecCheckBox.Location = new System.Drawing.Point(3, 43);
            this.psExecCheckBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.psExecCheckBox.Name = "psExecCheckBox";
            this.psExecCheckBox.Size = new System.Drawing.Size(185, 19);
            this.psExecCheckBox.TabIndex = 33;
            this.psExecCheckBox.Text = "PowerShell Execution Policy:";
            this.psExecCheckBox.UseVisualStyleBackColor = true;
            this.psExecCheckBox.CheckedChanged += new System.EventHandler(this.psExecCheckBox_CheckedChanged);
            // 
            // browseButton
            // 
            this.browseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseButton.Location = new System.Drawing.Point(637, 15);
            this.browseButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(70, 22);
            this.browseButton.TabIndex = 32;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // psScriptTextBox
            // 
            this.psScriptTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.psScriptTextBox.Location = new System.Drawing.Point(193, 17);
            this.psScriptTextBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.psScriptTextBox.Name = "psScriptTextBox";
            this.psScriptTextBox.Size = new System.Drawing.Size(443, 23);
            this.psScriptTextBox.TabIndex = 31;
            this.psScriptTextBox.TextChanged += new System.EventHandler(this.psScriptTextBox_TextChanged);
            // 
            // psScriptCheckBox
            // 
            this.psScriptCheckBox.AutoSize = true;
            this.psScriptCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.psScriptCheckBox.Location = new System.Drawing.Point(3, 18);
            this.psScriptCheckBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.psScriptCheckBox.Name = "psScriptCheckBox";
            this.psScriptCheckBox.Size = new System.Drawing.Size(176, 19);
            this.psScriptCheckBox.TabIndex = 30;
            this.psScriptCheckBox.Text = "Execute PowerShell Script:";
            this.psScriptCheckBox.UseVisualStyleBackColor = true;
            this.psScriptCheckBox.CheckedChanged += new System.EventHandler(this.psScriptCheckBox_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.taskCheckBox);
            this.groupBox4.Location = new System.Drawing.Point(421, 162);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox4.Size = new System.Drawing.Size(300, 83);
            this.groupBox4.TabIndex = 39;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Scheduled Task";
            // 
            // taskCheckBox
            // 
            this.taskCheckBox.AutoSize = true;
            this.taskCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.taskCheckBox.Location = new System.Drawing.Point(3, 18);
            this.taskCheckBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.taskCheckBox.Name = "taskCheckBox";
            this.taskCheckBox.Size = new System.Drawing.Size(249, 19);
            this.taskCheckBox.TabIndex = 35;
            this.taskCheckBox.Text = "Schedule a Task to Renew Automatically";
            this.taskCheckBox.UseVisualStyleBackColor = true;
            this.taskCheckBox.CheckedChanged += new System.EventHandler(this.taskCheckBox_CheckedChanged);
            // 
            // renewalNumericUpDown
            // 
            this.renewalNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.renewalNumericUpDown.Location = new System.Drawing.Point(627, 212);
            this.renewalNumericUpDown.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.renewalNumericUpDown.Size = new System.Drawing.Size(86, 23);
            this.renewalNumericUpDown.TabIndex = 44;
            this.renewalNumericUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.renewalNumericUpDown.ValueChanged += new System.EventHandler(this.renewalNumericUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(428, 212);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 15);
            this.label1.TabIndex = 36;
            this.label1.Text = "Renew Days before Expiration:";
            // 
            // settingsGroupBox
            // 
            this.settingsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsGroupBox.Controls.Add(this.registeredLabel);
            this.settingsGroupBox.Controls.Add(this.iisRadioButton);
            this.settingsGroupBox.Controls.Add(this.standaloneRadioButton);
            this.settingsGroupBox.Controls.Add(this.label9);
            this.settingsGroupBox.Controls.Add(this.serviceComboBox);
            this.settingsGroupBox.Controls.Add(this.label8);
            this.settingsGroupBox.Controls.Add(this.emailTextBox);
            this.settingsGroupBox.Controls.Add(this.label6);
            this.settingsGroupBox.Location = new System.Drawing.Point(6, 57);
            this.settingsGroupBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.settingsGroupBox.Name = "settingsGroupBox";
            this.settingsGroupBox.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.settingsGroupBox.Size = new System.Drawing.Size(562, 102);
            this.settingsGroupBox.TabIndex = 40;
            this.settingsGroupBox.TabStop = false;
            this.settingsGroupBox.Text = "Settings";
            // 
            // registeredLabel
            // 
            this.registeredLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.registeredLabel.AutoSize = true;
            this.registeredLabel.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.registeredLabel.Location = new System.Drawing.Point(471, 16);
            this.registeredLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.registeredLabel.Name = "registeredLabel";
            this.registeredLabel.Size = new System.Drawing.Size(76, 15);
            this.registeredLabel.TabIndex = 33;
            this.registeredLabel.Text = "REGISTERED";
            this.registeredLabel.Visible = false;
            // 
            // iisRadioButton
            // 
            this.iisRadioButton.AutoSize = true;
            this.iisRadioButton.Location = new System.Drawing.Point(234, 71);
            this.iisRadioButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.iisRadioButton.Name = "iisRadioButton";
            this.iisRadioButton.Size = new System.Drawing.Size(103, 19);
            this.iisRadioButton.TabIndex = 31;
            this.iisRadioButton.TabStop = true;
            this.iisRadioButton.Text = "Local IIS Server";
            this.iisRadioButton.UseVisualStyleBackColor = true;
            this.iisRadioButton.CheckedChanged += new System.EventHandler(this.iisRadioButton_CheckedChanged);
            // 
            // standaloneRadioButton
            // 
            this.standaloneRadioButton.AutoSize = true;
            this.standaloneRadioButton.Location = new System.Drawing.Point(62, 71);
            this.standaloneRadioButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.standaloneRadioButton.Name = "standaloneRadioButton";
            this.standaloneRadioButton.Size = new System.Drawing.Size(150, 19);
            this.standaloneRadioButton.TabIndex = 30;
            this.standaloneRadioButton.TabStop = true;
            this.standaloneRadioButton.Text = "Standalone HTTP Server";
            this.standaloneRadioButton.UseVisualStyleBackColor = true;
            this.standaloneRadioButton.CheckedChanged += new System.EventHandler(this.standaloneRadioButton_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(3, 72);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 15);
            this.label9.TabIndex = 29;
            this.label9.Text = "Server:";
            // 
            // serviceComboBox
            // 
            this.serviceComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serviceComboBox.FormattingEnabled = true;
            this.serviceComboBox.Location = new System.Drawing.Point(62, 42);
            this.serviceComboBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.serviceComboBox.Name = "serviceComboBox";
            this.serviceComboBox.Size = new System.Drawing.Size(407, 23);
            this.serviceComboBox.TabIndex = 28;
            this.serviceComboBox.TextUpdate += new System.EventHandler(this.serviceComboBox_TextUpdate);
            this.serviceComboBox.DropDownClosed += new System.EventHandler(this.serviceComboBox_DropDownClosed);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(3, 43);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 15);
            this.label8.TabIndex = 27;
            this.label8.Text = "Service:";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.emailTextBox.Location = new System.Drawing.Point(62, 15);
            this.emailTextBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(407, 23);
            this.emailTextBox.TabIndex = 26;
            this.emailTextBox.TextChanged += new System.EventHandler(this.emailTextBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(3, 16);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 15);
            this.label6.TabIndex = 25;
            this.label6.Text = "e-mail*:";
            // 
            // issueButton
            // 
            this.issueButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.issueButton.Enabled = false;
            this.issueButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.issueButton.Location = new System.Drawing.Point(580, 129);
            this.issueButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.issueButton.Name = "issueButton";
            this.issueButton.Size = new System.Drawing.Size(138, 22);
            this.issueButton.TabIndex = 35;
            this.issueButton.Text = "Issue Certificate";
            this.issueButton.UseVisualStyleBackColor = true;
            this.issueButton.Click += new System.EventHandler(this.issueButton_Click);
            // 
            // revokeButton
            // 
            this.revokeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.revokeButton.Location = new System.Drawing.Point(580, 97);
            this.revokeButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.revokeButton.Name = "revokeButton";
            this.revokeButton.Size = new System.Drawing.Size(138, 22);
            this.revokeButton.TabIndex = 34;
            this.revokeButton.Text = "Revoke Certificate";
            this.revokeButton.UseVisualStyleBackColor = true;
            this.revokeButton.Visible = false;
            this.revokeButton.Click += new System.EventHandler(this.revokeButton_ClickAsync);
            // 
            // certButton
            // 
            this.certButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.certButton.Location = new System.Drawing.Point(580, 67);
            this.certButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.certButton.Name = "certButton";
            this.certButton.Size = new System.Drawing.Size(138, 22);
            this.certButton.TabIndex = 32;
            this.certButton.Text = "Show Certificate";
            this.certButton.UseVisualStyleBackColor = true;
            this.certButton.Visible = false;
            this.certButton.Click += new System.EventHandler(this.certButton_Click);
            // 
            // standaloneGroupBox
            // 
            this.standaloneGroupBox.Controls.Add(this.httpPortNumericUpDown);
            this.standaloneGroupBox.Controls.Add(this.checkPortButton);
            this.standaloneGroupBox.Controls.Add(this.inUseLabel);
            this.standaloneGroupBox.Controls.Add(this.label12);
            this.standaloneGroupBox.Controls.Add(this.label11);
            this.standaloneGroupBox.Location = new System.Drawing.Point(6, 162);
            this.standaloneGroupBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.standaloneGroupBox.Name = "standaloneGroupBox";
            this.standaloneGroupBox.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.standaloneGroupBox.Size = new System.Drawing.Size(411, 83);
            this.standaloneGroupBox.TabIndex = 41;
            this.standaloneGroupBox.TabStop = false;
            this.standaloneGroupBox.Text = "Standalone HTTP Server Settings";
            // 
            // httpPortNumericUpDown
            // 
            this.httpPortNumericUpDown.Location = new System.Drawing.Point(87, 18);
            this.httpPortNumericUpDown.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.httpPortNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.httpPortNumericUpDown.Name = "httpPortNumericUpDown";
            this.httpPortNumericUpDown.Size = new System.Drawing.Size(82, 23);
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
            this.checkPortButton.Location = new System.Drawing.Point(306, 15);
            this.checkPortButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.checkPortButton.Name = "checkPortButton";
            this.checkPortButton.Size = new System.Drawing.Size(102, 22);
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
            this.inUseLabel.Location = new System.Drawing.Point(178, 19);
            this.inUseLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.inUseLabel.Name = "inUseLabel";
            this.inUseLabel.Size = new System.Drawing.Size(80, 15);
            this.inUseLabel.TabIndex = 3;
            this.inUseLabel.Text = "PORT IN USE";
            this.inUseLabel.Visible = false;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(3, 44);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(392, 30);
            this.label12.TabIndex = 2;
            this.label12.Text = "All Challenges are processed on Port 80, if you use a different port above you mu" +
    "st set Port Forwarding on your Router accordingly.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(3, 19);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 15);
            this.label11.TabIndex = 0;
            this.label11.Text = "Server Port:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(10, 25);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 15);
            this.label10.TabIndex = 42;
            this.label10.Text = "Configuration:";
            // 
            // configsComboBox
            // 
            this.configsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.configsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.configsComboBox.FormattingEnabled = true;
            this.configsComboBox.Location = new System.Drawing.Point(111, 25);
            this.configsComboBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.configsComboBox.Name = "configsComboBox";
            this.configsComboBox.Size = new System.Drawing.Size(246, 23);
            this.configsComboBox.TabIndex = 43;
            this.configsComboBox.SelectedIndexChanged += new System.EventHandler(this.configsComboBox_SelectedIndexChanged);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.Location = new System.Drawing.Point(358, 23);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(81, 22);
            this.deleteButton.TabIndex = 44;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // newConfigButton
            // 
            this.newConfigButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newConfigButton.Location = new System.Drawing.Point(580, 22);
            this.newConfigButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.newConfigButton.Name = "newConfigButton";
            this.newConfigButton.Size = new System.Drawing.Size(138, 22);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 654);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 8, 0);
            this.statusStrip1.Size = new System.Drawing.Size(734, 22);
            this.statusStrip1.TabIndex = 46;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // actionToolStripStatusLabel
            // 
            this.actionToolStripStatusLabel.Name = "actionToolStripStatusLabel";
            this.actionToolStripStatusLabel.Size = new System.Drawing.Size(725, 17);
            this.actionToolStripStatusLabel.Spring = true;
            this.actionToolStripStatusLabel.Text = "WinCertes";
            this.actionToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // actionToolStripProgressBar
            // 
            this.actionToolStripProgressBar.AutoSize = false;
            this.actionToolStripProgressBar.Name = "actionToolStripProgressBar";
            this.actionToolStripProgressBar.Size = new System.Drawing.Size(162, 16);
            this.actionToolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.actionToolStripProgressBar.Visible = false;
            // 
            // WinCertesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 676);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.renewalNumericUpDown);
            this.Controls.Add(this.issueButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newConfigButton);
            this.Controls.Add(this.revokeButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.configsComboBox);
            this.Controls.Add(this.certButton);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.iisGroupBox);
            this.Controls.Add(this.standaloneGroupBox);
            this.Controls.Add(this.settingsGroupBox);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.domainsGroupBox);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.MinimumSize = new System.Drawing.Size(750, 507);
            this.Name = "WinCertesForm";
            this.Text = "WinCertes";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.WinCertesForm_HelpButtonClicked);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.WinCertesForm_HelpRequested);
            this.iisGroupBox.ResumeLayout(false);
            this.iisGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iisPortNumericUpDown)).EndInit();
            this.domainsGroupBox.ResumeLayout(false);
            this.domainsGroupBox.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.renewalNumericUpDown)).EndInit();
            this.settingsGroupBox.ResumeLayout(false);
            this.settingsGroupBox.PerformLayout();
            this.standaloneGroupBox.ResumeLayout(false);
            this.standaloneGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.httpPortNumericUpDown)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog browseOpenFileDialog;
        private System.Windows.Forms.GroupBox iisGroupBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox sniCheckBox;
        private System.Windows.Forms.ListBox sitesListBox;
        private System.Windows.Forms.Label webRootLabel;
        private System.Windows.Forms.ListBox bindingsListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox domainsGroupBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox domainTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.ListBox domainsListBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox psExecComboBox;
        private System.Windows.Forms.CheckBox psExecCheckBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox psScriptTextBox;
        private System.Windows.Forms.CheckBox psScriptCheckBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox taskCheckBox;
        private System.Windows.Forms.GroupBox settingsGroupBox;
        private System.Windows.Forms.ComboBox serviceComboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox standaloneGroupBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton iisRadioButton;
        private System.Windows.Forms.RadioButton standaloneRadioButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox iisCheckBox;
        private System.Windows.Forms.Button certButton;
        private System.Windows.Forms.Label registeredLabel;
        private System.Windows.Forms.Button revokeButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox configsComboBox;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Label inUseLabel;
        private System.Windows.Forms.Button checkPortButton;
        private System.Windows.Forms.NumericUpDown iisPortNumericUpDown;
        private System.Windows.Forms.NumericUpDown renewalNumericUpDown;
        private System.Windows.Forms.NumericUpDown httpPortNumericUpDown;
        private System.Windows.Forms.Button issueButton;
        private System.Windows.Forms.Button newConfigButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel actionToolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar actionToolStripProgressBar;
    }
}

