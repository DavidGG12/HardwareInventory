<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Alpheus_0._6.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <!--titulo de la pestaña-->
    <title>TESH - Hardware</title>
    <!--estilos para iconos font awesome-->
    <link href="font-6/css/all.css" rel="stylesheet" />
     <!--Conexión a la hoja de estilos-->
    <link rel="stylesheet" href="css/estiloadm.css" />
    <!--icono de la pestaña-->
    <link rel="icon" type="image/ico" href="img/icon.ico" />
    <!--Estilos de Boostrap-->
    <link rel="stylesheet" href="css/bootstrap.min.css" />
     <!--Fuentes de texto en la pagina-->
    <link href="https://fonts.googleapis.com/css?family=Nunito&display=swap" rel="stylesheet"/> 
    <link href="https://fonts.googleapis.com/css?family=Overpass&display=swap" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row justify-content-center align-content-center">
                <div class="col-8 barra">
                    <h4 class="text-light">Logo</h4>
                </div>
                <div class="col-4 text-right barra">
                    <ul class="navbar-nav mr-auto">
                        <li>
                            <!--Menu Sesión-->
                            <asp:Label ID="SesionLbl" runat="server" Text="Usuario"></asp:Label>
                            <a href="#" class="px-3 text-light perfil dropdown-toggle" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><i class="fas fa-user-circle user"></i></a>

                            <div class="dropdown-menu" aria-labelledby="navbar-dropdown">
                                <a class="dropdown-item menuperfil cerrar" href="Login.aspx"><i class="fas fa-sign-out-alt m-1"></i>Salir
                                </a>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </div>

        <!--Menu-->
        <div class="container-fluid">
            <div class="row">
                <div class="barra-lateral col-12 col-sm-auto">
                    <nav class="menu d-flex d-sm-block justify-content-center flex-wrap">
                        <a href="computadoras.aspx"><i class="fas fa-desktop"></i>  Registro de CPU/Dispositivos</a>
                        <a href="Alta.aspx"><i class="fas fa-mouse"></i>  Transferencia CPU/Dispositivos</a>
                        <a href="Registrar_Area.aspx"><i class="fas fa-map-marker-alt"></i>  Registro de Áreas</a>
                        <a href="Cambio.aspx"><i class="fa-solid fa-arrow-right-arrow-left"></i>  Cambio de CPU/Dispositivo</a>
                        <a href="Registro.aspx"><i class="fas fa-users"></i>  Registro de Usuario</a>
                        <a href="#"><i class="fa-solid fa-bars"></i>  Reporte de Mantenimiento</a>
                        <a href="#"><i class="fa-solid fa-pen-to-square"></i> Edición CPU/Usuario</a>
                    
                    </nav>
                </div>
                <main class="main col">
                    <div class="row justify-content-center align-content-center text-center">
                        <!--Tabla va aquí-->
                        <div class="columna col-lg-6">
                            <asp:Label ID="Error" runat="server" Text="" />
                            <legend>Agregar Usuario:</legend>
                            <br />
                            <label>Tipo: </label>
                            <br />
                            <asp:DropDownList ID="TipoList" runat="server" DataSourceID="Tipo" DataTextField="Tipo" DataValueField="Tipo"></asp:DropDownList>
                            <asp:SqlDataSource ID="Tipo" runat="server" ConnectionString="<%$ ConnectionStrings:MatiasConnection %>" SelectCommand="SELECT [Tipo] FROM [Tipo_Usuario]"></asp:SqlDataSource>
                            <br />
                            <label>Nombre: </label>
                            </br>
                            <asp:TextBox ID="Nombre" runat="server" Text="" />
                            </br>
                            <label>Apellido Paterno: </label>
                            </br>
                            <asp:TextBox ID="Apellido_Paterno" runat="server" Text="" />
                            </br>
                            <label>Apellido Materno: </label>
                            </br>
                            <asp:TextBox ID="Apellido_Materno" runat="server" Text="" />
                            </br>
                            <label>Usuario: </label>
                            </br>
                            <asp:TextBox ID="Usuario" runat="server" Text="" />
                            </br>
                            <label>Contraseña: </label><asp:Label runat="server" ID="Error_Contraseña" Text=""/>
                            </br>
                            <asp:TextBox ID="Contraseña" runat="server" Text="" TextMode="Password" />
                            </br>
                            <label></label>
                            </br>
                            <label>Revalidar Contraseña: </label><asp:Label runat="server" ID="Error_Contraseña_nCoincide" Text=""/>
                            </br>
                            <asp:TextBox ID="Contraseña_Revalidar" runat="server" Text="" TextMode="Password" />
                            <br />
                            <asp:Button ID="Registrar" runat="server" Text="Registrar" OnClick="Registrar_Click" />
                        </div>
                    </div>
                </main>
            </div>
        </div>





        <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.min.js"></script>
        <script src="https://kit.fontawesome.com/646c794df3.js"></script>
    </form>
</body>
</html>
