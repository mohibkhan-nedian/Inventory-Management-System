<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Practice.aspx.cs" Inherits="WebApplication3.Practice" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
       <script type="text/javascript">
           function uploadStarted() {
               $get("imgDisplay").style.display = "none";
           }
           function uploadComplete(sender, args) {
               var imgDisplay = $get("imgDisplay");
               imgDisplay.src = "images/loader.gif";
               imgDisplay.style.cssText = "";
               var img = new Image();
               img.onload = function () {
                   imgDisplay.style.cssText = "height:100px;width:100px";
                   imgDisplay.src = img.src;
               };
               img.src = "<%=ResolveUrl(UploadFolderPath) %>" + args.get_fileName();
        }
        </script>
</head>
 
<body>
     <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <cc1:AsyncFileUpload OnClientUploadComplete="uploadComplete" runat="server" ID="AsyncFileUpload1"
        Width="400px" UploaderStyle="Modern" CompleteBackColor="White" UploadingBackColor="#CCFFFF"
        ThrobberID="imgLoader" OnUploadedComplete="FileUploadComplete" OnClientUploadStarted = "uploadStarted"/>
    <asp:Image ID="imgLoader" runat="server" ImageUrl="~/images/loader.gif" /><br /><br />
    <img id = "imgDisplay" alt="" src="" style = "display:none"/>


     
         
    </form>
</body>
</html>
