﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;


namespace MakePic {
	public partial class mainform : Form {

		public mainform() {
			InitializeComponent();
			button1.Text = "Start!";
			Save.Enabled = Enabled;

		}

        int pic_widht = 800;
        int pic_height = 600;

		private void mainform_Load(object sender, EventArgs e) {

			capture = new Capture();

			this.Width = pic_widht+100;
			this.Height = pic_height+100;
			label2.Text = "-";
			label4.Text = "-";
            
			capture.SetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FPS, 40);
			capture.SetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FRAME_WIDTH, pic_widht);
			capture.SetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FRAME_HEIGHT, pic_height);

			Application.Idle += ProcessFrame;

		}

		private Capture capture;        //takes images from camera as image frames
		private bool captureInProgress; // checks if capture is executing

		private void ProcessFrame(object sender, EventArgs arg) {
			Image<Bgr, Byte> ImageFrame = capture.QueryFrame();  //line 1
			imageBox1.Image = ImageFrame;        //line 2
		}

		private void button1_Click(object sender, EventArgs e) {

			#region if capture is not created, create it now
			if(capture == null) {
				try {
					capture = new Capture();
				} catch(NullReferenceException excpt) {
					MessageBox.Show(excpt.Message);
				}
			}
			#endregion


			if(capture != null) {
				if(captureInProgress) {  //if camera is getting frames then stop the capture and set button Text
					// "Start" for resuming capture
					button1.Text = "Start!"; //
					Application.Idle -= ProcessFrame;

				} else {
					//if camera is NOT getting frames then start the capture and set button
					// Text to "Stop" for pausing capture
					button1.Text = "Stop";
					Application.Idle += ProcessFrame;
					Save.Enabled = true;
				}

				captureInProgress = !captureInProgress;
			}
		}

		private void ReleaseData() {
			if(capture != null)
				capture.Dispose();
		}

		private void Save_Click(object sender, EventArgs e) {
			SaveFileDialog save_file_dialog = new SaveFileDialog();
			//save_file_dialog.ShowDialog();
			save_file_dialog.RestoreDirectory = true;
			save_file_dialog.Filter = "JPG fájl | *.jpg";
			Stream myStream;
            
            if(save_file_dialog.ShowDialog() == DialogResult.OK) {
				imageBox1.Image.Save(save_file_dialog.FileName);
			}
			//Image img = Image.FromFile();
			Bitmap bm = new Bitmap(save_file_dialog.FileName);
			reload_pic_and_draw_intersection(bm);
		}
        
		private void reload_pic_and_draw_intersection(Bitmap img) {
            
			PictureBox pb = new PictureBox();
			pb.Image = img;

			Color c = new Color();
			c = Color.White;
			for(int i = 0; i < imageBox1.Image.Bitmap.Width - 1; i+=25) {
				for(int j = 0; j < imageBox1.Image.Bitmap.Height - 1; j+=25) {
					if((i % 25 == 0) && (j % 25 == 0)) {
						img.SetPixel(i, j, c);
						intersections[i, j] = 1;
						if(i > 0 && j > 0 && i < pic_widht && j < pic_height) {
							img.SetPixel(i, j, c);
							img.SetPixel(i + 1, j, c);
							img.SetPixel(i - 1, j, c);
							img.SetPixel(i, j + 1, c);
							img.SetPixel(i, j - 1, c);
							img.SetPixel(i + 1, j + 1, c);
							img.SetPixel(i - 1, j - 1, c);
							img.SetPixel(i + 1, j - 1, c);
							img.SetPixel(i - 1, j + 1, c);

							intersections[i, j] = 1;
							intersections[i + 1, j] = 1;
							intersections[i - 1, j] = 1;
							intersections[i, j + 1] = 1;
							intersections[i, j - 1] = 1;
							intersections[i + 1, j + 1] = 1;
							intersections[i + 1, j - 1] = 1;
							intersections[i - 1, j + 1] = 1;
							intersections[i - 1, j - 1] = 1;

						}
					}
				}
			}
			pb.Width = img.Width;
			pb.Height = img.Height;
			this.Controls.Add(pb);
			pb.MouseClick += check_where_lmb_clicked;
			imageBox1.Visible = false;
            
		}

        
		private void check_where_lmb_clicked(object sender, MouseEventArgs e) {
			if(e.Button == MouseButtons.Left) {
				if(intersections[e.X, e.Y] == 1) {
					set_labels_visible(true);
					label2.Text = e.X.ToString();
					label4.Text = e.Y.ToString();
				} else {
					// set_labels_visible(false);
				}
			}
            
		}

        public void fgv() {
            messege
        }
        public void fgv2() { }

		private void set_labels_visible(bool state) {
			label1.Visible = state;
			label2.Visible = state;
			label3.Visible = state;
			label4.Visible = state;
		}

		int[,] intersections = new int[800, 600];

	}
}