using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        ship ship;
        asteroids asteroids;
        Brush brush;
        Pen pen;
        Bullet bullets;
        bool alive = true;
        public Form1()
        {
            InitializeComponent();
            ship = new ship(ClientSize.Height, ClientSize.Width);
            asteroids = new asteroids(ClientSize.Width, ClientSize.Height);
            brush = new SolidBrush(Color.Black);
            bullets = new Bullet(ClientSize.Width, ClientSize.Height);
            pen = new Pen(Color.Red, 2);
            timer1.Enabled = true;
            timer2.Enabled = true;
            timer1.Interval = 200;
            timer2.Interval = 10;
            timer3.Enabled = true;
            timer3.Interval = 2000;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (alive)
            {
                e.Graphics.FillPolygon(brush, ship.a);
                for (int i = 0; i < asteroids.stones.Count; ++i)
                {
                    e.Graphics.FillEllipse(brush, asteroids.stones[i].X, asteroids.stones[i].Y, 10, 10);
                }
                for (int i=0; i<bullets.bullets.Count; ++i)
                {
                    e.Graphics.DrawLine(pen, bullets.bullets[i], bullets.secondPoint(bullets.bullets[i], bullets.dir[i]));
                }
            }
            else
            {
                e.Graphics.DrawString("GAME OVER", DefaultFont, brush, 200, 250);
                timer1.Enabled = false;
                timer2.Enabled = false;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < asteroids.stones.Count; ++i)
            {
                asteroids.stoneMove(i);
            }
            for (int i = 0; i < bullets.bullets.Count; ++i)
            {
                bullets.bulletMove(i);
            }
            if (checkDeath(ship.a, asteroids.stones)) alive = false;
            checkStonesAndBullets();

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if (ship.dir != 0) --ship.dir;
                else ship.dir = 7;
                ship.setPointsForShip(ship.dir);
            }
            if (e.KeyCode == Keys.Right)
            {
                if (ship.dir != 7) ++ship.dir;
                else ship.dir = 0;
                ship.setPointsForShip(ship.dir);
            }
            if (e.KeyCode == Keys.Space)
            {
                bullets.addNewBullet(ship.dir);
            }
            if (e.KeyCode == Keys.S)
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
            }
        }
        bool checkCollisionLineSegmentAndCircle(PointF a, PointF b, PointF o)
        {
            if (b.Y < a.Y)
            {
                PointF c = b;
                b = a;
                a = c;
            }
            if (Math.Pow(a.X - o.X, 2) + Math.Pow(a.Y - o.Y, 2) < 100) {  return true; }
            if (Math.Pow(b.X - o.X, 2) + Math.Pow(b.Y - o.Y, 2) < 100) {  return true; }
			if (b.X - a.X == 0)
			{
                if (o.X < a.X + 10 && o.X > a.X - 10 && o.Y < b.Y && o.Y > a.Y) {  return true; }
			}
            if (b.Y - a.Y == 0)
            {
                if (a.X < b.X)
                {
                    if (o.X > a.X && o.X < b.X && o.Y < a.Y + 10 && o.Y > a.Y - 10)
                    {
                         return true;
                    }
                }
                else if (o.X > b.X && o.X < a.X && o.Y < a.Y + 10 && o.Y > a.Y - 10) { return true; }
            }
            float k;
            k = (b.X - a.X) * o.X + (b.Y - a.Y) * o.Y - b.X * (b.X - a.X) - b.Y * (b.Y - a.Y);
            float l;
            l = (b.X - a.X) * o.X + (b.Y - a.Y) * o.Y - a.X * (b.X - a.X) - a.Y * (b.Y - a.Y);
            float n;
            float m;
            if (b.X < a.X)
            {
                n = o.Y * (a.X - b.X) + o.X * (b.Y - a.Y) + b.Y * (b.X - a.X) - 10 * (b.Y - a.Y) * (b.X - a.X) / (float)Math.Sqrt(Math.Pow(b.X - a.X, 2)+Math.Pow(b.Y-a.Y, 2)) - b.X*(b.Y- a.Y);
                m = o.Y * (a.X - b.X) + o.X * (b.Y - a.Y) + b.Y * (b.X - a.X) + 10 * (b.Y - a.Y) * (b.X - a.X) / (float)Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2)) - b.X * (b.Y - a.Y);
            }
            n = o.Y * (b.X - a.X) - o.X * (b.Y - a.Y) - b.Y * (b.X - a.X) + 10 * (b.Y - a.Y) * (b.X - a.X) / (float)Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2)) + b.X * (b.Y - a.Y);
            m = o.Y * (b.X - a.X) - o.X * (b.Y - a.Y) - b.Y * (b.X - a.X) - 10 * (b.Y - a.Y) * (b.X - a.X) / (float)Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2)) + b.X * (b.Y - a.Y);
            if (k < 0 && l > 0 && n < 0 && m > 0) {  return true; }
			return false;
        }
        bool checkDeath(PointF[] ship, List<PointF>asteroids)
        {
            for (int i = 0; i < asteroids.Count; ++i)
            {
                if (checkCollisionLineSegmentAndCircle(ship[0], ship[1], asteroids[i]) || checkCollisionLineSegmentAndCircle(ship[2], ship[1], asteroids[i]) || checkCollisionLineSegmentAndCircle(ship[0], ship[2], asteroids[i])) return true;
            }
            return false;
        }

        void checkStonesAndBullets()
        {
            List<int> a = new List<int>();
            List<int> b = new List<int>();
            for (int i=0; i<asteroids.stones.Count; ++i)
            {
                for (int j=0; j<bullets.bullets.Count; ++j)
                {
                    if (Math.Pow(bullets.bullets[j].X - asteroids.stones[i].X-5 , 2) + Math.Pow(bullets.bullets[j].Y - asteroids.stones[i].Y-5, 2) < 25) { a.Add(j); b.Add(i); }
                }
            }
            for (int i=0; i<a.Count; ++i)
            {
                bullets.removeBullet(a[i]);
                asteroids.removeStone(b[i]);
            }
            for (int i=0; i<bullets.bullets.Count; ++i)
            {
                if (bullets.bullets[i].X <= 0 || bullets.bullets[i].Y <= 0 || bullets.bullets[i].X >=ClientSize.Width || bullets.bullets[i].Y >= ClientSize.Height) bullets.removeBullet(i);
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            asteroids.createStone();
        }
    }
}
