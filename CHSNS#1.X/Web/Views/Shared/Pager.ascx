<%@ Control Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl<IPagedList>" %>
<div class="page">
    <%
        foreach (string key in Request.QueryString.Keys)
            if (Request.QueryString[key] != null && !string.IsNullOrEmpty(key))
                this.ViewContext.RouteData.Values[key] = Request.QueryString[key];
        if (ViewData.Model.TotalPages > 1) {
            if (ViewData.Model.CurrentPage != 1) {
                this.ViewContext.RouteData.Values["p"] = 1;
                Writer.Write(Html.RouteLink("首页", this.ViewContext.RouteData.Values));
                Writer.Write(" ");
            }
            if (ViewData.Model.HasPreviousPage) {
                this.ViewContext.RouteData.Values["p"] = ViewData.Model.CurrentPage - 1;
                Writer.Write(Html.RouteLink("上一页", this.ViewContext.RouteData.Values));
            }
            else {
                Writer.Write("上一页");
            }
            Writer.Write(" ");
            int currint = 10;
            for (int i = 2; i <= 19; i++) {
                if ((ViewData.Model.CurrentPage + i - currint) >= 1 && (ViewData.Model.CurrentPage + i - currint) <= ViewData.Model.TotalPages)
                    if (currint == i) {
                        Writer.Write(string.Format("[{0}]", ViewData.Model.CurrentPage));
                    }
                    else {
                        this.ViewContext.RouteData.Values["p"] = ViewData.Model.CurrentPage + i - currint;
                        Writer.Write(Html.RouteLink((ViewData.Model.CurrentPage + i - currint).ToString(), this.ViewContext.RouteData.Values));
                    }
                Writer.Write(" ");
            }
            if (ViewData.Model.HasNextPage) {
                this.ViewContext.RouteData.Values["p"] = ViewData.Model.CurrentPage + 1;
                Writer.Write(Html.RouteLink("下一页", this.ViewContext.RouteData.Values));
            }
            else {  Writer.Write("下一页");}
        Writer.Write(" ");
        if (ViewData.Model.CurrentPage != ViewData.Model.TotalPages) {
            this.ViewContext.RouteData.Values["p"] = ViewData.Model.TotalPages;
            Writer.Write(Html.RouteLink("末页", this.ViewContext.RouteData.Values));
        }
        Writer.Write(" ");
        }
    %>
    <%=ViewData.Model.CurrentPage %>/<%=ViewData.Model.TotalPages %>
</div>
