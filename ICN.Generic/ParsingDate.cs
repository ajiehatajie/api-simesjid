using System;
using System.Globalization;

namespace ICN.Generic
{
    public class ParsingDate
    {
        static CultureInfo m_currentCulture = CultureInfo.CurrentCulture;
        static CultureInfo m_cultureLocal = new CultureInfo("id-ID");

        public static string CurrentCultureDateFormat { get { return m_currentCulture.DateTimeFormat.ShortDatePattern; } }
        public static string LocalCultureDateFormat { get { return m_cultureLocal.DateTimeFormat.ShortDatePattern; } }


        public static DateTime ParsingDateServerCulture(string strDate)
        {
            try
            {
                if (!string.IsNullOrEmpty(strDate))
                {
                    strDate = strDate.Split(new char[] { ' ' })[0];
                    strDate = strDate.Replace("-", "/");
                    return DateTime.ParseExact(strDate, m_currentCulture.DateTimeFormat.ShortDatePattern, m_currentCulture);
                }
                else
                {
                    return DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ParsingDateServerCulture(DateTime dtmDate)
        {
            try
            {
                return dtmDate.ToString(m_currentCulture.DateTimeFormat.ShortDatePattern);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DateTime ParsingDateCurrentCulture(string strDate)
        {
            try
            {
                return Convert.ToDateTime(strDate, new CultureInfo("id-ID"));
            }
            catch
            {
                return DateTime.Today;
            }
        }

        public static string ParsingDateCurrentCulture(DateTime dtmDate)
        {
            try
            {
                return dtmDate.ToString(m_currentCulture.DateTimeFormat.ShortDatePattern);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DateTime ParsingDateToLocalFormat(string strDate)
        {
            try
            {
                if (!string.IsNullOrEmpty(strDate))
                {

                    return ParsingDateCurrentCulture(strDate);
                }
                else
                {
                    return DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ParsingDateToLocalFormat(DateTime dtmDate)
        {
            try
            {
                return dtmDate.ToString(m_cultureLocal.DateTimeFormat.ShortDatePattern);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ParsingDateAndTimeToLocalFormat(DateTime dtmDate)
        {
            try
            {
                return dtmDate.ToString(m_cultureLocal.DateTimeFormat.ShortDatePattern) + " - " + dtmDate.ToString(m_cultureLocal.DateTimeFormat.ShortTimePattern);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
