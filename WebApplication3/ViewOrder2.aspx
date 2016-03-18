<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewOrder2.aspx.cs" Inherits="WebApplication3.ViewOrder2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <customControls:Header2 ID="Header1" runat="server"></customControls:Header2>
        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" >
                            <ItemTemplate>
                               <div >
                                        <img src='<%# "data:image/png;base64,"+ Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"Images"),0,((byte[])DataBinder.Eval(Container.DataItem,"Images")).Length) %>'  />
                                        <asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"PItem")%>' ></asp:label>
                                   <br />    
                                    <asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"productid")%>' ></asp:label>
                                        <asp:Button runat="server" Text="Confim" CommandName ="btn" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"customerid") %>' UseSubmitBehavior="false" CausesValidation="false" />
                                </div>
                                
                            </ItemTemplate>
                        </asp:Repeater>

        <asp:Label runat="server" ID="lblInfo"></asp:Label>

        
    </div>
    </form>
</body>
</html>
