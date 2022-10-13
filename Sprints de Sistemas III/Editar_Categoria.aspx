<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Editar_Categoria.aspx.cs" Inherits="Sprints_de_Sistemas_III.Editar__Nuevo" EnableEventValidation="False" EnableSessionState="True" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <table class="nav-justified">
            <tr>
                <td style="height: 17px; width: 195px">
                    <asp:Label ID="Label1" runat="server" Text="Nombre de la categoria:"></asp:Label>
                </td>
                <td style="height: 17px">
                    <asp:TextBox ID="Nomb_Cat" runat="server"></asp:TextBox>
                    <asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 195px">
                    <asp:Label ID="Label2" runat="server" Text="Descripcion de categoria:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Desct_cat" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </p>
    <asp:Label ID="Alert_lb" runat="server" Text="Esta Categoria ya existe" Visible="False"></asp:Label>
    <br />
    <asp:Button ID="Agregar_Cat" runat="server" OnClick="Agregar_Cat_Click" Text="Agregar Nueva Categoria" />
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" PostBackUrl="~/Agregar Inv.aspx" Text="Volver" />
</asp:Content>
