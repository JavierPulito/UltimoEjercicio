<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="paginaCrear.aspx.cs" Inherits="UltimoEjercicio.View.paginaCrear" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label>
            <asp:TextBox ID="TextBoxNombre" runat="server"></asp:TextBox>
        </div>
        <asp:Panel ID="Panel1" runat="server">
            <asp:Label ID="Label2" runat="server" Text="Raza:"></asp:Label>
            <asp:TextBox ID="TextBoxRaza" runat="server"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server">
            <asp:Label ID="Label3" runat="server" Text="Edad:"></asp:Label>
            <asp:TextBox ID="TextBoxEdad" runat="server"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="Panel3" runat="server">
            <asp:Label ID="Label4" runat="server" Text="Vacunado:"></asp:Label>
            <asp:CheckBox ID="CheckBoxVacunados" runat="server" />
        </asp:Panel>
        <asp:Panel ID="Panel4" runat="server">
            <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" />
            <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" />
        </asp:Panel>
    </form>
</body>
</html>
