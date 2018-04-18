using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab10
{
    public partial class Form1 : Form
    {
        public Graphics g;
        static int x1 = 0, x2 = 0, x3 = 0, x4 = 0;
        Pen p;
        SolidBrush brush;

        public Form1()
        {
            
            InitializeComponent();
            g = CreateGraphics();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

            timer1.Start();

            Pen p = new Pen(Color.Black, 20);//Выбор цвета и размера
            Rectangle main = new Rectangle(10, 10, 769, 501);//координаты
            g.DrawRectangle(p, main);//draw
            SolidBrush brush = new SolidBrush(Color.Blue);//выбор цвета для заливки
            g.FillRectangle(brush, main);//fill

            p = new Pen(Color.White, 1);//установка цвета для pen - белый,размер 1
            brush = new SolidBrush(Color.White);//установка цвета для brush - белый
            //создал массив прямоугольников т.к для рисования кружков нам необходимо знать координаты как для rectangle
            //на этом моменте закончил с draw и fill для кружков

            //начинаю работу над астероидами

            Point[] arr =
            {
                new Point(160,120),
                new Point(100,180),
                new Point(220,180),
            };

            p = new Pen(Color.Red, 10);
            brush = new SolidBrush(Color.Red);
            g.DrawPolygon(p, arr);
            g.FillPolygon(brush, arr);

            Point[] arrr =
            {
                new Point(100,140),
                new Point(220,140),
                new Point(160,200),
            };
            p = new Pen(Color.Red, 10);
            brush = new SolidBrush(Color.Red);
            g.DrawPolygon(p, arrr);
            g.FillPolygon(brush, arrr);


            Point[] arr1 =
           {
                new Point(240,320),
                new Point(200,360),
                new Point(280,360),
            };
            p = new Pen(Color.Red, 10);
            brush = new SolidBrush(Color.Red);
            g.DrawPolygon(p, arr1);
            g.FillPolygon(brush, arr1);

            Point[] arrr1 =
          {
                new Point(200,340),
                new Point(280,340),
                new Point(240,380),
            };
            p = new Pen(Color.Red, 10);
            brush = new SolidBrush(Color.Red);
            g.DrawPolygon(p, arrr1);
            g.FillPolygon(brush, arrr1);

            Point[] arr2 =
          {
                new Point(540,120),
                new Point(520,160),
                new Point(560,160),
            };
            p = new Pen(Color.Red, 10);
            brush = new SolidBrush(Color.Red);
            g.DrawPolygon(p, arr2);
            g.FillPolygon(brush, arr2);

            Point[] arrr2 =
          {
                new Point(520,140),
                new Point(560,140),
                new Point(540,180),
            };
            p = new Pen(Color.Red, 10);
            brush = new SolidBrush(Color.Red);
            g.DrawPolygon(p, arrr2);
            g.FillPolygon(brush, arrr2);

            Point[] arr3 =
          {
                new Point(500,380),
                new Point(440,440),
                new Point(560,440),
            };
            p = new Pen(Color.Red, 10);
            brush = new SolidBrush(Color.Red);
            g.DrawPolygon(p, arr3);
            g.FillPolygon(brush, arr3);

            Point[] arrr3 =
          {
                new Point(440,400),
                new Point(560,400),
                new Point(500,460),
            };
            p = new Pen(Color.Red, 10);
            brush = new SolidBrush(Color.Red);
            g.DrawPolygon(p, arrr3);
            g.FillPolygon(brush, arrr3);

            //Желтый многоугольник в середине
            Point[] mn =
            {
                new Point(380,200),
                new Point(420,220),
                new Point(420,280),
                new Point(380,300),
                new Point(340,280),
                new Point(340,220),
            };
            p = new Pen(Color.Yellow, 10);
            brush = new SolidBrush(Color.Yellow);
            g.DrawPolygon(p, mn);
            g.FillPolygon(brush, mn);

            Point[] str =
            {
                new Point(380,220),
                new Point(400,240),
                new Point(390,240),
                new Point(390,260),
                new Point(370,260),
                new Point(370,240),
                new Point(360,240),

            };
            p = new Pen(Color.Green, 10);
            brush = new SolidBrush(Color.Green);
            g.DrawPolygon(p, str);
            g.FillPolygon(brush, str);

            button1.Visible = false;

            Rectangle r = new Rectangle(340, 420, 75, 40);
            p = new Pen(Color.Blue, 10);
            brush = new SolidBrush(Color.Blue);
            g.DrawRectangle(p, r);
            g.FillRectangle(brush, r);
            Draw();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {


        }
        int dx1 = 10;

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i <100;i++) 
                if (x1 + 100 > Width || x1 < 0)
                    dx1 *= -1;
            
            x1 += dx1;

            Refresh();
            Draw();
        }
        List<Rectangle> circle = new List<Rectangle>();
        Rectangle[] ell =
            {
                new Rectangle(x1 +60,60,40,40),
                new Rectangle(x2 +520,300,40,40),
                new Rectangle(x3 +705,440,40,40),
                new Rectangle(x4 +725,200,40,40),
                new Rectangle(320,20,40,40),
                new Rectangle(460,80,40,40),
                new Rectangle(320,360,40,40),
                new Rectangle(100,400,40,40),
            };

        private void Draw()
        {

            p = new Pen(Color.White, 1);//установка цвета для pen - белый,размер 1
            brush = new SolidBrush(Color.White);

            for (int i = 0; i < ell.Length; ++i)
            {
                g.DrawEllipse(p, ell[i]);
                g.FillEllipse(brush, ell[i]);
                circle.Add(ell[i]);
            }

        }
    }

    internal class Triangle
    {

        public Triangle(int x1, int y1, int x2, int y2, int x3, int y3)
        {


        }
    }
}
