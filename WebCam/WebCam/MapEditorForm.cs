using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MakePicFromCam {
    public partial class MapEditorForm : Form {
        public MapEditorForm() {
            InitializeComponent();
        }

        Bitmap loadedimage;
        Bitmap loadedimage2;
        MImage myimage;
        Color colorhsl;
        OnePixelRGB colorrgb;
        String fajlnevki;
        String fajlnevbe;      
       
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




struct OnePixelRGB {
    public int R;
    public int G;
    public int B;
}

struct OnePixelHSL {
    public double H;
    public double S;
    public double L;
}

class MImage {
    protected Bitmap bmp;
    protected Bitmap bmp2;
    protected int szelesseg;
    protected int magassag;
    protected OnePixelRGB[,] pixelsrgb;
    protected OnePixelHSL[,] pixelshsl;
    public MImage(Bitmap ujbitmap) {
        bmp = ujbitmap;
        szelesseg = ujbitmap.Width;
        magassag = ujbitmap.Height;
        pixelsrgb = new OnePixelRGB[szelesseg, magassag];
        pixelshsl = new OnePixelHSL[szelesseg, magassag];
        //for (int i = 0; i < szelesseg; i++)
        //{
        //    for (int j = 0; j < magassag; j++)
        //    {
        //        pixelsrgb[i, j].R = (bmp.GetPixel(i, j)).R;
        //        pixelsrgb[i, j].G = (bmp.GetPixel(i, j)).G;
        //        pixelsrgb[i, j].B = (bmp.GetPixel(i, j)).B;

        //        pixelshsl[i, j].H = (bmp.GetPixel(i, j)).GetHue();
        //        pixelshsl[i, j].S = (bmp.GetPixel(i, j)).GetSaturation();
        //        pixelshsl[i, j].L = (bmp.GetPixel(i, j)).GetBrightness();

        //    }
        //}
        Binarize(bmp);
    }

    public void SetPixelRGB(int x, int y, int r, int g, int b) {
        pixelsrgb[x, y].R = r;
        pixelsrgb[x, y].G = g;
        pixelsrgb[x, y].B = b;
    }


    public void SetPixelHSL(int x, int y, double h, double s, double l) {
        pixelshsl[x, y].H = h;
        pixelshsl[x, y].S = s;
        pixelshsl[x, y].L = l;
    }

    public OnePixelRGB GetPixelRGB(int x, int y) {
        return pixelsrgb[x, y];
    }

    public OnePixelHSL GetPixelHSL(int x, int y) {
        return pixelshsl[x, y];
    }

    public void DrawRGB(int r, int g, int b) {
        Color color = Color.FromArgb(255, r, g, b);

        for (int i = 0; i < szelesseg; i++) {
            for (int j = 0; j < magassag; j++) {
                SetPixelRGB(i, j, r, g, b);
                SetPixelHSL(i, j, color.GetHue(), color.GetSaturation(), color.GetBrightness());
                bmp.SetPixel(i, j, color);
            }
        }
    }


    public static Color ColorFromAhsb(int a, float h, float s, float b) {


        if (0 == s) {
            return Color.FromArgb(a, Convert.ToInt32(b * 255),
              Convert.ToInt32(b * 255), Convert.ToInt32(b * 255));
        }

        float fMax, fMid, fMin;
        int iSextant, iMax, iMid, iMin;

        if (0.5 < b) {
            fMax = b - (b * s) + s;
            fMin = b + (b * s) - s;
        } else {
            fMax = b + (b * s);
            fMin = b - (b * s);
        }

        iSextant = (int)Math.Floor(h / 60f);
        if (300f <= h) {
            h -= 360f;
        }
        h /= 60f;
        h -= 2f * (float)Math.Floor(((iSextant + 1f) % 6f) / 2f);
        if (0 == iSextant % 2) {
            fMid = h * (fMax - fMin) + fMin;
        } else {
            fMid = fMin - h * (fMax - fMin);
        }

        iMax = Convert.ToInt32(fMax * 255);
        iMid = Convert.ToInt32(fMid * 255);
        iMin = Convert.ToInt32(fMin * 255);

        switch (iSextant) {
            case 1:
                return Color.FromArgb(a, iMid, iMax, iMin);
            case 2:
                return Color.FromArgb(a, iMin, iMax, iMid);
            case 3:
                return Color.FromArgb(a, iMin, iMid, iMax);
            case 4:
                return Color.FromArgb(a, iMid, iMin, iMax);
            case 5:
                return Color.FromArgb(a, iMax, iMin, iMid);
            default:
                return Color.FromArgb(a, iMax, iMid, iMin);
        }
    }



    public static OnePixelRGB HSLtoRGB(int a, float h, float s, float b) {
        OnePixelRGB rgb;

        if (0 == s) {
            rgb.R = Convert.ToInt32(b * 255);
            rgb.G = Convert.ToInt32(b * 255);
            rgb.B = Convert.ToInt32(b * 255);
            return rgb;
        }

        float fMax, fMid, fMin;
        int iSextant, iMax, iMid, iMin;

        if (0.5 < b) {
            fMax = b - (b * s) + s;
            fMin = b + (b * s) - s;
        } else {
            fMax = b + (b * s);
            fMin = b - (b * s);
        }

        iSextant = (int)Math.Floor(h / 60f);
        if (300f <= h) {
            h -= 360f;
        }
        h /= 60f;
        h -= 2f * (float)Math.Floor(((iSextant + 1f) % 6f) / 2f);
        if (0 == iSextant % 2) {
            fMid = h * (fMax - fMin) + fMin;
        } else {
            fMid = fMin - h * (fMax - fMin);
        }

        iMax = Convert.ToInt32(fMax * 255);
        iMid = Convert.ToInt32(fMid * 255);
        iMin = Convert.ToInt32(fMin * 255);

        switch (iSextant) {
            case 1:
                rgb.R = iMid;
                rgb.G = iMax;
                rgb.B = iMin;
                return rgb;
            case 2:
                rgb.R = iMin;
                rgb.G = iMax;
                rgb.B = iMid;
                return rgb;
            case 3:
                rgb.R = iMin;
                rgb.G = iMid;
                rgb.B = iMax;
                return rgb;
            case 4:
                rgb.R = iMid;
                rgb.G = iMin;
                rgb.B = iMax;
                return rgb;
            case 5:
                rgb.R = iMax;
                rgb.G = iMin;
                rgb.B = iMid;
                return rgb;

            default:
                rgb.R = iMax;
                rgb.G = iMid;
                rgb.B = iMin;
                return rgb;
        }
    }


    public void DrawHSL(double h, double s, double l) {


        Color color = ColorFromAhsb(255, (float)h, (float)s, (float)l);
        OnePixelRGB rgb = HSLtoRGB(255, (float)h, (float)s, (float)l);
        for (int i = 0; i < szelesseg; i++) {
            for (int j = 0; j < magassag; j++) {
                SetPixelHSL(i, j, h, s, l);
                SetPixelRGB(i, j, rgb.R, rgb.G, rgb.B);
                bmp.SetPixel(i, j, color);

            }
        }
    }


    public void EnlargeImage(int scale) {
        Boolean talalt = false;
        for (int i = 0; i < szelesseg; i++) {
            for (int j = 0; j < magassag; j++) {
                if ((bmp.GetPixel(i, j).GetBrightness() <= (double)0.5) && (bmp.GetPixel(i, j).GetSaturation() <= (double)0.5)) {
                    using (Graphics grf = Graphics.FromImage(bmp)) {
                        using (Brush brsh = new SolidBrush(Color.Black)) {
                            grf.FillEllipse(brsh, i, j, scale, scale);
                            grf.FillEllipse(brsh, (i) - (int)(scale / 5), j - (int)(scale / 5), scale, scale);
                            grf.FillEllipse(brsh, (i) - ((int)(scale / 5)) * 2, j - ((int)(scale / 5)) * 2, scale, scale);
                            grf.FillEllipse(brsh, (i) - ((int)(scale / 5)) * 3, j - ((int)(scale / 5)) * 3, scale, scale);
                            grf.FillEllipse(brsh, (i) - ((int)(scale / 5)) * 4, j - ((int)(scale / 5)) * 4, scale, scale);
                            talalt = true;

                        }


                    }


                }
                if (talalt == true) {
                    j += scale;

                }

            }

            if (talalt == true) {
                i += scale;
                talalt = false;
            }
        }


    }



    public void RandomGenerator(int difficulty) {
        Random rnd = new Random();
        int x = rnd.Next(1, szelesseg);
        int y = rnd.Next(1, magassag);
        int scale = 0;
        int times = 0;

        switch (difficulty) {
            case 1:
                scale = 20;
                times = 10;
                break;
            case 2:
                scale = 30;
                times = 20;
                break;
            case 3:
                scale = 36;
                times = 30;
                break;

            default:
                scale = 20;
                times = 5;
                break;
        }

        for (int i = 0; i <= times; i++) {
            x = rnd.Next(1, szelesseg);
            y = rnd.Next(1, magassag);

            if (((bmp.GetPixel(x, y).GetBrightness() <= (double)0.2) && (bmp.GetPixel(x, y).GetSaturation() <= (double)0.2))) {

                using (Graphics grf = Graphics.FromImage(bmp)) {
                    using (Brush brsh = new SolidBrush(Color.DarkGoldenrod)) {
                        grf.FillEllipse(brsh, x, y, scale, scale);


                    }

                }

            } else {
                while (!((bmp.GetPixel(x, y).GetBrightness() <= (double)0.2) && (bmp.GetPixel(x, y).GetSaturation() <= (double)0.2))) {
                    x = rnd.Next(1, szelesseg);
                    y = rnd.Next(1, magassag);
                }

            }
        }
    }


    public void Binarize(Bitmap temp) {

        for (int i = 0; i < szelesseg; i++) {
            for (int j = 0; j < magassag; j++) {

                if ((temp.GetPixel(i, j).GetBrightness() <= (double)0.23) && (temp.GetPixel(i, j).GetSaturation() <= (double)0.23)) {

                    temp.SetPixel(i, j, Color.Black);
                } else {
                    temp.SetPixel(i, j, Color.White);
                }



            }
        }
    }

    public Bitmap ResetBMP(Bitmap ujbitmap) {
        bmp2 = ujbitmap;
        Binarize(bmp2);
        for (int i = 0; i < szelesseg; i++) {
            for (int j = 0; j < magassag; j++) {
                //pixelsrgb[i, j].R = (bmp2.GetPixel(i, j)).R;
                //pixelsrgb[i, j].G = (bmp2.GetPixel(i, j)).G;
                //pixelsrgb[i, j].B = (bmp2.GetPixel(i, j)).B;

                //pixelshsl[i, j].H = (bmp2.GetPixel(i, j)).GetHue();
                //pixelshsl[i, j].S = (bmp2.GetPixel(i, j)).GetSaturation();
                //pixelshsl[i, j].L = (bmp2.GetPixel(i, j)).GetBrightness();

                bmp.SetPixel(i, j, bmp2.GetPixel(i, j));

            }
        }
        return bmp;
    }

    public Bitmap GetBMP() {
        return bmp;
    }


    public void Save(String fajlnev) {
        bmp.Save(fajlnev);
    }
}