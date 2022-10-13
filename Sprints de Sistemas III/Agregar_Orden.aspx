<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Agregar_Orden.aspx.cs" Inherits="Sprints_de_Sistemas_III.Agregar_Orden" EnableSessionState="True" EnableEventValidation="False" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Crear una nueva Orden de Compra</h1>
    <table class="nav-justified" style="width: 54%; height: 69px">
        <tr>
            <td style="width: 408px">
                <asp:TextBox ID="Buscador_prov_tx" runat="server"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
                <asp:Label ID="ID_prov" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
            <td>Datos del Proveedor:</td>
        </tr>
        <tr>
            <td style="width: 408px; height: 212px">
        <asp:GridView ID="Colum_Prov" runat="server" AutoGenerateColumns="False" DataKeyNames="ID">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="NombreCompleto" HeaderText="Proveedor" />
                <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:Button ID="Prov_selectBtn" runat="server" OnClick="Prov_selectBtn_Click" Text="Seleccionar" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
                <br />
                <asp:Button ID="Button2" runat="server" Text="Agregar Articulos" OnClick="Button2_Click" Visible="False" />
            </td>
            <td style="height: 212px">Nombre del Proveedor:
                <br />
                    <asp:Label ID="Nomb_lb" runat="server" Text="Nombre del Proveedor:" Visible="False"></asp:Label>
                &nbsp;<br />
                Telefono:<br />
                    <asp:Label ID="Telf_lb" runat="server" Text="Telefono:" Visible="False"></asp:Label>
                <br />
                Direccion:<br />
                    <asp:Label ID="Direc_lb" runat="server" Text="Direccion:" Visible="False"></asp:Label>
                <br />
                CUIL:</td>
        </tr>
        <tr>
            <td style="width: 408px">
                <asp:Button ID="Button3" runat="server" PostBackUrl="~/Ordenes_comp.aspx" Text="Cancelar" />
            </td>
            <td>
                <asp:Button ID="Button4" runat="server" Text="Cambiar de Proveedor" Visible="False" OnClick="Button4_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 408px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <p>
        <br />
    </p>
</asp:Content>
