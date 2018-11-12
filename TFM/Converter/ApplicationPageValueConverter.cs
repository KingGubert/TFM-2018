using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFM.Pages;
using TFM.ViewModel;

namespace TFM.Converter
{
    /// <summary>
    /// Dient zur verwaltung aller Pages dieser Application
    /// </summary>
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

           //Je nach übergebener Applicationpage wird eine neue Instanz dieser Seite zurückgegeben
            switch ((ApplicationPage)value)
            {

                case ApplicationPage.Login:
                    return new LoginPage();

                default:
                    //Falls unbekannte Page wird hier angehalten
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
