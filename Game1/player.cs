﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Game1
{
    class player
    {
        int x, y, width, height, speed;
        Image playerimg;
        Rectangle playerrect;

        public player()
        {
            speed = 10;
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

        public void MovePlayer(string move)
        {
            switch (move)
            {
                case "left":
                    x -= speed;
                    playerrect.Location = new Point(x, y);
                    break;

                case "right":
                    x += speed;
                    playerrect.Location = new Point(x, y);
                    break;

                case "up":
                    y -= speed;
                    playerrect.Location = new Point(x, y);
                    break;

                case "down":
                    y += speed;
                    playerrect.Location = new Point(x, y);
                    break;
            }
        }
    }
}
