<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BusquedaMantenimiento.aspx.cs" Inherits="Alpheus_0._6.BusquedaMantenimiento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="Buscartxt" runat="server"></asp:TextBox>
            <asp:Button ID="Buscar" runat="server" Text="Buscar" OnClick="Buscar_Click" />
            <br />
            <asp:Label ID="LabelPrueba" runat="server"></asp:Label>
        </div>
        <div>
            <!--
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Area"></asp:TemplateField>
                    <asp:TemplateField HeaderText="No de Serie"></asp:TemplateField>
                    <asp:TemplateField HeaderText="Tipo"></asp:TemplateField>
                    <asp:TemplateField HeaderText="Marca"></asp:TemplateField>
                    <asp:TemplateField HeaderText="Modelo"></asp:TemplateField>
                    <asp:TemplateField HeaderText="RAM"></asp:TemplateField>
                    <asp:TemplateField HeaderText="DiscoDuro"></asp:TemplateField>
                    <asp:TemplateField HeaderText="S.O."></asp:TemplateField>
                    <asp:TemplateField HeaderText="Office"></asp:TemplateField>
                    <asp:TemplateField HeaderText="Procesador"></asp:TemplateField>
                    <asp:TemplateField HeaderText="Mouse"></asp:TemplateField>
                    <asp:TemplateField HeaderText="Teclado"></asp:TemplateField>
                    <asp:TemplateField HeaderText="Monitor"></asp:TemplateField>
                    <asp:TemplateField HeaderText="Inventario"></asp:TemplateField>
                    <asp:TemplateField HeaderText="Estatus">
                        <ItemTemplate>
                            <asp:DropDownList ID="DropDownList1" runat="server">
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha Ultimo Mantenimiento"></asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha Programada"></asp:TemplateField>
                    <asp:ButtonField HeaderText="Quitar" Text="Quitar" />
                </Columns>
            </asp:GridView>
            -->
            <asp:GridView ID="AreaGrid" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="ID"></asp:TemplateField>
                    <asp:TemplateField HeaderText="Area"></asp:TemplateField>
                    <asp:ButtonField Text="Botón" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
