<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products2.aspx.cs" Inherits="WebApplication3.Products2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
         <link href="css/style1.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript">
         function doPostBack(o) {
             __doPostBack(o.id, '');
         }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
          <customControls:Header ID="Header1" runat="server"></customControls:Header>
     <%-- <div class="dropdown clearfix">
   <ul class="dropdown-menu" role="menu" aria-labelledby="dropdownMenu" style="display:block;position:static;margin-bottom:5px;">
      <li><a tabindex="-1" runat="server" id="chk1" href="#" name="1"></a></li>
      <li><a tabindex="-1" runat="server" id="chk2" href="#" name="2">Gadgets</a></li>
      <li><a tabindex="-1" runat="server" id="chk3" href="#">Something else here</a></li>
      <li class="divider"></li>
      <li><a tabindex="-1" href="#">Separated link</a></li>
    </ul>
  </div>--%>

         <div class="sidebar1" title="Categories">
         
          <%-- <div>--%>

           <%--<asp:CheckBox runat="server" ID="chk1" Text="Clothes" AutoPostBack="true" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           </div>
           <br />
           <asp:CheckBox runat="server" ID="chk2" Text="Gadgets" AutoPostBack="true" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           <br />
           <asp:CheckBox runat="server" ID="chk3" Text="Home Appliances" AutoPostBack="true" />
           <br />--%>
               <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater2_ItemCommand" OnItemDataBound="Repeater2_ItemDataBound" >
                   <HeaderTemplate>
                       <h2>Categories</h2>
                   </HeaderTemplate>     
                       <ItemTemplate>
                                
                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"CatName")%>' ID="l1"/><br />
                                
                            </ItemTemplate>
                        </asp:Repeater>
       </div>
          <div class="tileContainer" >
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    
                    <asp:Panel ID="Panel1" runat="server"></asp:Panel>
                    <div class="stripBar">Search Name:</div>
                    <asp:TextBox ID="Search" CssClass="inputSearchBox" runat="server" onkeyup="doPostBack(this);" onfocus="this.value = this.value;"></asp:TextBox>
                    <br />
                  
   <div style=" background-color: transparent; text-align: center; position: relative; display: inline-block; ">
             <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" >
                            <ItemTemplate>
                               <div class="outlineBox" >
                                        <img class="tile" src='<%# "data:image/png;base64,"+ Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"Images"),0,((byte[])DataBinder.Eval(Container.DataItem,"Images")).Length) %>'  />
                                  
                                    <br />      
                                   <asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"PItem")%>' ></asp:label>
                                   <br />    
                                    <asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"PDescr")%>' ></asp:label>
                                    <br/>
                                      
                                    <asp:Button runat="server" Text="View Details" CssClass="btn btn-primary" CommandName ="btn" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"ProductId") %>' UseSubmitBehavior="false" CausesValidation="false" />
                               
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

               </div>

                            </ContentTemplate>
            </asp:UpdatePanel>
           <%-- <div style="height: 500px; background-color: transparent;"></div>--%>

            <!-- end .container -->
        </div>
    </div>
    
    </form>
</body>
</html>
