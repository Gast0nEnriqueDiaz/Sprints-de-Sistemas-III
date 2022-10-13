<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mov_stock.aspx.cs" Inherits="Sprints_de_Sistemas_III.Mov_stock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Movimientos de Stock</h1>
    <p>
        Ingrese nombre/COD del articulo/ o deposito:
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Buscar" />
        <br />
    </p>
    <p>
        <asp:GridView ID="Stk_colum" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                <asp:BoundField DataField="Nombre" HeaderText="Deposito" />
                <asp:BoundField DataField="AN" HeaderText="Articulo" />
                <asp:BoundField DataField="Fecha_hora" HeaderText="Fecha" />
                <asp:BoundField DataField="Activ" HeaderText="Actividad" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
            </Columns>
        </asp:GridView>
    </p>
</asp:Content>
