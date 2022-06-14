<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Alta.aspx.cs" Inherits="Alpheus_0._6.Alta" %>

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
                        &nbsp;<asp:SqlDataSource ID="Area" runat="server" ConnectionString="<%$ ConnectionStrings:MatiasConnection %>" SelectCommand="SELECT [Subarea] FROM [Subareas]"></asp:SqlDataSource>
                        <label>No. de Control Interno: </label>
                        <asp:TextBox ID="ResguardatarioTxt" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        <label>Área de destino: </label>
                        <asp:DropDownList ID="AreaDestinoList" runat="server" DataSourceID="Area" DataTextField="Subarea" DataValueField="Subarea"></asp:DropDownList>
                        <label>Ubicación física: </label>
                        <asp:DropDownList ID="UbicacionList" runat="server">
                            <asp:ListItem>EDIFICIO A</asp:ListItem>
                            <asp:ListItem>EDIFICIO B</asp:ListItem>
                            <asp:ListItem>EDIFICIO C</asp:ListItem>
                            <asp:ListItem>EDIFICIO F</asp:ListItem>
                            <asp:ListItem>EDIFICIO G</asp:ListItem>
                            <asp:ListItem>EDIFICIO J</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <br />
                        <label>Usuario Responsable del Centro de Computo: </label>
                        <asp:DropDownList ID="UsuarioList" runat="server" DataSourceID="Usuario" DataTextField="Usuario" DataValueField="Usuario"></asp:DropDownList>
                        <asp:SqlDataSource ID="Usuario" runat="server" ConnectionString="<%$ ConnectionStrings:MatiasConnection %>" SelectCommand="SELECT [Usuario] FROM [Usuario]"></asp:SqlDataSource>
                        <label>Nombre Recibe: </label>
                        <asp:TextBox ID="RecibeTxt" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        <label>Motivo: </label>
                        <asp:TextBox ID="MotivoTxt" runat="server"></asp:TextBox>
                        <br />
                        <br />

                        <div>
                            <asp:Label ID="error" runat="server" Text=""></asp:Label>
                            <asp:TextBox ID="BuscarTxt" runat="server"></asp:TextBox>
                            <asp:Button ID="Buscar" runat="server" Text="Buscar" OnClick="Buscar_Click" />
                            <br />
                            <div>
                                <asp:GridView ID="CPUGrid" runat="server" AutoGenerateColumns="False" OnRowCommand="QuitarBtn">
                                    <Columns>
                                        <asp:TemplateField HeaderText="No Serie"></asp:TemplateField>
                                        <asp:TemplateField HeaderText="Tipo"></asp:TemplateField>
                                        <asp:TemplateField HeaderText="Nombre"></asp:TemplateField>
                                        <asp:TemplateField HeaderText="Marca"></asp:TemplateField>
                                        <asp:TemplateField HeaderText="Modelo"></asp:TemplateField>
                                        <asp:TemplateField HeaderText="RAM (GB)"></asp:TemplateField>
                                        <asp:TemplateField HeaderText="Disco Duro (GB)"></asp:TemplateField>
                                        <asp:TemplateField HeaderText="SO"></asp:TemplateField>
                                        <asp:TemplateField HeaderText="Office"></asp:TemplateField>
                                        <asp:TemplateField HeaderText="Procesador"></asp:TemplateField>
                                        <asp:TemplateField HeaderText="No Inventario"></asp:TemplateField>
                                        <asp:ButtonField Text="Quitar" ButtonType="Button"  />
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div>
                                <asp:GridView ID="DisGrid" runat="server" AutoGenerateColumns="False" OnRowCommand="QuitarBtn">
                                    <Columns>
                                        <asp:TemplateField HeaderText="No Serie"></asp:TemplateField>
                                        <asp:TemplateField HeaderText="Tipo"></asp:TemplateField>
                                        <asp:TemplateField HeaderText="Marca"></asp:TemplateField>
                                        <asp:TemplateField HeaderText="Modelo"></asp:TemplateField>
                                        <asp:TemplateField HeaderText="No Inventario"></asp:TemplateField>
                                        <asp:ButtonField Text="Quitar" ButtonType="Button"  />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <asp:Button ID="Registrar" runat="server" Text="Adelante" OnClick="Registrar_Click" />
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
