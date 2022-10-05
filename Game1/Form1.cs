using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game1
{
    public partial class Form1 : Form
    {
        player player = new player();
        enemy[] enemy = new enemy[2];
        bool left, right, up, down, hit;
        string move;
        int iframe, i, ecount;
        public Form1()
        {
            ecount = 2;
            InitializeComponent();
            for (int i = 0; i < ecount; i++)
            {
                int x = 10 + (i * 200);
                enemy[i] = new enemy(x);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            player.DrawPlayer(e.Graphics);
            for (i = 0; i < ecount; i++)
            {
                enemy[i].DrawEnemy(e.Graphics);
            }
        }
        private void PlayerTmr(object sender, EventArgs e)
        {
            GamePanel.Invalidate();
            if (left) { move = "left";  player.MovePlayer(move); }
            if (right) { move = "right"; player.MovePlayer(move); }
            if (up) { move = "up"; player.MovePlayer(move); }
            if (down) { move = "down"; player.MovePlayer(move); }
            foreach (enemy enemies in enemy)
            {
                if (player.playerrect.IntersectsWith(enemies.enemyrect) && hit)
                {
                    hit = false;
                    player.x += 5;
                    player.playerrect.Location = new Point(player.x, player.y);
                    GamePanel.BackColor = Color.Red;
                }
            }
            if (hit)
            {
                GamePanel.BackColor = Color.Gray;
            }
        }

        private void HitTmr(object sender, EventArgs e)
        {
            iframe++;
            if (iframe >= 2)
            {
                hit = true;
                iframe = 0;
            }
        }

        private void EnemyTmr(object sender, EventArgs e)
        {
            GamePanel.Invalidate();
            for (i = 0; i < ecount; i++)
            {
                enemy[i].x += enemy[i].enemyspeed;
                if (enemy[i].x > GamePanel.Right - 50)
                {
                    enemy[i].enemyspeed = -enemy[i].enemyspeed;
                }
                if (enemy[i].x < GamePanel.Left)
                {
                    enemy[i].enemyspeed = -enemy[i].enemyspeed;
                }
                enemy[i].MoveEnemy();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.A) { left = true; }
            if (e.KeyData == Keys.D) { right = true; }
            if (e.KeyData == Keys.W) { up = true; }
            if (e.KeyData == Keys.S) { down = true; }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.A) { left = false; }
            if (e.KeyData == Keys.D) { right = false; }
            if (e.KeyData == Keys.W) { up = false; }
            if (e.KeyData == Keys.S) { down = false; }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
    public class MyPanel : System.Windows.Forms.Panel
    {
        public MyPanel()
        {
            this.SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint |
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true);
        }
    }
}
