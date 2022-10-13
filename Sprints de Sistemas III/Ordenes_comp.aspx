<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ordenes_comp.aspx.cs" Inherits="Sprints_de_Sistemas_III.Ordenes_comp" EnableSessionState="True" EnableEventValidation="False" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Ordenes de Compra</h1>
    <p>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
    </p>
    <p>
        <asp:TextBox ID="Buscador_ord_tx" runat="server" style="height: 22px"></asp:TextBox>
        <asp:Button ID="Buscar_OrdNro_btn" runat="server" OnClick="Buscar_art_btn_Click" Text="Buscar" />
    &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Agregar_ord" runat="server" Text="Agregar Orden" OnClick="Agregar_ord_Click" PostBackUrl="~/Agregar_Orden.aspx" />
    </p>
    <p>
        <asp:Button ID="Aprob_btn" runat="server" OnClick="Aprob_btn_Click" Text="Aprobadas" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ESP_btn" runat="server" OnClick="ESP_btn_Click" Text="Sin Aprobar" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Fact_btn" runat="server" OnClick="Fact_btn_Click" Text="Facturadas" />
    </p>
    <table class="nav-justified">
        <tr>
            <td style="width: 640px">
                <br />
        <asp:GridView ID="Colum_Ord" runat="server" AutoGenerateColumns="False" DataKeyNames="ID">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="Numero de Orden" />
                <asp:BoundField DataField="NombreCompleto" HeaderText="Proveedor" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:Button ID="Ord_detalles" runat="server" OnClick="Ord_detalles_Click" Text="Ver Detalles" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:Button ID="Ord_editBtn" runat="server" OnClick="Ord_editBtn_Click" Text="Editar" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
            </td>
            <td>
                <asp:Label ID="NRo_ord_lb" runat="server" Text="Label" Visible="False"></asp:Label>
                <br />
                <asp:Button ID="Agregar_art_btn" runat="server" Text="Agregar" OnClick="Agregar_art_btn_Click" Visible="False" />
                <br />
                <asp:GridView ID="Colum_Detalles_ord" runat="server" AutoGenerateColumns="False" DataKeyNames="ID">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="COD" />
                        <asp:BoundField DataField="ID_Ord" HeaderText="Nro Orden" Visible="False" />
                        <asp:BoundField DataField="Nombre" HeaderText="Articulo" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                        <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:Button ID="Art_editBtn" runat="server" OnClick="Art_editBtn_Click" Text="Editar" />
                    </ItemTemplate>
                </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 640px; height: 20px;"></td>
            <td style="height: 20px">
                <table class="nav-justified">
                    <tr>
                        <td style="height: 20px; width: 155px">
                            <asp:Label ID="Label2" runat="server" Text="Cantidad" Visible="False"></asp:Label>
                        </td>
                        <td style="height: 20px">
                            <asp:TextBox ID="Cant_tx" runat="server" TextMode="Number" Visible="False" Width="56px"></asp:TextBox>
                            <asp:Label ID="ID_deta" runat="server" Text="Label" Visible="False"></asp:Label>

                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Debe ser un valor superior a 0" ControlToValidate="Cant_tx" Operator="GreaterThan" Type="Integer" ValueToCompare="0"></asp:CompareValidator>

                        </td>
                    </tr>
                    <tr>
                        <td class="modal-sm" style="width: 155px">
                            <asp:Button ID="Cant_cam_bt" runat="server" OnClick="Cant_cam_bt_Click" Text="Cambiar Cantidad" Visible="False" Width="144px" />
                        </td>
                        <td>
                            <asp:Button ID="Borar_art" runat="server" OnClick="Borar_art_Click" Text="Quitar Articulo" Visible="False" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;&nbsp;&nbsp;
        <table class="nav-justified" style="width: 39%">
            <tr>
                <td style="height: 17px; width: 218px">
                    <asp:Label ID="Nomb_Prov_lb" runat="server" Text="Nombre del Proveedor:" Visible="False"></asp:Label>
                </td>
                <td style="height: 17px; width: 176px;">
                    <asp:DropDownList ID="Lista_provs" runat="server" DataSourceID="SqlDataSource1" DataTextField="NombreCompleto" DataValueField="ID" Visible="False">
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:hospitalConnectionString %>" SelectCommand="SELECT * FROM [Proveedor]"></asp:SqlDataSource>
                </td>
                <td style="height: 17px; width: 161px;">
                </td>
            </tr>
            <tr>
                <td style="height: 17px; width: 218px">
                    <asp:Button ID="Camb_prov_btn" runat="server" Text="Cambiar Proveedor" Visible="False" OnClick="Camb_prov_btn_Click" />
                </td>
                <td style="height: 17px; width: 176px;">
                    <asp:Button ID="Ord_aprob_btn" runat="server" Text="Aprobar Orden" Visible="False" OnClick="Ord_aprob_btn_Click" />
                </td>
                <td style="height: 17px; width: 161px;">
                    <asp:Button ID="Borrar_ord_btn" runat="server" Text="Borrar" Visible="False" OnClick="Borrar_ord_btn_Click" />
                </td>
            </tr>
            </table>
    </p>
    <p>
        &nbsp;</p>
                    </asp:Content>
