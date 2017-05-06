using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;

namespace DebugAndTraceAppenders
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
    }
}
