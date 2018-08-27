<%@ Page Title="" Language="C#" MasterPageFile="~/home.master" AutoEventWireup="true" CodeFile="nomina.aspx.cs" Inherits="nomina_nomina" %>

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
                    <asp:ListItem>2026</asp:ListItem>
                    <asp:ListItem>2027</asp:ListItem>
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
                                        <asp:Label ID="lblPeriodo" runat="server" Text='<%# Bind("iIdPeriodo") %>' Visible="False" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSerie" runat="server" Text='<%# Bind("Serie") %>' Visible="False" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTipo" runat="server" Text='<%# Bind("Tipo") %>' Visible="False" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Periodo Nomina">
                                    <ItemTemplate>
                                        <asp:Label ID="fkiIdPeriodo" runat="server" Text='<%# Bind("fkiIdPeriodo") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                 <asp:TemplateField HeaderText="Serie">
                                    <ItemTemplate>
                                        <asp:Label ID="iEstatusEmpleado" runat="server" Text='<%# Bind("iEstatusEmpleado") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Tipo">
                                    <ItemTemplate>
                                        <asp:Label ID="iTipoNomina" runat="server" Text='<%# Bind("iTipoNomina") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--<asp:TemplateField HeaderText="Empleado C">
                                    <ItemTemplate>
                                        <asp:Label Width="300px" style=" text-align:right;" ID="nombrearchivo" runat="server" Text='<%# Bind("fkIidEmpleadoC") %>'  Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                
                                
                                

                                <asp:CommandField ButtonType="Image" HeaderText="" 
                                    SelectImageUrl="../imagenes/vistapre.png"
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



                    <br /><br /><br /><br />

                    <!--<<<<<<<<<<<<<<<<<<<< NOMINA DATA GRID>>>>>>>>>>>>>>>>>>>>>>>>>>>> -->
                    <div  style="overflow-x:auto; width:1000px">>
                     <asp:GridView ID="dtgNom" runat="server" AutoGenerateColumns="False" 
                    GridLines="None" CellPadding="4" ForeColor="#333333" AllowPaging="True" 
                    PageSize="1000" >
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                
                                <asp:TemplateField HeaderText="ID">
                                    <ItemTemplate>
                                        <asp:Label Width="50px"  ID="iIdNomina" runat="server" Text='<%# Bind("iIdNomina") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="iIdEmpleado">
                                    <ItemTemplate>
                                        <asp:Label Width="50px" ID="iIdEmpleado" runat="server" Text='<%# Bind("iIdEmpleado") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CodigoEmpleado">
                                    <ItemTemplate>
                                        <asp:Label  Width="80px" ID="CodigoEmpleado" runat="server" Text='<%# Bind("CodigoEmpleado") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField  HeaderText="Nombre">
                                    <ItemTemplate>
                                        <asp:Label Width="300px"  ID="Nombre" runat="server" Text='<%# Bind("Nombre") %>'  Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label Width="100px" ID="Status" runat="server" Text='<%# Bind("Status") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="RFC">
                                    <ItemTemplate>
                                        <asp:Label Width="150px" ID="RFC" runat="server" Text='<%# Bind("RFC") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>  
                                <asp:TemplateField HeaderText="CURP">
                                    <ItemTemplate>
                                        <asp:Label Width="150px" ID="CURP" runat="server" Text='<%# Bind("CURP") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Num_IMSS">
                                    <ItemTemplate>
                                        <asp:Label Width="150px"  ID="Num_IMSS" runat="server" Text='<%# Bind("Num_IMSS") %>'  Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fecha_Nac">
                                    <ItemTemplate>
                                        <asp:Label Width="100px" ID="Fecha_Nac" runat="server" Text='<%# Bind("Fecha_Nac") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Edad">
                                    <ItemTemplate>
                                        <asp:Label Width="50px" ID="Edad" runat="server" Text='<%# Bind("Edad") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Puesto">
                                    <ItemTemplate>
                                        <asp:Label Width="250px" ID="Puesto" runat="server" Text='<%# Bind("Puesto") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Buque">
                                    <ItemTemplate>
                                        <asp:Label Width="300px"  ID="Buque" runat="server" Text='<%# Bind("Buque") %>'  Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Tipo_Infonavit">
                                    <ItemTemplate>
                                        <asp:Label  Width="150px" ID="Tipo_Infonavit" runat="server" Text='<%# Bind("Tipo_Infonavit") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Valor_Infonavit">
                                    <ItemTemplate>
                                        <asp:Label  Width="150px" ID="Valor_Infonavit" runat="server" Text='<%# Bind("Valor_Infonavit") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>  
                                <asp:TemplateField HeaderText="Sueldo_Base_TMM">
                                    <ItemTemplate>
                                        <asp:Label Width="150px" ID="Sueldo_Base_TMM" runat="server" Text='<%# Bind("Sueldo_Base_TMM") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Salario_Diario">
                                    <ItemTemplate>
                                        <asp:Label Width="200px"  ID="Salario_Diario" runat="server" Text='<%# Bind("Salario_Diario") %>'  Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Salario_Cotizacion">
                                    <ItemTemplate>
                                        <asp:Label  Width="150px" ID="Salario_Cotizacion" runat="server" Text='<%# Bind("Salario_Cotizacion") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Dias_Trabajados">
                                    <ItemTemplate>
                                        <asp:Label  Width="150px" ID="Dias_Trabajados" runat="server" Text='<%# Bind("Dias_Trabajados") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tipo_Incapacidad">
                                    <ItemTemplate>
                                        <asp:Label  Width="150px" ID="Tipo_Incapacidad" runat="server" Text='<%# Bind("Tipo_Incapacidad") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Numero_dias">
                                    <ItemTemplate>
                                        <asp:Label  Width="150px"  ID="Numero_dias" runat="server" Text='<%# Bind("Numero_dias") %>'  Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Sueldo_Base">
                                    <ItemTemplate>
                                        <asp:Label  Width="150px" ID="Sueldo_Base" runat="server" Text='<%# Bind("Sueldo_Base") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Tiempo_Extra_Fijo">
                                    <ItemTemplate>
                                        <asp:Label  Width="150px" ID="Tiempo_Extra_Fijo" runat="server" Text='<%# Bind("Tiempo_Extra_Fijo") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>  
                                <asp:TemplateField HeaderText="Tiempo_Extra_Ocasional">
                                    <ItemTemplate>
                                        <asp:Label  Width="150px" ID="Tiempo_Extra_Ocasional" runat="server" Text='<%# Bind("Tiempo_Extra_Ocasional") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField   HeaderText="Desc_Sem_Obligatorio">
                                    <ItemTemplate>
                                        <asp:Label  Width="150px"  ID="Desc_Sem_Obligatorio" runat="server" Text='<%# Bind("Desc_Sem_Obligatorio") %>'  Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vacaciones_proporcionales">
                                    <ItemTemplate>
                                        <asp:Label  Width="150px" ID="Vacaciones_proporcionales" runat="server" Text='<%# Bind("Vacaciones_proporcionales") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Sueldo_Base_Mensual">
                                    <ItemTemplate>
                                        <asp:Label  Width="150px" ID="Sueldo_Base_Mensual" runat="server" Text='<%# Bind("Sueldo_Base_Mensual") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Aguinaldo_gravado">
                                    <ItemTemplate>
                                        <asp:Label  Width="150px" ID="Aguinaldo_gravado" runat="server" Text='<%# Bind("Aguinaldo_gravado") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Aguinaldo_exento">
                                    <ItemTemplate>
                                        <asp:Label  Width="150px"  ID="Aguinaldo_exento" runat="server" Text='<%# Bind("Aguinaldo_exento") %>'  Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Total_Aguinaldo">
                                    <ItemTemplate>
                                        <asp:Label  Width="150px" ID="Total_Aguinaldo" runat="server" Text='<%# Bind("Total_Aguinaldo") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Prima_vac_gravado">
                                    <ItemTemplate>
                                        <asp:Label  Width="250px" ID="Prima_vac_gravado" runat="server" Text='<%# Bind("Prima_vac_gravado") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>  
                                <asp:TemplateField HeaderText="Prima_vac_exento">
                                    <ItemTemplate>
                                        <asp:Label  Width="250px" ID="Prima_vac_exento" runat="server" Text='<%# Bind("Prima_vac_exento") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total_Prima_vac">
                                    <ItemTemplate>
                                        <asp:Label Width="150px"  ID="Total_Prima_vac" runat="server" Text='<%# Bind("Total_Prima_vac") %>'  Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Total_pecepciones">
                                    <ItemTemplate>
                                        <asp:Label Width="150px" ID="Total_pecepciones" runat="server" Text='<%# Bind("Total_pecepciones") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField  HeaderText="Total_percepciones_p_isr">
                                    <ItemTemplate>
                                        <asp:Label Width="150px" ID="Total_percepciones_p_isr" runat="server" Text='<%# Bind("Total_percepciones_p_isr") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField  HeaderText="Incapacidad">
                                    <ItemTemplate>
                                        <asp:Label Width="150px"  ID="Incapacidad" runat="server" Text='<%# Bind("Incapacidad") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField  HeaderText="ISR">
                                    <ItemTemplate>
                                        <asp:Label  Width="100px"  ID="ISR" runat="server" Text='<%# Bind("ISR") %>'  Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField  HeaderText="IMSS">
                                    <ItemTemplate>
                                        <asp:Label Width="150px"  ID="IMSS" runat="server" Text='<%# Bind("IMSS") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField  HeaderText="Infonavit">
                                    <ItemTemplate>
                                        <asp:Label Width="150px"  ID="Infonavit" runat="server" Text='<%# Bind("Infonavit") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>  
                                <asp:TemplateField HeaderText="Infonavit_bim_anterior">
                                    <ItemTemplate>
                                        <asp:Label Width="250px"  ID="Infonavit_bim_anterior" runat="server" Text='<%# Bind("Infonavit_bim_anterior") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField  HeaderText="Ajuste_infornavit">
                                    <ItemTemplate>
                                        <asp:Label Width="150px"  ID="Ajuste_infornavit" runat="server" Text='<%# Bind("Ajuste_infornavit") %>'  Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField  HeaderText="Cuota_Sindical">
                                    <ItemTemplate>
                                        <asp:Label Width="150px"  ID="Cuota_Sindical" runat="server" Text='<%# Bind("Cuota_Sindical") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Pension_Alimenticia">
                                    <ItemTemplate>
                                        <asp:Label Width="150px" ID="Pension_Alimenticia" runat="server" Text='<%# Bind("Pension_Alimenticia") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Prestamo">
                                    <ItemTemplate>
                                        <asp:Label Width="150px" ID="Prestamo" runat="server" Text='<%# Bind("Prestamo") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fonacot">
                                    <ItemTemplate>
                                        <asp:Label Width="150px"   ID="Fonacot" runat="server" Text='<%# Bind("Fonacot") %>'  Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Subsidio_Generado">
                                    <ItemTemplate>
                                        <asp:Label Width="150px"  ID="Subsidio_Generado" runat="server" Text='<%# Bind("Subsidio_Generado") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Subsidio_Aplicado">
                                    <ItemTemplate>
                                        <asp:Label Width="150px"  ID="Subsidio_Aplicado" runat="server" Text='<%# Bind("Subsidio_Aplicado") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>  
                                <asp:TemplateField HeaderText="Maecco">
                                    <ItemTemplate>
                                        <asp:Label Width="150px"  ID="Maecco" runat="server" Text='<%# Bind("Maecco") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Prestamo_Personal_S">
                                    <ItemTemplate>
                                        <asp:Label Width="150px"   ID="Prestamo_Personal_S" runat="server" Text='<%# Bind("Prestamo_Personal_S") %>'  Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Adeudo_Infonavit_S">
                                    <ItemTemplate>
                                        <asp:Label Width="150px" ID="Adeudo_Infonavit_S" runat="server" Text='<%# Bind("Adeudo_Infonavit_S") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Diferencia_Infonavit_S">
                                    <ItemTemplate>
                                        <asp:Label Width="150px"  ID="Diferencia_Infonavit_S" runat="server" Text='<%# Bind("Diferencia_Infonavit_S") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Complemento_Sindicato">
                                    <ItemTemplate>
                                        <asp:Label Width="250px"  ID="Complemento_Sindicato" runat="server" Text='<%# Bind("Complemento_Sindicato") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Retenciones_Maecco">
                                    <ItemTemplate>
                                        <asp:Label Width="250px"  ID="Retenciones_Maecco" runat="server" Text='<%# Bind("Retenciones_Maecco") %>'  Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Porcentaje_Comision">
                                    <ItemTemplate>
                                        <asp:Label Width="150px"  ID="Porcentaje_Comision" runat="server" Text='<%# Bind("Porcentaje_Comision") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>

                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Comision_Mecco">
                                    <ItemTemplate>
                                        <asp:Label Width="150px"  ID="Comision_Mecco" runat="server" Text='<%# Bind("Comision_Mecco") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>  
                                <asp:TemplateField HeaderText="Comision_complemento">
                                    <ItemTemplate>
                                        <asp:Label Width="250px"  ID="Comision_complemento" runat="server" Text='<%# Bind("Comision_complemento") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IMSS_CS">
                                    <ItemTemplate>
                                        <asp:Label Width="150px"   ID="IMSS_CS" runat="server" Text='<%# Bind("IMSS_CS") %>'  Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="RCV_CS">
                                    <ItemTemplate>
                                        <asp:Label Width="150px"  ID="RCV_CS" runat="server" Text='<%# Bind("RCV_CS") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Infonavit_CS">
                                    <ItemTemplate>
                                        <asp:Label Width="150px"  ID="Infonavit_CS" runat="server" Text='<%# Bind("Infonavit_CS") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ISN_CS">
                                    <ItemTemplate>
                                        <asp:Label Width="150px"  ID="ISN_CS" runat="server" Text='<%# Bind("ISN_CS") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total_Costo_Social">
                                    <ItemTemplate>
                                        <asp:Label Width="150px"   ID="Total_Costo_Social" runat="server" Text='<%# Bind("Total_Costo_Social") %>'  Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Subtotal">
                                    <ItemTemplate>
                                        <asp:Label Width="150px"   ID="Subtotal" runat="server" Text='<%# Bind("Subtotal") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="IVA">
                                    <ItemTemplate>
                                        <asp:Label Width="150px"   ID="IVA" runat="server" Text='<%# Bind("IVA") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>  
                                <asp:TemplateField HeaderText="TOTAL_DEPOSITO">
                                    <ItemTemplate>
                                        <asp:Label Width="180px" ID="TOTAL_DEPOSITO" runat="server" Text='<%# Bind("TOTAL_DEPOSITO") %>' Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                              


                              <%--  <asp:CommandField ButtonType="Image" HeaderText="" 
                                    SelectImageUrl="../imagenes/vistapre.png"
                                    ShowSelectButton="True" >
                                    
                                <HeaderStyle Width="40px" />
                                </asp:CommandField>
                                          --%>
                                
                                          
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
                    </div>


            </ContentTemplate>
        </asp:UpdatePanel>
        

    </section>

</asp:Content>


