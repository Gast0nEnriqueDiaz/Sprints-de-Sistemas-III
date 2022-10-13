 <%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Agregar Inv.aspx.cs" Inherits="Sprints_de_Sistemas_III.Agregar_Inv" EnableEventValidation="False" EnableSessionState="True" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;</p>
    <p>
        <table class="nav-justified">
            <tr>
                <td style="width: 262px">
                    <asp:Button ID="Articulos_btn" runat="server" Text="Ver Articulos" OnClick="Articulos_btn_Click" />
                    <asp:Label ID="ID_Art_lb" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
                <td style="width: 347px">
                    <asp:Button ID="Deposit_btn" runat="server" Text="Ver Depositos" OnClick="Deposit_btn_Click" />
                    <asp:Label ID="ID_Dep_lb" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="Cate_btn" runat="server" Text="Ver Categorias" OnClick="Cate_btn_Click" />
                    <asp:Label ID="ID_cat_lb" runat="server" Text="Label" Visible="False"></asp:Label>
                    <br />
                </td>
            </tr>
        </table>
    </p>
    <p>
        &nbsp;</p>
    <table class="nav-justified">
        <tr>
            <td class="modal-sm" style="width: 286px">
        <asp:TextBox ID="Buscador_art" runat="server" Visible="False" Width="210px">Ingrese Categoria/Nombre/COD</asp:TextBox>
        <asp:Button ID="Buscar_art_btn" runat="server" OnClick="Buscar_art_btn_Click" Text="Buscar" Visible="False" />
                <br />
        <asp:Button ID="Agregar_Art_btn" runat="server" Text="Agregar Articulo" PostBackUrl="~/Agregar_Articulo.aspx" OnClick="Agregar_Art_btn_Click" />
    <table id="Tabla_cat1" style="width: 149%">
        <tr>
            <td style="height: 20px; width: 214px">
                <asp:Label ID="Art_nom_lb" runat="server" Text="Nombre" Visible="False"></asp:Label>
            </td>
            <td style="height: 20px; width: 300px">
                <asp:TextBox ID="Art_nom" runat="server" Visible="False"></asp:TextBox>
                <asp:Label ID="Alert_lb" runat="server" Text="Ya existe un articulo asi" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 214px; height: 22px">
                <asp:Label ID="Art_cat_lb" runat="server" Text="Categoria" Visible="False"></asp:Label>
            </td>
            <td style="height: 22px; width: 300px">
                    <asp:DropDownList ID="Categorias_list" runat="server" DataSourceID="SqlDataSource1" DataTextField="Nombre_categoria" DataValueField="Nombre_categoria" Visible="False">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:hospitalConnectionString %>" SelectCommand="SELECT [Nombre_categoria] FROM [Categorias]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td style="width: 214px; height: 22px">
                <asp:Label ID="Art_Pre_lb" runat="server" Text="Precio" Visible="False"></asp:Label>
            </td>
            <td style="height: 22px; width: 300px">
                <asp:TextBox ID="Art_precio" runat="server" Visible="False" TextMode="Number"></asp:TextBox>

                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Debe ser un valor superior a 0" ControlToValidate="Art_precio" Operator="GreaterThan" Type="Integer" ValueToCompare="0"></asp:CompareValidator>

            </td>
        </tr>
        <tr>
            <td style="width: 214px; height: 22px">
                <asp:Label ID="Art_desc_lb" runat="server" Text="Descripcion" Visible="False"></asp:Label>
            </td>
            <td style="height: 22px; width: 300px">
                <asp:TextBox ID="Art_desc" runat="server" Visible="False" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 214px; height: 22px">
                <asp:Label ID="Art_stk_lb" runat="server" Text="Stock" Visible="False"></asp:Label>
            </td>
            <td style="width: 300px; height: 22px">
                <asp:TextBox ID="Art_stk" runat="server" TextMode="Number" Visible="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 214px">
                <asp:Button ID="Art_camb_btn" runat="server" Text="Guardar Cambios" Visible="False" OnClick="Art_camb_btn_Click" />
            </td>
            <td class="modal-sm">
                <asp:Button ID="Art_elin_byn" runat="server" Text="Borrar Articulo" Visible="False" OnClick="Art_elin_byn_Click" />
            </td>
        </tr>
    </table>
                <br />
        <asp:GridView ID="Articulos_Colum" runat="server" AutoGenerateColumns="False" Width="364px" DataKeyNames="ID">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="COD" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Nombre_categoria" HeaderText="Categoria" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                <asp:TemplateField HeaderText="Editar">
                    <ItemTemplate>
                        <asp:Button ID="Articulo_editBtn" runat="server" OnClick="Articulo_editBtn_Click" Text="Editar" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
            </td>
            <td style="width: 338px">
        <asp:TextBox ID="Buscador_dep" runat="server" Visible="False" Width="210px">Ingrese ID deposito</asp:TextBox>
                <asp:Button ID="Buscador_dep_btn" runat="server" OnClick="Buscador_dep_btn_Click" Text="Buscar" Visible="False" />
                <br />
        <asp:Button ID="Agregar_Dep_btn" runat="server" Text="Agregar Deposito" PostBackUrl="~/Agregar_Dep.aspx" />
    <table id="Tabla_cat0" style="width: 50%">
        <tr>
            <td style="height: 20px; width: 214px">
                <asp:Label ID="Dep_nom_lb" runat="server" Text="Nombre" Visible="False"></asp:Label>
            </td>
            <td style="height: 20px; width: 300px">
                <asp:TextBox ID="Depos_nom" runat="server" Visible="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 214px; height: 22px">
                <asp:Label ID="Dep_ubi_lb" runat="server" Text="Ubicacion" Visible="False"></asp:Label>
            </td>
            <td style="width: 300px; height: 22px">
                <asp:TextBox ID="Depo_ubi" runat="server" Visible="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 214px">
                <asp:Button ID="Depos_guardar_btn" runat="server" Text="Guardar Cambios" Visible="False" OnClick="Depos_guardar_btn_Click" />
            </td>
            <td class="modal-sm">
                <asp:Button ID="Depor_borrar_btn" runat="server" Text="Borrar Deposito" Visible="False" OnClick="Depor_borrar_btn_Click" />
            </td>
        </tr>
    </table>
        <asp:GridView ID="Depositos_col" runat="server" AutoGenerateColumns="False" DataKeyNames="ID">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Direccion" HeaderText="Ubicacion" />
                <asp:TemplateField HeaderText="Editar">
                    <ItemTemplate>
                        <asp:Button ID="DepositaEditBtn" runat="server" OnClick="DepositaEditBtn_Click" Text="Editar" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Stock">
                    <ItemTemplate>
                        <asp:Button ID="Dep_Stock_ver" runat="server" OnClick="Dep_Stock_ver_Click" Text="Ver Articulos" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
            </td>
            <td>
        <asp:TextBox ID="Buscador_cat" runat="server" Visible="False" Width="210px">Ingrese Nombre/ID</asp:TextBox>
                <asp:Button ID="Buscador_cat_btn" runat="server" OnClick="Buscador_cat_btn_Click" Text="Buscar" Visible="False" />
                <br />
        <asp:Button ID="Agregar_Cat_btn" runat="server" OnClick="Agregar_Cat_btn_Click" Text="Agregar Categoria" PostBackUrl="~/Editar_Categoria.aspx" />
    <table id="Tabla_cat" style="width: 50%">
        <tr>
            <td style="height: 20px; width: 214px">
                <asp:Label ID="Nomb_cat_ed" runat="server" Text="Nombre" Visible="False"></asp:Label>
            </td>
            <td style="height: 20px; width: 300px">
                <asp:TextBox ID="Nombre_cat_edit" runat="server" Visible="False"></asp:TextBox>
                <asp:Label ID="Alert_lb0" runat="server" Text="Ya existe un categotia asi" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 214px; height: 22px">
                <asp:Label ID="Desc_cat_ed" runat="server" Text="Descripcion" Visible="False"></asp:Label>
            </td>
            <td style="height: 22px; width: 300px">
                <asp:TextBox ID="Desc_cat_edit" runat="server" Visible="False" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 214px">
                <asp:Button ID="Camb_cat_btn" runat="server" Text="Guardar Cambios" Visible="False" OnClick="Camb_cat_btn_Click" />
            </td>
            <td class="modal-sm">
                <asp:Button ID="Eliminar_cat_btn" runat="server" Text="Borrar Categoria" Visible="False" OnClick="Eliminar_cat_btn_Click" />
            </td>
        </tr>
    </table>
        <asp:GridView ID="Categorias_colum" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="Categorias_colum_SelectedIndexChanged" DataKeyNames="ID">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Nombre_categoria" HeaderText="Nombre_categoria" />
                <asp:BoundField DataField="Descipcion" HeaderText="Descripcion" />
                <%--<asp:ButtonField HeaderText="Editar" Text="Editar" />--%>
                <asp:TemplateField HeaderText="Editar">
                    <ItemTemplate>
                        <asp:Button ID="CategoriaBtn" runat="server" OnClick="CategoriaBtn_Click" Text="Editar" />
                    </ItemTemplate>
                </asp:TemplateField>
                
            </Columns>
        </asp:GridView>
            </td>
        </tr>
    </table>
<p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;
        <asp:Label ID="lbl1" runat="server" Text="Seleccione un deposito:" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="droplista_dept" runat="server" DataSourceID="SqlDataSource2" DataTextField="Nombre" DataValueField="Nombre" Visible="False">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:hospitalConnectionString %>" SelectCommand="SELECT [Nombre] FROM [Deposito]"></asp:SqlDataSource>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        <br />
    </p>
</asp:Content>
