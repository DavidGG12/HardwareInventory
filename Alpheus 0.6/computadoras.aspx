<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="computadoras.aspx.cs" Inherits="Alpheus_0._6.computadoras" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/estiloadm.css" />

    <title>Administrador</title>

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
                    <a href="Registro.aspx"><i class="fas fa-users"></i><span>Registro Usuario</span></a>
                    <a href="#"><i class="fas fa-map-marker-alt"></i><span>Áreas</span></a>
                    
                </nav>
            </div>
            <main class="main col">
                <div class="row justify-content-center align-content-center text-center">
                    <!--Tabla va aquí-->
                    <div class="columna col-lg-6">
                        <asp:Label ID="Error" runat="server" Text="" />
                        <br />
                        <br />
                        <asp:RadioButtonList ID="DispCPURadio" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DispCPURadio_SelectedIndexChanged" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1" Text="Dispositivos" Selected="True">Dispositivos</asp:ListItem>
                            <asp:ListItem Value="2" Text="CPU">CPU</asp:ListItem>
                        </asp:RadioButtonList>
                        <br />
                        <asp:Label ID="NoSerie" runat="server" Text="No. Serie: " />
                        <asp:TextBox ID="NoSerieTxt" runat="server"></asp:TextBox>

                        <asp:Label ID="Area" runat="server" Text="Area: " />
                        <asp:DropDownList ID="AreaList" runat="server" DataSourceID="AreaSql" DataTextField="Subarea" DataValueField="Subarea"></asp:DropDownList>
                        
                        <asp:SqlDataSource ID="AreaSql" runat="server" ConnectionString="<%$ ConnectionStrings:MatiasConnection %>" SelectCommand="SELECT [Subarea] FROM [Subareas]"></asp:SqlDataSource>
                        
                        <asp:Label ID="Tipo" runat="server" Text="Tipo: " />
                        <asp:DropDownList ID="TipoList" runat="server">
                            <asp:ListItem>LAPTOP</asp:ListItem>
                            <asp:ListItem>PC</asp:ListItem>
                        </asp:DropDownList>

                        <asp:Label ID="Nombre" runat="server" Text="Nombre: " />
                        <asp:TextBox ID="NombreTxt" runat="server" Enabled="False"></asp:TextBox>

                        <asp:Label ID="Marca" runat="server" Text="Marca: " />
                        <asp:TextBox ID="MarcaTxt" runat="server"></asp:TextBox>

                        <asp:Label ID="Modelo" runat="server" Text="Modelo: " />
                        <asp:TextBox ID="ModeloTxt" runat="server"></asp:TextBox>

                        <asp:Label ID="RAM" runat="server" Text="Tamaño RAM GB: " />
                        <asp:TextBox ID="RAMTxt" runat="server" TextMode="Number" Enabled="False"></asp:TextBox>

                        <asp:Label ID="DiscoDuro" runat="server" Text="Tamaño Disco Duro GB: " />
                        <asp:TextBox ID="DiscoTxt" runat="server" TextMode="Number" Enabled="False"></asp:TextBox>

                        <asp:Label ID="SO" runat="server" Text="Sistema Operativo: " />
                        <asp:TextBox ID="SOText" runat="server" Enabled="False"></asp:TextBox>

                        <asp:Label ID="Office" runat="server" Text="Office: " />
                        <asp:TextBox ID="OfficeTxt" runat="server" Enabled="False"></asp:TextBox>

                        <asp:Label ID="Procesador" runat="server" Text="Procesador: " />
                        <asp:TextBox ID="ProcesadorTxt" runat="server" Enabled="False"></asp:TextBox>

                        <asp:Label ID="NoInventario" runat="server" Text="No Inventario: " />
                        <asp:TextBox ID="NoInventarioTxt" runat="server"></asp:TextBox>

                        <asp:Label ID="Estatus" runat="server" Text="Estatus: " />
                        <asp:DropDownList ID="EstatusList" runat="server">
                            <asp:ListItem>BAJA</asp:ListItem>
                            <asp:ListItem>EN REVISION</asp:ListItem>
                            <asp:ListItem>REVISADO</asp:ListItem>
                        </asp:DropDownList>

                        <asp:Label ID="Observacion" runat="server" Text="Observación: " />
                        <asp:TextBox ID="ObservacionTxt" runat="server"></asp:TextBox>

                        <br />
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
