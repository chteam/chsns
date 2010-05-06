using System;
using System.IO;
using System.Text;
using System.Web.UI;


namespace MvcHelper
{
    /// <summary>
    /// Concreate implementation of FlexiGrid renderer.
    /// </summary>
    /// <typeparam name="T">Type of Model.</typeparam>
    public class FlexiGridRenderer<T> : IGridRenderer<FlexiGridSettings<T>> where T : class
    {
        #region Private fields

        /// <summary>
        /// This value is used to append when there is no specific grid id is given by the user.
        /// </summary>
        private static int _gridIndex = 0;

        /// <summary>
        /// Id of the grid, this will be used if user hasn't specified an id.
        /// </summary>
        private string _gridId = string.Empty;

        #endregion

        #region Implementation of IGridRenderer<FlexiGridSettings<T>>

        /// <summary>
        /// Renders the specified data.
        /// </summary>
        /// <param name="data">The data that needs to be rendered..</param>
        /// <returns>Rendered output as string.</returns>
        public string Render(FlexiGridSettings<T> data)
        {
            this.InitializeToDefaults(data);

            using (var sw = new StringWriter())
            {
                using (var htmlWriter = new HtmlTextWriter(sw))
                {
                    // Create a hidden table element
                    htmlWriter.AddStyleAttribute(HtmlTextWriterStyle.Display, "none");
                    htmlWriter.AddAttribute(HtmlTextWriterAttribute.Id, this._gridId);
                    htmlWriter.RenderBeginTag(HtmlTextWriterTag.Table);
                    htmlWriter.RenderEndTag();

                    // Create the javascript tag.
                    htmlWriter.AddAttribute(HtmlTextWriterAttribute.Type, @"text/javascript");
                    htmlWriter.RenderBeginTag(HtmlTextWriterTag.Script);
                    htmlWriter.Write(this.GenerateJavascript(data));
                    htmlWriter.RenderEndTag();
                }

                return sw.ToString();
            }
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Initializes to the default values.
        /// </summary>
        /// <param name="data">The data that needs to be rendered..</param>
        private void InitializeToDefaults(FlexiGridSettings<T> data)
        {
            // If GridId is not specified, set a default value
            this._gridId = string.IsNullOrEmpty(data.GridId)
                               ? string.Format("FlexiGrid_{0}", _gridIndex++)
                               : data.GridId;
        }

     
        private string GenerateJavascript(FlexiGridSettings<T> data)
        {
            var sb = new StringBuilder();
            sb.Append("(function(){");
            //sb.AppendFormat(@"$(""#{0}"").flexigrid({{", this._gridId).AppendLine();

            //if (!string.IsNullOrEmpty(data.ActionUrl))
            //{
            //    sb.AppendFormat("url:'{0}',", data.ActionUrl).AppendLine();
            //}

            //sb.AppendFormat("dataType:'{0}',", data.GridDataType.GetDescription()).AppendLine();

            sb.Append("var cols=[");

            int count = 0;
            int totalCount = data.GridColumns.Count;
            foreach (FlexiGridColumn<T> column in data.GridColumns)
            {
                count++;

                sb.AppendFormat("{{ display: '{0}', name: '{1}', width: {2}, sortable: {3}, align: '{4}' }}"
                                , column.ColumnSettings.ColumnTitle
                                , column.FieldName
                                , column.ColumnSettings.ColumnWidth
                                , column.ColumnSettings.ColumnSortable.ToString().ToLower()
                                , column.ColumnSettings.ColumnAlignment.GetDescription());

                if (count < totalCount)
                {
                    sb.AppendLine(",");
                }
            }
            sb.AppendLine("];");
            //sb.AppendLine("searchitems:[");

            //count = 0;
            //totalCount = data.GridColumns.Count;
            //foreach (FlexiGridColumn<T> column in data.GridColumns)
            //{
            //    count++;
            //    sb.AppendFormat("{{ display: '{0}', name: '{1}' }}", column.ColumnSettings.ColumnTitle, column.FieldName);

            //    if (count < totalCount)
            //    {
            //        sb.AppendLine(",");
            //    }
            //}

            //sb.AppendLine();
            //sb.AppendLine("],");

            //if (!string.IsNullOrEmpty(data.DefaultSortField))
            //{
            //    sb.AppendFormat(@"sortname:""{0}"",", data.DefaultSortField).AppendLine();
            //    sb.AppendFormat(@"sortorder:""{0}""", data.DefaultSortOrder.GetDescription()).AppendLine();
            //}

            //if (data.EnablePager)
            //{
            //    sb.AppendFormat(",{0}", Environment.NewLine);
            //    sb.AppendFormat(@"usepager:{0}", data.EnablePager.ToString().ToLower());
            //}

            //if (!string.IsNullOrEmpty(data.GridTitle))
            //{
            //    sb.AppendFormat(",{0}", Environment.NewLine);
            //    sb.AppendFormat(@"title:'{0}'", data.GridTitle);
            //}

            //if (data.EnableRecordsPerPage)
            //{
            //    sb.AppendFormat(",{0}", Environment.NewLine);
            //    sb.AppendFormat(@"useRp:{0}", data.EnableRecordsPerPage.ToString().ToLower());
            //    sb.AppendFormat(",{0}", Environment.NewLine);
            //    sb.AppendFormat(@"rp:{0}", data.RecordsPerPage);
            //}

            //if (data.EnableTableToggleButton)
            //{
            //    sb.AppendFormat(",{0}", Environment.NewLine);
            //    sb.AppendFormat(@"showTableToggleBtn: {0}", data.EnableTableToggleButton.ToString().ToLower());
            //}

            //if (data.GridWidth > 0)
            //{
            //    sb.AppendFormat(",{0}", Environment.NewLine);
            //    sb.AppendFormat(@"width:{0}", data.GridWidth);
            //}

            //if (data.GridWidth > 0)
            //{
            //    sb.AppendFormat(",{0}", Environment.NewLine);
            //    sb.AppendFormat(@"height:{0}", data.GridHeight);
            //    sb.AppendLine();
            //}

            //sb.AppendLine("}").AppendLine(");").AppendLine();
            return sb.ToString();
        }

        #endregion
    }
}
