using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication4
{
    class ship
    {
        public PointF[] a;
        public int dir;
        float width, height;
        public ship(float height, float width)
        {
            this.dir = 0;
            a = new PointF[3];
            a[0].X = (float)(width / 2 - 20 / Math.Sqrt(2));
            a[0].Y = (float)(height / 2 - 20 / Math.Sqrt(2));
            a[1].X = width / 2 + 20;
            a[1].Y = height / 2;
            a[2].X = width / 2;
            a[2].Y = height / 2 + 20;
            this.height = height;
            this.width = width;
        }

        public void setPointsForShip(int dir)
        {
            switch (dir)
            {
                case 0:
                    {
                        a[0].X = (float)(width / 2 - 20 / Math.Sqrt(2));
                        a[0].Y = (float)(height / 2 - 20 / Math.Sqrt(2));
                        a[1].X = (width / 2 + 20);
                        a[1].Y = (height / 2);
                        a[2].X = (width / 2);
                        a[2].Y = (height / 2 + 20);
                        break;
                    }
                case 1:
                    {
                        a[0].X = (width / 2);
                        a[0].Y = (height / 2 - 20);
                        a[1].X = ((float)(width / 2 + 20 / Math.Sqrt(2)));
                        a[1].Y = ((float)(height / 2 + 20 / Math.Sqrt(2)));
                        a[2].X = ((float)(width / 2 - 20 / Math.Sqrt(2)));
                        a[2].Y = ((float)(height / 2 + 20 / Math.Sqrt(2)));
                        break;
                    }
                case 2:
                    {
                        a[0].X =((float)(width / 2 + 20 / Math.Sqrt(2)));
                        a[0].Y = ((float)(height / 2 - 20 / Math.Sqrt(2)));
                        a[1].X = (width / 2);
                        a[1].Y = (height / 2 + 20);
                        a[2].X = (width / 2 - 20);
                        a[2].Y = (height / 2);
                        break;
                    }
                case 3:
                    {
                        a[0].X = (width / 2 + 20);
                        a[0].Y = (height / 2);
                        a[1].X = ((float)(width / 2 - 20 / Math.Sqrt(2)));
                        a[1].Y = ((float)(height / 2 + 20 / Math.Sqrt(2)));
                        a[2].X = ((float)(width / 2 - 20 / Math.Sqrt(2)));
                        a[2].Y = ((float)(height / 2 - 20 / Math.Sqrt(2)));
                        break;
                    }
                case 4:
                    {
                        a[0].X = ((float)(width / 2 + 20 / Math.Sqrt(2)));
                        a[0].Y = ((float)(height / 2 + 20 / Math.Sqrt(2)));
                        a[1].X = (width / 2 - 20);
                        a[1].Y = (height / 2);
                        a[2].X = (width / 2);
                        a[2].Y = (height / 2 - 20);
                        break;
                    }
                case 5:
                    {
                        a[0].X = (width / 2);
                        a[0].Y = (height / 2 + 20);
                        a[1].X = ((float)(width / 2 - 20 / Math.Sqrt(2)));
                        a[1].Y = ((float)(height / 2 - 20 / Math.Sqrt(2)));
                        a[2].X = ((float)(width / 2 + 20 / Math.Sqrt(2)));
                        a[2].Y = ((float)(height / 2 - 20 / Math.Sqrt(2)));
                        break;
                    }
                case 6:
                    {
                        a[0].X = ((float)(width / 2 - 20 / Math.Sqrt(2)));
                        a[0].Y = ((float)(height / 2 + 20 / Math.Sqrt(2)));
                        a[1].X = (width / 2);
                        a[1].Y = (height / 2 - 20);
                        a[2].X = (width / 2 + 20);
                        a[2].Y = (height / 2);
                        break;
                    }
                case 7:
                    {
                        a[0].X = (width / 2 - 20);
                        a[0].Y = (height / 2);
                        a[1].X = ((float)(width / 2 + 20 / Math.Sqrt(2)));
                        a[1].Y = ((float)(height / 2 - 20 / Math.Sqrt(2)));
                        a[2].X = ((float)(width / 2 + 20 / Math.Sqrt(2)));
                        a[2].Y = ((float)(height / 2 + 20 / Math.Sqrt(2)));
                        break;
                    }
            }
        }

    }
}
