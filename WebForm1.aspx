<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript">
    window.onload = function () {
        alert(json.ip);
    };
    function GetClientId()
{
	var ip = '<%=Request.ServerVariables["REMOTE_ADDR"]%>';
	return ip;
}
</script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
