<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu_Proveedores.aspx.cs" Inherits="Sprints_de_Sistemas_III.Menu_Proveedores" EnableEventValidation="False" EnableSessionState="True" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <asp:Label ID="ID_prov" runat="server" Text="Label" Visible="False"></asp:Label>
        <br />
    <br />
        <asp:TextBox ID="Buscador_prov_tx" runat="server" style="height: 22px"></asp:TextBox>
        <asp:Button ID="Buscar_prov_btn" runat="server" OnClick="Buscar_art_btn_Click" Text="Buscarr" CssClass="button"/>
        &nbsp;&nbsp;&nbsp;    <asp:Button ID="Agregar_prov_btn" runat="server" Text="Agregar Proveedor" OnClick="Button1_Click" PostBackUrl="~/Agregar_Proveedor.aspx" />
        <br />
        <br />
        <table class="nav-justified" style="width: 39%">
            <tr>
                <td style="height: 17px; width: 218px">
                    <asp:Label ID="Nomb_lb" runat="server" Text="Nombre del Proveedor:" Visible="False"></asp:Label>
                </td>
                <td style="height: 17px; width: 176px;">
                    <asp:TextBox ID="Nomb_prov" runat="server" Visible="False"></asp:TextBox>
                </td>
                <td style="height: 17px; width: 161px;">
                    <asp:Label ID="Alert_lb" runat="server" Text="Ya existe este proveedor" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 17px; width: 218px">
                    <asp:Label ID="Telf_lb" runat="server" Text="Telefono:" Visible="False"></asp:Label>
                </td>
                <td style="height: 17px; width: 176px;">
                    <asp:TextBox ID="Telf_prov" runat="server" Visible="False"></asp:TextBox>
                </td>
                <td style="height: 17px; width: 161px;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 218px">
                    <asp:Label ID="Direc_lb" runat="server" Text="Direccion:" Visible="False"></asp:Label>
                </td>
                <td style="width: 176px">
                    <asp:TextBox ID="Direcc_prov" runat="server" Visible="False"></asp:TextBox>
                </td>
                <td style="width: 161px">
                    <asp:Button ID="Edit_prov_camb_btn" runat="server" OnClick="Edit_prov_camb_btn_Click" Text="Guardar Cambios" Visible="False" />
                </td>
            </tr>
        </table>
        <asp:GridView ID="Colum_Prov" runat="server" AutoGenerateColumns="False" AllowPaging="true" DataKeyNames="ID" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="NombreCompleto" HeaderText="Proveedor" />
                <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
                <asp:TemplateField HeaderText="Editar">
                    <ItemTemplate>
                        <center>
                            <asp:Button ID="Prov_editBtn" runat="server" OnClick="Prov_editBtn_Click" Text="Editar" />
                        </center>  
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <br />
        </asp:Content>
