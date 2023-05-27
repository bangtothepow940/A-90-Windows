using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_90_Windows
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            End();
        }

        public async void End()
        {
            await Task.Delay(1350);
            this.Close();
            BS();
        }
        private static void BS()
        {
            foreach (Screen screen in Screen.AllScreens)
            {
                Form2 bsForm2 = new();
                bsForm2.StartPosition = FormStartPosition.Manual;
                bsForm2.FormBorderStyle = FormBorderStyle.None;
                bsForm2.BackColor = Color.Black;
                bsForm2.Bounds = screen.Bounds;
                bsForm2.Show();
            }
        }
    }
}
