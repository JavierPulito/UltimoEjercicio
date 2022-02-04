<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="paginaEditar.aspx.cs" Inherits="UltimoEjercicio.View.paginaEditar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Panel ID="Panel1" runat="server" Height="135px">
            <asp:GridView ID="GridView1" runat="server" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDataBound="GridView1_RowDataBound" AutoGenerateEditButton="True">
            </asp:GridView>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" Height="24px">
            <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
            <asp:TextBox ID="TextBoxNombre" runat="server"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="Panel3" runat="server">
            <asp:Label ID="Label2" runat="server" Text="Raza:"></asp:Label>
            <asp:TextBox ID="TextBoxRaza" runat="server"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="Panel4" runat="server">
            <asp:Label ID="Label3" runat="server" Text="Edad:"></asp:Label>
            <asp:TextBox ID="TextBoxEdad" runat="server"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="Panel5" runat="server">
            <asp:Label ID="Label4" runat="server"></asp:Label>
            <asp:CheckBox ID="CheckBox1" Text="¿Está vacunado ?" runat="server" />
        </asp:Panel>
        <asp:Panel ID="Panel6" runat="server">
            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" />
            <asp:Button ID="btnVolver" runat="server" Text="Volver" />
        </asp:Panel>
    </form>
</body>
</html>
