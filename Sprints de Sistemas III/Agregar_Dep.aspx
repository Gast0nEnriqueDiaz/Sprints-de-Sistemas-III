<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Agregar_Dep.aspx.cs" Inherits="Sprints_de_Sistemas_III.Agregar_Dep" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <p>
        <br />
        <table class="nav-justified">
            <tr>
                <td style="height: 17px; width: 148px">
                    <asp:Label ID="Label1" runat="server" Text="Nombre del Deposito:"></asp:Label>
                </td>
                <td style="height: 17px">
                    <asp:TextBox ID="Nomb_dep" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 148px">
                    <asp:Label ID="Label2" runat="server" Text="Direccion:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Direcc_dep" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </p>
    <br />
    <asp:Button ID="Agregar_depo" runat="server" OnClick="Agregar_depo_Click" Text="Agregar Nuevo Deposito" />
&nbsp;&nbsp;&nbsp;
       <asp:Button ID="Button1" runat="server" PostBackUrl="~/Agregar Inv.aspx" Text="Volver" />
</asp:Content>
