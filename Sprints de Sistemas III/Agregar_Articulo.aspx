<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Agregar_Articulo.aspx.cs" Inherits="Sprints_de_Sistemas_III.Agregar_Articulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <p>
        <br />
        <table class="nav-justified">
            <tr>
                <td style="height: 17px; width: 195px">
                    <asp:Label ID="Label1" runat="server" Text="Nombre del Articulo:"></asp:Label>
                </td>
                <td style="height: 17px">
                    <asp:TextBox ID="Nomb_art" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 195px; height: 22px;">
                    <asp:Label ID="Label2" runat="server" Text="Categoria a la que pertenece:"></asp:Label>
                </td>
                <td style="height: 22px">
                    <asp:DropDownList ID="Categorias_list" runat="server" DataSourceID="SqlDataSource1" DataTextField="Nombre_categoria" DataValueField="Nombre_categoria">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:hospitalConnectionString %>" SelectCommand="SELECT [Nombre_categoria] FROM [Categorias]" OnSelecting="SqlDataSource1_Selecting"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 195px; height: 22px;">
                    <asp:Label ID="Label3" runat="server" Text="Precio:"></asp:Label>
                </td>
                <td style="height: 22px">
                    <asp:TextBox ID="Precio" runat="server" TextMode="Number" Width="90px"></asp:TextBox>

                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Debe ser un valor superior a 0" ControlToValidate="Precio" Operator="GreaterThan" Type="Integer" ValueToCompare="0"></asp:CompareValidator>

                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 195px; height: 22px;">
                    <asp:Label ID="Label4" runat="server" Text="Descipcion:"></asp:Label>
                </td>
                <td style="height: 22px">
                    <asp:TextBox ID="Descripcion" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 195px; height: 22px;">
                    <asp:Label ID="Label5" runat="server" Text="Stock a ingresar:" Visible="False"></asp:Label>
                </td>
                <td style="height: 22px">
                    <asp:TextBox ID="Stock" runat="server" style="margin-left: 82" TextMode="Number" Width="46px" Visible="False"></asp:TextBox>
                </td>
            </tr>
        </table>
    </p>
       <asp:Label ID="Alert_lb" runat="server" Text="Este Articulo ya existe en la base de datos" Visible="False"></asp:Label>
    <br />
    <asp:Button ID="Agregar_Art" runat="server" OnClick="Agregar_Art_Click" Text="Agregar Nuevo Articulo" />
&nbsp;&nbsp;&nbsp;
       <asp:Button ID="Button1" runat="server" PostBackUrl="~/Agregar Inv.aspx" Text="Volver" />
</asp:Content>
