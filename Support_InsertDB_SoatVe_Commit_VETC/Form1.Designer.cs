namespace Support_InsertDB_SoatVe_Commit_VETC
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
            this.btninsert = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtpathfile = new System.Windows.Forms.TextBox();
            this.btnbrowserpathfile = new System.Windows.Forms.Button();
            this.btnreadfile = new System.Windows.Forms.Button();
            this.DBView = new System.Windows.Forms.DataGridView();
            this.radCheckOutTollTicket = new System.Windows.Forms.RadioButton();
            this.radCheckForceOpen = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.DBView)).BeginInit();
            this.SuspendLayout();
            // 
            // btninsert
            // 
            this.btninsert.Location = new System.Drawing.Point(873, 4);
            this.btninsert.Name = "btninsert";
            this.btninsert.Size = new System.Drawing.Size(75, 23);
            this.btninsert.TabIndex = 0;
            this.btninsert.Text = "Insert";
            this.btninsert.UseVisualStyleBackColor = true;
            this.btninsert.Click += new System.EventHandler(this.btninsert_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Path File:";
            // 
            // txtpathfile
            // 
            this.txtpathfile.Location = new System.Drawing.Point(69, 3);
            this.txtpathfile.Name = "txtpathfile";
            this.txtpathfile.Size = new System.Drawing.Size(400, 20);
            this.txtpathfile.TabIndex = 2;
            // 
            // btnbrowserpathfile
            // 
            this.btnbrowserpathfile.Location = new System.Drawing.Point(475, 1);
            this.btnbrowserpathfile.Name = "btnbrowserpathfile";
            this.btnbrowserpathfile.Size = new System.Drawing.Size(24, 23);
            this.btnbrowserpathfile.TabIndex = 0;
            this.btnbrowserpathfile.Text = "...";
            this.btnbrowserpathfile.UseVisualStyleBackColor = true;
            this.btnbrowserpathfile.Click += new System.EventHandler(this.btnbrowserpathfile_Click);
            // 
            // btnreadfile
            // 
            this.btnreadfile.Location = new System.Drawing.Point(505, 1);
            this.btnreadfile.Name = "btnreadfile";
            this.btnreadfile.Size = new System.Drawing.Size(75, 23);
            this.btnreadfile.TabIndex = 0;
            this.btnreadfile.Text = "Read File";
            this.btnreadfile.UseVisualStyleBackColor = true;
            this.btnreadfile.Click += new System.EventHandler(this.btnreadfile_Click);
            // 
            // DBView
            // 
            this.DBView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DBView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DBView.Location = new System.Drawing.Point(0, 32);
            this.DBView.Name = "DBView";
            this.DBView.Size = new System.Drawing.Size(960, 457);
            this.DBView.TabIndex = 3;
            // 
            // radCheckOutTollTicket
            // 
            this.radCheckOutTollTicket.AutoSize = true;
            this.radCheckOutTollTicket.Location = new System.Drawing.Point(586, 6);
            this.radCheckOutTollTicket.Name = "radCheckOutTollTicket";
            this.radCheckOutTollTicket.Size = new System.Drawing.Size(132, 17);
            this.radCheckOutTollTicket.TabIndex = 6;
            this.radCheckOutTollTicket.TabStop = true;
            this.radCheckOutTollTicket.Text = "OUT_CheckTollTicket";
            this.radCheckOutTollTicket.UseVisualStyleBackColor = true;
            this.radCheckOutTollTicket.CheckedChanged += new System.EventHandler(this.radCheckOutTollTicket_CheckedChanged);
            // 
            // radCheckForceOpen
            // 
            this.radCheckForceOpen.AutoSize = true;
            this.radCheckForceOpen.Location = new System.Drawing.Point(724, 7);
            this.radCheckForceOpen.Name = "radCheckForceOpen";
            this.radCheckForceOpen.Size = new System.Drawing.Size(138, 17);
            this.radCheckForceOpen.TabIndex = 7;
            this.radCheckForceOpen.TabStop = true;
            this.radCheckForceOpen.Text = "OUT_CheckForceOpen";
            this.radCheckForceOpen.UseVisualStyleBackColor = true;
            this.radCheckForceOpen.CheckedChanged += new System.EventHandler(this.radCheckForceOpen_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 489);
            this.Controls.Add(this.radCheckForceOpen);
            this.Controls.Add(this.radCheckOutTollTicket);
            this.Controls.Add(this.DBView);
            this.Controls.Add(this.txtpathfile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnbrowserpathfile);
            this.Controls.Add(this.btnreadfile);
            this.Controls.Add(this.btninsert);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.DBView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btninsert;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtpathfile;
        private System.Windows.Forms.Button btnbrowserpathfile;
        private System.Windows.Forms.Button btnreadfile;
        private System.Windows.Forms.DataGridView DBView;
        private System.Windows.Forms.RadioButton radCheckOutTollTicket;
        private System.Windows.Forms.RadioButton radCheckForceOpen;
    }
}

