<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="stock_dep.aspx.cs" Inherits="Sprints_de_Sistemas_III.stock_dep" EnableEventValidation="False" EnableSessionState="True" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
    </p>
    <p>
                <asp:TextBox ID="busc_txt" runat="server"></asp:TextBox>
                <asp:Button ID="Buscador_btn" runat="server" Text="Buscar " OnClick="Button1_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Ver_art_btn" runat="server" Text="Agregar Articulo" OnClick="Ver_art_btn_Click" />
        <br />
    </p>
    <table id="Tabla_cat1" style="width: 87%">
        <tr>
            <td style="width: 166px; height: 22px">
        <asp:GridView ID="Articulos_Colum" runat="server" AutoGenerateColumns="False" Width="419px" DataKeyNames="ID">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Nombre_categoria" HeaderText="Categoria" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="Stock_Deposit" HeaderText="Stock En Deposito" />
                <asp:TemplateField HeaderText="Editar">
                    <ItemTemplate>
                        <asp:Button ID="Articulo_editBtn" runat="server" OnClick="Articulo_editBtn_Click" Text="Actualizar Stock" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
            </td>
            <td style="width: 11px; height: 22px">
                <asp:Label ID="ID_art_add" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
            <td style="width: 300px; height: 22px">
                <asp:Label ID="Busc_lb" runat="server" Text="Ingrese el COD, o nombre :" Visible="False"></asp:Label>
                <asp:TextBox ID="Busc_art_txt" runat="server" Visible="False"></asp:TextBox>
                <asp:Button ID="Bus_art_btn" runat="server" OnClick="Bus_art_btn_Click" Text="Button" Visible="False" />
        <asp:GridView ID="Articulos_Colum0" runat="server" AutoGenerateColumns="False" Width="364px" DataKeyNames="ID">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Nombre_categoria" HeaderText="Categoria" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                <asp:TemplateField HeaderText="Editar">
                    <ItemTemplate>
                        <asp:Button ID="Articulo_selectBtn0" runat="server" OnClick="Articulo_selectBtn0_Click" Text="Seleccionar" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

            </td>
        </tr>
        <tr>
            <td style="width: 166px; height: 22px">
                <asp:Label ID="Art_stk_lb" runat="server" Text="Stock" Visible="False"></asp:Label>
                <asp:TextBox ID="Art_stk" runat="server" TextMode="Number" Visible="False" Width="89px"></asp:TextBox>

                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Debe ser un valor superior a 0" ControlToValidate="Art_stk" Operator="GreaterThan" Type="Integer" ValueToCompare="0"></asp:CompareValidator>

            </td>
            <td style="width: 11px; height: 22px">
                &nbsp;</td>
            <td style="width: 300px; height: 22px">
                <asp:Label ID="Stock_lb2" runat="server" Text="Cantidad a guardar:" Visible="False"></asp:Label>
                <asp:TextBox ID="Art_add_Stock" runat="server" TextMode="Number" Visible="False" Width="80px">1</asp:TextBox>

                <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Debe ser un valor superior a 0" ControlToValidate="Art_add_Stock" Operator="GreaterThan" Type="Integer" ValueToCompare="0"></asp:CompareValidator>

            </td>
        </tr>
        <tr>
            <td style="width: 166px">
                <asp:Button ID="Art_camb_btn" runat="server" Text="Guardar Cambios" Visible="False" OnClick="Art_camb_btn_Click" />
            </td>
            <td class="modal-sm" style="width: 11px">
                <asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label>
                <asp:Label ID="Cant_orig" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
            <td class="modal-sm">
                <asp:Button ID="Add_art_btn" runat="server" OnClick="Add_art_btn_Click" Text="Agregar al Deposito" Visible="False" />
                <asp:Label ID="Alerta_lb" runat="server" Text="Ese articulo ya se encuentra en el deposito" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
    <p>
        <asp:Button ID="Button1" runat="server" PostBackUrl="~/Agregar Inv.aspx" Text="Volver" />
    </p>
</asp:Content>
