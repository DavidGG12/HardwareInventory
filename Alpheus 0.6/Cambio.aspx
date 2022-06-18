<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cambio.aspx.cs" Inherits="Alpheus_0._6.Cambio" %>

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
                    <a href="Mantenimiento.aspx"><i class="fa-solid fa-bars"></i>  Reporte de Mantenimiento</a>
                    <a href="Edicion.aspx"><i class="fa-solid fa-pen-to-square"></i> Edición CPU/Usuario</a>
                    
                </nav>
            </div>
            <main class="main col">
                <asp:Label ID="Error" runat="server" Text="" ></asp:Label>
                        <br />
                <div class="panel-body">
                    <h4>Cambio de Equipo</h4>
                        <div class="row">
                            <div class="col-md-4 col-md-offset">
                                <div class="form-group">
                                    <asp:RadioButtonList ID="CPU_DISP_RBtnList" runat="server" CssClass="texto" AutoPostBack="true" OnSelectedIndexChanged="CPU_DISP_RBtnList_SelectedIndexChanged" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True">Dispositivos</asp:ListItem>
                                        <asp:ListItem>CPU</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4 col-md-offset">
                                <div class="form-group">
                                    <asp:Label ID ="Folio" runat="server" CssClass="texto" Text="Folio: "></asp:Label>
                                    <asp:TextBox ID="FolioTxt" CssClass="input" runat="server" ></asp:TextBox>
                                </div>
                             </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4 col-md-offset">
                                <div class="form-group">
                                    <asp:Label ID="Nombre" runat="server" CssClass="texto" Text="Nombre del Solicitante: "></asp:Label>
                                    <asp:DropDownList ID="NombreTxtList" runat="server" CssClass="input" DataSourceID="NombreSql" DataTextField="Usuario_Recibidor" DataValueField="Usuario_Recibidor"></asp:DropDownList>
                                    <asp:SqlDataSource ID="NombreSql" runat="server" ConnectionString="<%$ ConnectionStrings:MatiasConnection %>" SelectCommand="SELECT [Usuario_Recibidor] FROM [Transferencia]"></asp:SqlDataSource>
                                    <asp:Button ID="BuscarBtn" runat="server" Text="Buscar" CssClass="boton" OnClick="BuscarBtn_Click" />
                                </div>
                            </div>
                         </div>
                     
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
                        <div class="row">
                            <div class="col-md-4 col-md-offset">
                                <div class="form-group">
                                    <asp:Label ID="Observacion" runat="server" CssClass="texto" Text="Razón del Cambio: "></asp:Label>
                                    <asp:TextBox ID="ObservacionTxt" CssClass="input" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4 col-md-offset">
                                <div class="form-group">
                                    <asp:Label ID="NoSerie1" runat="server" CssClass="texto" Text="No. de Serie: "></asp:Label>
                                    <asp:DropDownList ID="NoSerieListCPU" CssClass="input" runat="server" Enabled="false" DataSourceID="NoSerieSql" DataTextField="NoSerie" DataValueField="NoSerie" AutoPostBack="true" OnSelectedIndexChanged="NoSerieListCPU_SelectedIndexChanged"></asp:DropDownList>
                                    <asp:SqlDataSource ID="NoSerieSql" runat="server" ConnectionString="<%$ ConnectionStrings:MatiasConnection %>" SelectCommand="SELECT [NoSerie] FROM [CPU]"></asp:SqlDataSource>                               
                                </div>
                            </div>
                            <div class="col-md-4 col-md-offset">
                                <div class="form-group">
                                    <asp:Label ID="NoSerie2" runat="server" CssClass="texto" Text="No. de Serie: "></asp:Label>
                                    <asp:DropDownList ID="NoSerieListDisp" runat="server" CssClass="input" DataSourceID="Disp" DataTextField="NoSerie" DataValueField="NoSerie" OnSelectedIndexChanged="NoSerieListDisp_SelectedIndexChanged"></asp:DropDownList>
                                    <asp:SqlDataSource ID="Disp" runat="server" ConnectionString="<%$ ConnectionStrings:MatiasConnection %>" SelectCommand="SELECT [NoSerie] FROM [Dispositivos]"></asp:SqlDataSource>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4 col-md-offset">
                                <div class="form-group">
                                    <!--<asp:Label ID="Entrega" runat="server" CssClass="texto" Text="Entrega"></asp:Label>-->
                                    <h4>Entrega</h4>
                                </div>
                            </div>
                            <div class="col-md-4 col-md-offset">
                                <div class="form-group">
                                    <h4>Retira</h4>
                                    <!--<asp:Label ID="Retira" runat="server" CssClass="texto" Text="Retira"></asp:Label>-->
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4 col-md-offset">
                                <div class="form-group">
                                    <asp:Label ID="TipoLblEntrega" runat="server" CssClass="texto" Text="Tipo: "></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-4 col-md-offset">
                                <div class="form-group">
                                    <asp:Label ID="TipoLblRetiro" runat="server" CssClass="texto" Text="Tipo:"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4 col-md-offset">
                                <div class="form-group">
                                    <asp:Label ID="MarcaLblEntrega" runat="server" CssClass="texto" Text="Marca: "></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-4 col-md-offset">
                                <div class="form-group">
                                    <asp:Label ID="MarcaLblRetiro" runat="server" CssClass="texto" Text="Marca: "></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4 col-md-offset">
                                <div class="form-group">
                                    <asp:Label ID="ModeloLblEntrega" runat="server" CssClass="texto" Text="Modelo: "></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-4 col-md-offset">
                                <div class="form-group">
                                    <asp:Label ID="ModeloLblRetiro" runat="server" CssClass="texto" Text="Modelo: "></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4 col-md-offset">
                                <div class="form-group">
                                    <asp:Label ID="NoSerieLblEntrega" runat="server" CssClass="texto" Text="No. de Serie: "></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-4 col-md-offset">
                                <div class="form-group">
                                    <asp:Label ID="NoSerieLblRetiro" runat="server" CssClass="texto" Text="No. de Serie: "></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4 col-md-offset">
                                <div class="form-group">
                                    <asp:Label ID="NoInventarioLblEntrega" runat="server" CssClass="texto" Text="No. de Inventario: "></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-4 col-md-offset">
                                <div class="form-group">
                                    <asp:Label ID="NoInventarioLblRetiro" runat="server" CssClass="texto" Text="No. de Inventario: "></asp:Label>
                                </div>
                            </div>
                        </div>
                        <asp:Button ID="RegistrarBtn" runat="server" CssClass="boton" Text="Registrar" OnClick="RegistrarBtn_Click" />
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
