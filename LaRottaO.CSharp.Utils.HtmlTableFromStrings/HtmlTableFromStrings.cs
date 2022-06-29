using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaRottaO.CSharp.Utils.Html
{
    public static class HtmlTableFromStrings
    {
        public static String generate(String argTableTitle, Boolean argFirstRowIsHeader, StringBuilder argSbTableDataToInsert, Char argRowSeparator, Char argColumnSeparator)
        {
            try
            {
                List<String> dataAsList = argSbTableDataToInsert.ToString().Split(argRowSeparator).ToList<String>();

                StringBuilder sbHtmlTable = new StringBuilder();

                //Add html headers and a title, to make table look better

                sbHtmlTable.Append("<html>" + Environment.NewLine);
                sbHtmlTable.Append("<head>" + Environment.NewLine);
                sbHtmlTable.Append("<style>" + Environment.NewLine);
                sbHtmlTable.Append("table {" + Environment.NewLine);
                sbHtmlTable.Append("font-family: arial, sans-serif;" + Environment.NewLine);
                sbHtmlTable.Append("border-collapse: collapse;  " + Environment.NewLine);
                sbHtmlTable.Append("width: 100%;" + Environment.NewLine);
                sbHtmlTable.Append("}" + Environment.NewLine);
                sbHtmlTable.Append("td, th {" + Environment.NewLine);
                sbHtmlTable.Append("border: 1px solid #dddddd;" + Environment.NewLine);
                sbHtmlTable.Append("text-align: left;" + Environment.NewLine);
                sbHtmlTable.Append("padding: 8px;" + Environment.NewLine);
                sbHtmlTable.Append("}" + Environment.NewLine);
                sbHtmlTable.Append("tr:nth-child(even) {" + Environment.NewLine);
                sbHtmlTable.Append("background-color: #dddddd;" + Environment.NewLine);
                sbHtmlTable.Append("}" + Environment.NewLine);
                sbHtmlTable.Append("</style>" + Environment.NewLine);
                sbHtmlTable.Append("</head>" + Environment.NewLine);
                sbHtmlTable.Append("<body style=\"font-family: arial, sans-serif\">" + Environment.NewLine);
                sbHtmlTable.Append("<br>" + Environment.NewLine);

                if (!String.IsNullOrEmpty(argTableTitle))
                {
                    sbHtmlTable.Append("<h3>" + argTableTitle + "</h3>" + Environment.NewLine);
                }

                sbHtmlTable.Append("<br>" + Environment.NewLine);

                sbHtmlTable.Append("</body>" + Environment.NewLine);
                sbHtmlTable.Append("</html>" + Environment.NewLine);

                //Add table headers

                sbHtmlTable.Append("<table>" + Environment.NewLine);
                sbHtmlTable.Append("<tr>" + Environment.NewLine);

                if (argFirstRowIsHeader)
                {
                    sbHtmlTable.Append("<th>" + dataAsList[0].Replace(argColumnSeparator.ToString(), "</th><th>") + "</th>" + Environment.NewLine);
                }
                sbHtmlTable.Append("<tr>" + Environment.NewLine);

                int i = 0;

                if (argFirstRowIsHeader)
                {
                    i = 1;
                }

                for (; i < dataAsList.Count; i++)
                {
                    sbHtmlTable.Append("<tr>");
                    sbHtmlTable.Append("<td>" + dataAsList[i].Replace(argColumnSeparator.ToString(), "</td><td>") + "</td>");
                    sbHtmlTable.Append("<tr>");
                }

                //End table

                sbHtmlTable.Append("</table>" + Environment.NewLine);

                //Add footer

                sbHtmlTable.Append("</body>" + Environment.NewLine);
                sbHtmlTable.Append("</html>" + Environment.NewLine);

                return sbHtmlTable.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: Unable to parse Strings to HTML table: " + ex.ToString());

                return "";
            }
        }
    }
}