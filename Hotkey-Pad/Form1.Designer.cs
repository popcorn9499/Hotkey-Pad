namespace hotkey_pad
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageVR = new System.Windows.Forms.TabPage();
            this.tabPageEditor = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageVR);
            this.tabControl1.Controls.Add(this.tabPageEditor);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(852, 517);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageVR
            // 
            this.tabPageVR.Location = new System.Drawing.Point(4, 22);
            this.tabPageVR.Name = "tabPageVR";
            this.tabPageVR.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVR.Size = new System.Drawing.Size(844, 491);
            this.tabPageVR.TabIndex = 0;
            this.tabPageVR.Text = "VR Pad";
            this.tabPageVR.UseVisualStyleBackColor = true;
            // 
            // tabPageEditor
            // 
            this.tabPageEditor.Location = new System.Drawing.Point(4, 22);
            this.tabPageEditor.Name = "tabPageEditor";
            this.tabPageEditor.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEditor.Size = new System.Drawing.Size(844, 491);
            this.tabPageEditor.TabIndex = 1;
            this.tabPageEditor.Text = "Pad Editor";
            this.tabPageEditor.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 517);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageVR;
        private System.Windows.Forms.TabPage tabPageEditor;
    }
}

