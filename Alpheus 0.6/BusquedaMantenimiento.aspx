﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BusquedaMantenimiento.aspx.cs" Inherits="Alpheus_0._6.BusquedaMantenimiento" %>

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
    </form>
</body>
</html>
