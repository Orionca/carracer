namespace WebCam {
    partial class mainform {
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
            this.components = new System.ComponentModel.Container();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.open_image_btn = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.set_finish_line_btn = new System.Windows.Forms.Button();
            this.open_img_btn = new System.Windows.Forms.Button();
            this.capture_new_track_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBox1
            // 
            this.imageBox1.Location = new System.Drawing.Point(12, 12);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(354, 382);
            this.imageBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imageBox1.TabIndex = 2;
            this.imageBox1.TabStop = false;
            // 
            // open_image_btn
            // 
            this.open_image_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.open_image_btn.Location = new System.Drawing.Point(134, 428);
            this.open_image_btn.Name = "open_image_btn";
            this.open_image_btn.Size = new System.Drawing.Size(75, 23);
            this.open_image_btn.TabIndex = 3;
            this.open_image_btn.Text = "Open Image";
            this.open_image_btn.UseVisualStyleBackColor = true;
            this.open_image_btn.Visible = false;
            this.open_image_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // Save
            // 
            this.Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Save.Location = new System.Drawing.Point(620, 411);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 4;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(676, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "X:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(699, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(676, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Y:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(699, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "label4";
            // 
            // set_finish_line_btn
            // 
            this.set_finish_line_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.set_finish_line_btn.Location = new System.Drawing.Point(620, 12);
            this.set_finish_line_btn.Name = "set_finish_line_btn";
            this.set_finish_line_btn.Size = new System.Drawing.Size(114, 23);
            this.set_finish_line_btn.TabIndex = 13;
            this.set_finish_line_btn.Text = "Set Finish Line";
            this.set_finish_line_btn.UseVisualStyleBackColor = true;
            this.set_finish_line_btn.Click += new System.EventHandler(this.set_finish_line_btn_Click);
            // 
            // open_img_btn
            // 
            this.open_img_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.open_img_btn.Location = new System.Drawing.Point(527, 411);
            this.open_img_btn.Name = "open_img_btn";
            this.open_img_btn.Size = new System.Drawing.Size(75, 23);
            this.open_img_btn.TabIndex = 14;
            this.open_img_btn.Text = "Open Image";
            this.open_img_btn.UseVisualStyleBackColor = true;
            this.open_img_btn.Click += new System.EventHandler(this.open_img_btn_Click);
            // 
            // capture_new_track_btn
            // 
            this.capture_new_track_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.capture_new_track_btn.Location = new System.Drawing.Point(374, 411);
            this.capture_new_track_btn.Name = "capture_new_track_btn";
            this.capture_new_track_btn.Size = new System.Drawing.Size(114, 23);
            this.capture_new_track_btn.TabIndex = 15;
            this.capture_new_track_btn.Text = "Capture New Track";
            this.capture_new_track_btn.UseVisualStyleBackColor = true;
            this.capture_new_track_btn.Visible = false;
            this.capture_new_track_btn.Click += new System.EventHandler(this.capture_new_track_btn_Click);
            // 
            // mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 453);
            this.Controls.Add(this.capture_new_track_btn);
            this.Controls.Add(this.open_img_btn);
            this.Controls.Add(this.set_finish_line_btn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.open_image_btn);
            this.Controls.Add(this.imageBox1);
            this.Name = "mainform";
            this.Text = "WebCam";
            this.Load += new System.EventHandler(this.mainform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imageBox1;
        private System.Windows.Forms.Button open_image_btn;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button set_finish_line_btn;
        private System.Windows.Forms.Button open_img_btn;
        private System.Windows.Forms.Button capture_new_track_btn;
    }
}

