<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication3.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="b1" runat="server" Text="Add Inventory" OnClick="b1_Click" />
        &nbsp;<asp:Button ID="Button1" runat="server" Text="Add Category" OnClick="Button1_Click" />
        <br />

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label Text="CatId" runat="server" ID="catid" ></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="L1" runat="server" Text="ProductId"></asp:Label>
        <br />
        <asp:TextBox runat="server" ID="productId" ></asp:TextBox>

    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

    
    <asp:DropDownList runat="server" ID="d1"></asp:DropDownList>

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="catname" Text="CategoryName" runat="server" ></asp:Label>:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

        <br />
        <asp:Label ID="L2" runat="server" Text="ProductItem" ></asp:Label> <br />

    <asp:TextBox runat="server" ID="productItem"></asp:TextBox>

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="catdetails" Text ="Category Details"></asp:Label>:
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>

        <br />
        <br />
        UploadImage:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
&nbsp;<asp:FileUpload runat="server" ID="image" Width="200" EnableTheming="true" OnLoad="image_Load" OnPreRender="image_PreRender" OnUnload="image_Unload"  />

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="Add" OnClick="Button2_Click" />
        <br />
        <asp:Image ID="Image1" runat="server" Height="96px" OnLoad="Image1_Load" style="margin-left: 0px" Width="176px" />

        <br />
        <asp:Label ID="L3" runat="server" Text="ProductDescription"></asp:Label><br />

    <asp:TextBox runat="server" ID="productDesc"></asp:TextBox>

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        <br />
        <asp:Label runat="server" ID="L4" Text="SupplierName:"></asp:Label><br />

        <asp:TextBox runat="server" ID="supplierName"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <asp:Label runat="server" ID="L5" Text="UnitCost:"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox runat="server" ID="unitCost"></asp:TextBox>

        <br />
        <asp:Label ID="L6" runat="server" Text="UnitSellPrice:"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;

    <asp:TextBox runat="server" ID="sellPrice"></asp:TextBox>
        <br />
    
            <asp:Label runat="server" ID="L7" Text="Discount:"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox runat="server" ID="discount"></asp:TextBox>

        <br />
        <br />
        <asp:Label runat="server" ID="L8" Text="UnitPerStock:"></asp:Label>&nbsp;&nbsp;&nbsp;

        <asp:TextBox runat="server" ID="unitperstock"></asp:TextBox>

        <br />
        <asp:Label runat="server" ID="L9" Text="UnitInOrder:"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

    <asp:TextBox runat="server" ID="unitInOrder"></asp:TextBox>

        <br />
        <asp:Label runat="server" ID="L10" Text="StockQuantity:"></asp:Label>&nbsp;&nbsp;

        <asp:TextBox runat="server" ID="stockQuantity"></asp:TextBox>

        <br />
        <br />

        <asp:Button runat="server" ID="saveButton" Text="Save" OnClick="saveButton_Click"/>
    &nbsp;
        <asp:Label runat="server" ID="lblInfo"></asp:Label>
    </div>
    </form>
</body>
</html>
