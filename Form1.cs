using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidpointDisplacement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static Bitmap bmp = new Bitmap(583, 426);

        Pen myPen = new Pen(Color.Black);

        Graphics g = Graphics.FromImage(bmp);
        public class Point
        {
            public int x;
            public int y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        Point H1 = new Point(0, 0);
        Point H2 = new Point(0, 0);
        LinkedList<Point> points = new LinkedList<Point>();
        Random rand = new Random(1);
        void CreateList()
        {
            
            points.AddFirst(H1);
            points.AddLast(H2);
        }

        void GeneratePoints(Point h1, Point h2, float R)
        {
            
            //int i = countPoints;
            var first_point = points.First;
            Point h = new Point(0, 0);
            
            first_point = points.First;
            while (first_point != points.Last)
            {                    
                var next_point = first_point.Next;
                var dist = Math.Sqrt(Math.Pow(next_point.Value.x - first_point.Value.x, 2) + Math.Pow(next_point.Value.y - first_point.Value.y, 2));
                h.x = (next_point.Value.x - first_point.Value.x) / 2 + first_point.Value.x;
                h.y = (next_point.Value.y - first_point.Value.y) / 2 + first_point.Value.y + rand.Next(-(int)(R * dist), (int)(R * dist));
                Point hnew = new Point(h.x, h.y);
                //hnew.x = h.x;
                //hnew.y = h.y;
                points.AddAfter(first_point, hnew);
                first_point = next_point;
            }
            g.Clear(Color.White);
            for (var iter = points.First; iter != points.Last; iter = iter.Next)
            {
                g.DrawLine(myPen, iter.Value.x, iter.Value.y, iter.Next.Value.x, iter.Next.Value.y);
            }
            pictureBox1.Image = bmp;
            //Point h = new Point();
            //h.y = (h1.y + h2.y) / 2;
            //h.x = (h1.x + h2.x) / 2 + rand.Next((int)(-R*countPoints), (int)(R*countPoints));
            //countPoints -= 2;
            //while(countPoints != 0)
            //{
            //    points.AddAfter(points.First, h);
            //}
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            H1.x = 0;
            H1.y = pictureBox1.Height / 2;
            H2.x = pictureBox1.Width - 1;
            H2.y = pictureBox1.Height / 2 - 20;
            float R = 0.4f;
            if(textBox1.Text != "")
            {
                H1.x = int.Parse(textBox1.Text);
            }
            if (textBox2.Text != "")
            {
                H1.y = int.Parse(textBox2.Text);
            }
            if (textBox3.Text != "")
            {
                H2.x = int.Parse(textBox3.Text);
            }
            if (textBox4.Text != "")
            {
                H2.y = int.Parse(textBox4.Text);
            }
            if (textBox6.Text != "")
            {
                R = float.Parse(textBox6.Text);
            }
            CreateList();
            GeneratePoints(H1, H2, R);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            points = new LinkedList<Point>();
            g.Clear(Color.White);
            pictureBox1.Image = bmp;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!(Char.IsDigit(number) || char.IsControl(number)))
                e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!(Char.IsDigit(number) || char.IsControl(number)))
                e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!(Char.IsDigit(number) || char.IsControl(number)))
                e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!(Char.IsDigit(number) || char.IsControl(number)))
                e.Handled = true;
        }


        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && (e.KeyChar <= 39 || e.KeyChar >= 46) && number != 47 && number != 61) //калькулятор
                e.Handled = true;
        }
    }
}
