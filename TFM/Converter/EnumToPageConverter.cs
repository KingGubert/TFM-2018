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
    public class EnumToPageConverter : BaseValueConverter<EnumToPageConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            //Je nach übergebener Applicationpage wird eine neue Instanz dieser Seite zurückgegeben
            switch ((ApplicationPage)value)
            {
                //Neue LoginSeite
                case ApplicationPage.Login:
                    return new LoginPage();

                //Neues Spielfenster
                case ApplicationPage.GameScreen:
                    return new GameScreen();

                //Drawstack zur Anzeige der noch zu ziehenden Karten
                case ApplicationPage.DrawStack:
                    return new DrawStack();
			
				case ApplicationPage.test:
					return new test();


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
