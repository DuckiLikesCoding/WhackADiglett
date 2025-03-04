using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhackADiglett
{
    public partial class Form1 : Form
    {
        static Image Full = WhackADiglett.Properties.Resources.Diglett_Front;
        static Image Half = WhackADiglett.Properties.Resources.Diglett_Half;
        static Image Hole = WhackADiglett.Properties.Resources.Diglett_Hole;
        static Random random = new Random();
        int randomX = 0;
        int randomY = 0;
        int diglettCount = 0;
        int score = 0;
        int speed = 1000;


        public  Form1()
        {
            InitializeComponent();

            for (int x = 0; x <= 3; x++) // x0 to x3
            {
                for (int y = 0; y <= 3; y++) // y0 to y3
                {
                    // create the picture box name 
                    string pictureBoxName = $"x{x}y{y}";

                    // Find the PictureBox by name
                    Control control = this.Controls[pictureBoxName];
                    if (control is PictureBox pictureBox)
                    {
                        pictureBox.Image = Hole;
                    }
                }
            }

            StartLoop();
        }

        private async void StartLoop()
        {
            while (true)
            {
                if (diglettCount < 16)
                {
                    string boxName = RandomCoordinate();

                    Control control = this.Controls[boxName];

                    if (control is PictureBox pictureBox)
                    {
                        if (pictureBox.Image != null && pictureBox.Image == Hole)
                        {
                            DiglettAnimation(pictureBox);
                            await Task.Delay(speed);
                        }
                    }
                }
                else
                { 
                    await Task.Delay(speed);
                }
            }
        }

        private string RandomCoordinate()
        {
            randomX = random.Next(0, 4);
            randomY = random.Next(0, 4);

            return $"x{randomX}y{randomY}";
        }
        private async void DiglettAnimation(PictureBox imageBox)
        {
            if (imageBox.Image == Hole)
            {
                diglettCount++;
                imageBox.Image = Half;
                await Task.Delay(500);
                imageBox.Image = Full;
                StartDisappearanceTimer(imageBox);
            }

            else if (imageBox.Image == Full)
            {
                imageBox.Image = Half;
                await Task.Delay(50);
                imageBox.Image = Hole;
                diglettCount--;
            }
        }

        private void StartDisappearanceTimer(PictureBox imageBox)
        {
            Timer diglettTimer = new Timer();
            int interval = 3000;
            diglettTimer.Interval = interval;
            diglettTimer.Tag = imageBox; // Associate the PictureBox with the timer

            diglettTimer.Tick += (sender, e) =>
            {
                // Check if the Diglett is still visible
                if (imageBox.Image == Full)
                {
                    DiglettAnimation(imageBox);
                }

                // Stop and dispose of the timer
                diglettTimer.Stop();
                diglettTimer.Dispose();
            };

            diglettTimer.Start(); // Start the timer
        }

        private void x0y0_Click(object sender, EventArgs e)
        {
            if (x0y0.Image == Full) {DiglettAnimation(x0y0);}
            
        }
        private void x1y0_Click(object sender, EventArgs e)
        {
            if (x1y0.Image == Full) { DiglettAnimation(x1y0); }
        }
        private void x2y0_Click(object sender, EventArgs e)
        {
            if (x2y0.Image == Full) { DiglettAnimation(x2y0); }
        }
        private void x3y0_Click(object sender, EventArgs e)
        {
            if (x3y0.Image == Full) { DiglettAnimation(x3y0); }
        }
        private void x0y1_Click(object sender, EventArgs e)
        {
            if (x0y1.Image == Full) { DiglettAnimation(x0y1); }

        }
        private void x1y1_Click(object sender, EventArgs e)
        {
            if (x1y1.Image == Full) { DiglettAnimation(x1y1); }

        }
        private void x2y1_Click(object sender, EventArgs e)
        {
            if (x2y1.Image == Full) { DiglettAnimation(x2y1); }

        }
        private void x3y1_Click(object sender, EventArgs e)
        {
            if (x3y1.Image == Full) { DiglettAnimation(x3y1); }

        }
        private void x0y2_Click(object sender, EventArgs e)
        {
            if (x0y2.Image == Full) { DiglettAnimation(x0y2); }
        }
        private void x1y2_Click(object sender, EventArgs e)
        {
            if (x1y2.Image == Full) { DiglettAnimation(x1y2); }
        }
        private void x2y2_Click(object sender, EventArgs e)
        {
            if (x2y2.Image == Full) { DiglettAnimation(x2y2); }
        }
        private void x3y2_Click(object sender, EventArgs e)
        {
            if (x3y2.Image == Full) { DiglettAnimation(x3y2); }

        }
        private void x0y3_Click(object sender, EventArgs e)
        {
            if (x0y3.Image == Full) { DiglettAnimation(x0y3); }

        }
        private void x1y3_Click(object sender, EventArgs e)
        {
            if (x1y3.Image == Full) { DiglettAnimation(x1y3); }

        }
        private void x2y3_Click(object sender, EventArgs e)
        {
            if (x2y3.Image == Full) { DiglettAnimation(x2y3); }

        }
        private void x3y3_Click(object sender, EventArgs e)
        {
            if (x3y3.Image == Full) { DiglettAnimation(x3y3); }

        }
    }
}
