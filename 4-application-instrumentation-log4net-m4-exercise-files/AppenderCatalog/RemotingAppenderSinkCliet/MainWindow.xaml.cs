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

namespace RemotingAppenderSink
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly RemoteAppenderSink _loggingSink;
        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;
            LogEvents = new ObservableCollection<LoggingEvent>();

            _loggingSink = new RemoteAppenderSink();
            _loggingSink.EventsReceived += (s, a) => AddLogEvents(a.LoggingEvents);

            RemotingConfiguration.Configure("remotingappendersink.exe.config", false);
            RemotingServices.Marshal(_loggingSink, "RemoteLogger");
        }

        private void AddLogEvents(IEnumerable<LoggingEvent> loggingEvents)
        {
            if (Dispatcher.CheckAccess())
            {
                loggingEvents.ToList().ForEach( LogEvents.Add );
                var item = LogEventListView.Items[ LogEventListView.Items.Count - 1 ];
                LogEventListView.ScrollIntoView( item );
            }
            else
            {
                Dispatcher.BeginInvoke( (Action<IEnumerable<LoggingEvent>>)AddLogEvents, DispatcherPriority.Normal, loggingEvents);
            }
        }

        public ObservableCollection<LoggingEvent> LogEvents { get; private set; }
    }
}
