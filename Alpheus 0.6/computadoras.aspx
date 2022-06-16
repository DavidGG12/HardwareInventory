<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="computadoras.aspx.cs" Inherits="Alpheus_0._6.computadoras" %>

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
                    <a href="#"><i class="fa-solid fa-bars"></i>  Reporte de Mantenimiento</a>
                    <a href="#"><i class="fa-solid fa-pen-to-square"></i> Edición CPU/Usuario</a>
                    
                </nav>
            </div>
                    
           <main class="main col"> 
               <!--Error-->
               <asp:Label ID="Error" runat="server" Text="" />
              
                        <!--estilo de boostrap para poner formulario doble/agruparlo-->
                        <div class="panel-body">
                            <h1 class="h1">Administrador</h1>
                             <p>Elija el formulario a rellenar.</p>
                            <div class="row">
                                <div class="col-md-4 col-md-offset-1">
                                <div class="form-group">
                                   <!--Radio button para seleccionar el registro a llenar-->
                                    <asp:RadioButtonList ID="DispCPURadio" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DispCPURadio_SelectedIndexChanged" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1" Text="Dispositivos" Selected="True">Dispositivos</asp:ListItem>
                                    <asp:ListItem Value="2" Text="CPU">CPU</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                              </div>
                            </div>


                            <div class="row">
                                <div class="col-md-4 col-md-offset-1">
                                    <div class="form-group">
                                        <!--No. serie-->
                                        <asp:Label ID="NoSerie" runat="server" CssClass="texto" Text="No. Serie: " />
                                            <asp:TextBox ID="NoSerieTxt" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-4 col-md-offset-1">
                                    <div class="form-group">
                                        <!--Área en función-->
                                        <asp:Label ID="Area" runat="server" CssClass="texto"  Text="Area destinada: " />
                                        <asp:DropDownList ID="AreaList" runat="server" CssClass="Area" DataTextField="Subarea" DataValueField="Subarea" DataSourceID="AreaSql"></asp:DropDownList>
                                        <asp:SqlDataSource ID="AreaSql" runat="server" ConnectionString="<%$ ConnectionStrings:MatiasConnection %>" SelectCommand="SELECT [Subarea] FROM [Subareas]"></asp:SqlDataSource>                       
                                    </div>
                                </div>

                         
                             <div class="col-md-4 col-md-offset-1">
                                 <div class="form-group">
                                     <!--Tipo de dispositivo-->
                                     <asp:Label ID="Tipo" runat="server" CssClass="texto"  Text="Tipo de dispositivo: " />
                                        <asp:DropDownList ID="TipoList" runat="server">
                                        <asp:ListItem>LAPTOP</asp:ListItem>
                                        <asp:ListItem>PC</asp:ListItem>
                                            <asp:ListItem>MOUSE</asp:ListItem>
                                            <asp:ListItem>TECLADO</asp:ListItem>
                                            <asp:ListItem>MONITOR</asp:ListItem>
                                     </asp:DropDownList>
                                 </div>
                             </div>
                        </div>

                        <div class="row">
                             <div class="col-md-4 col-md-offset-1">
                                 <div class="form-group">
                                     <!--Nombre del dispositivo-->
                                     <asp:Label ID="Nombre" runat="server" CssClass="texto"  Text="Nombre del dispositivo: " />
                                     <asp:TextBox ID="NombreTxt" runat="server" Enabled="False"></asp:TextBox>
                                 </div>
                             </div>

                            <div class="col-md-4 col-md-offset-1">
                                <div class="form-group">
                                    <!--Nombre de la marca-->
                                    <asp:Label ID="Marca" runat="server"  CssClass="texto" Text="Marca del dispositivo: " />
                                    <asp:TextBox ID="MarcaTxt" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4 col-md-offset-1">
                                <div class="form-group">
                                    <!--Modelo del dispositivo-->
                                    <asp:Label ID="Modelo" runat="server" CssClass="texto"  Text="Modelo del dispositivo: " />
                                    <asp:TextBox ID="ModeloTxt" runat="server"></asp:TextBox>
                                </div>
                            </div>
                       </div>

                       <div class="row">
                           <div class="col-md-4 col-md-offset-1">
                               <div class="form-group">
                                   <!--Modelo del dispositivo-->
                                   <asp:Label ID="RAM" runat="server" CssClass="texto" Text="Tamaño en RAM(gb): " />
                                   <asp:TextBox ID="RAMTxt" runat="server" TextMode="Number" Enabled="False"></asp:TextBox>
                               </div>
                           </div>

                           <div class="col-md-4 col-md-offset-1">
                               <div class="form-group">
                                   <!--Tamaño Disco Duro del dispositivo-->
                                   <asp:Label ID="DiscoDuro" runat="server" CssClass="texto" Text="Tamaño en disco duro(gb): " />
                                   <asp:TextBox ID="DiscoTxt" runat="server" TextMode="Number" Enabled="False"></asp:TextBox>
                               </div>
                           </div>

                           <div class="col-md-4 col-md-offset-1">
                               <div class="form-group">
                                   <!--Sistema Oprativo del dispositivo-->
                                    <asp:Label ID="SO" runat="server" CssClass="texto" Text="Sistema Operativo del dispositivo: " />
                                    <asp:TextBox ID="SOText" runat="server" Enabled="False"></asp:TextBox>
                           </div>
                        </div>
                     </div>
                     
                     <div class="row">
                          <div class="col-md-4 col-md-offset-1">
                               <div class="form-group">
                                   <!--Office del dispositivo-->
                                       <asp:Label ID="Office" runat="server" CssClass="texto" Text="Office integrado: " />
                                       <asp:TextBox ID="OfficeTxt" runat="server" Enabled="False"></asp:TextBox>
                                   </div>
                              </div>

                         <div class="col-md-4 col-md-offset-1">
                               <div class="form-group">
                                   <!--Procesador del dispositivo-->
                                   <asp:Label ID="Procesador" runat="server" CssClass="texto"  Text="Procesador integrado: " />
                                   <asp:TextBox ID="ProcesadorTxt" runat="server" Enabled="False"></asp:TextBox> 
                                   </div>
                             </div>

                         <div class="col-md-4 col-md-offset-1">
                               <div class="form-group">
                                   <!--No. de Inventario del dispositivo-->
                                   <asp:Label ID="NoInventario" runat="server" CssClass="texto" Text="No. indicado de Inventario: " />
                                   <asp:TextBox ID="NoInventarioTxt" runat="server"></asp:TextBox>
                                   </div>
                             </div>
                         </div>

                        <div class="row">
                          <div class="col-md-4 col-md-offset-1">
                               <div class="form-group">
                                   <!--Estatus del dispositivo-->
                                   <asp:Label ID="Estatus" runat="server" CssClass="texto" Text="Estatus del dispositivo: " />
                                    <asp:DropDownList ID="EstatusList" runat="server">
                                        <asp:ListItem>BAJA</asp:ListItem>
                                        <asp:ListItem>EN REVISION</asp:ListItem>
                                        <asp:ListItem>REVISADO</asp:ListItem>
                                    </asp:DropDownList>
                                   </div>
                              </div>

                            <div class="col-md-4 col-md-offset-1">
                               <div class="form-group">
                                   <!--Office del dispositivo-->
                                   <asp:Label ID="Observacion" runat="server" CssClass="texto" Text="Observaciones: " />
                                   <asp:TextBox ID="ObservacionTxt" runat="server"></asp:TextBox>
                            </div>
                          </div>
                        </div>

                             <div class="row">
                               <div class="col-md-4 col-md-offset-1">
                               <div class="form-group">
                                   <!--botón registrar-->
                                  <asp:Button ID="Registrar" runat="server" Text="Registrar" CssClass="boton" OnClick="Registrar_Click" />
                               </div>
                              </div>
                             
                               <div class="col-md-4 col-md-offset-1">
                               <div class="form-group">
                                 <!--botón editar--> 
                                <asp:Button ID="Editar" runat="server" Text="Editar"  CssClass="boton-editar"/>
                              </div>
                            </div>

                                 <div class="col-md-4 col-md-offset-1">
                               <div class="form-group">
                                 <!--botón editar--> 
                                <asp:Button ID="Eliminar" runat="server" Text="Eliminar"  CssClass="boton-eliminar"/>
                              </div>
                            </div>
                           </div>
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
