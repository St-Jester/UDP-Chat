namespace MultyChat
{
    partial class Chat
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.allMessages = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.status = new System.Windows.Forms.Label();
            this.portLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sendButton = new System.Windows.Forms.Button();
            this.messageText = new System.Windows.Forms.TextBox();
            this.portInfo = new System.Windows.Forms.TextBox();
            this.nickname = new System.Windows.Forms.TextBox();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.joinButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.allMessages);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 360);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server";
            // 
            // allMessages
            // 
            this.allMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.allMessages.Location = new System.Drawing.Point(3, 16);
            this.allMessages.Multiline = true;
            this.allMessages.Name = "allMessages";
            this.allMessages.ReadOnly = true;
            this.allMessages.Size = new System.Drawing.Size(319, 341);
            this.allMessages.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.status);
            this.groupBox2.Controls.Add(this.portLabel);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.sendButton);
            this.groupBox2.Controls.Add(this.messageText);
            this.groupBox2.Controls.Add(this.portInfo);
            this.groupBox2.Controls.Add(this.nickname);
            this.groupBox2.Controls.Add(this.disconnectButton);
            this.groupBox2.Controls.Add(this.joinButton);
            this.groupBox2.Location = new System.Drawing.Point(365, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(312, 360);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Client";
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(172, 72);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(51, 13);
            this.status.TabIndex = 4;
            this.status.Text = "OFLLINE";
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(94, 99);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(25, 13);
            this.portLabel.TabIndex = 3;
            this.portLabel.Text = "port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "State";
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(27, 337);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(257, 23);
            this.sendButton.TabIndex = 2;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // messageText
            // 
            this.messageText.Location = new System.Drawing.Point(27, 166);
            this.messageText.Multiline = true;
            this.messageText.Name = "messageText";
            this.messageText.Size = new System.Drawing.Size(257, 165);
            this.messageText.TabIndex = 1;
            // 
            // portInfo
            // 
            this.portInfo.Location = new System.Drawing.Point(185, 99);
            this.portInfo.Multiline = true;
            this.portInfo.Name = "portInfo";
            this.portInfo.Size = new System.Drawing.Size(99, 19);
            this.portInfo.TabIndex = 1;
            this.portInfo.Text = "9005";
            this.portInfo.TextChanged += new System.EventHandler(this.portInfo_TextChanged);
            // 
            // nickname
            // 
            this.nickname.Location = new System.Drawing.Point(27, 23);
            this.nickname.Multiline = true;
            this.nickname.Name = "nickname";
            this.nickname.Size = new System.Drawing.Size(257, 17);
            this.nickname.TabIndex = 1;
            this.nickname.Text = "Name";
            // 
            // disconnectButton
            // 
            this.disconnectButton.Location = new System.Drawing.Point(209, 50);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(75, 19);
            this.disconnectButton.TabIndex = 1;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // joinButton
            // 
            this.joinButton.Location = new System.Drawing.Point(27, 50);
            this.joinButton.Name = "joinButton";
            this.joinButton.Size = new System.Drawing.Size(75, 19);
            this.joinButton.TabIndex = 0;
            this.joinButton.Text = "Join";
            this.joinButton.UseVisualStyleBackColor = true;
            this.joinButton.Click += new System.EventHandler(this.joinButton_Click);
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 384);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Chat";
            this.Text = "Chat";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox allMessages;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox messageText;
        private System.Windows.Forms.TextBox nickname;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.Button joinButton;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.TextBox portInfo;
    }
}

