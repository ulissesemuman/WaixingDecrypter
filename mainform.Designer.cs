namespace WaixingDecrypter
{
    partial class mainform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainform));
            this.decryptbutton = new System.Windows.Forms.Button();
            this.compare = new System.Windows.Forms.CheckBox();
            this.head = new System.Windows.Forms.CheckBox();
            this.nes = new System.Windows.Forms.CheckBox();
            this.mapperchange = new System.Windows.Forms.CheckBox();
            this.mapsave = new System.Windows.Forms.CheckBox();
            this.convertbutton = new System.Windows.Forms.Button();
            this.meth2 = new System.Windows.Forms.CheckBox();
            this.newmapper = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // decryptbutton
            // 
            this.decryptbutton.Location = new System.Drawing.Point(12, 12);
            this.decryptbutton.Name = "decryptbutton";
            this.decryptbutton.Size = new System.Drawing.Size(290, 39);
            this.decryptbutton.TabIndex = 0;
            this.decryptbutton.Text = "decrypt .wxn file";
            this.decryptbutton.UseVisualStyleBackColor = true;
            this.decryptbutton.Click += new System.EventHandler(this.button1_Click);
            // 
            // compare
            // 
            this.compare.AutoSize = true;
            this.compare.Location = new System.Drawing.Point(12, 57);
            this.compare.Name = "compare";
            this.compare.Size = new System.Drawing.Size(221, 17);
            this.compare.TabIndex = 2;
            this.compare.Text = "compare against original && log differences";
            this.compare.UseVisualStyleBackColor = true;
            // 
            // head
            // 
            this.head.AutoSize = true;
            this.head.Location = new System.Drawing.Point(12, 71);
            this.head.Name = "head";
            this.head.Size = new System.Drawing.Size(299, 17);
            this.head.TabIndex = 3;
            this.head.Text = "decrypt first 16 bytes (usually unencrypted custom header)";
            this.head.UseVisualStyleBackColor = true;
            // 
            // nes
            // 
            this.nes.AutoSize = true;
            this.nes.Checked = true;
            this.nes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.nes.Location = new System.Drawing.Point(12, 85);
            this.nes.Name = "nes";
            this.nes.Size = new System.Drawing.Size(286, 17);
            this.nes.TabIndex = 4;
            this.nes.Text = "make .nes w/mapper 0 or 4 (overwrites custom header)";
            this.nes.UseVisualStyleBackColor = true;
            this.nes.CheckedChanged += new System.EventHandler(this.nes_CheckedChanged);
            // 
            // mapperchange
            // 
            this.mapperchange.AutoSize = true;
            this.mapperchange.Location = new System.Drawing.Point(136, 99);
            this.mapperchange.Name = "mapperchange";
            this.mapperchange.Size = new System.Drawing.Size(118, 17);
            this.mapperchange.TabIndex = 5;
            this.mapperchange.Text = "use custom mapper";
            this.mapperchange.UseVisualStyleBackColor = true;
            this.mapperchange.CheckedChanged += new System.EventHandler(this.mapper4_CheckedChanged);
            // 
            // mapsave
            // 
            this.mapsave.AutoSize = true;
            this.mapsave.Location = new System.Drawing.Point(12, 99);
            this.mapsave.Name = "mapsave";
            this.mapsave.Size = new System.Drawing.Size(71, 17);
            this.mapsave.TabIndex = 6;
            this.mapsave.Text = "with save";
            this.mapsave.UseVisualStyleBackColor = true;
            // 
            // convertbutton
            // 
            this.convertbutton.Location = new System.Drawing.Point(12, 130);
            this.convertbutton.Name = "convertbutton";
            this.convertbutton.Size = new System.Drawing.Size(290, 29);
            this.convertbutton.TabIndex = 7;
            this.convertbutton.Text = "convert decrypted rom to emuvt bin (attempted)";
            this.convertbutton.UseVisualStyleBackColor = true;
            this.convertbutton.Click += new System.EventHandler(this.convert_Click);
            // 
            // meth2
            // 
            this.meth2.AutoSize = true;
            this.meth2.Location = new System.Drawing.Point(26, 160);
            this.meth2.Name = "meth2";
            this.meth2.Size = new System.Drawing.Size(230, 30);
            this.meth2.TabIndex = 8;
            this.meth2.Text = "if prg bigger than chr or size not power of 2,\r\nput chr at end of 1st half";
            this.meth2.UseVisualStyleBackColor = true;
            // 
            // newmapper
            // 
            this.newmapper.Enabled = false;
            this.newmapper.Location = new System.Drawing.Point(254, 99);
            this.newmapper.Name = "newmapper";
            this.newmapper.Size = new System.Drawing.Size(44, 20);
            this.newmapper.TabIndex = 9;
            // 
            // mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 198);
            this.Controls.Add(this.newmapper);
            this.Controls.Add(this.meth2);
            this.Controls.Add(this.convertbutton);
            this.Controls.Add(this.mapsave);
            this.Controls.Add(this.mapperchange);
            this.Controls.Add(this.nes);
            this.Controls.Add(this.head);
            this.Controls.Add(this.compare);
            this.Controls.Add(this.decryptbutton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainform";
            this.Text = "wxn decrypter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button decryptbutton;
        private System.Windows.Forms.CheckBox compare;
        private System.Windows.Forms.CheckBox head;
        private System.Windows.Forms.CheckBox nes;
        private System.Windows.Forms.CheckBox mapperchange;
        private System.Windows.Forms.CheckBox mapsave;
        private System.Windows.Forms.Button convertbutton;
        private System.Windows.Forms.CheckBox meth2;
        private System.Windows.Forms.TextBox newmapper;
    }
}

