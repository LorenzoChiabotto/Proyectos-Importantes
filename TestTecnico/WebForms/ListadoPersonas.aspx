<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ListadoPersonas.aspx.vb" Inherits="WebForms.ListadoPersonas" %>

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

    <form id="form1" runat="server">
        <div class="formulario">

            <asp:Button ID="btCrear" runat="server" Text="Nueva Persona" />
            
            <br />
            <br />

            <table style="width: 100%" border="1">
                    <tr>
                        <th>Nombre Completo</th>
                        <th>Fecha de Nacimiento</th>
                        <th>Edad</th>
                        <th>Sexo</th>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                    <tr>
                        <td><%#Container.DataItem("nombre_Persona")%></td>
                        <td><%#FuncionFormatear(Container.DataItem("nacimiento_Persona"))%></td>
                        <td><%#Container.DataItem("edad_Persona")%></td>
                        <td><%#Container.DataItem("sexo_Persona")%></td>
                        <td>
                            <asp:Button CommandName ='<%#Container.DataItem("id_Persona") %>' ID="btModificar" OnClick="btModificar_Click" runat="server" Text="Modificar" /></td>
                        <td>
                            <asp:Button CommandName ='<%#Container.DataItem("id_Persona") %>' ID="btEliminar" OnClick="btEliminar_Click" runat="server" Text="X" BackColor="Red" ForeColor="White" /></td>
                       </tr>
                    </ItemTemplate>
                    </asp:Repeater>
                </table>
        </div>
    </form>
</body>
</html>
