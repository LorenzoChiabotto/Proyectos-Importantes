<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Eliminacion.aspx.vb" Inherits="WebForms.Eliminacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="estilos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="formulario">

            ¿Desea eliminar este registro de la tabla
            <asp:Label ID="lblTabla" runat="server" Font-Bold="True"></asp:Label>
            ?<br />
            <br />
            <asp:Label ID="lblRegistro" runat="server" Font-Bold="True"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btAceptar" runat="server" Text="Aceptar" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btCancelar" runat="server" Text="Cancelar" />

        </div>
    </form>
</body>
</html>
