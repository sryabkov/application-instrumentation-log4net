using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WhyYouShouldntUseFileAppenderInProduction
{
    public partial class Form1 : Form
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof (Form1));
        private bool _clicked;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var thread = new Thread(MonitorButtonNotClicked);
            thread.IsBackground = true;
            thread.Start();
        }
        
        private void MonitorButtonNotClicked()
        {
            while (true)
            {
                Log.Info("About to check if button has been pushed....");

                if (_clicked)
                {
                    Log.Warn( "OMG THE BUTTON HAS BEEN PUSHED!!!!1" );
                    return;
                }

                Log.Info( "Button has not been pushed" );
                Thread.Sleep( 10 );                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _clicked = true;
        }
    }
}
