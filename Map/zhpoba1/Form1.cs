using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace zhpoba1
{

    public partial class Form1 : Form
    {
        Bitmap loadedimage;
        Bitmap loadedimage2;
        MImage myimage;
        Color colorhsl;
        OnePixelRGB colorrgb;
   
        public Form1()
        {
            InitializeComponent();

        }

       
        private void Form1_Load(object sender, EventArgs e)
        {
            loadedimage = new Bitmap("imagetest2.jpg");
            loadedimage2 = new Bitmap("imagetest2.jpg");
            pictureBox1.Image = loadedimage;
            myimage = new MImage(loadedimage);
            pictureBox2.Image = myimage.GetBMP();
            hScrollBar1.Value = 10;
            label1.Text = hScrollBar1.Value.ToString();
            label3.Text = hScrollBar2.Value.ToString();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
        
            label1.Text = hScrollBar1.Value.ToString();
            myimage.EnlargeImage(hScrollBar1.Value);
            pictureBox2.Image = myimage.GetBMP();
    
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            label3.Text = hScrollBar2.Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String fajlnev;
            fajlnev = textBox1.Text;
            if (fajlnev == "") {
                fajlnev = "defaultname";
            }
            fajlnev = fajlnev + ".jpg";
            myimage.Save(fajlnev);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hScrollBar1.Value = 0;
            hScrollBar2.Value = 0;
            label1.Text = hScrollBar1.Value.ToString();
            label3.Text = hScrollBar2.Value.ToString();
            pictureBox2.Image = myimage.ResetBMP(loadedimage2);

        }



 
    }
}
