<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Alpheus_0._6.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="css/Login.css" type="text/css" />
    <link rel="icon" type="image/ico" href="img/icon.ico" />
    <title>Iniciar Sesión</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="box">
            <asp:Label ID="Error" runat="server" />
                </br>
                <label>Usuario: </label>
                </br>
                <asp:TextBox ID="Usuario" runat="server" Text="" class="Usuario" placeholder="Usuario"/>
                </br>
                </br>
                <label>Contraseña: </label>
                </br>

                <asp:TextBox ID="contraseña" runat="server" Text="" placeholder="********" class="contraseña" TextMode ="Password" />
                </br>
                </br>
                <asp:Button ID="boton_ingresar" runat="server" Text="Iniciar Sesión"  CssClass="boton_ingresar" OnClick="boton_ingresar_Click"/>
                <!--&nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp-->
                <asp:Button ID="boton_registrar" runat="server" Text="Registrarse"  CssClass="boton_registrar"/>
            <br />
        </div>
    </form>
</body>
</html>
