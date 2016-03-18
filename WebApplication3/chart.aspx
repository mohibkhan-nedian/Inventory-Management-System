 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chart.aspx.cs" Inherits="WebApplication3.chart" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <asp:ScriptManager ID="Scriptmanager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
      <customControls:Header5 ID="Header1" runat="server"></customControls:Header5>
        <asp:DropDownList runat="server" id="d1"></asp:DropDownList>
        <asp:DropDownList runat="server" id="d2"></asp:DropDownList> 
         <asp:Button runat="server" ID="btn" OnClick="btn_Click" Text="Show"/>
        <asp:Label runat="server" ID="lbl3"></asp:Label>
        <asp:Label runat="server" ID="lbl2"></asp:Label>   
           
                <br />
        <asp:Chart ID="Chart1" runat="server">
            <series>
               <asp:Series Name="Series1">
        
           </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
        </asp:Chart>
        <asp:Label ID="lbl1" runat="server" ></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
    </form>
</body>
</html>
