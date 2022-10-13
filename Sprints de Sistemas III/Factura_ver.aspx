<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Factura_ver.aspx.cs" Inherits="Sprints_de_Sistemas_III.Factura_ver" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Facturas</h1>
    <p>
        <asp:TextBox ID="Buscador_fact_tx" runat="server"></asp:TextBox>
        <asp:Button ID="Buscador_fact" runat="server" OnClick="Button1_Click" Text="Buscar" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Nueva_fact" runat="server" PostBackUrl="~/Facturas.aspx" Text="Nueva Factura" />
    </p>
    <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="Espera_btn" runat="server" Text="En espera" Visible="False" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Pagadas_btn" runat="server" Text="Pagadas" Visible="False" />
    </p>
    <p>
        <asp:GridView ID="Fact_colum" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="Numero" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                <asp:BoundField DataField="ID_ord" HeaderText="Orden" />
                <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                <asp:BoundField DataField="NombreCompleto" HeaderText="Proveedor" />
                <asp:BoundField DataField="MontoPagar" HeaderText="Monto" />
                <asp:BoundField DataField="MetodoPago" HeaderText="Metodo de pago" />
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:Button ID="Pagar_Btn" runat="server" OnClick="Pagar_Btn_Click" Text="Pagar" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </p>
    <p>&nbsp;</p>
</asp:Content>
