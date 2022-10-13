<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu_Inicial.aspx.cs" Inherits="Sprints_de_Sistemas_III.Menu_Inicial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" >
    <center>
        <h1>Menú principal</h1>
    </center>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<table class="nav-justified" CssClass:"table1";>
            <tr>
                <td class="modal-sm" style="width: 284px">
                    <center>
                        <img alt="" src="Images/articulos.png" style="width: 137px; height: 223px" CssClass="images1"/>
                        </center>
                 </td>
                                    
                <td style="width: 50px">&nbsp;</td>
                <td style="width: 320px">
                    
                    <center>
                        <img alt="" src="Images/proveedor.jpg" style="width: 225px; height: 225px" />
                    </center>
                    </td>
                    
     
                <td style="width: 41px">&nbsp;</td>
                <td>
                    <center>
                        <img alt="" src="Images/ordenes%20de%20compra.png" style="width: 223px; height: 226px" />
                    </center>
                    

                </td>
                </tr>
            <tr>
                <td class="modal-sm" style="width: 284px">
                    <center>
                        <asp:Button ID="Button1" runat="server" PostBackUrl="~/Agregar Inv.aspx" Text="Articulos"   CssClass="button1"/>
                    </center>
                </td>
                <td style="width: 50px">&nbsp;</td>
                <td style="width: 320px">
                    <center>
                        <asp:Button ID="Button2" runat="server" PostBackUrl="~/Menu_Proveedores.aspx" Text="Proveedores" OnClick="Button2_Click" CssClass="button1"/>
                    </center>
        
                </td>
                <td style="width: 41px">&nbsp;</td>
                <td>
                    <center>
                        <asp:Button ID="Button3" runat="server" PostBackUrl="~/Ordenes_comp.aspx" Text="Ordenes de Compra"  CssClass="button1" style="margin-right: 0"/>
                    </center>
        
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 284px; height: 20px;"></td>
                <td style="width: 50px; height: 20px;"></td>
                <td style="width: 320px; height: 20px;"></td>
                <td style="width: 41px; height: 20px;"></td>
                <td style="height: 20px"></td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 284px; height: 20px;">
                    <center>
                        <img alt="" src="Images/factura.jpg" style="width: 200px; height: 200px" />
                    </center>
                    

                </td>
                <td style="width: 50px; height: 20px;"></td>
                <td style="width: 320px; height: 20px;">
                    <center>
                        <img alt="" src="Images/deposito.png" style="width: 280px; height: 200px" />
                    </center>
                    

                </td>
                <td style="width: 41px; height: 20px;"></td>
                <td style="height: 20px"></td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 284px">
                    <center>
                        <asp:Button ID="Button4" runat="server" PostBackUrl="~/Factura_ver.aspx" Text="Facturas" CssClass="button1"/>
                    </center>
        
                </td>
                <td style="width: 50px">&nbsp;</td>
                <td style="width: 320px">
                    <center>
                       <asp:Button ID="Button5" runat="server" PostBackUrl="~/Mov_stock.aspx" Text="Movimiento de Stock" CssClass="button1"/>
                    </center>
                </td>
                <td style="width: 41px">&nbsp;</td>
                <td>
                    <center>
                        <asp:Button ID="Button6" runat="server" PostBackUrl="~/Factura_ver.aspx" Text="Depositos" CssClass="button1"/>
                    </center>
                        
                    </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 284px">
                    &nbsp;</td>
                <td style="width: 50px">&nbsp;</td>
                <td style="width: 320px">
                    &nbsp;</td>
                <td style="width: 41px">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 284px">
                    &nbsp;</td>
                <td style="width: 50px">&nbsp;</td>
                <td style="width: 320px">
                    &nbsp;</td>
                <td style="width: 41px">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 284px">
                        <asp:Button ID="Button7" runat="server" PostBackUrl="~/Factura_ver.aspx" Text="Depositos" CssClass="button1"/>
                    </td>
                <td style="width: 50px">&nbsp;</td>
                <td style="width: 320px">
                    &nbsp;</td>
                <td style="width: 41px">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 284px">
                    &nbsp;</td>
                <td style="width: 50px">&nbsp;</td>
                <td style="width: 320px">
                    &nbsp;</td>
                <td style="width: 41px">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </p>
    
    <p>
        &nbsp;</p>
</asp:Content>
