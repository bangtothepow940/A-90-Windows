using System.Windows.Forms;
using System.Timers;
using System.Media;
using System;
using Microsoft.VisualBasic.Devices;
using System.Runtime.CompilerServices;

namespace A_90_Windows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TheThing();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style &= ~0x20000; // WS_MINIMIZEBOX
                return cp;
            }
        }

        public async void TheThing()
        {
            //Event start
            timer1.Stop();
            Form2 form2 = new();
            SoundPlayer playerFakeout = new SoundPlayer(Properties.Resources.FakeoutA90);
            SoundPlayer playerSpawn = new SoundPlayer(Properties.Resources.A90SpawnSound);
            SoundPlayer playerHit = new SoundPlayer(Properties.Resources.A90Hit);

            //Set random Form2 spawn
            Random _random = new();
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            int x = _random.Next(screen.Width - form2.Width);
            int y = _random.Next(screen.Height - form2.Height);
            form2.Location = new Point(x, y);
            //Spawn Form2
            form2.Show();
            playerFakeout.Play();
            await Task.Delay(450);
            form2.Close();
            await Task.Delay(1500);
            //Stop sign
            this.Show();
            playerSpawn.Play();
            int mX = Cursor.Position.X;
            int mY = Cursor.Position.Y;
            await Task.Delay(1000);
            //If the cursor moved, jumpscare user. Else, pass and continue the program.
            if (mX != Cursor.Position.X || mY != Cursor.Position.Y)
            {
                Form3 form3 = new();
                this.Hide();
                playerHit.Play();
                form3.Show();
            }
            else
            {
                //Event end
                await Task.Delay(250);
                this.Hide();
                int newInterval = random.Next(3000, 60000);
                timer1.Interval = newInterval;
                timer1.Start();
            }
        }

        private Random random = new Random();
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}