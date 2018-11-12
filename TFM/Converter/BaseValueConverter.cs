
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace TFM.Converter
{
    /// <summary>
    /// Generic Base Value converter for direct use in xaml, es muss keine staticressource mehr aneglegt werden
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
            where T : class, new()
    {
        #region properties

        private static T mConverter = null;


        // Die zu überschreibenden convertmethoden
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);


        #endregion

        /// <summary>
        /// Für die direkte verwendung der markupextension in xaml, gibt nach einmaligen initialisieren den jeweiligen typ des angefragten converters zurück
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return mConverter ?? (mConverter = new T());
        }
    }
}
