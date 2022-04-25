<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Alpheus_0._6.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="box">
            <asp:Label ID="Error" runat="server" />
                <label>Usuario: </label>
                </br>
                <asp:TextBox ID="Usuario" runat="server" Text=" " CssId="Usuario" />
                </br>
                </br>
                <label>Contraseña: </label>
                </br>
                <asp:TextBox ID="contraseña" runat="server" Text=" " CssId="contraseña"/>
                </br>
                </br>
                <asp:Button ID="boton_ingresar" runat="server" Text="Iniciar Sesión"  CssId="boton_ingresar" OnClick="boton_ingresar_Click"/>
                <asp:Button ID="boton_registrar" runat="server" Text="Registrarse"  CssId="boton_registrar"/>
        </div>
    </form>
</body>
</html>
