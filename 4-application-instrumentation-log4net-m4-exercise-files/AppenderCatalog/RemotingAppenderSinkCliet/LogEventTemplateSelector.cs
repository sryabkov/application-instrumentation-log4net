using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace RemotingAppenderSink
{
    public class LoggingEventStyleConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            FrameworkElement targetElement = values[0] as FrameworkElement;
            var styleName = values[1] as log4net.Core.Level;

            if (styleName == null)
                return null;

            Style newStyle = (Style)targetElement.TryFindResource(styleName.ToString());

            
            return newStyle;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class LogEventTemplateSelector : DataTemplateSelector
    {
        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            var logEvent = item as log4net.Core.LoggingEvent;

            if (null == logEvent )
            {
                return null;
            }

            var ctrl = container as FrameworkElement;
            if (null == ctrl)
            {
                return null;
            }

            var templateName = logEvent.Level.ToString();
            var template = ctrl.TryFindResource(templateName) as DataTemplate;

            return template;

        }
    }
}
