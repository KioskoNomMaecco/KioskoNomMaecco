<%@ Page Title="" Language="C#" MasterPageFile="~/home.master" AutoEventWireup="true" CodeFile="documentos.aspx.cs" Inherits="imss_documentos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section class="content-header">
      <h1>
        Determinación de cuotas, comprobantes de pago
        <small><asp:Label ID="lblnombre" runat="server" Text=""></asp:Label></small>
      </h1>
      <ol class="breadcrumb">
        <li><a href="../inicio/inicio.aspx"><i class="fa fa-dashboard"></i> Inicio</a></li>
        <%--<li><a href="#">Bienvenido</a></li>--%>
        <li class="active">Cuotas</li>
      </ol>
    </section>

    <!-- Main content -->
    <section class="content">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        
        
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                Empresas Asignadas
                <br/>
                <asp:DropDownList ID="cboempresas" runat="server"></asp:DropDownList>
                <br/>
                <br/>
                Mes:
                <asp:DropDownList ID="cbomes" runat="server">
                    <asp:ListItem Value="1">Enero</asp:ListItem>
                    <asp:ListItem Value="2">Febrero</asp:ListItem>
                    <asp:ListItem Value="3">Marzo</asp:ListItem>
                    <asp:ListItem Value="4">Abril</asp:ListItem>
                    <asp:ListItem Value="5">Mayo</asp:ListItem>
                    <asp:ListItem Value="6">Junio</asp:ListItem>
                    <asp:ListItem Value="7">Julio</asp:ListItem>
                    <asp:ListItem Value="8">Agosto</asp:ListItem>
                    <asp:ListItem Value="9">Septiembre</asp:ListItem>
                    <asp:ListItem Value="10">Octubre</asp:ListItem>
                    <asp:ListItem Value="11">Noviembre</asp:ListItem>
                    <asp:ListItem Value="12">Diciembre</asp:ListItem>
                </asp:DropDownList>
                <br/>
                 <br/>
                Año:

                <asp:DropDownList ID="cboanio" runat="server">
                    <asp:ListItem>2015</asp:ListItem>
                    <asp:ListItem>2016</asp:ListItem>
                    <asp:ListItem>2017</asp:ListItem>
                    <asp:ListItem>2018</asp:ListItem>
                    <asp:ListItem>2019</asp:ListItem>
                    <asp:ListItem>2020</asp:ListItem>
                    <asp:ListItem>2021</asp:ListItem>
                    <asp:ListItem>2022</asp:ListItem>
                    <asp:ListItem>2023</asp:ListItem>
                    <asp:ListItem>2024</asp:ListItem>
                    <asp:ListItem>2025</asp:ListItem>
                </asp:DropDownList>
                <br/>
                <br/>
                

                <asp:Button ID="cmdbuscar" runat="server" Text="Buscar" 
                    onclick="cmdbuscar_Click"></asp:Button>
                <br/>
                <asp:Label ID="lblmensaje" runat="server" Text=""></asp:Label>
                <br/>
                <asp:GridView ID="dtgnominas" runat="server" AutoGenerateColumns="False" 
                    GridLines="None" CellPadding="4" ForeColor="#333333" AllowPaging="True" 
                        onrowcommand="dtgnominas_RowCommand" 
                        onpageindexchanging="dtgnominas_PageIndexChanging" 
                        onselectedindexchanged="dtgnominas_SelectedIndexChanged"
                        >
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:Label ID="iIdInfoKiosko" runat="server" Text='<%# Bind("iIdInfoKiosko") %>' Visible="false" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                

                                
                                
                                
                                <asp:TemplateField HeaderText="Archivo">
                                    <ItemTemplate>
                                        <asp:Label Width="300px" style=" text-align:right;" ID="nombrearchivo" runat="server" Text='<%# Bind("nombrearchivo") %>'  Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                
                                

                                <asp:CommandField ButtonType="Image" HeaderText="" 
                                    SelectImageUrl="../imagenes/bajar.png"
                                    ShowSelectButton="True" >
                                    
                                <HeaderStyle Width="40px" />
                                </asp:CommandField>
                                          
                                
                                
                                          
                               

                                          
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="False" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
        

    </section>

</asp:Content>

