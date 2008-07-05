<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>

    <script src="jquery-1.2.3-intellisense.js" type="text/javascript"></script>

    <script  type="text/javascript">
    //注意，上面引用的是jquery-1.2.3-intellisense.js，这个文件中只有jQuery的函数签名，没有具体的功能实现
    //发布时要换成jquery-1.2.3.pack.js。
    
    $(function(){
        $('p').html('wuchang');
    });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p></p>
    </div>
    </form>
</body>
</html>
