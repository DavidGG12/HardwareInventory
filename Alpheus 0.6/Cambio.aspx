﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cambio.aspx.cs" Inherits="Alpheus_0._6.Cambio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/estiloadm.css" />
    <title></title>
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
                        
                        <a href="#" class="px-3 text-light perfil dropdown-toggle" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><i class="fas fa-user-circle user"></i></a>

                        <div class="dropdown-menu" aria-labelledby="navbar-dropdown">
                            <a class="dropdown-item menuperfil cerrar" href="#"><i class="fas fa-sign-out-alt m-1"></i>Salir
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
                    <a href="#"><i class="fas fa-desktop"></i><span>CPU</span></a>
                    <a href="#"><i class="fas fa-mouse"></i><span>Dispositivo</span></a>
                    <a href="#"><i class="fas fa-users"></i><span>Registro Usuario</span></a>
                    <a href="#"><i class="fas fa-map-marker-alt"></i><span>Áreas</span></a>
                    
                </nav>
            </div>
            <main class="main col">
                <div class="row justify-content-center align-content-center text-center">
                    <!--Tabla va aquí-->
                    <div class="columna col-lg-6">
                        <asp:Label ID="Error" runat="server" Text="" ></asp:Label>
                        <br />
                        <asp:RadioButtonList ID="CPU_DISP_RBtnList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="CPU_DISP_RBtnList_SelectedIndexChanged" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True">Dispositivos</asp:ListItem>
                            <asp:ListItem>CPU</asp:ListItem>
                        </asp:RadioButtonList>
                        <br />
                        <asp:Label ID ="Folio" runat="server" Text="Folio: "></asp:Label>
                        <asp:TextBox ID="FolioTxt" runat="server" ></asp:TextBox>
                        <br />
                        <asp:Label ID="Nombre" runat="server" Text="Nombre del Solicitante: "></asp:Label>
                        <asp:DropDownList ID="NombreTxtList" runat="server" DataSourceID="NombreSql" DataTextField="Usuario_Recibidor" DataValueField="Usuario_Recibidor"></asp:DropDownList>
                        <asp:SqlDataSource ID="NombreSql" runat="server" ConnectionString="<%$ ConnectionStrings:MatiasConnection %>" SelectCommand="SELECT [Usuario_Recibidor] FROM [Transferencia]"></asp:SqlDataSource>
                        <asp:Button ID="BuscarBtn" runat="server" Text="Buscar" OnClick="BuscarBtn_Click" />
                        <br />
                        <br />
                        <asp:Label ID="AreaLbl" runat="server" Text="Area:"></asp:Label>
                        <br />
                        <asp:Label ID="MarcaLbl" runat="server" Text="Marca:"></asp:Label>
                        <asp:Label ID="NoSerieLbl" runat="server" Text="No. de Serie: "></asp:Label>
                        <br />
                        <asp:Label ID="InventarioLbl" runat="server" Text="No. de Inventario: "></asp:Label>
                        <asp:Label ID="ModeloLbl" runat="server" Text="Modelo: "></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="TipoMantenimiento" runat="server" Text="Tipo de Mantenimiento: "></asp:Label>
                        <br />
                        <asp:RadioButtonList ID="TipoMantenimientoRBtnList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="TipoMantenimientoRBtnList_SelectedIndexChanged" RepeatDirection="Horizontal">
                            <asp:ListItem>Preventivo</asp:ListItem>
                            <asp:ListItem>Correctivo</asp:ListItem>
                            <asp:ListItem>Otro</asp:ListItem>

                        </asp:RadioButtonList>
                        <asp:TextBox ID="OtroTxt" runat="server" Enabled="false"></asp:TextBox>
                        <br />
                        <asp:Label ID="Observacion" runat="server" Text="Observación: "></asp:Label>
                        <asp:TextBox ID="ObservacionTxt" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="NoSerie1" runat="server" Text="No. de Serie: "></asp:Label>
                        <asp:DropDownList ID="NoSerieListCPU" runat="server" Enabled="false" DataSourceID="NoSerieSql" DataTextField="NoSerie" DataValueField="NoSerie" AutoPostBack="true" OnSelectedIndexChanged="NoSerieListCPU_SelectedIndexChanged"></asp:DropDownList>
                        <asp:SqlDataSource ID="NoSerieSql" runat="server" ConnectionString="<%$ ConnectionStrings:MatiasConnection %>" SelectCommand="SELECT [NoSerie] FROM [CPU]"></asp:SqlDataSource>
                        <asp:Label ID="NoSerie2" runat="server" Text="No. de Serie: "></asp:Label>
                        <asp:DropDownList ID="NoSerieListDisp" runat="server"></asp:DropDownList>
                        <br />
                        <br />
                        <asp:Label ID="Entrega" runat="server" Text="Entrega"></asp:Label>
                        <asp:Label ID="Retira" runat="server" Text="Retira"></asp:Label>
                        <br />
                        <asp:Label ID="TipoLblEntrega" runat="server" Text="Tipo: "></asp:Label>
                        <asp:Label ID="TipoLblRetiro" runat="server"  Text="Tipo:"></asp:Label>
                        <br />
                        <asp:Label ID="MarcaLblEntrega" runat="server" Text="Marca: "></asp:Label>
                        <asp:Label ID="MarcaLblRetiro" runat="server" Text="Marca: "></asp:Label>
                        <br />
                        <asp:Label ID="ModeloLblEntrega" runat="server" Text="Modelo: "></asp:Label>
                        <asp:Label ID="ModeloLblRetiro" runat="server" Text="Modelo: "></asp:Label>
                        <br />
                        <asp:Label ID="NoSerieLblEntrega" runat="server" Text="No. de Serie: "></asp:Label>
                        <asp:Label ID="NoSerieLblRetiro" runat="server" Text="No. de Serie: "></asp:Label>
                        <br />
                        <asp:Label ID="NoInventarioLblEntrega" runat="server" Text="No. de Inventario: "></asp:Label>
                        <asp:Label ID="NoInventarioLblRetiro" runat="server" Text="No. de Inventario: "></asp:Label>
                        <br />
                        <br />
                        <asp:Button ID="RegistrarBtn" runat="server" Text="Registrar" OnClick="RegistrarBtn_Click" />
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