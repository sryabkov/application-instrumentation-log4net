using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using UdpAppenderListener;
using log4net.Core;

namespace UdpAppenderListener
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly UdpListener _listener;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            LogEvents = new ObservableCollection<string>();

            _listener = new UdpListener();
            _listener.LogMessageReceived += (s,a)=>AddLogEvents(a.Message);
            _listener.Start();
        }

        private void AddLogEvents(string message)
        {
            if (Dispatcher.CheckAccess())
            {
                LogEvents.Add(message);
                var item = LogEventListView.Items[ LogEventListView.Items.Count - 1 ];
                LogEventListView.ScrollIntoView( item );
            }
            else
            {
                Dispatcher.BeginInvoke( (Action<string>)AddLogEvents, DispatcherPriority.Normal, message);
            }
        }

        public ObservableCollection<string> LogEvents { get; private set; }
    }
}
