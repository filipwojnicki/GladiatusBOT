namespace GladiatusBOT
{
    partial class Form1
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
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.testbttn = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.lvlTxt = new System.Windows.Forms.Label();
            this.nickTxt = new System.Windows.Forms.Label();
            this.loginPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.passBox = new System.Windows.Forms.TextBox();
            this.loginBox = new System.Windows.Forms.TextBox();
            this.passTxt = new System.Windows.Forms.Label();
            this.loginTxt = new System.Windows.Forms.Label();
            this.expeditionTimer = new System.Windows.Forms.Timer(this.components);
            this.dungeonTimer = new System.Windows.Forms.Timer(this.components);
            this.workTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.loginPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Left;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1002, 537);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox3);
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.testbttn);
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.comboBox4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.logoutButton);
            this.panel1.Controls.Add(this.lvlTxt);
            this.panel1.Controls.Add(this.nickTxt);
            this.panel1.Location = new System.Drawing.Point(1008, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 377);
            this.panel1.TabIndex = 1;
            this.panel1.Tag = "Postać";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(56, 301);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(179, 17);
            this.checkBox3.TabIndex = 12;
            this.checkBox3.Text = "W przerwie od wypraw rób lochy";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(56, 282);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(162, 17);
            this.checkBox2.TabIndex = 11;
            this.checkBox2.Text = "Po zakończeniu idź do pracy";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // testbttn
            // 
            this.testbttn.Location = new System.Drawing.Point(189, 19);
            this.testbttn.Name = "testbttn";
            this.testbttn.Size = new System.Drawing.Size(75, 23);
            this.testbttn.TabIndex = 3;
            this.testbttn.Text = "test";
            this.testbttn.UseVisualStyleBackColor = true;
            this.testbttn.Visible = false;
            this.testbttn.Click += new System.EventHandler(this.testbttn_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(264, 213);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(83, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Lokalizacja";
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(156, 219);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(69, 21);
            this.comboBox4.TabIndex = 8;
            this.comboBox4.Text = "0";
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Wybierz potwora do bicia";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(156, 246);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(69, 21);
            this.comboBox2.TabIndex = 4;
            this.comboBox2.Text = "1";
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(150, 324);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Wyprawa";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(68, 351);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(75, 23);
            this.logoutButton.TabIndex = 3;
            this.logoutButton.Text = "Wyloguj";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Visible = false;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // lvlTxt
            // 
            this.lvlTxt.AutoSize = true;
            this.lvlTxt.Location = new System.Drawing.Point(55, 19);
            this.lvlTxt.Name = "lvlTxt";
            this.lvlTxt.Size = new System.Drawing.Size(0, 13);
            this.lvlTxt.TabIndex = 1;
            // 
            // nickTxt
            // 
            this.nickTxt.AutoSize = true;
            this.nickTxt.Location = new System.Drawing.Point(14, 19);
            this.nickTxt.Name = "nickTxt";
            this.nickTxt.Size = new System.Drawing.Size(0, 13);
            this.nickTxt.TabIndex = 0;
            // 
            // loginPanel
            // 
            this.loginPanel.Controls.Add(this.label1);
            this.loginPanel.Controls.Add(this.comboBox1);
            this.loginPanel.Controls.Add(this.button1);
            this.loginPanel.Controls.Add(this.checkBox1);
            this.loginPanel.Controls.Add(this.passBox);
            this.loginPanel.Controls.Add(this.loginBox);
            this.loginPanel.Controls.Add(this.passTxt);
            this.loginPanel.Controls.Add(this.loginTxt);
            this.loginPanel.Location = new System.Drawing.Point(1008, 384);
            this.loginPanel.Name = "loginPanel";
            this.loginPanel.Size = new System.Drawing.Size(267, 153);
            this.loginPanel.TabIndex = 2;
            this.loginPanel.Tag = "Postać";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Serwer: ";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(62, 93);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(81, 21);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.Text = "1";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(180, 120);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Zaloguj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(13, 120);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(78, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Zapamiętaj";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // passBox
            // 
            this.passBox.Location = new System.Drawing.Point(58, 49);
            this.passBox.Name = "passBox";
            this.passBox.PasswordChar = '*';
            this.passBox.Size = new System.Drawing.Size(197, 20);
            this.passBox.TabIndex = 3;
            this.passBox.UseSystemPasswordChar = true;
            // 
            // loginBox
            // 
            this.loginBox.Location = new System.Drawing.Point(58, 23);
            this.loginBox.Name = "loginBox";
            this.loginBox.Size = new System.Drawing.Size(197, 20);
            this.loginBox.TabIndex = 2;
            // 
            // passTxt
            // 
            this.passTxt.AutoSize = true;
            this.passTxt.Location = new System.Drawing.Point(13, 52);
            this.passTxt.Name = "passTxt";
            this.passTxt.Size = new System.Drawing.Size(42, 13);
            this.passTxt.TabIndex = 1;
            this.passTxt.Text = "Hasło: ";
            // 
            // loginTxt
            // 
            this.loginTxt.AutoSize = true;
            this.loginTxt.Location = new System.Drawing.Point(13, 26);
            this.loginTxt.Name = "loginTxt";
            this.loginTxt.Size = new System.Drawing.Size(39, 13);
            this.loginTxt.TabIndex = 0;
            this.loginTxt.Text = "Login: ";
            // 
            // expeditionTimer
            // 
            this.expeditionTimer.Interval = 10000;
            this.expeditionTimer.Tick += new System.EventHandler(this.expeditionTimer_Tick);
            // 
            // dungeonTimer
            // 
            this.dungeonTimer.Interval = 10000;
            this.dungeonTimer.Tick += new System.EventHandler(this.dungeonTimer_Tick);
            // 
            // workTimer
            // 
            this.workTimer.Interval = 10000;
            this.workTimer.Tick += new System.EventHandler(this.workTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 537);
            this.Controls.Add(this.loginPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.webBrowser1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GladiatusBot";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.loginPanel.ResumeLayout(false);
            this.loginPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lvlTxt;
        private System.Windows.Forms.Label nickTxt;
        private System.Windows.Forms.Panel loginPanel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox passBox;
        private System.Windows.Forms.TextBox loginBox;
        private System.Windows.Forms.Label passTxt;
        private System.Windows.Forms.Label loginTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Timer expeditionTimer;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button testbttn;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Timer dungeonTimer;
        private System.Windows.Forms.Timer workTimer;
    }
}

