
using System;
using System.Globalization;

namespace BusinessLayer.Convertor
{
    public static class MiladyToShamsi
    {
        public static string ToShamsi(DateTime value)
        {
            PersianCalendar pc= new PersianCalendar();

            return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/"  + pc.GetDayOfMonth(value).ToString("00");    
        }
    }
}
