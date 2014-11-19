using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;



    struct OnePixelRGB{
        public int R;
        public int G;
        public int B;
    }

    struct OnePixelHSL
    {
        public double H;
        public double S;
        public double L;
    }

    class MImage
    {
        protected Bitmap bmp;
        protected Bitmap bmp2;
        protected int szelesseg;
        protected int magassag;
        protected OnePixelRGB[,] pixelsrgb;
        protected OnePixelHSL[,] pixelshsl;
        public MImage(Bitmap ujbitmap)
        {
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

        public void SetPixelRGB(int x, int y, int r, int g, int b)
        {
            pixelsrgb[x, y].R = r;
            pixelsrgb[x, y].G = g;
            pixelsrgb[x, y].B = b;
        }


        public void SetPixelHSL(int x, int y, double h, double s, double l)
        {
            pixelshsl[x, y].H = h;
            pixelshsl[x, y].S = s;
            pixelshsl[x, y].L = l;
        }

        public OnePixelRGB GetPixelRGB(int x, int y)
        {
            return pixelsrgb[x, y];
        }

        public OnePixelHSL GetPixelHSL(int x, int y)
        {
            return pixelshsl[x, y];
        }

        public void DrawRGB(int r, int g, int b)
        {
            Color color = Color.FromArgb(255,r, g, b);
            
            for (int i = 0; i < szelesseg; i++)
            {
                for (int j = 0; j < magassag; j++)
                {
                   SetPixelRGB(i, j, r, g, b);
                   SetPixelHSL(i, j, color.GetHue(), color.GetSaturation(), color.GetBrightness());
                   bmp.SetPixel(i, j, color);
                }
            }
        }


      public static Color ColorFromAhsb(int a, float h, float s, float b)
        {

           
            if (0 == s)
            {
                return Color.FromArgb(a, Convert.ToInt32(b * 255),
                  Convert.ToInt32(b * 255), Convert.ToInt32(b * 255));
            }

            float fMax, fMid, fMin;
            int iSextant, iMax, iMid, iMin;

            if (0.5 < b)
            {
                fMax = b - (b * s) + s;
                fMin = b + (b * s) - s;
            }
            else
            {
                fMax = b + (b * s);
                fMin = b - (b * s);
            }

            iSextant = (int)Math.Floor(h / 60f);
            if (300f <= h)
            {
                h -= 360f;
            }
            h /= 60f;
            h -= 2f * (float)Math.Floor(((iSextant + 1f) % 6f) / 2f);
            if (0 == iSextant % 2)
            {
                fMid = h * (fMax - fMin) + fMin;
            }
            else
            {
                fMid = fMin - h * (fMax - fMin);
            }

            iMax = Convert.ToInt32(fMax * 255);
            iMid = Convert.ToInt32(fMid * 255);
            iMin = Convert.ToInt32(fMin * 255);

            switch (iSextant)
            {
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



      public static OnePixelRGB HSLtoRGB(int a, float h, float s, float b)
      {
          OnePixelRGB rgb;

          if (0 == s)
          {
              rgb.R = Convert.ToInt32(b * 255);
              rgb.G = Convert.ToInt32(b * 255);
              rgb.B = Convert.ToInt32(b * 255);
              return rgb;
          }

          float fMax, fMid, fMin;
          int iSextant, iMax, iMid, iMin;

          if (0.5 < b)
          {
              fMax = b - (b * s) + s;
              fMin = b + (b * s) - s;
          }
          else
          {
              fMax = b + (b * s);
              fMin = b - (b * s);
          }

          iSextant = (int)Math.Floor(h / 60f);
          if (300f <= h)
          {
              h -= 360f;
          }
          h /= 60f;
          h -= 2f * (float)Math.Floor(((iSextant + 1f) % 6f) / 2f);
          if (0 == iSextant % 2)
          {
              fMid = h * (fMax - fMin) + fMin;
          }
          else
          {
              fMid = fMin - h * (fMax - fMin);
          }

          iMax = Convert.ToInt32(fMax * 255);
          iMid = Convert.ToInt32(fMid * 255);
          iMin = Convert.ToInt32(fMin * 255);

          switch (iSextant)
          {
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


        public void DrawHSL(double h, double s, double l)
        {


         Color color = ColorFromAhsb(255, (float)h, (float)s, (float)l);
         OnePixelRGB rgb = HSLtoRGB(255, (float)h, (float)s, (float)l);
            for (int i = 0; i < szelesseg; i++)
            {
                for (int j = 0; j < magassag; j++)
                {
                   SetPixelHSL(i, j,  h,  s,  l);
                   SetPixelRGB(i, j, rgb.R, rgb.G, rgb.B);
                   bmp.SetPixel(i, j, color);

                }
            }
        }


        public void EnlargeImage(int scale) {
            for (int i = 0; i < szelesseg; i++)
            {
                for (int j = 0; j < magassag; j++)
                {
                    if ((bmp.GetPixel(i, j).GetBrightness() <= (double)0.5) && (bmp.GetPixel(i, j).GetSaturation() <= (double)0.5))
                    {
                    using (Graphics grf = Graphics.FromImage(bmp))
                    {
                        using (Brush brsh = new SolidBrush(Color.Black))
                        {
                            grf.FillEllipse(brsh, i, j, scale, scale);
                          
                        }
                          i += scale;
                          j += scale;
                    }
                }

                }
            }
           
        
        }


        public void Binarize(Bitmap temp)
        {

            for (int i = 0; i < szelesseg; i++)
            {
                for (int j = 0; j < magassag; j++)
                {

                    if ((temp.GetPixel(i, j).GetBrightness() <= (double)0.2) && (temp.GetPixel(i, j).GetSaturation() <= (double)0.2))
                    {

                        temp.SetPixel(i, j, Color.Black);
                    }
                    else
                    {
                        temp.SetPixel(i, j, Color.White);
                    }



                }
            }
        }

        public Bitmap ResetBMP(Bitmap ujbitmap) {
            bmp2 = ujbitmap;
            Binarize(bmp2);
            for (int i = 0; i < szelesseg; i++)
            {
                for (int j = 0; j < magassag; j++)
                {
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

        public Bitmap GetBMP()
        {
            return bmp;
        }


        public void Save(String fajlnev)
        {
            bmp.Save(fajlnev);
        }
    }






namespace zhpoba1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
