<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="WebApplication3.ProductDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
          <customControls:Header ID="Header1" runat="server"></customControls:Header>
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
              
                <div class="container">
                    <div class="sidebar1">
                        <%--<img src="ImgHandler.ashx?i=<%=coachID %>" alt="Coaching Image" width="100%" id="Img1" style="background-color: transparent; display: block;" />
                   --%>   <asp:Image ID="img" runat="server" Height="200px" BackColor="Transparent"  />
                          <!-- end .sidebar1 -->
                    </div>
                    <div class="content">
                        <h1>
                            <asp:Label runat="server" ID="Heading">
                            </asp:Label></h1>
                        
                        <div style="padding-left: 20px;">
                            <pre><asp:Label runat="server" ID="Description" cssclass="description"></asp:Label></pre>
                        </div>

                         <div style="padding-left: 20px;">
                            <pre><asp:Label runat="server" ID="unitPerStock" cssclass="description"></asp:Label></pre>
                        </div>
                     
                         <div style="padding-left: 20px;">
                            <pre><asp:Label runat="server" ID="costprice" cssclass="description"></asp:Label></pre>
                        </div>

                        <div style="padding-left: 20px;">
                            <pre><asp:Label runat="server" ID="supplier" cssclass="description"></asp:Label></pre>
                        </div>

                        <div style="padding-left: 20px">
                            <pre><asp:DropDownList runat="server" ID="d1"></asp:DropDownList></pre>
                        </div>

                        <div style="padding-left: 20px">
                            <pre><asp:Button OnClick="placeorder_Click" ID="placeorder" runat="server" Text="Place Order" /></pre>
                            <pre>&nbsp;</pre>
                            <pre><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></pre>
                        </div>


                       

                        <asp:SqlDataSource ID="CoachIn" runat="server" ConnectionString="<%$ ConnectionStrings:ims %>" SelectCommand="SELECT * FROM Product"></asp:SqlDataSource>

                        <!-- end .content -->
                    </div>
                    
                    <!-- end .container -->
                </div>

                
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
