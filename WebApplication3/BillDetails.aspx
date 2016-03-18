<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillDetails.aspx.cs" Inherits="WebApplication3.BillDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <customControls:Header2 ID="Header1" runat="server"></customControls:Header2>
               <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand"  >
                            <ItemTemplate>
                               <div >
                                        <img src='<%# "data:image/png;base64,"+ Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"Images"),0,((byte[])DataBinder.Eval(Container.DataItem,"Images")).Length) %>'  />
                                   <br />    
                                    <asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"PItem")%>' ></asp:label>
                                   <br />    
                                    <asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"PDescr")%>' ></asp:label>

                                   <br />
                                       <asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Size")%>' ></asp:label>
                                   <br />
                                       <asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"OrderedQuantity")%>' ></asp:label>
                                   <br />
                                       <asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"DeliveredQuantity")%>' ></asp:label>     
                                  <br />
                                           <asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"OrderDate")%>' ></asp:label>
                                   <br />
                                             <asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"SumOfTotal")%>' ></asp:label>
                                 
                                    
                                    </div>
                                
                            </ItemTemplate>
                        </asp:Repeater>

        <asp:Label runat="server" ID="lbl1"></asp:Label>
           <br />
        <asp:TextBox runat="server" ID="t1" ></asp:TextBox>
            <br /> 
                                   <select runat="server" id="select1" name="select1">
                                       <option>Check</option>
                                       <option>Cash</option>
                                       <option>Credit</option>
                                   </select>
        <br />
        <asp:button id="btn1" runat="server" Text="Generate Bill" OnClick="btn1_Click" ></asp:button>

    </div>
    </form>
</body>
</html>
