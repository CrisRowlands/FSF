using Microsoft.Phone.Controls;
using Microsoft.Phone.Net.NetworkInformation;
using System;
using System.Globalization;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Data;

namespace Classes
{
    public static class Helper
    {
        public static string PageString = "/Pages/MainPage.xaml";
        public static string RemoveHTML(string encodedHTML, bool trim = false)
        {
            string decodedHTML = string.Empty;
            bool inTag = false;

            foreach (char c in encodedHTML.ToCharArray())
            {
                if (c == '<')
                {
                    inTag = true;
                    continue;
                }
                if (c == '>')
                {
                    inTag = false;
                    continue;
                }
                if (!inTag)
                {
                    decodedHTML += c;
                }
            }
            decodedHTML = RemoveExtraEncoding(decodedHTML);
            decodedHTML = decodedHTML.Trim();
            if (trim)
            {
                if (decodedHTML.Length > 120)
                {
                    decodedHTML = decodedHTML.Substring(0, 117) + "...";
                }
            }
            return decodedHTML;
        }
        public static string RemoveExtraEncoding(string html)
        {
            try
            {
                string temp = Regex.Replace(html.
                    Replace("&ndash;", "-").
                    Replace("&nbsp;", " ").
                    Replace("&rsquo;", "'").
                    Replace("&amp;", "&").
                    Replace("&#038;", "&").
                    Replace("&quot;", "\"").
                    Replace("&#039;", "'").
                    Replace("&#8230;", "...").
                    Replace("&#8212;", "—").
                    Replace("&#8211;", "-").
                    Replace("&#8220;", "“").
                    Replace("&#8221;", "”").
                    Replace("&#8217;", "'").
                    Replace("&#160;", " ").
                    Replace("&gt;", ">").
                    Replace("&rdquo;", "\"").
                    Replace("&ldquo;", "\"").
                    Replace("&lt;", "<").
                    Replace("&#215;", "×").
                    Replace("&#8242;", "′").
                    Replace("&#8243;", "″").
                    Replace("&#8216;", "'"),
                    "<[^<>]+>", string.Empty);

                temp = HttpUtility.HtmlDecode(temp);

                return temp;
            }
            catch
            {
                return html;
            }
        }
    }
    #region CONVERTERS.
    public class Capitalise : IValueConverter // CONVERTER TO RETURN A STRING AS ALL CAPITALS.
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value as string).ToUpper();
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
    public class ImageConverter : IValueConverter // TURNS A STRING INTO A BITMAPIMAGE.
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ImageManager.CachedImage(value as string);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
    #endregion
}