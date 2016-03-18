<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductDetail2.aspx.cs" Inherits="WebApplication3.ProductDetail2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
  <form id="form1" runat="server">
       <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <customControls:Header3 ID="Header2" runat="server"></customControls:Header3>
         
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
                        </div>
                      </div>
         <div class="form-group">  
         <asp:Label Text="Product Description" runat="server" CssClass="control-label col-sm-2" ID="catid"  ></asp:Label>
         <div class="col-sm-7">
         <asp:TextBox ID="pdesc" runat="server"  CssClass="form-control"></asp:TextBox>
       </div>
        </div>
                        <br />
         <div class="form-group">  
         <asp:Label Text="Discount" runat="server" CssClass="control-label col-sm-2" ID="Label1"  ></asp:Label>
         <div class="col-sm-7">
         <asp:TextBox ID="disc" runat="server"  CssClass="form-control"></asp:TextBox>
       </div>
        </div>
                        <br />

                         <div class="form-group">  
         <asp:Label Text="Unit Per Stock" runat="server" CssClass="control-label col-sm-2" ID="Label2" ></asp:Label>
         <div class="col-sm-7">
         <asp:TextBox ID="ups" runat="server"  CssClass="form-control"></asp:TextBox>
       </div>
        </div>
                        <br />

                         <div class="form-group">  
         <asp:Label Text="Units in Order" runat="server" CssClass="control-label col-sm-2" ID="Label3"  ></asp:Label>
         <div class="col-sm-7">
         <asp:TextBox ID="inorder" runat="server"  CssClass="form-control"></asp:TextBox>
       </div>
        </div>
                        <br />

                         <div class="form-group">  
         <asp:Label Text="Unit Cost" runat="server" CssClass="control-label col-sm-2" ID="Label4"  ></asp:Label>
         <div class="col-sm-7">
         <asp:TextBox ID="unitcost" runat="server"   CssClass="form-control"></asp:TextBox>
       </div>
        </div>
                        <br />

                         <div class="form-group">  
         <asp:Label Text="Unit Sell Price" runat="server" CssClass="control-label col-sm-2" ID="Label5"  ></asp:Label>
         <div class="col-sm-7">
         <asp:TextBox ID="sellprice" runat="server"   CssClass="form-control"></asp:TextBox>
       </div>
        </div>
                        <br />
                         <div class="form-group">  
         <asp:Label Text="Stock Quanitity" runat="server" CssClass="control-label col-sm-2" ID="Label6" ></asp:Label>
         <div class="col-sm-7">
         <asp:TextBox ID="stock" runat="server" CssClass="form-control"></asp:TextBox>
       </div>
        </div>
                        <br />
                         <div class="form-group">  
         <asp:Label Text="Supplier " runat="server" CssClass="control-label col-sm-2" ID="Label7"  ></asp:Label>
         <div class="col-sm-7">
         <asp:TextBox ID="suplier" runat="server"   CssClass="form-control"></asp:TextBox>
       </div>
        </div>
                          
             <div style="padding-left: 1100px">
                            <br />
                            <asp:Button OnClick="update_click" ID="up" CssClass="btn btn-primary" runat="server" Text="Update" />
            </div>
                    
                     <%--   <asp:SqlDataSource ID="CoachIn" runat="server" ConnectionString="<%$ ConnectionStrings:ims %>" SelectCommand="SELECT * FROM Product"></asp:SqlDataSource>--%>

                        <!-- end .content -->
                    </div>
                    
                    <!-- end .container -->
                </div>
                   <asp:TextBox ID="fake" runat="server" Visible="false" CssClass="form-control"></asp:TextBox>
                
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>

</body>
</html>
