<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BusquedaMantenimiento.aspx.cs" Inherits="Alpheus_0._6.BusquedaMantenimiento" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link rel="stylesheet" type="text/css" href="css/Busqueda.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!--<asp:ScriptManager ID="scm" runat="server"></asp:ScriptManager>-->
            <asp:Panel ID="VtnModal" runat="server" style="display: none; width: 340px; height: 240px;" class="ModalContenedor">
                <div style="width: 340px; height: 240px;">
                    <asp:Label ID="msg" runat="server" />
                    <br />
                    <asp:Button ID="CerrarModal" runat="server" Text="Cerrar" />
                </div>
            </asp:Panel>
            <div>
                <asp:TextBox ID="Buscartxt" runat="server"></asp:TextBox>
                <asp:Button ID="Buscar" runat="server" Text="Buscar" OnClick="Buscar_Click" />
                <br />
                <asp:Label ID="LabelPrueba" runat="server"></asp:Label>
                <asp:Label ID="LabelPrueba2" runat="server"></asp:Label>
            </div>
            <div>
                <asp:GridView ID="CPUGrid" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="No Serie"><asp:TemplateField>
                        <asp:TemplateField HeaderText="Tipo"></asp:TemplateField>
                        <asp:TemplateField HeaderText="Usuario"></asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre"></asp:TemplateField>
                        <asp:TemplateField HeaderText="Marca"></asp:TemplateField>
                        <asp:TemplateField HeaderText="Modelo"></asp:TemplateField>
                        <asp:TemplateField HeaderText="RAM (GB)"></asp:TemplateField>
                        <asp:TemplateField HeaderText="Disco Duro (GB)"></asp:TemplateField>
                        <asp:TemplateField HeaderText="SO"></asp:TemplateField>
                        <asp:TemplateField HeaderText="Office"></asp:TemplateField>
                        <asp:TemplateField HeaderText="Procesador"></asp:TemplateField>
                        <asp:TemplateField HeaderText="No Inventario"></asp:TemplateField>
                        <asp:ButtonField Text="Quitar" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <!--Boton oculto para la ventana modal-->
        <asp:Button ID="BtnModal" runat="server" Text="Mostrar" style="display:none;"/>
        <ajaxToolkit:ModalPopupExtender ID="AjaModal" runat="server" OkControlID="CerrarModal" CancelControlID="CerrarModal" TargetControlID="BtnModal" PopupControlID="VtnModal"></ajaxToolkit:ModalPopupExtender>
    </form>
</body>
</html>
