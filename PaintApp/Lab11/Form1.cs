using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;

namespace Lab11
{
    enum Item
    {
        Rectangle, Triangle, Ellipse, Line, Text, Pen, FloodFill,Eraser,RightTriangle
    }
    public partial class Form1 : Form
    {
        Color paintcolor;
        Color initColor, fillColor;

        Queue<Point> q = new Queue<Point>();
        Graphics g = default(Graphics);
        Bitmap bmp;
        Pen pen = new Pen(Color.Black,1);
        bool chose = false;
        bool draw = false;
        int x, y, lx = 0, ly = 0;
        Item CurrItem = Item.Pen;
        int Xaxis = 0;
        int Yaxis = 0;
        public Form1()
        {
            InitializeComponent();

            bmp = new Bitmap(PaintBox.Width, PaintBox.Height);
            g = Graphics.FromImage(bmp);
            PaintBox.Image = bmp;

            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
          //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;


        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void PaintBox_Click(object sender, EventArgs e)
        {

        }

        private void PaintBox_MouseClck(object sender, MouseEventArgs e)
        {

        }
        Point firstPoint;
        Point secondPoint;
        bool pressmouse = false;
        public void check(int x, int y)
        {
            if (x < 0 || x >= PaintBox.Width || y < 0 || y >= PaintBox.Height)
                return;

            if (bmp.GetPixel(x, y) == initColor)
            {
                q.Enqueue(new Point(x, y));
                bmp.SetPixel(x, y, paintcolor);
            }
        }
        private void PaintBox_MouseDwn(object sender, MouseEventArgs e)
        {
            pressmouse = true;
            draw = true;
            x = e.X;
            y = e.Y;
            firstPoint =e.Location;
            if (CurrItem == Item.FloodFill)
            {
                initColor = bmp.GetPixel(e.X, e.Y);
                q.Enqueue(new Point(e.X, e.Y));
                bmp.SetPixel(e.X, e.Y, paintcolor);
                while (q.Count > 0)
                {
                    secondPoint = q.Dequeue();
                    check(secondPoint.X + 1, secondPoint.Y);
                    check(secondPoint.X - 1, secondPoint.Y);

                    check(secondPoint.X, secondPoint.Y + 1);
                    check(secondPoint.X, secondPoint.Y - 1);

                   // PaintBox.Refresh();
                    Thread.Sleep(0);
                }

            }
        }

        private void PaintBox_MouseUp(object sender, MouseEventArgs e)
        {
           

            draw = false;
            lx = e.X;
            ly = e.Y;
            switch (CurrItem)
            {

                case Item.Rectangle:
                    g.DrawRectangle(new Pen(paintcolor), x, y, secondPoint.X - x, secondPoint.Y - y);
                    break;
                case Item.Ellipse:
                    g.DrawEllipse(new Pen(paintcolor), x, y, secondPoint.X - x, secondPoint.Y - y);
                    break;
                case Item.Eraser:
                    g.FillEllipse(new SolidBrush(PaintBox.BackColor), secondPoint.X - x + x, secondPoint.Y - y + y, Convert.ToInt32(ToolSizeBox.Text), Convert.ToInt32(ToolSizeBox.Text));
                    break;
                case Item.Pen:
                    break;
                case Item.Line:
                    g.DrawLine(new Pen(paintcolor), firstPoint, secondPoint);
                    break;
                case Item.FloodFill:
                    break;
                case Item.Triangle:
                    Point[] points = { new Point(x, secondPoint.Y), new Point((secondPoint.X + x) / 2, y), new Point(secondPoint.X, secondPoint.Y) };
                    g.DrawPolygon(new Pen(paintcolor), points);
                    break;
                case Item.RightTriangle:
                    g.DrawPolygon(new Pen(paintcolor), PryamugTreug(firstPoint, secondPoint));
                    break;
                default:
                    break;

            }

            PaintBox.Refresh();

        }

        private void PaintBox_MouseMove(object sender, MouseEventArgs e)
        {
            Xaxis = e.X;
            Yaxis = e.Y;
            YboxLocation.Text = Yaxis.ToString();
            XboxLocation.Text = Xaxis.ToString();
            secondPoint = e.Location;

            if (draw)
            {


                //g = PaintBox.CreateGraphics();
                switch (CurrItem)
                {

                    case Item.Rectangle:
                    
                        break;
                    case Item.Ellipse:

                        break;
                    case Item.Eraser:
                        g.FillEllipse(new SolidBrush(PaintBox.BackColor), e.X - x + x, e.Y - y + y, Convert.ToInt32(ToolSizeBox.Text), Convert.ToInt32(ToolSizeBox.Text));
                        break;
                    case Item.Pen:
                        g.DrawLine(new Pen(paintcolor, Convert.ToInt32(ToolSizeBox.Text)), firstPoint, secondPoint);
                        firstPoint = secondPoint;

                        break;
                    case Item.Line:

                        break;

                    case Item.Triangle:


                        break;
                    case Item.RightTriangle:

                        break;
                    default:
                        break;


                }
                PaintBox.Refresh();


            }
        }
        public void floodfill()
        {

        }
        Point[] PryamugTreug(Point R, Point T)
        {
            Point[] points = new Point[]

            {
                R,
                T,
                new Point(R.X,T.Y)
                
            };

            return points;

        }
        private void RectangleBtn_Click(object sender, EventArgs e)
        {
            CurrItem = Item.Rectangle;
        }

        private void TriangleBtn_Click(object sender, EventArgs e)
        {
            CurrItem = Item.Triangle;

        }

        private void EllipseBtn_Click(object sender, EventArgs e)
        {
            CurrItem = Item.Ellipse;

        }

        private void LineBtn_Click(object sender, EventArgs e)
        {
            CurrItem = Item.Line;

        }

        private void TextBtn_Click(object sender, EventArgs e)
        {
            CurrItem = Item.Text;

        }

        private void PenBtn_Click(object sender, EventArgs e)
        {
            CurrItem = Item.Pen;

        }

        private void FloodFillBtn_Click(object sender, EventArgs e)
        {
            CurrItem = Item.FloodFill;

        }

        

        private void EraserBtn_Click(object sender, EventArgs e)
        {
            CurrItem = Item.Eraser;
        }

        private void DeleteFile_Btn_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            PaintBox.Refresh();
        }

        private void OpenFile_Btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Png files|*.png|Jpeg files|*.jpeg|Bitmaps|*.bmp";
            if(op.ShowDialog()== DialogResult.OK)
            {
                PaintBox.Image = (Image)Image.FromFile(op.FileName).Clone();
            }
        }

        private void SaveFile_Btn_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(PaintBox.Width, PaintBox.Height);
            g = Graphics.FromImage(bmp);
            Rectangle r = PaintBox.RectangleToScreen(PaintBox.ClientRectangle);
            g.CopyFromScreen(r.Location, Point.Empty, PaintBox.Size);
            g.Dispose();
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "Png files|*.png|Jpeg files|*.jpeg|Bitmaps|*.bmp";
            if(sv.ShowDialog()== DialogResult.OK)
            {
                if (sv.FileName.Contains(".jpeg"))
                {
                    bmp.Save(sv.FileName, ImageFormat.Jpeg);
                }
                else if (sv.FileName.Contains(".png"))
                {
                    bmp.Save(sv.FileName, ImageFormat.Png);
                }
                else if (sv.FileName.Contains(".bmp"))
                {
                    bmp.Save(sv.FileName, ImageFormat.Bmp);
                }
            }
        }

        private void PaintBox_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            if (pressmouse)
            {
                switch (CurrItem)
                {

                    case Item.Rectangle:
                        e.Graphics.DrawRectangle(new Pen(paintcolor), x, y, secondPoint.X - x, secondPoint.Y - y);
                        break;
                    case Item.Ellipse:
                        e.Graphics.DrawEllipse(new Pen(paintcolor), x, y, secondPoint.X - x, secondPoint.Y - y);
                        break;
                    case Item.Eraser:
                        e.Graphics.FillEllipse(new SolidBrush(PaintBox.BackColor), secondPoint.X - x + x, secondPoint.Y - y + y, Convert.ToInt32(ToolSizeBox.Text), Convert.ToInt32(ToolSizeBox.Text));
                        break;
                    case Item.Pen:
                        break;
                    case Item.Line:
                        e.Graphics.DrawLine(new Pen(paintcolor), firstPoint, secondPoint);
                        break;
                    case Item.FloodFill:
                        break;
                    case Item.Triangle:
                        Point[] points = { new Point(x, secondPoint.Y), new Point((secondPoint.X + x) / 2, y), new Point(secondPoint.X, secondPoint.Y) };
                        e.Graphics.DrawPolygon(new Pen(paintcolor), points);
                        break;
                    case Item.RightTriangle:
                        e.Graphics.DrawPolygon(new Pen(paintcolor), PryamugTreug(firstPoint, secondPoint));
                        break;
                    case Item.Text:
                        break;
                    default:
                        break;

                }
            }
            
        }

        private void RightTriangleBtn_Click(object sender, EventArgs e)
        {
            CurrItem = Item.RightTriangle;
        }

       
       
        private void StartDrawBtn_Click(object sender, EventArgs e)
        {
           
            if (CurrItem == Item.Text)
            {


                //g = PaintBox.CreateGraphics();
                if (FontStyleBox.Text == "Regular")
                {
                    g.DrawString(TextDrawBox.Text, new Font(FontFamilyComboBox.Text, Convert.ToInt32(FontSizeBox.Text), FontStyle.Regular), new SolidBrush(paintcolor), new PointF(Xaxis, Yaxis));
                }
                if (FontStyleBox.Text == "Italic")
                {
                    g.DrawString(TextDrawBox.Text, new Font(FontFamilyComboBox.Text, Convert.ToInt32(FontSizeBox.Text), FontStyle.Italic), new SolidBrush(paintcolor), new PointF(Xaxis, Yaxis));

                }
                if (FontStyleBox.Text == "Underline")
                {
                    g.DrawString(TextDrawBox.Text, new Font(FontFamilyComboBox.Text, Convert.ToInt32(FontSizeBox.Text), FontStyle.Underline), new SolidBrush(paintcolor), new PointF(Xaxis, Yaxis));

                }
                if (FontStyleBox.Text == "Bold")
                {
                    g.DrawString(TextDrawBox.Text, new Font(FontFamilyComboBox.Text, Convert.ToInt32(FontSizeBox.Text), FontStyle.Bold), new SolidBrush(paintcolor), new PointF(Xaxis, Yaxis));

                }
                if (FontStyleBox.Text == "StrikeOut")
                {

                    g.DrawString(TextDrawBox.Text, new Font(FontFamilyComboBox.Text, Convert.ToInt32(FontSizeBox.Text), FontStyle.Strikeout), new SolidBrush(paintcolor), new PointF(Xaxis, Yaxis));

                }
                g.Dispose();
            }
            else { MessageBox.Show("Your text empty"); }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FontFamily[] family = FontFamily.Families;
            foreach(FontFamily font in family)
            {
                FontFamilyComboBox.Items.Add(font.GetName(1).ToString());
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (CurrItem == Item.Text)
            {


                //g = PaintBox.CreateGraphics();
                if (FontStyleBox.Text == "Regular")
                {
                    g.DrawString(TextDrawBox.Text, new Font(FontFamilyComboBox.Text, Convert.ToInt32(FontSizeBox.Text), FontStyle.Regular), new SolidBrush(paintcolor), new PointF(Xaxis, Yaxis));
                }
                if (FontStyleBox.Text == "Italic")
                {
                    g.DrawString(TextDrawBox.Text, new Font(FontFamilyComboBox.Text, Convert.ToInt32(FontSizeBox.Text), FontStyle.Italic), new SolidBrush(paintcolor), new PointF(Xaxis, Yaxis));

                }
                if (FontStyleBox.Text == "Underline")
                {
                    g.DrawString(TextDrawBox.Text, new Font(FontFamilyComboBox.Text, Convert.ToInt32(FontSizeBox.Text), FontStyle.Underline), new SolidBrush(paintcolor), new PointF(Xaxis, Yaxis));

                }
                if (FontStyleBox.Text == "Bold")
                {
                    g.DrawString(TextDrawBox.Text, new Font(FontFamilyComboBox.Text, Convert.ToInt32(FontSizeBox.Text), FontStyle.Bold), new SolidBrush(paintcolor), new PointF(Xaxis, Yaxis));

                }
                if (FontStyleBox.Text == "StrikeOut")
                {

                    g.DrawString(TextDrawBox.Text, new Font(FontFamilyComboBox.Text, Convert.ToInt32(FontSizeBox.Text), FontStyle.Strikeout), new SolidBrush(paintcolor), new PointF(Xaxis, Yaxis));

                }
                g.Dispose();
            }
        }

        private void ColorBox_MouseDwn(object sender, MouseEventArgs e)
        {
            chose = true;
        }

        private void ColorBox_MouseUp(object sender, MouseEventArgs e)
        {
            chose = false;
        }

        private void ColorBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (chose)
            {
                Bitmap bmp = (Bitmap)ColorBox.Image.Clone();
                paintcolor = bmp.GetPixel(e.X, e.Y);
                ChosenColorBox.BackColor = paintcolor;
            }
        }
        
    }
}
