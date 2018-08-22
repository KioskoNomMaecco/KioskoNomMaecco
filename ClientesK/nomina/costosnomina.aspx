<%@ Page Title="" Language="C#" MasterPageFile="~/home.master" AutoEventWireup="true" CodeFile="costosnomina.aspx.cs" Inherits="nomina_costosnomina" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section class="content-header">
      <h1>
          Buscar Nomina
        <small><asp:Label ID="lblnombre" runat="server" Text=""></asp:Label></small>
      </h1>
      <ol class="breadcrumb">
        <li><a href="../inicio/inicio.aspx"><i class="fa fa-dashboard"></i> Inicio</a></li>
        <%--<li><a href="#">Bienvenido</a></li>--%>
        <li class="active">Declaraciones</li>
      </ol>
    </section>

    <!-- Main content -->
    <section class="content">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        
        
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
               <%-- Empresas Asignadas
                <br/>
                <asp:DropDownList ID="cboempresas" runat="server"></asp:DropDownList>
                <br/>--%>
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
                        onselectedindexchanged="dtgnominas_SelectedIndexChanged" Width="434px">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:Label ID="iIdNomina" runat="server" Text='<%# Bind("iIdNomina") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                 <asp:TemplateField HeaderText="NOMBRE">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmpleadoC" runat="server" Text='<%# Bind("EmpleadoC") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="IMSS">
                                    <ItemTemplate>
                                        <asp:Label ID="lblimss" runat="server" Text='<%# Bind("IMSS") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                
                                
                                <asp:TemplateField HeaderText="RCV">
                                    <ItemTemplate>
                                        <asp:Label Width="300px" style=" text-align:right;" ID="lblrcv" runat="server" Text='<%# Bind("RCV") %>'  Visible="False" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="INFONAVIT">
                                    <ItemTemplate>
                                        <asp:Label Width="300px" style=" text-align:right;" ID="lblinfonavit" runat="server" Text='<%# Bind("INFONAVIT") %>'  Visible="False" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ISN">
                                    <ItemTemplate>
                                        <asp:Label Width="300px" style=" text-align:right;" ID="lblisn" runat="server" Text='<%# Bind("ISN") %>'  Visible="False" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="TOTAL">
                                    <ItemTemplate>
                                        <asp:Label Width="300px" style=" text-align:right;" ID="lbltotal" runat="server" Text='<%# Bind("TOTAL") %>'  Visible="False" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                

                                
                                
                                
                                          
                               

                                          
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

                    <asp:GridView ID="dtgcostos" runat="server" AutoGenerateColumns="False" 
                    GridLines="None" CellPadding="4" ForeColor="#333333" AllowPaging="True" >


                        
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:Label ID="iIdNomina" runat="server" Text='<%# Bind("iIdNomina") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                 <asp:TemplateField HeaderText="NOMBRE">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmpleadoC" runat="server" Text='<%# Bind("EmpleadoC") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="IMSS">
                                    <ItemTemplate>
                                        <asp:Label ID="lblimss" runat="server" Text='<%# Bind("IMSS") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                
                                
                                <asp:TemplateField HeaderText="RCV">
                                    <ItemTemplate>
                                        <asp:Label Width="300px" style=" text-align:right;" ID="lblrcv" runat="server" Text='<%# Bind("RCV") %>'  Visible="False" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="INFONAVIT">
                                    <ItemTemplate>
                                        <asp:Label Width="300px" style=" text-align:right;" ID="lblinfonavit" runat="server" Text='<%# Bind("INFONAVIT") %>'  Visible="False" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ISN">
                                    <ItemTemplate>
                                        <asp:Label Width="300px" style=" text-align:right;" ID="lblisn" runat="server" Text='<%# Bind("ISN") %>'  Visible="False" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="TOTAL">
                                    <ItemTemplate>
                                        <asp:Label Width="300px" style=" text-align:right;" ID="lbltotal" runat="server" Text='<%# Bind("TOTAL") %>'  Visible="False" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                

                                
                                
                                
                                          
                               

                                          
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

