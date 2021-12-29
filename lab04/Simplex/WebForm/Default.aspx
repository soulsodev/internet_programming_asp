<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebForm.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<br />
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server">X:</asp:Label>
            <asp:TextBox runat="server" ID="textX" />

            <asp:Label runat="server">Y:</asp:Label>
            <asp:TextBox runat="server" ID="textY" />
           
            <asp:Button runat="server" ID="add" OnClick="Add_Click" Text="Add" />
        </div>
         <br />
        <div>
            <asp:Label runat="server">RESULT:</asp:Label>
            <asp:TextBox runat="server" ID="textAddResponse" />
        </div>
   
    <br />

    <div>
            <asp:Label runat="server">S:</asp:Label>
            <asp:TextBox runat="server" ID="textS" />
            <asp:Label runat="server">D:</asp:Label>
            <asp:TextBox runat="server" ID="textD" />
            <asp:Button runat="server" ID="concat" OnClick="Concat_Click" Text="Concat" />
        </div>
         <br />
        <div>
            <asp:Label runat="server">RESULT:</asp:Label>
            <asp:TextBox runat="server" ID="textConcatResponse" />
        </div>
   
    <br />

    <div>   
            <asp:Label runat="server">S1:</asp:Label>
            <asp:TextBox runat="server" ID="textA1S" />
            <asp:Label runat="server">K1:</asp:Label>
            <asp:TextBox runat="server" ID="textA1K" />
            <asp:Label runat="server">F1:</asp:Label>
            <asp:TextBox runat="server" ID="textA1F" />
        <br />
            <asp:Label runat="server">S2:</asp:Label>
            <asp:TextBox runat="server" ID="textA2S" />
            <asp:Label runat="server">K2:</asp:Label>   
            <asp:TextBox runat="server" ID="textA2K" />
            <asp:Label runat="server">F2:</asp:Label>
            <asp:TextBox runat="server" ID="textA2F" />
        <br />
        <br />
            <asp:Button runat="server" ID="Button2" OnClick="Sum_Click" Text="Sum" />
        </div>
         <br />
        <div>
            <asp:Label runat="server">RESULT:</asp:Label>
            <asp:TextBox runat="server" ID="textSumResponse" />
        </div>
   
    <br />
        </form>
</body>
</html>
