/**
@file
    StringHelper.cs
@author
    William Chang
@version
    0.2
@date
    - Created: 2009-08-11
    - Modified: 2015-08-28
    .
@note
    References:
    - General:
        - Nothing.
        .
    .
*/

using System;

namespace SandboxAspnetMvc5.Web.Helpers {

public static class StringHelper
{
    /// <summary>Is expected value equal to one of the listed values.</summary>
    public static bool IsEqual(object expected, params string[] actuals)
    {
        if(expected != null) {
            string typedExpected = Convert.ToString(expected);
            for(int i = 0;i < actuals.Length;i += 1) {
                if(String.Equals(typedExpected, actuals[i])) {return true;}
            }
        }
        return false;
    }

    /// <summary>Convert string (from request form) to nullable type.</summary>
    /// <remarks>
    /// Extension method.
    /// http://stackoverflow.com/questions/773078/c-convert-string-to-nullable-type-int-double-etc
    /// </remarks>
    public static T? ToNullable<T>(this string value) where T : struct
    {
        if(!String.IsNullOrEmpty(value.Trim())) {
            return (T)Convert.ChangeType(value, typeof(T));
        } else {
            return null;
        }
    }

    /// <summary>Convert string (from request form) to type. If null, return default value.</summary>
    /// <remarks>Extension method.</remarks>
    public static T ToTypeOrDefault<T>(this string value, T defaultValue) where T : struct
    {
        if(!String.IsNullOrEmpty(value.Trim())) {
            return (T)Convert.ChangeType(value, typeof(T));
        } else {
            return defaultValue;
        }
    }

    /// <summary>Format URL string as a markup link (aka hyperlink).</summary>
    /// <remarks>Extension method.</remarks>
    public static string ToLink(this string value)
    {
        if(!String.IsNullOrEmpty(value)) {
            return new System.Text.StringBuilder().AppendFormat("<a href=\"{0}\">{0}</a>", value).ToString();
        } else {
            return null;
        }
    }

    /// <summary>Format URL string as a markup link (aka hyperlink).</summary>
    /// <remarks>Extension method.</remarks>
    public static string ToLink(this string value, string label) {
        if(!String.IsNullOrEmpty(value)) {
            return new System.Text.StringBuilder().AppendFormat("<a href=\"{0}\">{1}</a>", value, label).ToString();
        } else {
            return null;
        }
    }

    /// <summary>Concatenates the string array with a whitespace.</summary>
    public static string Concat(params string[] tokens)
    {
        for(int i = 0;i < tokens.Length;i += 1) {
            tokens[i] = RemoveWhitespacesExtra(tokens[i]);
        }
        return String.Join(" ", tokens);
    }

    /// <summary>Shorten string.</summary>
    public static string ShortString(string source, int limit)
    {
        if(source.Length > limit) {
            return source.Substring(0, limit) + " ...";
        } else {
            return source;
        }
    }

    /// <summary>Get string in between two strings.</summary>
    /// <remarks>http://www.mycsharpcorner.com//Post.aspx?postID=15</remarks>
    /// <returns>An array of System.String instance containing the string in the middle.</returns>
    public static string[] GetStringInBetween(string strBegin, string strEnd, string strSource, bool includeBegin, bool includeEnd)
    {
        string[] result = {String.Empty, String.Empty};
        int iIndexOfBegin = strSource.IndexOf(strBegin);
        if(iIndexOfBegin != -1) {
            // include the Begin string if desired
            if(includeBegin) {
                iIndexOfBegin -= strBegin.Length;
            }
            strSource = strSource.Substring(iIndexOfBegin + strBegin.Length);
            int iEnd = strSource.IndexOf(strEnd);
            if(iEnd != -1) {
                // include the End string if desired
                if(includeEnd) {
                    iEnd += strEnd.Length;
                }
                result[0] = strSource.Substring(0, iEnd);
                // advance beyond this segment
                if(iEnd + strEnd.Length < strSource.Length) {
                    result[1] = strSource.Substring(iEnd + strEnd.Length);
                }
            }
        } else {
            // stay where we are
            result[1] = strSource;
        }
        return result;
    }

    /// <summary>Remove string in between two strings.</summary>
    /// <remarks>http://www.mycsharpcorner.com//Post.aspx?postID=15</remarks>
    /// <returns>An array of System.String instance containing the string in the middle.</returns>
    public static string RemoveStringInBetween(string strBegin, string strEnd, string strSource, bool removeBegin, bool removeEnd)
    {
        string[] result = GetStringInBetween(strBegin, strEnd, strSource, removeBegin, removeEnd);
        if(result[0] != String.Empty) {
            return strSource.Replace(result[0], String.Empty);
        }
        // nothing found between begin & end
        return strSource;
    }

    /// <summary>Remove whitespaces from string.</summary>
    /// <remarks>Extension method.</remarks>
    public static string RemoveWhitespaces(this string source)
    {
        return source.Trim().Replace(" ", String.Empty);
    }

    /// <summary>Remove extra whitespaces from string. (Another regular expression: @"\s{2,}" pattern.)</summary>
    /// <remarks>
    /// Extension method.
    /// 
    /// References:
    /// http://nlakkakula.wordpress.com/2008/09/16/removing-additional-white-spaces-in-sentence-c/
    /// http://authors.aspalliance.com/stevesmith/articles/removewhitespace.asp
    /// </remarks>
    public static string RemoveWhitespacesExtra(this string source)
    {
        return System.Text.RegularExpressions.Regex.Replace(source.Trim(), @"\s+", " ");
    }

    /// <summary>Remove breaks (aka line breaks or new lines).</summary>
    /// <remarks>
    /// Extension method.
    /// 
    /// References:
    /// http://stackoverflow.com/questions/238002/replace-line-breaks-in-a-string-c
    /// </remarks>
    public static string RemoveBreaks(this string source)
    {
        return source.Replace("\r\n", String.Empty).Replace("\r", String.Empty).Replace("\n", String.Empty);
    }

    /// <summary>Strip (remove) all HTML from string.</summary>
    public static string StripHtml(string source)
    {
        return System.Text.RegularExpressions.Regex.Replace(source, @"<(.|\n)*?>", String.Empty);
    }

    /// <summary>
    /// Uppercase the first letter in a string.
    /// Modify character in-place with ToCharArray.
    /// </summary>
    /// <remarks>http://dotnetperls.com/Content/Uppercase-First-Letter.aspx</remarks>
    /// <param name="strSource">The string you want to uppercase the first letter.</param>
    /// <returns>The new uppercased string.</returns>
    public static string ToUpperFirst(string strSource)
    {
        if(String.IsNullOrEmpty(strSource)) {
            return String.Empty;
        }
        char[] letters = strSource.ToCharArray();
        letters[0] = char.ToUpper(letters[0]);
        return new String(letters);
    }

    /// <summary>To HTML from sequence (special characters).</summary>
    public static string ToHtmlFromSequence(string src) {
        src = src.Replace("\n", "<br />");
        return src;
    }

    /// <summary>To HTML from user control file (ascx).</summary>
    public static string ToHtml(System.Web.UI.UserControl uc) {
        System.IO.StringWriter sw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter writer = new System.Web.UI.HtmlTextWriter(sw);
        string contents = String.Empty;
        //try {
            uc.RenderControl(writer);
            contents = sw.ToString();
        //} catch {
        //    return "HTML Conversion Error";
        //}
        return contents;
    }

    /// <summary>
    /// This static function will take an encoded string and
    /// convert certain tags to their original format leaving
    /// tags like <script></script> in their encoded state.
    /// </summary>
    /// <param name="oldHTML">encoded string coming in</param>
    /// <returns>return string with certain tags decoded</returns>
    public static string ConvertEncodedHtmlToValidHtml(string oldHTML)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder(oldHTML);
        sb.Replace("\r\n", "<br />");
        sb.Replace("&lt;strong&gt;", "<strong>");
        sb.Replace("&lt;/strong&gt;", "</strong>");
        sb.Replace("&lt;/b&gt;", "</b>");
        sb.Replace("&lt;b&gt;", "<b>");
        sb.Replace("&lt;/b&gt;", "</b>");
        sb.Replace("&lt;i&gt;", "<i>");
        sb.Replace("&lt;/i&gt;", "</i>");
        sb.Replace("&lt;p&gt;", "<p>");
        sb.Replace("&lt;/p&gt;", "</p>");
        sb.Replace("&lt;u&gt;", "<u>");
        sb.Replace("&lt;/u&gt;", "</u>");
        sb.Replace("&lt;br&gt;", "<br>");
        sb.Replace("&lt;br/&gt;", "<br/>");
        sb.Replace("&lt;br /&gt;", "<br />");
        return sb.ToString();
    }

    /// <summary>Read text file for markup code.</summary>
    public static String ReadTextFile(System.Web.HttpServerUtility server, string filePath, bool isReplaceCarraige)
    {
        string content = String.Empty;
        string path = server.MapPath(filePath);

        // Create StreamReader object.
        System.IO.Stream file = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite);
        System.IO.StreamReader streamReader = new System.IO.StreamReader(file);
        // Read the entire file into a string.
        content = streamReader.ReadToEnd();
        // Replace carraige returns with markup code.
        if(isReplaceCarraige) {
            content = content.Replace("\r\n", "<br />");
        }
        // Close StreamReader object.
        streamReader.Close();
        // Return content.
        return content;
    }
}

}
