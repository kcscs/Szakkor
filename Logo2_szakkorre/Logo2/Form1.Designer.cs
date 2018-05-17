namespace Logo2
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
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.rajz = new System.Windows.Forms.Panel();
            this.parancs = new System.Windows.Forms.TextBox();
            this.runCommand = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rajz
            // 
            this.rajz.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rajz.BackColor = System.Drawing.Color.White;
            this.rajz.Location = new System.Drawing.Point(13, 13);
            this.rajz.Name = "rajz";
            this.rajz.Size = new System.Drawing.Size(480, 398);
            this.rajz.TabIndex = 0;
            this.rajz.Paint += new System.Windows.Forms.PaintEventHandler(this.rajz_Paint);
            // 
            // parancs
            // 
            this.parancs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.parancs.Location = new System.Drawing.Point(13, 418);
            this.parancs.Name = "parancs";
            this.parancs.Size = new System.Drawing.Size(397, 20);
            this.parancs.TabIndex = 1;
            this.parancs.KeyUp += new System.Windows.Forms.KeyEventHandler(this.parancs_KeyUp);
            // 
            // runCommand
            // 
            this.runCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.runCommand.Location = new System.Drawing.Point(416, 416);
            this.runCommand.Name = "runCommand";
            this.runCommand.Size = new System.Drawing.Size(77, 23);
            this.runCommand.TabIndex = 2;
            this.runCommand.Text = "Futtatás";
            this.runCommand.UseVisualStyleBackColor = true;
            this.runCommand.Click += new System.EventHandler(this.runCommand_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 450);
            this.Controls.Add(this.runCommand);
            this.Controls.Add(this.parancs);
            this.Controls.Add(this.rajz);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox parancs;
        public System.Windows.Forms.Panel rajz;
        private System.Windows.Forms.Button runCommand;
    }
}

