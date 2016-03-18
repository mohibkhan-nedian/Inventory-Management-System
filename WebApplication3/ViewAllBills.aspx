<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewAllBills.aspx.cs" Inherits="WebApplication3.ViewAllBills" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <customControls:Header2 ID="Header1" runat="server"></customControls:Header2>
        <asp:HyperLink runat="server" ID="h1" Text="View Open Bills"></asp:HyperLink>
<asp:HyperLink runat="server" ID="h2" Text="View Open Bills"></asp:HyperLink>

        <br />


           <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand"  >
                            <ItemTemplate>
                               <div >
                                        <asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"BillNo")%>' ></asp:label>
                                   <br />    
                                    <asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"OrderDate")%>' ></asp:label>
                                   <br />
                                    <asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"SumofTotal")%>' ></asp:label>
                                   <br />
                                        <asp:Button runat="server" Text="View Details" CommandName ="btn" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"BillNo") %>' UseSubmitBehavior="false" CausesValidation="false" />
                              
                                   <br />
                               
                               </div>
                                
                            </ItemTemplate>
                        </asp:Repeater>
    
    </div>
    </form>
</body>
</html>
