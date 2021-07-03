
namespace Server
{
    partial class Server
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Server));
            this.btnExit = new System.Windows.Forms.Button();
            this.lvSearchHistory = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.rtbResult = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbReceived = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWork = new System.ComponentModel.BackgroundWorker();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbUid = new System.Windows.Forms.TextBox();
            this.tbDatabase = new System.Windows.Forms.TextBox();
            this.Setting = new System.Windows.Forms.GroupBox();
            this.Setting.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(294, 246);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(175, 93);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lvSearchHistory
            // 
            this.lvSearchHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvSearchHistory.Enabled = false;
            this.lvSearchHistory.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvSearchHistory.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.lvSearchHistory.HideSelection = false;
            this.lvSearchHistory.Location = new System.Drawing.Point(604, 277);
            this.lvSearchHistory.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.lvSearchHistory.Name = "lvSearchHistory";
            this.lvSearchHistory.Size = new System.Drawing.Size(272, 267);
            this.lvSearchHistory.TabIndex = 14;
            this.lvSearchHistory.UseCompatibleStateImageBehavior = false;
            this.lvSearchHistory.View = System.Windows.Forms.View.List;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1022, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 44);
            this.label3.TabIndex = 13;
            this.label3.Text = "Result";
            // 
            // rtbResult
            // 
            this.rtbResult.Location = new System.Drawing.Point(908, 153);
            this.rtbResult.Name = "rtbResult";
            this.rtbResult.Size = new System.Drawing.Size(361, 391);
            this.rtbResult.TabIndex = 1;
            this.rtbResult.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(657, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 44);
            this.label2.TabIndex = 11;
            this.label2.Text = "Received";
            // 
            // tbReceived
            // 
            this.tbReceived.Enabled = false;
            this.tbReceived.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbReceived.Location = new System.Drawing.Point(604, 153);
            this.tbReceived.Multiline = true;
            this.tbReceived.Name = "tbReceived";
            this.tbReceived.Size = new System.Drawing.Size(272, 63);
            this.tbReceived.TabIndex = 10;
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(30, 246);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(187, 93);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(519, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 44);
            this.label1.TabIndex = 8;
            this.label1.Text = "SERVER";
            // 
            // backgroundWork
            // 
            this.backgroundWork.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWork_DoWork);
            this.backgroundWork.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWork_ProgressChanged);
            this.backgroundWork.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWork_RunWorkerCompleted);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(611, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(256, 44);
            this.label5.TabIndex = 41;
            this.label5.Text = "Search history";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(22, 166);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(179, 44);
            this.label7.TabIndex = 53;
            this.label7.Text = "Password";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(22, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 44);
            this.label6.TabIndex = 52;
            this.label6.Text = "Uid";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 44);
            this.label4.TabIndex = 51;
            this.label4.Text = "Database";
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.Location = new System.Drawing.Point(213, 167);
            this.tbPassword.Multiline = true;
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(256, 43);
            this.tbPassword.TabIndex = 2;
            // 
            // tbUid
            // 
            this.tbUid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUid.Location = new System.Drawing.Point(213, 105);
            this.tbUid.Multiline = true;
            this.tbUid.Name = "tbUid";
            this.tbUid.Size = new System.Drawing.Size(256, 43);
            this.tbUid.TabIndex = 1;
            // 
            // tbDatabase
            // 
            this.tbDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDatabase.Location = new System.Drawing.Point(213, 43);
            this.tbDatabase.Multiline = true;
            this.tbDatabase.Name = "tbDatabase";
            this.tbDatabase.Size = new System.Drawing.Size(256, 43);
            this.tbDatabase.TabIndex = 0;
            // 
            // Setting
            // 
            this.Setting.Controls.Add(this.tbDatabase);
            this.Setting.Controls.Add(this.label7);
            this.Setting.Controls.Add(this.btnConnect);
            this.Setting.Controls.Add(this.label6);
            this.Setting.Controls.Add(this.btnExit);
            this.Setting.Controls.Add(this.label4);
            this.Setting.Controls.Add(this.tbUid);
            this.Setting.Controls.Add(this.tbPassword);
            this.Setting.Location = new System.Drawing.Point(43, 153);
            this.Setting.Name = "Setting";
            this.Setting.Size = new System.Drawing.Size(502, 390);
            this.Setting.TabIndex = 0;
            this.Setting.TabStop = false;
            this.Setting.Text = "Setting";
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1317, 576);
            this.Controls.Add(this.Setting);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lvSearchHistory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rtbResult);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbReceived);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Server";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SERVER _ NHÓM 7";
            this.Setting.ResumeLayout(false);
            this.Setting.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ListView lvSearchHistory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtbResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbReceived;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWork;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbUid;
        private System.Windows.Forms.TextBox tbDatabase;
        private System.Windows.Forms.GroupBox Setting;
    }
}

