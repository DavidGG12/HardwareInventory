<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Alpheus_0._6.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <meta name="viewport" content="width=device-width, initial-scale=1.0"/> 
    <!--titulo de la pestaña-->
    <title>Iniciar Sesión</title>
    <!--estilos para iconos font awesome-->
    <link href="font-6/css/all.css" rel="stylesheet" />
     <!--Conexión a la hoja de estilos-->
     <link rel="stylesheet" href="css/Login.css" type="text/css" />
    <!--icono de la pestaña-->
    <link rel="icon" type="image/ico" href="img/icon.ico" />
     <!--Fuentes de texto en la pagina-->
    <link href="https://fonts.googleapis.com/css?family=Nunito&display=swap" rel="stylesheet"/> 
    <link href="https://fonts.googleapis.com/css?family=Overpass&display=swap" rel="stylesheet"/>
    <!--Scrips de transiciones-->
    <script type="text/javascript"></script>
</head>
<body>
    <!--Mensaje de Advertencia-->
  <asp:Label ID="Error" runat="server" />
      <!--Contenedor-->
      <div id="contenedor">
          <div id="central">
              <div id="login">
                 
                  <!--Estilo del titulo -->
                  <div class="titulo">Bienvenido</div>                  
                  <!--formulario-->
                    <form id="form2" class="login" runat="server"> 
                        <asp:Label runat="server" ID="error_login" Text="" />
                        <asp:TextBox ID="Usuario" name="Usuario" placeholder="Usuario" runat="server" CssClass="input"></asp:TextBox>
                         <asp:TextBox ID="Contraseña" placeholder="Contraseña" required="required" runat="server" TextMode="Password" CssClass="input"/>
                         <asp:Button ID="boton" runat="server" Text="Ingresar" CssClass="boton" OnClick="boton_ingresar_Click"/>
                         
                        </form>
                  </div>
                </div>
          </div>        
      </body>
</html>
