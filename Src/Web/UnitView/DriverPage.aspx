<%@ Page Language="C#" Inherits="Microsoft.Web.Testing.Light.Engine.TestDriverPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    protected override void OnPreInit(EventArgs e)
    {
        HttpContext.Current = this.Context;
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Microsoft.Web.Testing Javascript Driver</title>
    <link rel="stylesheet" type="text/css" media="screen" href="<%= Page.ClientScript.GetWebResourceUrl(typeof(Microsoft.Web.Testing.Light.Engine.TestDriverPage), "Microsoft.Web.Testing.Light.Engine.Resources.driver.css") %>" />
    <script type="text/javascript">
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="DriverPageScriptManager" EnablePageMethods="true" EnablePartialRendering="true">
            <Scripts>
                <asp:ScriptReference Name="Microsoft.Web.Testing.Light.Engine.Resources.TestcaseExecutor.js" Assembly="Microsoft.Web.Testing.Light" />
            </Scripts>
        </asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="DriverPageUpdatePanel">
            <ContentTemplate>
                <asp:PlaceHolder ID="DriverPageContentPlaceHolder" runat="server">
                </asp:PlaceHolder>
            </ContentTemplate>
        </asp:UpdatePanel>        
    </form>
    
    <script type="text/javascript">
        function TreeView_TestcaseExecuted(testId, passed, stackTrace) {
            testId = testId.replace(/\.([^.]+)$/ig, "\\\\$1");

            var anchorCollection = document.getElementsByTagName('a');
            for (i = 0; i < anchorCollection.length; i++) {
                var anchor = anchorCollection[i];
                if (anchor.href.indexOf(testId + "'") !== -1) {
                    if (passed) {
                        anchor.style.background = "green";
                        anchor.style.color = "white";
                        anchor.href = "javascript:LoadPassLog();"
                    }
                    else {
                        var pageDom = TestExecutor.get_activeWindow().get_activeFrame().calculateCurrentDom("all_attributes");
                        pageSources.push(pageDom);

                        errorLogs.push(stackTrace);
                        anchor.style.background = "red";
                        anchor.style.color = "white";
                        var logViewerHref = "javascript:LoadErrorLog(" + (errorLogs.length - 1) + ");"
                        anchor.href = logViewerHref;
                    }
                    return;
                }
            }
        }

        eval("window.LoadErrorLog = " + window.LoadErrorLog.toString().replace("WebResource", "/WebResource"));
        eval("window.LoadPassLog = " + window.LoadPassLog.toString().replace("WebResource", "/WebResource"));
</script>
</body>
</html>
