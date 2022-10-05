using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Game1
{
    class enemy
    {
        public int x { get; set; } 
        public int y { get; set; }
        public int enemyspeed { get; set; }
        int width, height;
        Image enemyimg;
        public Rectangle enemyrect;
        public enemy(int spacing)
        {
            enemyspeed = 0;
            x = spacing;
            y = 10;
            width = 100;
            height = 100;
            enemyimg = Properties.Resources.enemy;
            enemyrect = new Rectangle(x, y, width, height);
        }
        public void DrawEnemy(Graphics g)
        {
            g.DrawImage(enemyimg, enemyrect);
        }

        public void MoveEnemy()
        {
            enemyrect.Location = new Point(x, y);
        }
    }
}
