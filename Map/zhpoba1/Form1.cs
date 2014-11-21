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
            loadedimage = new Bitmap("imagetest3.jpg");
            loadedimage2 = new Bitmap("imagetest3.jpg");
            pictureBox1.Image = loadedimage;
            myimage = new MImage(loadedimage);
            pictureBox2.Image = myimage.GetBMP();
            label1.Text = hScrollBar1.Value.ToString();
            label3.Text = hScrollBar2.Value.ToString();
            label7.Visible = false;
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
        
            label1.Text = hScrollBar1.Value.ToString();
         
    
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            label3.Text = hScrollBar2.Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            fajlnevki = textBox1.Text;
            if (fajlnevki == "")
            {
                fajlnevki = "defaultname";

            }
            fajlnevki = fajlnevki + ".jpg";
            if (fajlnevki == fajlnevbe)
            {
                label7.Visible = true;
            }
            else
            {
                myimage.Save(fajlnevki);
                label7.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
  
            hScrollBar1.Value = hScrollBar1.Minimum;
            hScrollBar2.Value = hScrollBar2.Minimum;
            label1.Text = hScrollBar1.Value.ToString();
            label3.Text = hScrollBar2.Value.ToString();
            pictureBox2.Image = myimage.ResetBMP(loadedimage2);

        }

        private void button4_Click(object sender, EventArgs e)
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
            pictureBox2.Image = myimage.GetBMP();
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            myimage.EnlargeImage(hScrollBar1.Value);
            pictureBox2.Image = myimage.GetBMP();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            myimage.RandomGenerator(hScrollBar2.Value);
            pictureBox2.Image = myimage.GetBMP();
        
        }




 
    }
}
