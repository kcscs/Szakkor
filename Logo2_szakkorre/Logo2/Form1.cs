using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logo2
{
    public partial class Form1 : Form
    {
        //public static Form1 instance;

        public List<Vonal> lines = new List<Vonal>();
        public List<Kor> circles = new List<Kor>();
        private IParancskezelo parancskezelo;
        private Rajzlap rajzlap;
        private Bitmap teknos;

        private SolidBrush green = new SolidBrush(Color.LightGreen);
        private Pen greenPen = new Pen(Color.LightGreen, 3);

        bool busy = false;

        float markLength = 15;
        int markSize = 10;

        public Form1() {
            InitializeComponent();
            //instance = this;
            parancskezelo = new Parancskezelo();
            rajzlap = new Rajzlap(this);

            parancskezelo.Init();
            //teknos = (Bitmap)Bitmap.FromFile("teknos.png");
        }

        private void parancs_KeyUp(object sender, KeyEventArgs e) {
            if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return && !busy) {
                CallParancs();
            }
        }

        private void CallParancs() {
            busy = true;
            parancskezelo.Parancs(parancs.Text.Trim());
            busy = false;
            parancs.Text = "";
            rajz_Paint(null, null);
        }


        /// <summary>
        /// Rajzol egy vonalat a megadott színnel a rajzlapra a két pont között.
        /// </summary>
        /// <param name="innen"></param>
        /// <param name="ide"></param>
        public void DrawLine(Pont innen, Pont ide, Szin szin, float vastagsag = 1f) {
            lines.Add(new Vonal(innen, ide, szin, vastagsag));
            rajz_Paint(null, null);
        }

        public void DrawCircle(Pont center, float radius, Szin color, float thickness = 1f) {
            circles.Add(new Kor(center, radius, color, thickness));
            rajz_Paint(null, null);
        }

        public void Clear() {
            lines.Clear();
            circles.Clear();
        }

        public void ExportPNG(string path) {

            Bitmap bitmap = new Bitmap(rajz.Width, rajz.Height);
            rajz.DrawToBitmap(bitmap, new Rectangle(0, 0, rajz.Width, rajz.Height));
            bitmap.Save(path);
        }

        private void rajz_Paint(object sender, PaintEventArgs e) {
            Graphics graphics;
            if (e == null)
                graphics = rajz.CreateGraphics();
            else
                graphics = e.Graphics;
            graphics.Clear(Color.White);

            foreach (Vonal line in lines) {
                Pen p = new Pen(line.szin.GetColor(), line.vastagsag);

                graphics.DrawLine(p, line.p1.GetPoint(), line.p2.GetPoint());

                p.Dispose();
            }

            foreach (Kor circle in circles) {
                Pen p = new Pen(circle.szin.GetColor(), circle.vastagsag);

                Point pk = circle.kozeppont.GetPoint();
                graphics.DrawEllipse(p, pk.X - circle.sugar/2, pk.Y - circle.sugar/2, circle.sugar, circle.sugar);

                p.Dispose();
            }

            //Bitmap forgatott = teknos;//RotateImage(teknos, parancskezelo.teknosIrany());
            /*Bitmap forgatott = (Bitmap)RotateImage(teknos, 90);*/
            Point pont = parancskezelo.teknosHely().GetPoint();
            pont.X -= markSize/2;
            pont.Y -= markSize/2;

            /*pont.X += forgatott.Width / 2;
            pont.Y += forgatott.Height / 2;
            graphics.DrawImage(forgatott, pont);*/



            graphics.FillEllipse(green, new RectangleF(pont, new SizeF(markSize,markSize)));

            pont = parancskezelo.teknosHely().GetPoint();
            int x = (int)(Math.Sin(ConvertToRadians(parancskezelo.teknosIrany())) * markLength);
            int y = (int)(Math.Cos(ConvertToRadians(parancskezelo.teknosIrany())) * markLength);
            Point veg = new Point(pont.X+x, pont.Y-y);
            graphics.DrawLine(greenPen, pont, veg);
            //MessageBox.Show($"{x}, {y}");

            graphics.Dispose();
        }

        private void runCommand_Click(object sender, EventArgs e) {
            CallParancs();
        }

        public float ConvertToRadians(float angle) {
            return (float)(Math.PI / 180) * angle;
        }









        // FROM STACKOVERFLOW
        private Bitmap RotateImage(Bitmap b, float Angle) {
            // The original bitmap needs to be drawn onto a new bitmap which will probably be bigger 
            // because the corners of the original will move outside the original rectangle.
            // An easy way (OK slightly 'brute force') is to calculate the new bounding box is to calculate the positions of the 
            // corners after rotation and get the difference between the maximum and minimum x and y coordinates.
            float wOver2 = b.Width / 2.0f;
            float hOver2 = b.Height / 2.0f;
            float radians = -(float)(Angle / 180.0 * Math.PI);
            // Get the coordinates of the corners, taking the origin to be the centre of the bitmap.
            PointF[] corners = new PointF[]{
            new PointF(-wOver2, -hOver2),
            new PointF(+wOver2, -hOver2),
            new PointF(+wOver2, +hOver2),
            new PointF(-wOver2, +hOver2)
        };

            for (int i = 0; i < 4; i++) {
                PointF p = corners[i];
                PointF newP = new PointF((float)(p.X * Math.Cos(radians) - p.Y * Math.Sin(radians)), (float)(p.X * Math.Sin(radians) + p.Y * Math.Cos(radians)));
                corners[i] = newP;
            }

            // Find the min and max x and y coordinates.
            float minX = corners[0].X;
            float maxX = minX;
            float minY = corners[0].Y;
            float maxY = minY;
            for (int i = 1; i < 4; i++) {
                PointF p = corners[i];
                minX = Math.Min(minX, p.X);
                maxX = Math.Max(maxX, p.X);
                minY = Math.Min(minY, p.Y);
                maxY = Math.Max(maxY, p.Y);
            }

            // Get the size of the new bitmap.
            SizeF newSize = new SizeF(maxX - minX, maxY - minY);
            // ...and create it.
            Bitmap returnBitmap = new Bitmap((int)Math.Ceiling(newSize.Width), (int)Math.Ceiling(newSize.Height));
            // Now draw the old bitmap on it.
            using (Graphics g = Graphics.FromImage(returnBitmap)) {
                g.TranslateTransform(newSize.Width / 2.0f, newSize.Height / 2.0f);
                g.RotateTransform(Angle);
                g.TranslateTransform(-b.Width / 2.0f, -b.Height / 2.0f);

                g.DrawImage(b, 0, 0);
            }

            return returnBitmap;
        }
        /*public static Image RotateImage(Image img, float rotationAngle) {
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            bmp.SetResolution(img.HorizontalResolution, img.VerticalResolution);

            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            //now rotate the image
            gfx.RotateTransform(rotationAngle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new Point(0, 0));

            //dispose of our Graphics object
            gfx.Dispose();

            

            //return the image
            return bmp;
        }*/
    }
}
