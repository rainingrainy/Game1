using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Game1
{
    class player
    {
        int x, y, width, height;
        Image playerimg;
        Rectangle playerrect;

        public player()
        {
            x = 10;
            y = 10;
            width = 100;
            height = 100;
            playerimg = Properties.Resources.player;
            playerrect = new Rectangle(x, y, width, height);
        }

        public void DrawPlayer(Graphics g)
        {
            g.DrawImage(playerimg, playerrect);
        }
    }
}
