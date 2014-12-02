using System;
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
using MakePicFromCam;

namespace WebCam {
    public partial class mainform : Form {


        public mainform() {
            InitializeComponent();
            open_image_btn.Text = "Start!";
            Save.Enabled = Enabled;
            set_finish_line_btn.Enabled = false;
        }
        MakePicFromCam.MapEditorForm mpef = new MapEditorForm();
        Game_Controller gc = new Game_Controller();
        int pic_widht = 800;
        int pic_height = 600;

        private void mainform_Load(object sender, EventArgs e) {

            NewCapture();
        }

        private void NewCapture() {
            capture = new Capture();

            this.Width = pic_widht + 100;
            this.Height = pic_height + 100;
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
            if (capture == null) {
                try {
                    capture = new Capture();
                } catch (NullReferenceException excpt) {
                    MessageBox.Show(excpt.Message);
                }
            }
            #endregion


            if (capture != null) {
                if (captureInProgress) {  //if camera is getting frames then stop the capture and set button Text
                    // "Start" for resuming capture
                    open_image_btn.Text = "Start!"; //
                    Application.Idle -= ProcessFrame;

                } else {
                    //if camera is NOT getting frames then start the capture and set button
                    // Text to "Stop" for pausing capture
                    open_image_btn.Text = "Stop";
                    Application.Idle += ProcessFrame;
                    Save.Enabled = true;
                }

                captureInProgress = !captureInProgress;
            }
        }

        private void ReleaseData() {
            if (capture != null)
                capture.Dispose();
        }
        Bitmap track;
        private void Save_Click(object sender, EventArgs e) {
            SaveFileDialog save_file_dialog = new SaveFileDialog();
            //save_file_dialog.ShowDialog();
            save_file_dialog.RestoreDirectory = true;
            save_file_dialog.Filter = "JPG fájl | *.jpg";
            Stream myStream;


            if (save_file_dialog.ShowDialog() == DialogResult.OK) {
                imageBox1.Image.Save(save_file_dialog.FileName);
            }
            //Image img = Image.FromFile();
            track = new Bitmap(save_file_dialog.FileName);
            reload_pic_and_draw_intersection(track);
        }
        PictureBox pb = new PictureBox();
        private void reload_pic_and_draw_intersection(Bitmap img) {
            set_finish_line_btn.Enabled = true;

            pb.Image = img;

            Color c = new Color();
            c = Color.White;
            for (int i = 0; i < imageBox1.Image.Bitmap.Width - 1; i += 25) {
                for (int j = 0; j < imageBox1.Image.Bitmap.Height - 1; j += 25) {
                    if ((i % 25 == 0) && (j % 25 == 0)) {
                        img.SetPixel(i, j, c);
                        intersections[i, j] = 1;
                        if (i > 0 && j > 0 && i < pic_widht && j < pic_height) {
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
            pb.Invalidate();
            pb.Update();
            this.Controls.Add(pb);
            imageBox1.Visible = false;
            fl_counter = 0;
        }
        //Bitmap img, Point A, Point B
        public void DrawFinishLine(Bitmap img, Point A, Point B) {
            Pen pen = new Pen(Color.Red, 3);
            // Draw line to screen.
            using (var graphics = Graphics.FromImage(img)) {
                graphics.DrawLine(pen, A, B);

            }
        }
        Player player;
        public void check_where_lmb_clicked(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                if (intersections[e.X, e.Y] == 1) {
                    set_labels_visible(true);
                    label2.Text = e.X.ToString();
                    label4.Text = e.Y.ToString();
                } else {
                    // set_labels_visible(false);
                }
            }

            //player.draw_available_next_step(track, e.X, e.Y);


            Point p = new Point(e.X, e.Y);

            switch (fl_counter) {
                case 0:
                    gc.finish_line_start = p;

                    break;
                case 1:
                    gc.finish_line_end = p;
                    break;
                default:
                    break;
            }
            if (fl_counter == 1) {
                DrawFinishLine(track, gc.finish_line_start, gc.finish_line_end);
            }
            fl_counter++;
            pb.Invalidate();
            pb.Update();
        }

        private void set_labels_visible(bool state) {
            label1.Visible = state;
            label2.Visible = state;
            label3.Visible = state;
            label4.Visible = state;
        }

        int[,] intersections = new int[800, 600];



        int fl_counter = 0;
        private void set_finish_line_btn_Click(object sender, EventArgs e) {
            List<Point> p = new List<Point>();
            pb.MouseClick += check_where_lmb_clicked;
            fl_counter = 0;
            //imageBox1.MouseClick += check_where_lmb_clicked;

        }

        private void open_img_btn_Click(object sender, EventArgs e) {
            pb.MouseClick -= check_where_lmb_clicked;
            fl_counter = 0;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            openFileDialog1.Title = "Open an Image file";

            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                track = new Bitmap(openFileDialog1.FileName);
                reload_pic_and_draw_intersection(track);


            }
        }

        private void capture_new_track_btn_Click(object sender, EventArgs e) {
            NewCapture();
        }

        private void start_race_btn_Click(object sender, EventArgs e) {

        }

        private void map_editor_btn_Click(object sender, EventArgs e) {
            mpef.Show();
        }



    }
}

class Game_Controller {

    private Point fl_start;
    private Point fl_end;
    private List<Point[]> fl_points;

    public Point finish_line_start {
        get { return fl_start; }
        set { fl_start = value; }
    }
    public Point finish_line_end {
        get { return fl_end; }
        set { fl_end = value; }
    }
}

class Player {
    private Point position;
    private Color color;

    public Point Position {
        get { return position; }
        set { position = value; }
    }

    public void draw_location() { }

    public void draw_available_next_step(Bitmap img, int X, int Y) {
        using (Graphics grf = Graphics.FromImage(img)) {
            using (Brush brsh = new SolidBrush(ColorTranslator.FromHtml("#ff00ffff"))) {
                grf.FillEllipse(brsh, new Rectangle(X + 25, Y + 25, 10, 10));
                grf.FillEllipse(brsh, new Rectangle(X, Y + 25, 10, 10));
                grf.FillEllipse(brsh, new Rectangle(X + 25, Y, 10, 10));

            }
        }
    }
}