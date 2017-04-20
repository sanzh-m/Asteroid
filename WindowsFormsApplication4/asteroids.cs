using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication4
{
    class asteroids
    {
        public List<PointF> stones;
        public List<int> dir;
        float width, height;
        PointF k;
        Random rnd = new Random(DateTime.Now.Millisecond);

        public asteroids(float width, float height)
        {
            this.width = width;
            this.height = height;
            stones = new List<PointF>();
            dir = new List<int>();
            k = new PointF();
            k.X = 0;
            k.Y = 0;
            stones.Add(k);
            dir.Add(0);
            k.X = width / 2 - 5;
            stones.Add(k);
            dir.Add(1);
            k.X = width - 10;
            stones.Add(k);
            dir.Add(2);
            k.Y = height - 10;
            k.X = width / 2 - 5;
            stones.Add(k);
            dir.Add(5);
            k.X = 0;
            k.Y = height / 2 - 5;
            stones.Add(k);
            dir.Add(7);
            k.X = 0;
            k.Y = height - 10;
            stones.Add(k);
            dir.Add(6);
        }

        public void createStone()
        {
            int k = rnd.Next();
            PointF l = new PointF();
            dir.Add(k%7);
            switch (k % 7)
            {
                case 0:
                    {
                        l.X = 0;
                        l.Y = 0;
                        break;
                    }
                case 1:
                    {
                        l.X = width/2-5;
                        l.Y = 0;
                        break;
                    }
                case 2:
                    {
                        l.X = width -10;
                        l.Y = 0;
                        break;
                    }
                case 3:
                    {
                        l.X = width - 10;
                        l.Y = height/2-5;
                        break;
                    }
                case 4:
                    {
                        l.X = width -10;
                        l.Y = height -10;
                        break;
                    }
                case 5:
                    {
                        l.X = width/2-5;
                        l.Y = height -10;
                        break;
                    }
                case 6:
                    {
                        l.X = 0;
                        l.Y = height - 10;
                        break;
                    }
                case 7:
                    {
                        l.X = 0;
                        l.Y = height/2-5;
                        break;
                    }
            }
            stones.Add(l);
        }
        public void stoneMove(int i)
        {
            PointF l = stones[i];
            switch (dir[i])
            {
                case 0:
                    {
                        l.X+=(float)0.2;
                        l.Y += (float)0.2;
                        break;
                    }
                case 1:
                    {
                        l.Y += (float)0.2;
                        break;
                    }
                case 2:
                    {
                        l.X -=(float)0.2;
                        l.Y += (float)0.2;
                        break;
                    }
                case 3:
                    {
                        l.X -= (float)0.2;
                        break;
                    }
                case 4:
                    {
                        l.X -= (float)0.2;
                        l.Y -= (float)0.2;
                        break;
                    }
                case 5:
                    {
                        l.Y -= (float)0.2;
                        break;
                    }
                case 6:
                    {
                        l.X += (float)0.2;
                        l.Y -= (float)0.2;
                        break;
                    }
                case 7:
                    {
                        l.X += (float)0.2;
                        break;
                    }
            }
            stones[i] = l;
        }
        public void removeStone(int i)
        {
            List<PointF> a = new List<PointF>();
            List<int> b = new List<int>();
            for (int j=0; j<stones.Count; ++j)
            {
                if (j != i) { a.Add(stones[j]); b.Add(dir[j]); }
            }
            stones = a;
            dir = b;
        }
    }
}
