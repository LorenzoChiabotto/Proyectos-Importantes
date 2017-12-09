<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AltaModificacion.aspx.vb" Inherits="WebForms.AltaModificacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="estilos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="header">
        <div style="float:left">
            <ul class="menu">
                <li class="activo"><a href="ListadoPersonas.aspx">Personas</a></li>
            </ul>
        </div>
    </div>

    <br />
    <br />

    <form id="form1" runat="server">
        <div class="formulario">

            <asp:Label ID="Label1" runat="server" Font-Bold="False" ForeColor="#33A0E1" Text="Nombre Completo" Width="124px"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbNombre" runat="server" Width="445px"></asp:TextBox>
            <asp:RegularExpressionValidator ID="vNombre" runat="server" ControlToValidate="tbNombre" ErrorMessage="X" ValidationExpression="(([aA-zZ]+)((\s[aA-zZ]+)*)){1}" ValidationGroup="1"></asp:RegularExpressionValidator>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Font-Bold="False" ForeColor="#33A0E1" Text="Nacimiento" Width="70px"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbNacimiento" runat="server" Width="150px"></asp:TextBox>


            &nbsp;<asp:RegularExpressionValidator ID="vNacimiento" runat="server" ControlToValidate="tbNacimiento" ErrorMessage="X" ValidationExpression="^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$" ValidationGroup="1"></asp:RegularExpressionValidator>
            &nbsp;


            <asp:Label ID="Label10" runat="server" Font-Bold="False" ForeColor="#33A0E1" Text="Edad" Width="70px"></asp:Label>
            <asp:TextBox ID="tbEdad" runat="server" Width="49px"></asp:TextBox>


            <asp:RegularExpressionValidator ID="vEdad" runat="server" ControlToValidate="tbEdad" ErrorMessage="X" ValidationExpression="[0-9]{1,3}" ValidationGroup="1"></asp:RegularExpressionValidator>


            <br />


            <br />


            <asp:Label ID="Label9" runat="server" Font-Bold="False" ForeColor="#33A0E1" Text="Sexo" Width="70px"></asp:Label>
            <asp:DropDownList ID="ddSexo" runat="server" Height="16px" Width="178px">
                <asp:ListItem Value="MASCULINO">Masculino</asp:ListItem>
                <asp:ListItem Value="FEMENINO">Femenino</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="btGuardar" runat="server" Text="Guardar" Width="137px" ValidationGroup="1" />


        </div>
    </form>
</body>
</html>
