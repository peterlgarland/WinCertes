
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
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPage1 = new System.Windows.Forms.TabPage();
            standaloneGroupBox = new System.Windows.Forms.GroupBox();
            httpPortNumericUpDown = new System.Windows.Forms.NumericUpDown();
            checkPortButton = new System.Windows.Forms.Button();
            inUseLabel = new System.Windows.Forms.Label();
            challangeLabel = new System.Windows.Forms.Label();
            portLabel = new System.Windows.Forms.Label();
            settingsGroupBox = new System.Windows.Forms.GroupBox();
            registeredLabel = new System.Windows.Forms.Label();
            iisRadioButton = new System.Windows.Forms.RadioButton();
            standaloneRadioButton = new System.Windows.Forms.RadioButton();
            serverLabel = new System.Windows.Forms.Label();
            serviceComboBox = new System.Windows.Forms.ComboBox();
            serviceLabel = new System.Windows.Forms.Label();
            emailTextBox = new System.Windows.Forms.TextBox();
            emailLabel = new System.Windows.Forms.Label();
            tabPage2 = new System.Windows.Forms.TabPage();
            iisGroupBox = new System.Windows.Forms.GroupBox();
            iisPortNumericUpDown = new System.Windows.Forms.NumericUpDown();
            iisCheckBox = new System.Windows.Forms.CheckBox();
            iisPortLabel = new System.Windows.Forms.Label();
            sniCheckBox = new System.Windows.Forms.CheckBox();
            sitesListBox = new System.Windows.Forms.ListBox();
            webRootLabel = new System.Windows.Forms.Label();
            bindingsListBox = new System.Windows.Forms.ListBox();
            webChallengeLabel = new System.Windows.Forms.Label();
            siteBindingsLabel = new System.Windows.Forms.Label();
            tabPage3 = new System.Windows.Forms.TabPage();
            domainsGroupBox = new System.Windows.Forms.GroupBox();
            domainsLabel = new System.Windows.Forms.Label();
            addButton = new System.Windows.Forms.Button();
            domainTextBox = new System.Windows.Forms.TextBox();
            newDomainlabel = new System.Windows.Forms.Label();
            removeButton = new System.Windows.Forms.Button();
            domainsListBox = new System.Windows.Forms.ListBox();
            tabPage4 = new System.Windows.Forms.TabPage();
            taskGroupBox = new System.Windows.Forms.GroupBox();
            renewalNumericUpDown = new System.Windows.Forms.NumericUpDown();
            renewLabel = new System.Windows.Forms.Label();
            taskCheckBox = new System.Windows.Forms.CheckBox();
            psGroupBox = new System.Windows.Forms.GroupBox();
            psExecComboBox = new System.Windows.Forms.ComboBox();
            psExecCheckBox = new System.Windows.Forms.CheckBox();
            browseButton = new System.Windows.Forms.Button();
            psScriptTextBox = new System.Windows.Forms.TextBox();
            psScriptCheckBox = new System.Windows.Forms.CheckBox();
            tabPage5 = new System.Windows.Forms.TabPage();
            helpTextBox = new System.Windows.Forms.TextBox();
            browseOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            issueButton = new System.Windows.Forms.Button();
            revokeButton = new System.Windows.Forms.Button();
            certButton = new System.Windows.Forms.Button();
            configLabel = new System.Windows.Forms.Label();
            configsComboBox = new System.Windows.Forms.ComboBox();
            deleteButton = new System.Windows.Forms.Button();
            newConfigButton = new System.Windows.Forms.Button();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            actionToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            actionToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            standaloneGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)httpPortNumericUpDown).BeginInit();
            settingsGroupBox.SuspendLayout();
            tabPage2.SuspendLayout();
            iisGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iisPortNumericUpDown).BeginInit();
            tabPage3.SuspendLayout();
            domainsGroupBox.SuspendLayout();
            tabPage4.SuspendLayout();
            taskGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)renewalNumericUpDown).BeginInit();
            psGroupBox.SuspendLayout();
            tabPage5.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tabControl1.ImeMode = System.Windows.Forms.ImeMode.Off;
            tabControl1.Location = new System.Drawing.Point(6, 30);
            tabControl1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            tabControl1.Name = "tabControl1";
            tabControl1.Padding = new System.Drawing.Point(24, 12);
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(538, 249);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(standaloneGroupBox);
            tabPage1.Controls.Add(settingsGroupBox);
            tabPage1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tabPage1.Location = new System.Drawing.Point(4, 42);
            tabPage1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            tabPage1.Size = new System.Drawing.Size(530, 203);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Settings";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // standaloneGroupBox
            // 
            standaloneGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            standaloneGroupBox.Controls.Add(httpPortNumericUpDown);
            standaloneGroupBox.Controls.Add(checkPortButton);
            standaloneGroupBox.Controls.Add(inUseLabel);
            standaloneGroupBox.Controls.Add(challangeLabel);
            standaloneGroupBox.Controls.Add(portLabel);
            standaloneGroupBox.Location = new System.Drawing.Point(4, 114);
            standaloneGroupBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            standaloneGroupBox.Name = "standaloneGroupBox";
            standaloneGroupBox.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            standaloneGroupBox.Size = new System.Drawing.Size(522, 87);
            standaloneGroupBox.TabIndex = 42;
            standaloneGroupBox.TabStop = false;
            standaloneGroupBox.Text = "Standalone HTTP Server Settings";
            // 
            // httpPortNumericUpDown
            // 
            httpPortNumericUpDown.Location = new System.Drawing.Point(139, 17);
            httpPortNumericUpDown.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            httpPortNumericUpDown.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            httpPortNumericUpDown.Name = "httpPortNumericUpDown";
            httpPortNumericUpDown.Size = new System.Drawing.Size(82, 23);
            httpPortNumericUpDown.TabIndex = 5;
            httpPortNumericUpDown.Value = new decimal(new int[] { 80, 0, 0, 0 });
            httpPortNumericUpDown.ValueChanged += httpPortNumericUpDown_ValueChanged;
            // 
            // checkPortButton
            // 
            checkPortButton.Location = new System.Drawing.Point(561, 12);
            checkPortButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            checkPortButton.Name = "checkPortButton";
            checkPortButton.Size = new System.Drawing.Size(102, 22);
            checkPortButton.TabIndex = 4;
            checkPortButton.Text = "Check Port";
            checkPortButton.UseVisualStyleBackColor = true;
            checkPortButton.Visible = false;
            checkPortButton.Click += checkPortButton_Click;
            // 
            // inUseLabel
            // 
            inUseLabel.AutoSize = true;
            inUseLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            inUseLabel.ForeColor = System.Drawing.Color.Red;
            inUseLabel.Location = new System.Drawing.Point(256, 19);
            inUseLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            inUseLabel.Name = "inUseLabel";
            inUseLabel.Size = new System.Drawing.Size(80, 15);
            inUseLabel.TabIndex = 3;
            inUseLabel.Text = "PORT IN USE";
            inUseLabel.Visible = false;
            // 
            // challangeLabel
            // 
            challangeLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            challangeLabel.Location = new System.Drawing.Point(3, 44);
            challangeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            challangeLabel.Name = "challangeLabel";
            challangeLabel.Size = new System.Drawing.Size(515, 34);
            challangeLabel.TabIndex = 2;
            challangeLabel.Text = "All Challenges are processed on Port 80, if you use a different port above you must set Port Forwarding on your Router accordingly.";
            // 
            // portLabel
            // 
            portLabel.AutoSize = true;
            portLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            portLabel.Location = new System.Drawing.Point(4, 19);
            portLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            portLabel.Name = "portLabel";
            portLabel.Size = new System.Drawing.Size(75, 15);
            portLabel.TabIndex = 0;
            portLabel.Text = "Server Port:";
            // 
            // settingsGroupBox
            // 
            settingsGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            settingsGroupBox.Controls.Add(registeredLabel);
            settingsGroupBox.Controls.Add(iisRadioButton);
            settingsGroupBox.Controls.Add(standaloneRadioButton);
            settingsGroupBox.Controls.Add(serverLabel);
            settingsGroupBox.Controls.Add(serviceComboBox);
            settingsGroupBox.Controls.Add(serviceLabel);
            settingsGroupBox.Controls.Add(emailTextBox);
            settingsGroupBox.Controls.Add(emailLabel);
            settingsGroupBox.Location = new System.Drawing.Point(4, 2);
            settingsGroupBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            settingsGroupBox.Name = "settingsGroupBox";
            settingsGroupBox.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            settingsGroupBox.Size = new System.Drawing.Size(522, 110);
            settingsGroupBox.TabIndex = 41;
            settingsGroupBox.TabStop = false;
            settingsGroupBox.Text = "Settings";
            // 
            // registeredLabel
            // 
            registeredLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            registeredLabel.AutoSize = true;
            registeredLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            registeredLabel.Location = new System.Drawing.Point(885, 15);
            registeredLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            registeredLabel.Name = "registeredLabel";
            registeredLabel.Size = new System.Drawing.Size(76, 15);
            registeredLabel.TabIndex = 33;
            registeredLabel.Text = "REGISTERED";
            registeredLabel.Visible = false;
            // 
            // iisRadioButton
            // 
            iisRadioButton.AutoSize = true;
            iisRadioButton.Location = new System.Drawing.Point(331, 74);
            iisRadioButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            iisRadioButton.Name = "iisRadioButton";
            iisRadioButton.Size = new System.Drawing.Size(103, 19);
            iisRadioButton.TabIndex = 31;
            iisRadioButton.TabStop = true;
            iisRadioButton.Text = "Local IIS Server";
            iisRadioButton.UseVisualStyleBackColor = true;
            iisRadioButton.CheckedChanged += iisRadioButton_CheckedChanged;
            // 
            // standaloneRadioButton
            // 
            standaloneRadioButton.AutoSize = true;
            standaloneRadioButton.Location = new System.Drawing.Point(81, 74);
            standaloneRadioButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            standaloneRadioButton.Name = "standaloneRadioButton";
            standaloneRadioButton.Size = new System.Drawing.Size(150, 19);
            standaloneRadioButton.TabIndex = 30;
            standaloneRadioButton.TabStop = true;
            standaloneRadioButton.Text = "Standalone HTTP Server";
            standaloneRadioButton.UseVisualStyleBackColor = true;
            standaloneRadioButton.CheckedChanged += standaloneRadioButton_CheckedChanged;
            // 
            // serverLabel
            // 
            serverLabel.AutoSize = true;
            serverLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            serverLabel.Location = new System.Drawing.Point(3, 76);
            serverLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            serverLabel.Name = "serverLabel";
            serverLabel.Size = new System.Drawing.Size(48, 15);
            serverLabel.TabIndex = 29;
            serverLabel.Text = "Server:";
            // 
            // serviceComboBox
            // 
            serviceComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            serviceComboBox.FormattingEnabled = true;
            serviceComboBox.Location = new System.Drawing.Point(82, 41);
            serviceComboBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            serviceComboBox.Name = "serviceComboBox";
            serviceComboBox.Size = new System.Drawing.Size(438, 23);
            serviceComboBox.TabIndex = 28;
            // 
            // serviceLabel
            // 
            serviceLabel.AutoSize = true;
            serviceLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            serviceLabel.Location = new System.Drawing.Point(4, 44);
            serviceLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            serviceLabel.Name = "serviceLabel";
            serviceLabel.Size = new System.Drawing.Size(52, 15);
            serviceLabel.TabIndex = 27;
            serviceLabel.Text = "Service:";
            // 
            // emailTextBox
            // 
            emailTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            emailTextBox.Location = new System.Drawing.Point(82, 15);
            emailTextBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new System.Drawing.Size(438, 23);
            emailTextBox.TabIndex = 26;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            emailLabel.Location = new System.Drawing.Point(4, 18);
            emailLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(50, 15);
            emailLabel.TabIndex = 25;
            emailLabel.Text = "e-mail*:";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(iisGroupBox);
            tabPage2.Location = new System.Drawing.Point(4, 42);
            tabPage2.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            tabPage2.Size = new System.Drawing.Size(530, 203);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "IIS Settings";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // iisGroupBox
            // 
            iisGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            iisGroupBox.Controls.Add(iisPortNumericUpDown);
            iisGroupBox.Controls.Add(iisCheckBox);
            iisGroupBox.Controls.Add(iisPortLabel);
            iisGroupBox.Controls.Add(sniCheckBox);
            iisGroupBox.Controls.Add(sitesListBox);
            iisGroupBox.Controls.Add(webRootLabel);
            iisGroupBox.Controls.Add(bindingsListBox);
            iisGroupBox.Controls.Add(webChallengeLabel);
            iisGroupBox.Controls.Add(siteBindingsLabel);
            iisGroupBox.Location = new System.Drawing.Point(4, 2);
            iisGroupBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            iisGroupBox.Name = "iisGroupBox";
            iisGroupBox.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            iisGroupBox.Size = new System.Drawing.Size(517, 211);
            iisGroupBox.TabIndex = 35;
            iisGroupBox.TabStop = false;
            iisGroupBox.Text = "IIS Settings";
            // 
            // iisPortNumericUpDown
            // 
            iisPortNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            iisPortNumericUpDown.Location = new System.Drawing.Point(452, 169);
            iisPortNumericUpDown.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            iisPortNumericUpDown.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            iisPortNumericUpDown.Name = "iisPortNumericUpDown";
            iisPortNumericUpDown.Size = new System.Drawing.Size(58, 23);
            iisPortNumericUpDown.TabIndex = 43;
            iisPortNumericUpDown.Value = new decimal(new int[] { 443, 0, 0, 0 });
            iisPortNumericUpDown.ValueChanged += iisPortNumericUpDown_ValueChanged;
            // 
            // iisCheckBox
            // 
            iisCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            iisCheckBox.AutoSize = true;
            iisCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            iisCheckBox.Location = new System.Drawing.Point(403, 34);
            iisCheckBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            iisCheckBox.Name = "iisCheckBox";
            iisCheckBox.Size = new System.Drawing.Size(109, 19);
            iisCheckBox.TabIndex = 42;
            iisCheckBox.Text = "Bind to IIS Site";
            iisCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            iisCheckBox.UseVisualStyleBackColor = true;
            iisCheckBox.CheckedChanged += iisCheckBox_CheckedChanged;
            // 
            // iisPortLabel
            // 
            iisPortLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            iisPortLabel.AutoSize = true;
            iisPortLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            iisPortLabel.Location = new System.Drawing.Point(261, 171);
            iisPortLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            iisPortLabel.Name = "iisPortLabel";
            iisPortLabel.Size = new System.Drawing.Size(109, 15);
            iisPortLabel.TabIndex = 40;
            iisPortLabel.Text = "IIS Port to bind to:";
            // 
            // sniCheckBox
            // 
            sniCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            sniCheckBox.AutoSize = true;
            sniCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            sniCheckBox.Location = new System.Drawing.Point(261, 144);
            sniCheckBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            sniCheckBox.Name = "sniCheckBox";
            sniCheckBox.Size = new System.Drawing.Size(158, 19);
            sniCheckBox.TabIndex = 39;
            sniCheckBox.Text = "Server Name Indication";
            sniCheckBox.UseVisualStyleBackColor = true;
            sniCheckBox.CheckedChanged += sniCheckBox_CheckedChanged;
            // 
            // sitesListBox
            // 
            sitesListBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            sitesListBox.FormattingEnabled = true;
            sitesListBox.ItemHeight = 15;
            sitesListBox.Location = new System.Drawing.Point(3, 38);
            sitesListBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            sitesListBox.Name = "sitesListBox";
            sitesListBox.Size = new System.Drawing.Size(255, 154);
            sitesListBox.TabIndex = 38;
            sitesListBox.SelectedIndexChanged += sitesListBox_SelectedIndexChanged;
            // 
            // webRootLabel
            // 
            webRootLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            webRootLabel.Location = new System.Drawing.Point(164, 16);
            webRootLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            webRootLabel.Name = "webRootLabel";
            webRootLabel.Size = new System.Drawing.Size(346, 15);
            webRootLabel.TabIndex = 37;
            // 
            // bindingsListBox
            // 
            bindingsListBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            bindingsListBox.FormattingEnabled = true;
            bindingsListBox.ItemHeight = 15;
            bindingsListBox.Location = new System.Drawing.Point(261, 63);
            bindingsListBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            bindingsListBox.Name = "bindingsListBox";
            bindingsListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            bindingsListBox.Size = new System.Drawing.Size(251, 79);
            bindingsListBox.TabIndex = 36;
            // 
            // webChallengeLabel
            // 
            webChallengeLabel.AutoSize = true;
            webChallengeLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            webChallengeLabel.Location = new System.Drawing.Point(3, 16);
            webChallengeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            webChallengeLabel.Name = "webChallengeLabel";
            webChallengeLabel.Size = new System.Drawing.Size(142, 15);
            webChallengeLabel.TabIndex = 35;
            webChallengeLabel.Text = "Web Root for Challange:";
            // 
            // siteBindingsLabel
            // 
            siteBindingsLabel.AutoSize = true;
            siteBindingsLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            siteBindingsLabel.Location = new System.Drawing.Point(261, 38);
            siteBindingsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            siteBindingsLabel.Name = "siteBindingsLabel";
            siteBindingsLabel.Size = new System.Drawing.Size(78, 15);
            siteBindingsLabel.TabIndex = 34;
            siteBindingsLabel.Text = "Site Bindings:";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(domainsGroupBox);
            tabPage3.Location = new System.Drawing.Point(4, 42);
            tabPage3.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            tabPage3.Size = new System.Drawing.Size(530, 203);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Domains";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // domainsGroupBox
            // 
            domainsGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            domainsGroupBox.Controls.Add(domainsLabel);
            domainsGroupBox.Controls.Add(addButton);
            domainsGroupBox.Controls.Add(domainTextBox);
            domainsGroupBox.Controls.Add(newDomainlabel);
            domainsGroupBox.Controls.Add(removeButton);
            domainsGroupBox.Controls.Add(domainsListBox);
            domainsGroupBox.Location = new System.Drawing.Point(4, 2);
            domainsGroupBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            domainsGroupBox.Name = "domainsGroupBox";
            domainsGroupBox.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            domainsGroupBox.Size = new System.Drawing.Size(522, 211);
            domainsGroupBox.TabIndex = 37;
            domainsGroupBox.TabStop = false;
            domainsGroupBox.Text = "Domains*";
            // 
            // domainsLabel
            // 
            domainsLabel.AutoSize = true;
            domainsLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            domainsLabel.Location = new System.Drawing.Point(9, 17);
            domainsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            domainsLabel.Name = "domainsLabel";
            domainsLabel.Size = new System.Drawing.Size(207, 15);
            domainsLabel.TabIndex = 42;
            domainsLabel.Text = "Domains to Generate certifcate for:";
            // 
            // addButton
            // 
            addButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            addButton.Location = new System.Drawing.Point(445, 174);
            addButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            addButton.Name = "addButton";
            addButton.Size = new System.Drawing.Size(70, 22);
            addButton.TabIndex = 41;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // domainTextBox
            // 
            domainTextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            domainTextBox.Location = new System.Drawing.Point(165, 173);
            domainTextBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            domainTextBox.Name = "domainTextBox";
            domainTextBox.Size = new System.Drawing.Size(278, 23);
            domainTextBox.TabIndex = 40;
            // 
            // newDomainlabel
            // 
            newDomainlabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            newDomainlabel.AutoSize = true;
            newDomainlabel.Location = new System.Drawing.Point(9, 176);
            newDomainlabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            newDomainlabel.Name = "newDomainlabel";
            newDomainlabel.Size = new System.Drawing.Size(79, 15);
            newDomainlabel.TabIndex = 39;
            newDomainlabel.Text = "New Domain:";
            // 
            // removeButton
            // 
            removeButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            removeButton.Enabled = false;
            removeButton.Location = new System.Drawing.Point(445, 33);
            removeButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            removeButton.Name = "removeButton";
            removeButton.Size = new System.Drawing.Size(70, 22);
            removeButton.TabIndex = 38;
            removeButton.Text = "Remove";
            removeButton.UseVisualStyleBackColor = true;
            removeButton.Click += removeButton_Click;
            // 
            // domainsListBox
            // 
            domainsListBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            domainsListBox.FormattingEnabled = true;
            domainsListBox.ItemHeight = 15;
            domainsListBox.Location = new System.Drawing.Point(9, 33);
            domainsListBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            domainsListBox.Name = "domainsListBox";
            domainsListBox.Size = new System.Drawing.Size(434, 139);
            domainsListBox.TabIndex = 37;
            domainsListBox.SelectedIndexChanged += domainsListBox_SelectedIndexChanged;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(taskGroupBox);
            tabPage4.Controls.Add(psGroupBox);
            tabPage4.Location = new System.Drawing.Point(4, 42);
            tabPage4.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            tabPage4.Size = new System.Drawing.Size(530, 203);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Extra";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // taskGroupBox
            // 
            taskGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            taskGroupBox.Controls.Add(renewalNumericUpDown);
            taskGroupBox.Controls.Add(renewLabel);
            taskGroupBox.Controls.Add(taskCheckBox);
            taskGroupBox.Location = new System.Drawing.Point(4, 2);
            taskGroupBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            taskGroupBox.Name = "taskGroupBox";
            taskGroupBox.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            taskGroupBox.Size = new System.Drawing.Size(522, 83);
            taskGroupBox.TabIndex = 39;
            taskGroupBox.TabStop = false;
            taskGroupBox.Text = "Scheduled Task";
            // 
            // renewalNumericUpDown
            // 
            renewalNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            renewalNumericUpDown.Location = new System.Drawing.Point(432, 46);
            renewalNumericUpDown.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            renewalNumericUpDown.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            renewalNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            renewalNumericUpDown.Name = "renewalNumericUpDown";
            renewalNumericUpDown.Size = new System.Drawing.Size(86, 23);
            renewalNumericUpDown.TabIndex = 46;
            renewalNumericUpDown.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // renewLabel
            // 
            renewLabel.AutoSize = true;
            renewLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            renewLabel.Location = new System.Drawing.Point(4, 48);
            renewLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            renewLabel.Name = "renewLabel";
            renewLabel.Size = new System.Drawing.Size(178, 15);
            renewLabel.TabIndex = 45;
            renewLabel.Text = "Renew Days before Expiration:";
            // 
            // taskCheckBox
            // 
            taskCheckBox.AutoSize = true;
            taskCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            taskCheckBox.Location = new System.Drawing.Point(4, 18);
            taskCheckBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            taskCheckBox.Name = "taskCheckBox";
            taskCheckBox.Size = new System.Drawing.Size(249, 19);
            taskCheckBox.TabIndex = 35;
            taskCheckBox.Text = "Schedule a Task to Renew Automatically";
            taskCheckBox.UseVisualStyleBackColor = true;
            taskCheckBox.CheckedChanged += taskCheckBox_CheckedChanged;
            // 
            // psGroupBox
            // 
            psGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            psGroupBox.Controls.Add(psExecComboBox);
            psGroupBox.Controls.Add(psExecCheckBox);
            psGroupBox.Controls.Add(browseButton);
            psGroupBox.Controls.Add(psScriptTextBox);
            psGroupBox.Controls.Add(psScriptCheckBox);
            psGroupBox.Location = new System.Drawing.Point(4, 87);
            psGroupBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            psGroupBox.Name = "psGroupBox";
            psGroupBox.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            psGroupBox.Size = new System.Drawing.Size(522, 74);
            psGroupBox.TabIndex = 38;
            psGroupBox.TabStop = false;
            psGroupBox.Text = "PowerShell Core Script";
            // 
            // psExecComboBox
            // 
            psExecComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            psExecComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            psExecComboBox.FormattingEnabled = true;
            psExecComboBox.Location = new System.Drawing.Point(312, 43);
            psExecComboBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            psExecComboBox.Name = "psExecComboBox";
            psExecComboBox.Size = new System.Drawing.Size(206, 23);
            psExecComboBox.TabIndex = 34;
            psExecComboBox.SelectedIndexChanged += psExecComboBox_SelectedIndexChanged;
            // 
            // psExecCheckBox
            // 
            psExecCheckBox.AutoSize = true;
            psExecCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            psExecCheckBox.Location = new System.Drawing.Point(4, 47);
            psExecCheckBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            psExecCheckBox.Name = "psExecCheckBox";
            psExecCheckBox.Size = new System.Drawing.Size(185, 19);
            psExecCheckBox.TabIndex = 33;
            psExecCheckBox.Text = "PowerShell Execution Policy:";
            psExecCheckBox.UseVisualStyleBackColor = true;
            psExecCheckBox.CheckedChanged += psExecCheckBox_CheckedChanged;
            // 
            // browseButton
            // 
            browseButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            browseButton.Location = new System.Drawing.Point(439, 16);
            browseButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            browseButton.Name = "browseButton";
            browseButton.Size = new System.Drawing.Size(83, 22);
            browseButton.TabIndex = 32;
            browseButton.Text = "Browse";
            browseButton.UseVisualStyleBackColor = true;
            browseButton.Click += browseButton_Click;
            // 
            // psScriptTextBox
            // 
            psScriptTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            psScriptTextBox.Location = new System.Drawing.Point(239, 17);
            psScriptTextBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            psScriptTextBox.Name = "psScriptTextBox";
            psScriptTextBox.Size = new System.Drawing.Size(191, 23);
            psScriptTextBox.TabIndex = 31;
            psScriptTextBox.TextChanged += psScriptTextBox_TextChanged;
            // 
            // psScriptCheckBox
            // 
            psScriptCheckBox.AutoSize = true;
            psScriptCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            psScriptCheckBox.Location = new System.Drawing.Point(4, 21);
            psScriptCheckBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            psScriptCheckBox.Name = "psScriptCheckBox";
            psScriptCheckBox.Size = new System.Drawing.Size(176, 19);
            psScriptCheckBox.TabIndex = 30;
            psScriptCheckBox.Text = "Execute PowerShell Script:";
            psScriptCheckBox.UseVisualStyleBackColor = true;
            psScriptCheckBox.CheckedChanged += psScriptCheckBox_CheckedChanged;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(helpTextBox);
            tabPage5.Location = new System.Drawing.Point(4, 42);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new System.Windows.Forms.Padding(3);
            tabPage5.Size = new System.Drawing.Size(530, 203);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Help";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // helpTextBox
            // 
            helpTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            helpTextBox.Location = new System.Drawing.Point(6, 6);
            helpTextBox.Multiline = true;
            helpTextBox.Name = "helpTextBox";
            helpTextBox.ReadOnly = true;
            helpTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            helpTextBox.Size = new System.Drawing.Size(518, 191);
            helpTextBox.TabIndex = 0;
            // 
            // browseOpenFileDialog
            // 
            browseOpenFileDialog.FileName = "openFileDialog1";
            // 
            // issueButton
            // 
            issueButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            issueButton.Enabled = false;
            issueButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            issueButton.Location = new System.Drawing.Point(11, 281);
            issueButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            issueButton.Name = "issueButton";
            issueButton.Size = new System.Drawing.Size(138, 22);
            issueButton.TabIndex = 35;
            issueButton.Text = "Issue Certificate";
            issueButton.UseVisualStyleBackColor = true;
            issueButton.Click += issueButton_Click;
            // 
            // revokeButton
            // 
            revokeButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            revokeButton.Location = new System.Drawing.Point(406, 281);
            revokeButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            revokeButton.Name = "revokeButton";
            revokeButton.Size = new System.Drawing.Size(138, 22);
            revokeButton.TabIndex = 34;
            revokeButton.Text = "Revoke Certificate";
            revokeButton.UseVisualStyleBackColor = true;
            revokeButton.Visible = false;
            revokeButton.Click += revokeButton_ClickAsync;
            // 
            // certButton
            // 
            certButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            certButton.Location = new System.Drawing.Point(264, 281);
            certButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            certButton.Name = "certButton";
            certButton.Size = new System.Drawing.Size(138, 22);
            certButton.TabIndex = 32;
            certButton.Text = "Show Certificate";
            certButton.UseVisualStyleBackColor = true;
            certButton.Visible = false;
            certButton.Click += certButton_Click;
            // 
            // configLabel
            // 
            configLabel.AutoSize = true;
            configLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            configLabel.Location = new System.Drawing.Point(9, 8);
            configLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            configLabel.Name = "configLabel";
            configLabel.Size = new System.Drawing.Size(86, 15);
            configLabel.TabIndex = 42;
            configLabel.Text = "Configuration:";
            // 
            // configsComboBox
            // 
            configsComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            configsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            configsComboBox.FormattingEnabled = true;
            configsComboBox.Location = new System.Drawing.Point(131, 7);
            configsComboBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            configsComboBox.Name = "configsComboBox";
            configsComboBox.Size = new System.Drawing.Size(155, 23);
            configsComboBox.TabIndex = 43;
            configsComboBox.SelectedIndexChanged += configsComboBox_SelectedIndexChanged;
            // 
            // deleteButton
            // 
            deleteButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            deleteButton.Location = new System.Drawing.Point(288, 5);
            deleteButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new System.Drawing.Size(81, 22);
            deleteButton.TabIndex = 44;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // newConfigButton
            // 
            newConfigButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            newConfigButton.Location = new System.Drawing.Point(374, 5);
            newConfigButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            newConfigButton.Name = "newConfigButton";
            newConfigButton.Size = new System.Drawing.Size(170, 22);
            newConfigButton.TabIndex = 45;
            newConfigButton.Text = "New Configuration";
            newConfigButton.UseVisualStyleBackColor = true;
            newConfigButton.Click += newConfigButton_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { actionToolStripStatusLabel, actionToolStripProgressBar });
            statusStrip1.Location = new System.Drawing.Point(0, 309);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 8, 0);
            statusStrip1.Size = new System.Drawing.Size(551, 22);
            statusStrip1.TabIndex = 46;
            statusStrip1.Text = "statusStrip1";
            // 
            // actionToolStripStatusLabel
            // 
            actionToolStripStatusLabel.Name = "actionToolStripStatusLabel";
            actionToolStripStatusLabel.Size = new System.Drawing.Size(542, 17);
            actionToolStripStatusLabel.Spring = true;
            actionToolStripStatusLabel.Text = "WinCertes";
            actionToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // actionToolStripProgressBar
            // 
            actionToolStripProgressBar.AutoSize = false;
            actionToolStripProgressBar.Name = "actionToolStripProgressBar";
            actionToolStripProgressBar.Size = new System.Drawing.Size(162, 16);
            actionToolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            actionToolStripProgressBar.Visible = false;
            // 
            // WinCertesForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(551, 331);
            Controls.Add(tabControl1);
            Controls.Add(statusStrip1);
            Controls.Add(issueButton);
            Controls.Add(newConfigButton);
            Controls.Add(revokeButton);
            Controls.Add(deleteButton);
            Controls.Add(configsComboBox);
            Controls.Add(certButton);
            Controls.Add(configLabel);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            MinimumSize = new System.Drawing.Size(567, 370);
            Name = "WinCertesForm";
            Text = "WinCertes";
            Load += MainForm_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            standaloneGroupBox.ResumeLayout(false);
            standaloneGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)httpPortNumericUpDown).EndInit();
            settingsGroupBox.ResumeLayout(false);
            settingsGroupBox.PerformLayout();
            tabPage2.ResumeLayout(false);
            iisGroupBox.ResumeLayout(false);
            iisGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iisPortNumericUpDown).EndInit();
            tabPage3.ResumeLayout(false);
            domainsGroupBox.ResumeLayout(false);
            domainsGroupBox.PerformLayout();
            tabPage4.ResumeLayout(false);
            taskGroupBox.ResumeLayout(false);
            taskGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)renewalNumericUpDown).EndInit();
            psGroupBox.ResumeLayout(false);
            psGroupBox.PerformLayout();
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TextBox helpTextBox;
    }
}

