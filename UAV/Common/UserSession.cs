
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;

namespace UAV.Common
{
    public static class PilotSession
    {
        public static string UserType { get; set; }
            public static long UserId { get; set; }
            public static string UserName { get; set; }
            public static string UserEmail { get; set; }
            public static long SurveyId { get; set; }
        
    }
    //public class RowToIndexConvertor : MarkupExtension, IValueConverter
    //{
    //    static RowToIndexConvertor convertor;

    //    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        DataGridRow row = value as DataGridRow;

    //        if (row != null)
    //        {
    //            return row.GetIndex() + 1;
    //        }
    //        else
    //        {
    //            return -1;
    //        }
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override object ProvideValue(IServiceProvider serviceProvider)
    //    {
    //        if (convertor == null)
    //        {
    //            convertor = new RowToIndexConvertor();
    //        }

    //        return convertor;
    //    }


    //    public RowToIndexConvertor()
    //    {

    //    }
    //}



}
