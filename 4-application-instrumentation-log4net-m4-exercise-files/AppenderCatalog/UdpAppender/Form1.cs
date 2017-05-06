using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;

namespace UdpAppender
{
    public partial class Form1 : Form
    {
        private static ILog Log = LogManager.GetLogger(typeof (Form1));

        public Form1()
        {
            Log.Info( "Creating form");
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            var message = textBox.Text;
            Log.Info( message );
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var message = textBox.Text;
            Log.Warn(message);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var message = textBox.Text;
            Log.Error(message);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var message = textBox.Text;
            Log.Debug(message);
        }
    }
}
