<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Facturas.aspx.cs" Inherits="Sprints_de_Sistemas_III.Facturas" EnableEventValidation="False" EnableSessionState="True" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Registrar Una Nueva Factura</h1>
    <p>
        <br />
    </p>
    <table class="nav-justified" style="width: 85%">
        <tr>
            <td style="width: 506px; height: 69px">Ingrese el N° de orden de compra:
                <asp:TextBox ID="Num_ord" runat="server"></asp:TextBox>
                <asp:Button ID="Buscador_fact" runat="server" Text="Buscar" OnClick="Button1_Click" />
                <br />
                <br />
                Seleccione el Tipo de Factura:
                <asp:DropDownList ID="Tipo_fact" runat="server">
                    <asp:ListItem>A</asp:ListItem>
                    <asp:ListItem>B</asp:ListItem>
                    <asp:ListItem>C</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 274px; height: 69px">Datos del Proveedor:<br />
                Cuii:
                <asp:Label ID="Cuil_lb" runat="server" Text="Label" Visible="False"></asp:Label>
                <br />
                Telefono:
                <asp:Label ID="Telf_lb" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
            <td style="height: 69px; width: 296px;">Nombre:<asp:Label ID="Nomb_lb" runat="server" Text="Label" Visible="False"></asp:Label>
                <br />
                Mail:<asp:Label ID="Mail_lb" runat="server" Text="Label" Visible="False"></asp:Label>
                <br />
                Direccion:<asp:Label ID="Direc_lb" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 20px; width: 506px">Lista de Articulos solicitados: 
                <br />
                <asp:GridView ID="Colum_Detalles_ord" runat="server" AutoGenerateColumns="False" DataKeyNames="ID">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="COD" />
                        <asp:BoundField DataField="ID_Ord" HeaderText="Nro Orden" Visible="False" />
                        <asp:BoundField DataField="Nombre" HeaderText="Articulo" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                        
                    </Columns>
                </asp:GridView>
                <br />
            </td <%--aaaaa--%>>
            <td style="height: 20px; width: 274px">Ingresar Total a Pagar:<asp:TextBox ID="Total_fac" runat="server" TextMode="Number" Width="94px"></asp:TextBox>

                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Debe ser un valor superior a 0" ControlToValidate="Total_fac" Operator="GreaterThan" Type="Integer" ValueToCompare="0"></asp:CompareValidator>

                <br />
                <br />
                Forma de Pago:<asp:DropDownList ID="Met_pago" runat="server" Height="16px" Width="87px">
                    <asp:ListItem Value="Targeta">Targeta</asp:ListItem>
                    <asp:ListItem Value="Efectivo">Efectivo</asp:ListItem>
                    <asp:ListItem Value="Contado">Contado</asp:ListItem>
                    <asp:ListItem Value="Cuotas">Cuotas</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="height: 20px; width: 296px;">
                <asp:Label ID="ID_ord" runat="server" Text="Label" Visible="False"></asp:Label>
                <asp:Label ID="ID_prov" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 506px">&nbsp;</td>
            <td style="width: 274px">
                <asp:Button ID="Button2" runat="server" Text="Guardar" OnClick="Button2_Click" />
            </td>
            <td class="modal-sm" style="width: 296px">
                <asp:Button ID="Button3" runat="server" Text="Cancelar" PostBackUrl="~/Factura_ver.aspx" />
            </td>
        </tr>
    </table>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
