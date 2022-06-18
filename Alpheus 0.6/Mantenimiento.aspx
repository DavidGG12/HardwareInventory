<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mantenimiento.aspx.cs" Inherits="Alpheus_0._6.Mantenimiento" %>

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
     <!--Icono de la barra superior-->
    <div class="container-fluid">
        <div class="row justify-content-center align-content-center">
            <div class="col-8 barra">
                <h4>LOGO</h4>
            </div>

            <div class="col-4 text-right barra">
                <ul class="navbar-nav mr-auto">
                    <li>
                        <!--Menu Sesión-->
                        <asp:Label ID="SesionLbl" runat="server" Text="Usuario"></asp:Label>
                        <a href="#" class="px-3 text-light perfil dropdown-toggle" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><i class="fas fa-user-circle user"></i></a>

                        <div class="dropdown-menu" aria-labelledby="navbar-dropdown">
                            <!--METER CLASE PARA CERRAR SESION-->
                            <a class="dropdown-item menuperfil cerrar" href="Login.aspx"><i class="fas fa-sign-out-alt m-1"></i>Salir
                            </a>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </div>

    <!--Menu lateral-->
    <div class="container-fluid">
        <div class="row">
            <div class="barra-lateral col-12 col-sm-auto">
                <nav class="menu d-flex d-sm-block justify-content-center flex-wrap">
                    <a href="computadoras.aspx"><i class="fas fa-desktop"></i>  Registro de CPU/Dispositivos</a>
                    <a href="Alta.aspx"><i class="fas fa-mouse"></i>  Transferencia CPU/Dispositivos</a>
                    <a href="Registrar_Area.aspx"><i class="fas fa-map-marker-alt"></i>  Registro de Áreas</a>
                    <a href="Cambio.aspx"><i class="fa-solid fa-arrow-right-arrow-left"></i>  Cambio de CPU/Dispositivo</a>
                    <a href="Registro.aspx"><i class="fas fa-users"></i>  Registro de Usuario</a>
                    <a href="Mantenimiento.aspx"><i class="fa-solid fa-bars"></i>  Reporte de Mantenimiento</a>
                    <a href="Edicion.aspx"><i class="fa-solid fa-pen-to-square"></i> Edición CPU/Usuario</a>
                    
                </nav>
            </div>
                    
           <main class="main col"> 
               <!--Error-->
                <asp:Label ID="Error" runat="server" Text="" />
                <h4>Formulario de Mantenimiento</h4>

                <asp:RadioButtonList ID="CPU_DISP_RBtnList" runat="server" CssClass="texto" AutoPostBack="true" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True">Dispositivos</asp:ListItem>
                    <asp:ListItem>CPU</asp:ListItem>
                </asp:RadioButtonList>

                <asp:Label ID ="Folio" runat="server" CssClass="texto" Text="Folio: "></asp:Label>
                <asp:TextBox ID="FolioTxt" CssClass="input" runat="server" ></asp:TextBox>   
               
                <asp:Label ID="Nombre" runat="server" CssClass="texto" Text="Nombre del Solicitante: "></asp:Label>
                <asp:DropDownList ID="NombreTxtList" runat="server" CssClass="input" DataSourceID="NombreSql" DataTextField="Usuario_Recibidor" DataValueField="Usuario_Recibidor"></asp:DropDownList>
                <asp:SqlDataSource ID="NombreSql" runat="server" ConnectionString="<%$ ConnectionStrings:MatiasConnection %>" SelectCommand="SELECT [Usuario_Recibidor] FROM [Transferencia]"></asp:SqlDataSource>
                <asp:Button ID="BuscarBtn" runat="server" Text="Buscar" CssClass="boton" OnClick="BuscarBtn_Click" />

               <div class="row">
                    <div class="col-md-4 col-md-offset">
                         <div class="form-group">
                            <asp:Label ID="AreaLbl" CssClass="texto" runat="server" Text="Area:"></asp:Label>
                         </div>           
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-4 col-md-offset">
                        <div class="form-group">
                            <asp:Label ID="MarcaLbl" runat="server" CssClass="texto" Text="Marca:"></asp:Label>                            
                        </div>
                    </div>

                    <div class="col-md-4 col-md-offset">
                        <div class="form-group">
                            <asp:Label ID="NoSerieLbl" runat="server" CssClass="texto" Text="No. de Serie: "></asp:Label>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-4 col-md-offset">
                        <div class="form-group">
                            <asp:Label ID="InventarioLbl" runat="server" CssClass="texto" Text="No. de Inventario: "></asp:Label>
                        </div>
                    </div>

                    <div class="col-md-4 col-md-offset">
                        <div class="form-group">
                            <asp:Label ID="ModeloLbl" runat="server" CssClass="texto" Text="Modelo: "></asp:Label>
                        </div>
                    </div>
                </div>   
               
               <asp:Label ID="Servicio" runat="server" Text="Servicio Solicitado: "></asp:Label>
               <asp:TextBox ID="ServicioTxt" runat="server"></asp:TextBox>

               <asp:Label ID="TipoMantenimiento" runat="server" Text="Tipo de Mantenimiento: "></asp:Label>
               <asp:RadioButtonList ID="TipoMantenimientoRBtnList" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                   <asp:ListItem>Preventivo</asp:ListItem>
                   <asp:ListItem>Correctivo</asp:ListItem>
                   <asp:ListItem>Otro:</asp:ListItem>
                </asp:RadioButtonList>
               <asp:TextBox ID="OtroTxt" runat="server" Enabled="false"></asp:TextBox>


                <asp:Label ID="DescripcionFalla" runat="server" Text="Descripción técnica de la falla: "></asp:Label>
               <asp:TextBox ID="DescripcionFallaTxt" runat="server"></asp:TextBox>

               <asp:Label ID="DescripcionSoporte" runat="server" Text="Descripción del soporte técnico brindado: "></asp:Label>
               <asp:TextBox ID="DescripcionSoporteTxt" runat="server"></asp:TextBox>
            <asp:Button ID="RegistrarBtn" runat="server" Text="Registrar" OnClick="RegistrarBtn_Click" />
            </main>
        </div>
    </div>

      <!--Scrips--> 
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.min.js"></script>
    <script src="https://kit.fontawesome.com/646c794df3.js"></script>
    </form>
</body>
</html>
