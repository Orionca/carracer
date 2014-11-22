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
        String fajlnevki;
        String fajlnevbe;

        public Form1()
        {
            InitializeComponent();
 

          

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            loadedimage = new Bitmap("defaultname.jpg");
            loadedimage2 = new Bitmap("defaultname.jpg");
            pictureBox1.Image = loadedimage;
            label2.Text = hScrollBar1.Value.ToString();
            //pictureBox1.Location();
            myimage = new MImage(loadedimage);

        }

        private void button1_Click(object sender, EventArgs e)
        {


            fajlnevbe = textBox1.Text;
            if (fajlnevbe == "")
            {
                fajlnevbe = "defaultname";
            }
            fajlnevbe = fajlnevbe + ".jpg";

            loadedimage = new Bitmap(fajlnevbe);
            loadedimage2 = new Bitmap(fajlnevbe);
            pictureBox1.Image = loadedimage;
            myimage = new MImage(loadedimage);
            
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            label2.Text = hScrollBar1.Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            textBox1.Enabled = false;
            hScrollBar1.Enabled = false;

        }

    }
}
