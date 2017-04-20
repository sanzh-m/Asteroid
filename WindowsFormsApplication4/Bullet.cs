using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication4
{
    class Bullet
    {
        public List<PointF> bullets;
        public List<int> dir;
        float width, height;
        public Bullet(float width, float height)
        {
            bullets = new List<PointF>();
            dir = new List<int>();
            this.width = width;
            this.height = height;

        }

        public void addNewBullet(int dir)
        {
            PointF a = new PointF();
            switch (dir)
            {
                case 0:
                    {
                        a.X = (float)(width / 2 - 20 / Math.Sqrt(2)-7);
                        a.Y = (float)(height / 2 - 20 / Math.Sqrt(2)-7);
                        break;
                    }
                case 1:
                    {
                        a.X = (width / 2);
                        a.Y = (height / 2 - 30);
                        break;
                    }
                case 2:
                    {
                        a.X = ((float)(width / 2 + 20 / Math.Sqrt(2)) +7);
                        a.Y = ((float)(height / 2 - 20 / Math.Sqrt(2))-7);
                        break;
                    }
                case 3:
                    {
                        a.X = (width / 2 + 30);
                        a.Y = (height / 2);
                        break;
                    }
                case 4:
                    {
                        a.X = ((float)(width / 2 + 20 / Math.Sqrt(2)) +7);
                        a.Y = ((float)(height / 2 + 20 / Math.Sqrt(2)) +7);
                        break;
                    }
                case 5:
                    {
                        a.X = (width / 2);
                        a.Y = (height / 2 + 30);
                        break;
                    }
                case 6:
                    {
                        a.X = ((float)(width / 2 - 20 / Math.Sqrt(2)) - 7);
                        a.Y = ((float)(height / 2 + 20 / Math.Sqrt(2)) +7);
                        break;
                    }
                case 7:
                    {
                        a.X = (width / 2 - 30);
                        a.Y = (height / 2);
                        break;
                    }
            }
            bullets.Add(a);
            this.dir.Add(dir);
        }

        public PointF secondPoint(PointF b, int dir)
        {
            PointF a = new PointF();
            switch (dir)
            {
                case 0:
                    {
                        a.X = (float)(b.X + 7);
                        a.Y = (float)(b.Y + 7);
                        break;
                    }
                case 1:
                    {
                        a.X = b.X;
                        a.Y = (b.Y + 10);
                        break;
                    }
                case 2:
                    {
                        a.X = ((float)(b.X - 7));
                        a.Y = ((float)(b.Y + 7));
                        break;
                    }
                case 3:
                    {
                        a.X = (b.X - 10);
                        a.Y = (b.Y);
                        break;
                    }
                case 4:
                    {
                        a.X = ((float)(b.X - 7));
                        a.Y = ((float)(b.Y - 7));
                        break;
                    }
                case 5:
                    {
                        a.X = (b.X);
                        a.Y = (b.Y - 10);
                        break;
                    }
                case 6:
                    {
                        a.X = ((float)(b.X + 7));
                        a.Y = ((float)(b.Y - 7));
                        break;
                    }
                case 7:
                    {
                        a.X = (b.X + 10);
                        a.Y = (b.Y);
                        break;
                    }
            }
            return a;
        }
        public void bulletMove(int i)
        {
            PointF l = bullets[i];
            switch (dir[i])
            {
                case 0:
                    {
                        l.X -= (float)0.4;
                        l.Y -= (float)0.4;
                        break;
                    }
                case 1:
                    {
                        l.Y -= (float)0.4;
                        break;
                    }
                case 2:
                    {
                        l.X += (float)0.4;
                        l.Y -= (float)0.4;
                        break;
                    }
                case 3:
                    {
                        l.X += (float)0.4;
                        break;
                    }
                case 4:
                    {
                        l.X += (float)0.4;
                        l.Y += (float)0.4;
                        break;
                    }
                case 5:
                    {
                        l.Y += (float)0.4;
                        break;
                    }
                case 6:
                    {
                        l.X -= (float)0.4;
                        l.Y += (float)0.4;
                        break;
                    }
                case 7:
                    {
                        l.X -= (float)0.4;
                        break;
                    }
            }
            bullets[i] = l;
        }
        public void removeBullet(int i)
        {
            List<PointF> a = new List<PointF>();
            List<int> b = new List<int>();
            for (int j=0; j<bullets.Count; ++j)
            {
                if (j != i) { a.Add(bullets[j]); b.Add(dir[j]); }
            }
            bullets = a;
            dir = b;
        }
    }
}
