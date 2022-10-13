<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle_ord.aspx.cs" Inherits="Sprints_de_Sistemas_III.Detalle_ord" EnableEventValidation="False" EnableSessionState="True" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <H1>Agregar Articulos a la a orden N° 
            <asp:Label ID="ID_ord" runat="server" Text="label"></asp:Label></H1>
            <p>
        <asp:Label ID="ID_art" runat="server" Text="Label" Visible="False"></asp:Label>
    </p>
    <p>
        <table class="nav-justified" style="width: 99%; height: 255px;">
            <tr>
                <td style="width: 290px; height: 20px">
        <asp:TextBox ID="Buscador_art" runat="server" Width="210px">Ingrese Categoria/Nombre/COD</asp:TextBox>
        <asp:Button ID="Buscar_art_btn" runat="server" OnClick="Buscar_art_btn_Click" Text="Buscar" />
                    <br />
                    Articulos para solicitar:</td>
                <td style="width: 168px; height: 20px">Lista de articulos de la orden:</td>
            </tr>
            <tr>
                <td style="width: 290px" class="modal-sm">
        <asp:GridView ID="Articulos_Colum" runat="server" AutoGenerateColumns="False" Width="364px" DataKeyNames="ID">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Nombre_categoria" HeaderText="Categoria" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:Button ID="Articulo_SelectBtn" runat="server" OnClick="Articulo_SelectBtn_Click" Text="Seleccionar" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
                </td>
                <td style="width: 168px">
                <asp:GridView ID="Colum_Detalles_ord" runat="server" AutoGenerateColumns="False" DataKeyNames="ID">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="COD" />
                        <asp:BoundField DataField="ID_Ord" HeaderText="Nro Orden" Visible="False" />
                        <asp:BoundField DataField="Nombre" HeaderText="Articulo" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                        <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:Button ID="Quitar_artBtn" runat="server" OnClick="Quitar_artBtn_Click" Text="Quitar" />
                    </ItemTemplate>
                </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                    <br />
                </td>
            </tr>
            <tr>
                <td style="width: 290px; height: 40px;">
        <asp:Label ID="Nomb_art_lb" runat="server" Text="Seleccione un articulo"></asp:Label>
    &nbsp;&nbsp;&nbsp; </td>
                <td style="width: 168px; height: 40px;">
                    <asp:Button ID="Button1" runat="server" PostBackUrl="~/Ordenes_comp.aspx" Text="Volver" />
                </td>
            </tr>
            <tr>
                <td style="width: 290px" class="modal-sm">
                    <asp:Label ID="Cant_lb" runat="server" Text="Cantidad a solicitar :"></asp:Label>
                    <asp:TextBox ID="Cant_tx" runat="server" TextMode="Number" Width="40px">1</asp:TextBox>
&nbsp;<br />
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Debe ser un valor superior a 0" ControlToValidate="Cant_tx" Operator="GreaterThan" Type="Integer" ValueToCompare="0"></asp:CompareValidator>

                    <br />
                    <asp:Label ID="Alert_lb" runat="server" Text="Ese articulo ya esta en la orden" Visible="False"></asp:Label>
                    <br />
                    <asp:Button ID="Agre_art_ord" runat="server" OnClick="Agre_art_ord_Click" Text="Agregar a Orden" Visible="False" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" Text="Cancelar" OnClick="Button2_Click" />
                &nbsp;&nbsp;&nbsp;
                </td>
                <td style="width: 168px">&nbsp;</td>
            </tr>
        </table>
        <br />
    </p>
    <p>
        <br />
    </p>
    <p>
        &nbsp;</p>
</asp:Content>
