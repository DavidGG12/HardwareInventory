<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edicion.aspx.cs" Inherits="Alpheus_0._6.Edicion" %>

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
               <!--Error-->
               <asp:Label ID="Error" runat="server" Text="" />
                <!--estilo de boostrap para poner formulario doble/agruparlo-->
                        <div class="panel-body">
                            <legend>Actualizar Datos: </legend>

                            <div class="row">
                                <div class="col-md-4 col-md-offset-1">
                                    <div class="form-group">
                                        <!--Nombre-->
                                        <asp:Label ID="NombreUsuario" runat="server" CssClass="texto" Text="Nombre: " />
                                            <asp:TextBox ID="NombreUsuarioTxt" runat="server" CssClass="input" Text=""></asp:TextBox>
                                    </div>
                                </div>
                             <div class="col-md-4 col-md-offset-1">
                                 <div class="form-group">
                                     <!--Apellido Paterno-->
                                     <asp:Label ID="ApellidoP" runat="server" CssClass="texto"  Text="Apellido Paterno: " />
                                        <asp:TextBox ID="ApellidoPTxt" runat="server" CssClass="input" Text=""></asp:TextBox>
                                 </div>
                             </div>
                             <div class="col-md-4 col-md-offset-1">
                                 <div class="form-group">
                                     <!--Apellido Materno-->
                                     <asp:Label ID="ApellidoM" runat="server" CssClass="texto"  Text="Apellido Materno: " />
                                        <asp:TextBox ID="ApellidoMTxt" runat="server" CssClass="input" Text=""></asp:TextBox>
                                 </div>
                             </div>
                        </div>

                        <div class="row">
                             <div class="col-md-4 col-md-offset-1">
                                 <div class="form-group">
                                     <!--Usario-->
                                     <asp:Label ID="Usuario" runat="server" CssClass="texto"  Text="Usuario: " />
                                     <asp:Label ID="UsuarioLbl" runat="server" CssClass="input" Text=""></asp:Label>
                                 </div>
                             </div>

                            <div class="col-md-4 col-md-offset-1">
                                <div class="form-group">
                                    <!--Contraseña-->
                                    <asp:Label ID="Contraseña" runat="server"  CssClass="texto" Text="Contraseña: " />
                                    <asp:TextBox ID="ContraseñaTxt" runat="server" CssClass="input" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4 col-md-offset-1">
                                <div class="form-group">
                                    <!--Revalidar Contraseña-->
                                    <asp:Label ID="ContraseñaRev" runat="server" CssClass="texto"  Text="Revalida Contraseña: " />
                                    <asp:TextBox ID="ContraseñaRevTxt" runat="server" CssClass="input" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                       </div>

                             
                               <div class="col-md-4 col-md-offset-1">
                               <div class="form-group">
                                   <!--botón registrar-->
                                  <asp:Button ID="ActualizarUsuario" runat="server" Text="Actualizar" CssClass="boton" OnClick="ActualizarUsuario_Click"  />
                              
                              </div>
                            </div>     
                

                    <br />
                    <br />
                    <br />
                        <!--estilo de boostrap para poner formulario doble/agruparlo-->
                        <div class="panel-body">
                            <legend>Actualizar CPU/Disp</legend>
                            <div class="row">
                                <div class="col-md-4 col-md-offset-1">
                                <div class="form-group">
                                   <!--Radio button para seleccionar el registro a llenar-->
                                    <asp:RadioButtonList ID="DispCPURadio" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" OnSelectedIndexChanged="DispCPURadio_SelectedIndexChanged">
                                    <asp:ListItem Value="1" Text="Dispositivos" Selected="True">Dispositivos</asp:ListItem>
                                    <asp:ListItem Value="2" Text="CPU">CPU</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                              </div>
                            </div>

                            <br />
                            <asp:Label ID="Error_CPU" runat="server" Text=""></asp:Label>
                            <br />
                            <div class="row">
                                <div class="col-md-4 col-md-offset-1">
                                    <div class="form-group">
                                        <!--No. serie-->
                                        <asp:Label ID="NoSerie" runat="server" CssClass="texto" Text="No. Serie: " />
                                            <asp:TextBox ID="NoSerieTxt" runat="server"></asp:TextBox>
                                            <asp:Button ID="Buscar" runat="server"  Text="Buscar" CssClass="boton" OnClick="Buscar_Click"/>
                                    </div>
                                </div>
                            <br />
                            <br />
                        </div>

                        <div class="row">
                             <div class="col-md-4 col-md-offset-1">
                                 <div class="form-group">
                                     <!--Nombre del dispositivo-->
                                     <asp:Label ID="Nombre" runat="server" CssClass="texto"  Text="Nombre del dispositivo: " />
                                     <asp:TextBox ID="NombreTxt" runat="server" CssClass="input" Enabled="False"></asp:TextBox>
                                 </div>
                             </div>

                            <div class="col-md-4 col-md-offset-1">
                                <div class="form-group">
                                    <!--Nombre de la marca-->
                                    <asp:Label ID="Marca" runat="server"  CssClass="texto" Text="Marca del dispositivo: " />
                                    <asp:TextBox ID="MarcaTxt" CssClass="input" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4 col-md-offset-1">
                                <div class="form-group">
                                    <!--Modelo del dispositivo-->
                                    <asp:Label ID="Modelo" runat="server" CssClass="texto"  Text="Modelo del dispositivo: " />
                                    <asp:TextBox ID="ModeloTxt" CssClass="input" runat="server"></asp:TextBox>
                                </div>
                            </div>
                       </div>

                       <div class="row">
                           <div class="col-md-4 col-md-offset-1">
                               <div class="form-group">
                                   <!--Modelo del dispositivo-->
                                   <asp:Label ID="RAM" runat="server" CssClass="texto" Text="Tamaño en RAM(gb): " />
                                   <asp:TextBox ID="RAMTxt" runat="server" CssClass="input" TextMode="Number" Enabled="False"></asp:TextBox>
                               </div>
                           </div>

                           <div class="col-md-4 col-md-offset-1">
                               <div class="form-group">
                                   <!--Tamaño Disco Duro del dispositivo-->
                                   <asp:Label ID="DiscoDuro" runat="server" CssClass="texto" Text="Tamaño en disco duro(gb): " />
                                   <asp:TextBox ID="DiscoTxt" runat="server" CssClass="input" TextMode="Number" Enabled="False"></asp:TextBox>
                               </div>
                           </div>

                           <div class="col-md-4 col-md-offset-1">
                               <div class="form-group">
                                   <!--Sistema Oprativo del dispositivo-->
                                    <asp:Label ID="SO" runat="server" CssClass="texto" Text="Sistema Operativo del dispositivo: " />
                                    <asp:TextBox ID="SOText" runat="server" CssClass="input" Enabled="False"></asp:TextBox>
                           </div>
                        </div>
                     </div>
                     
                     <div class="row">
                          <div class="col-md-4 col-md-offset-1">
                               <div class="form-group">
                                   <!--Office del dispositivo-->
                                       <asp:Label ID="Office" runat="server" CssClass="texto" Text="Office integrado: " />
                                       <asp:TextBox ID="OfficeTxt" runat="server" CssClass="input" Enabled="False"></asp:TextBox>
                                   </div>
                              </div>

                         <div class="col-md-4 col-md-offset-1">
                               <div class="form-group">
                                   <!--Procesador del dispositivo-->
                                   <asp:Label ID="Procesador" runat="server" CssClass="texto"  Text="Procesador integrado: " />
                                   <asp:TextBox ID="ProcesadorTxt" runat="server" CssClass="input" Enabled="False"></asp:TextBox> 
                                   </div>
                             </div>

                         <div class="col-md-4 col-md-offset-1">
                               <div class="form-group">
                                   <!--No. de Inventario del dispositivo-->
                                   <asp:Label ID="NoInventario" runat="server" CssClass="texto" Text="No. indicado de Inventario: " />
                                   <asp:TextBox ID="NoInventarioTxt" CssClass="input" runat="server"></asp:TextBox>
                                   </div>
                             </div>
                         </div>

                            <div class="col-md-4 col-md-offset-1">
                               <div class="form-group">
                                   <!--Office del dispositivo-->
                                   <asp:Label ID="Observacion" runat="server" CssClass="texto" Text="Observaciones: " />
                                   <asp:TextBox ID="ObservacionTxt" CssClass="input" runat="server"></asp:TextBox>
                            </div>
                          </div>
                        </div>

                             <div class="row">
                               <div class="col-md-4 col-md-offset-1">
                               <div class="form-group">
                                   <!--botón registrar-->
                                  <asp:Button ID="Actualizar" runat="server" Text="Actualizar" CssClass="boton" OnClick="Actualizar_Click"  />
                               </div>
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
