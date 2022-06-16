<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrar_Area.aspx.cs" Inherits="Alpheus_0._6.Registrar_Area" %>

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
                        <asp:Label ID="Error" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:RadioButtonList ID="AreaSubAreaListTxt" runat="server" AutoPostBack="true" OnSelectedIndexChanged="AreaSubAreaListTxt_SelectedIndexChanged" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True">Área</asp:ListItem>
                            <asp:ListItem>Subárea</asp:ListItem>
                        </asp:RadioButtonList>
                        <br />
                        <legend>Registrar Área:</legend>
                        <br />
                        <asp:Label ID="Area" runat="server" Text="Área: "></asp:Label>
                        <br />
                        <asp:RadioButtonList ID="AdminLabRBtnList" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem>Administrativos</asp:ListItem>
                            <asp:ListItem>Laboratorio</asp:ListItem>
                            <asp:ListItem>Otro</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:TextBox ID="AreaTxt" runat="server"></asp:TextBox>
                        <br />
                        <legend>Registrar Subárea: </legend>
                        <br />
                        <asp:Label ID="AreaSub" runat="server" Text="Área: "></asp:Label>
                        <asp:DropDownList ID="AreaListTxt" runat="server" DataSourceID="AreaSql" DataTextField="Area" DataValueField="Area" Enabled="False"></asp:DropDownList>
                        <asp:SqlDataSource ID="AreaSql" runat="server" ConnectionString="<%$ ConnectionStrings:MatiasConnection %>" SelectCommand="SELECT [Area] FROM [Areas]"></asp:SqlDataSource>
                        <br />
                        <asp:Label ID="SubArea" runat="server" Text="Subárea: "></asp:Label>
                        <asp:TextBox ID="SubAreaTxt" runat="server" Enabled="False"></asp:TextBox>
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
