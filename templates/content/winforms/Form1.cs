using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewApp
{
    public partial class Form1 : Form
    {
        int count = 0;
        
        public Form1 ()
        {
            InitializeComponent ();
        }

        void btnAction_Click (object sender, EventArgs e)
        {
            btnAction.Text = string.Format ("You pressed {0} times.", ++count);
        }
    }
}
