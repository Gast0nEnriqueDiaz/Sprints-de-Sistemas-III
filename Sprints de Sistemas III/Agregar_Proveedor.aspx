<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Agregar_Proveedor.aspx.cs" Inherits="Sprints_de_Sistemas_III.Agregar_Proveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <table class="nav-justified" style="width: 39%">
            <tr>
                <td style="height: 17px; width: 218px">
                    <asp:Label ID="Nomb_lb" runat="server" Text="Nombre del Proveedor:"></asp:Label>
                </td>
                <td style="height: 17px; width: 176px;">
                    <asp:TextBox ID="Nomb_prov" runat="server"></asp:TextBox>
                </td>
                <td style="height: 17px; width: 161px;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="height: 17px; width: 218px">
                    <asp:Label ID="Telf_lb" runat="server" Text="Telefono:"></asp:Label>
                </td>
                <td style="height: 17px; width: 176px;">
                    <asp:TextBox ID="Telf_prov" runat="server"></asp:TextBox>
                </td>
                <td style="height: 17px; width: 161px;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 218px">
                    <asp:Label ID="Direc_lb" runat="server" Text="Direccion:"></asp:Label>
                </td>
                <td style="width: 176px">
                    <asp:TextBox ID="Direcc_prov" runat="server"></asp:TextBox>
                </td>
                <td style="width: 161px">
                    &nbsp;</td>
            </tr>
        </table>
        </p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Ya existe un proveedor con ese nombre" Visible="False"></asp:Label>
    </p>
    <p>
                    <asp:Button ID="Guardar_btn" runat="server" OnClick="Guardar_btn_Click" Text="Guardar Proveedor" />
                </p>
</asp:Content>
