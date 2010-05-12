using System;
using System.IO;
using System.Text;
using System.Web.UI;


namespace MvcHelper
{
    public class FlexigridRenderer<T> : IGridRenderer<FlexigridTableSettings<T>> where T : class
    {

        private static int _gridIndex = 0;

        private string _gridId = string.Empty;



        public string Render(FlexigridTableSettings<T> data)
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
                    if (!data.EnableDefaultPager && !string.IsNullOrEmpty(data.PageFilter))
                    {
                        //show the pager
                        if (data.PageFilter.StartsWith("#"))
                            htmlWriter.AddAttribute(HtmlTextWriterAttribute.Id, data.PageFilter.Substring(1));
                        if (data.PageFilter.StartsWith("."))
                            htmlWriter.AddAttribute(HtmlTextWriterAttribute.Class, data.PageFilter.Substring(1));
                        htmlWriter.RenderBeginTag(HtmlTextWriterTag.Div);
                        htmlWriter.RenderEndTag();
                    }
                    // Create the javascript tag.
                    htmlWriter.AddAttribute(HtmlTextWriterAttribute.Type, @"text/javascript");
                    htmlWriter.RenderBeginTag(HtmlTextWriterTag.Script);
                    htmlWriter.Write(this.GenerateJavascript(data));
                    htmlWriter.RenderEndTag();
                }

                return sw.ToString();
            }
        }

        private void InitializeToDefaults(FlexigridTableSettings<T> data)
        {
            // If GridId is not specified, set a default value
            this._gridId = string.IsNullOrEmpty(data.GridId)
                               ? string.Format("FlexiGrid_{0}", _gridIndex++)
                               : data.GridId;
        }


        private string GenerateJavascript(FlexigridTableSettings<T> data)
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
            foreach (FlexigridColumn<T> column in data.GridColumns)
            {
                count++;
                sb.Append("{");
                if (!string.IsNullOrEmpty(column.FieldName))
                    sb.AppendFormat("name:'{0}',", column.FieldName);
                if (column.ColumnSettings.ColumnWidth > 0)
                    sb.AppendFormat("width:{0},", column.ColumnSettings.ColumnWidth);
                if (column.ColumnSettings.ColumnSortable)
                    sb.Append("sortable:true,");
                if (column.ColumnSettings.ColumnAlignment != 0)
                    sb.AppendFormat("align:'{0}',", column.ColumnSettings.ColumnAlignment.GetDescription());
                if (column.ColumnSettings.ColumnHidden)
                    sb.Append("hide:true,");
                sb.AppendFormat("display:'{0}'", column.ColumnSettings.ColumnTitle).Append("}");
                if (count < totalCount)
                {
                    sb.AppendLine(",");
                }
            }
            sb.AppendLine("];");
            sb.AppendFormat(@"$('#{0}').gridext('{1}',cols,'{2}',{3},",
                this._gridId, data.ActionUrl, data.MenuId, data.MenuProcess ?? "null")
                .Append("{");
            if (data.EnableDefaultPager)
                sb.Append("usedefalutpager:true,");
            if (!string.IsNullOrEmpty(data.PageFilter))
                sb.AppendFormat("pager:'{0}',", data.PageFilter);
            if (data.EnableAutoLoad)
                sb.Append("autoload:true,");
            if (data.GridWidth > 0)
                sb.AppendFormat("height:{0},", data.GridHeight);
            if (!string.IsNullOrEmpty(data.GridTitle))
                sb.AppendFormat("title:'{0}',", data.GridTitle);
            if (data.ColMove)
                sb.AppendFormat("colMove:true,", data.ColMove);
            if (data.ColResize)
                sb.AppendFormat("colResize:true,", data.ColResize);
            sb.AppendFormat("rp:{0}", data.PageSize).Append("});");
            // $(".table1").gridext('Ajax/GetEntity', colModel, '#tablemenu', process,
            //{ colResize: true, colMove: true}); ;
            sb.Append("})();");
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
            return sb.ToString();
        }

    }
}
