using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using wcfKioskoCli;

public partial class nomina_nomina : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["objusuario"] == null)
        {
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Response.Redirect("../default.aspx");
        }

        if (!IsPostBack)
        {
            


        }
    }

    //private void cargar_empresas()
    //{
    //    IsvcKioskoCliClient Manejador = new IsvcKioskoCliClient();

    //    Tabla TablaEmpresas = Manejador.getEjecutaStoredProcedure1("getListadoEmpresaCliente", Session["idusuario"].ToString());
    //    cboempresas.Items.Clear();

    //    if (TablaEmpresas != null)
    //    {
    //        DataTable dtEmpresas = clFunciones.convertToDatatable(TablaEmpresas);
    //        for (int x = 0; x < dtEmpresas.Rows.Count; x++)
    //        {
    //            cboempresas.Items.Add(new ListItem(dtEmpresas.Rows[x]["nombre"].ToString(), dtEmpresas.Rows[x]["iIdEmpresa"].ToString()));
    //        }
    //    }
    //    else
    //    {
    //        cboempresas.Items.Add(new ListItem("Sin Empresas", "-1"));

    //    }
    //}


    protected void cmdbuscar_Click(object sender, EventArgs e)
    {
        lblmensaje.Text = "";

        cargar_grid();
    }

    private void cargar_grid()
    {
        wcfKioskoCli.IsvcKioskoCliClient Manejador = new IsvcKioskoCliClient();



        DataSet dsNominas = new DataSet();
        dsNominas.Tables.Add("Tabla");
        dsNominas.Tables[0].Columns.Add("iIdPeriodo");
        dsNominas.Tables[0].Columns.Add("Serie");
        dsNominas.Tables[0].Columns.Add("Tipo");
        dsNominas.Tables[0].Columns.Add("fkIidPeriodo");
        dsNominas.Tables[0].Columns.Add("iEstatusEmpleado");
        dsNominas.Tables[0].Columns.Add("iTipoNomina");




        try
        {
            Tabla tbNominas = Manejador.getEjecutaStoredProcedure1("getNominasMesAno", (cbomes.SelectedIndex + 1) + "|" + cboanio.Text);
            if (tbNominas != null)
            {
                DataTable dtNominas = clFunciones.convertToDatatable(tbNominas);
                for (int x = 0; x < dtNominas.Rows.Count; x++)
                {
                    String nombreEmpleado="";
                    Tabla tbPeriodo = Manejador.getEjecutaStoredProcedure1("getPeriodoxId", dtNominas.Rows[x]["fkIidPeriodo"].ToString());
                    if (tbPeriodo != null)
                    {
                        DataTable dtPeriodo = clFunciones.convertToDatatable(tbPeriodo);
                        for (int y = 0; y < dtPeriodo.Rows.Count; y++)
                        {
                            dsNominas.Tables[0].Rows.Add(dtNominas.Rows[x]["fkIidPeriodo"].ToString(),
                                               dtNominas.Rows[x]["iEstatusEmpleado"].ToString(),
                                               dtNominas.Rows[x]["iTipoNomina"].ToString(),
                                               dtPeriodo.Rows[y]["dFechaPeriodo"],
                                               series(dtNominas.Rows[x]["iEstatusEmpleado"].ToString()),
                                               tipo(dtNominas.Rows[x]["iTipoNomina"].ToString()));



                        }


                        
                        //nombreEmpleado = dtE.Rows[0]["cNombre"].ToString();

                    }

                

                }

                Session["dsPagos"] = dsNominas;
                dtgnominas.DataSource = dsNominas;
                dtgNom.DataSource = null;
                Session["dsNom"] = null;


            }
            else
            {
                Session["dsPagos"] = null;
                dtgnominas.DataSource = null;
                lblmensaje.Text = "Sin Nominas";
                dtgNom.DataSource = null;
                Session["dsNom"] = null;
            }
            dtgnominas.DataBind();
            dtgNom.DataBind();

        }
        catch (Exception EX)
        {
            clFunciones.JQMensaje(this, EX.Message.Replace("'", ""), TipoMensaje.Error);
        }

    }
    public String series(String tipo)
    {
         switch (tipo)
        {
            case "0":return "A";
            case "1":return "B";
            case "2":return "C";
            case "3":return "D";
            case "4":return "E";
            default: return "A";
            
        }
    }
    public String tipo(String t)
    {
        switch (t)
        {
            case "0": return "Abordo";
            case "1": return "Descanso";
           
            default: return "Abordo";

        }
    }

    protected void dtgnominas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            if (e.CommandName == "Select")
            {
                wcfKioskoCli.IsvcKioskoCliClient Manejador = new IsvcKioskoCliClient();


                int id = Convert.ToInt32(e.CommandArgument);

                string Periodo = ((Label)dtgnominas.Rows[id].FindControl("lblPeriodo")).Text;
                string Serie = ((Label)dtgnominas.Rows[id].FindControl("lblSerie")).Text;
                string Tipo = ((Label)dtgnominas.Rows[id].FindControl("lblTipo")).Text;


                DataSet dsNom = new DataSet();
                dsNom.Tables.Add("Tabla");
                dsNom.Tables[0].Columns.Add("iIdNomina");
                dsNom.Tables[0].Columns.Add("iIdEmpleado");
                dsNom.Tables[0].Columns.Add("CodigoEmpleado");
                dsNom.Tables[0].Columns.Add("Nombre");
                dsNom.Tables[0].Columns.Add("Status");
                dsNom.Tables[0].Columns.Add("RFC");
                dsNom.Tables[0].Columns.Add("CURP");
                dsNom.Tables[0].Columns.Add("Num_IMSS");
                dsNom.Tables[0].Columns.Add("Fecha_Nac");
                dsNom.Tables[0].Columns.Add("Edad");
                dsNom.Tables[0].Columns.Add("Puesto");
                dsNom.Tables[0].Columns.Add("Buque");
                dsNom.Tables[0].Columns.Add("Tipo_Infonavit");
                dsNom.Tables[0].Columns.Add("Valor_Infonavit");
                dsNom.Tables[0].Columns.Add("Sueldo_Base_TMM");
                dsNom.Tables[0].Columns.Add("Salario_Diario");
                dsNom.Tables[0].Columns.Add("Salario_Cotizacion");
                dsNom.Tables[0].Columns.Add("Dias_Trabajados");
                dsNom.Tables[0].Columns.Add("Tipo_Incapacidad");
                dsNom.Tables[0].Columns.Add("Numero_dias");
                dsNom.Tables[0].Columns.Add("Sueldo_Base");
                dsNom.Tables[0].Columns.Add("Tiempo_Extra_Fijo");
                dsNom.Tables[0].Columns.Add("Tiempo_Extra_Ocasional");
                dsNom.Tables[0].Columns.Add("Desc_Sem_Obligatorio");
                dsNom.Tables[0].Columns.Add("Vacaciones_proporcionales");
                dsNom.Tables[0].Columns.Add("Sueldo_Base_Mensual");
                dsNom.Tables[0].Columns.Add("Aguinaldo_gravado");
                dsNom.Tables[0].Columns.Add("Aguinaldo_exento");
                dsNom.Tables[0].Columns.Add("Total_Aguinaldo");
                dsNom.Tables[0].Columns.Add("Prima_vac_gravado");
                dsNom.Tables[0].Columns.Add("Prima_vac_exento");
                dsNom.Tables[0].Columns.Add("Total_Prima_vac");
                dsNom.Tables[0].Columns.Add("Total_pecepciones");
                dsNom.Tables[0].Columns.Add("Total_percepciones_p_isr");
                dsNom.Tables[0].Columns.Add("Incapacidad");
                dsNom.Tables[0].Columns.Add("ISR");
                dsNom.Tables[0].Columns.Add("IMSS");
                dsNom.Tables[0].Columns.Add("Infonavit");
                dsNom.Tables[0].Columns.Add("Infonavit_bim_anterior");
                dsNom.Tables[0].Columns.Add("Ajuste_infornavit");

                dsNom.Tables[0].Columns.Add("Cuota_Sindical");
                dsNom.Tables[0].Columns.Add("Pension_Alimenticia");
                dsNom.Tables[0].Columns.Add("Prestamo");
                dsNom.Tables[0].Columns.Add("Fonacot");
                dsNom.Tables[0].Columns.Add("Subsidio_Generado");
                dsNom.Tables[0].Columns.Add("Subsidio_Aplicado");
                dsNom.Tables[0].Columns.Add("Maecco");
                dsNom.Tables[0].Columns.Add("Prestamo_Personal_S");
                dsNom.Tables[0].Columns.Add("Adeudo_Infonavit_S");
                dsNom.Tables[0].Columns.Add("Diferencia_Infonavit_S");
                dsNom.Tables[0].Columns.Add("Complemento_Sindicato");
                dsNom.Tables[0].Columns.Add("Retenciones_Maecco");
                dsNom.Tables[0].Columns.Add("Porcentaje_Comision");
                dsNom.Tables[0].Columns.Add("Comision_Mecco");
                dsNom.Tables[0].Columns.Add("Comision_complemento");
                dsNom.Tables[0].Columns.Add("IMSS_CS");
                dsNom.Tables[0].Columns.Add("RCV_CS");
                dsNom.Tables[0].Columns.Add("Infonavit_CS");
                dsNom.Tables[0].Columns.Add("ISN_CS");
                dsNom.Tables[0].Columns.Add("Total_Costo_Social");
                dsNom.Tables[0].Columns.Add("Subtotal");
                dsNom.Tables[0].Columns.Add("IVA");
                dsNom.Tables[0].Columns.Add("TOTAL_DEPOSITO");


                  Tabla tbNominas = Manejador.getEjecutaStoredProcedure1("getNominasPeriodoSerieTipoFull", Periodo + "|" + Serie + "|" + Tipo);
                  if (tbNominas != null)
                  {
                        DataTable dtNominas = clFunciones.convertToDatatable(tbNominas);
                        for (int x = 0; x < dtNominas.Rows.Count; x++)
                        {
                            Tabla tbEmpleado = Manejador.getEjecutaStoredProcedure1("getEmpleadoCxId", dtNominas.Rows[x]["fkiIdEmpleadoC"].ToString());

                            if (tbEmpleado != null)
                            {
                                DataTable dtEmpleado = clFunciones.convertToDatatable(tbEmpleado);
                                for (int y = 0; y < dtEmpleado.Rows.Count; y++)
                                {

                                    double salariobasemensual = Double.Parse(dtNominas.Rows[x]["fSalarioDiario"].ToString()) * Double.Parse(dtNominas.Rows[x]["iDiasTrabajados"].ToString());
                                    double totalaguinaldo= Double.Parse( dtNominas.Rows[x]["fAguinaldoGravado"].ToString())+ Double.Parse( dtNominas.Rows[x]["fAguinaldoExento"].ToString());
                                    double totalprima = Double.Parse(dtNominas.Rows[x]["fPrimaVacacionalGravado"].ToString()) + Double.Parse(dtNominas.Rows[x]["fPrimaVacacionalExento"].ToString());

                                    String status = "";
                                    if (dtEmpleado.Rows[y]["iOrigen"].ToString() == "1")
                                    {
                                        status = "INTERINO";

                                    }
                                    else
                                    {
                                        status = "PLANTA";
                                    }

                                    DateTime nac = DateTime.Parse(dtEmpleado.Rows[y]["dFechaNac"].ToString().Remove(18));
                                    dsNom.Tables[0].Rows.Add(dtNominas.Rows[x]["iIdNomina"],
                                                    dtNominas.Rows[x]["fkiIdEmpleadoC"],
                                                    dtEmpleado.Rows[y]["cCodigoEmpleado"],
                                                    dtEmpleado.Rows[y]["cNombreLargo"] ,
                                                    status,
                                                    dtEmpleado.Rows[y]["cRFC"],
                                                    dtEmpleado.Rows[y]["cCURP"],
                                                    dtEmpleado.Rows[y]["cIMSS"],
                                                    nac.ToShortDateString(),
                                                    dtNominas.Rows[x]["Edad"],
                                                    dtNominas.Rows[x]["Puesto"],
                                                    dtNominas.Rows[x]["Buque"],
                                                    dtNominas.Rows[x]["TipoInfonavit"],
                                                    dtNominas.Rows[x]["fvalor"],
                                                    dtNominas.Rows[x]["fSalarioBase"],
                                                    dtNominas.Rows[x]["fSalarioDiario"],
                                                    dtNominas.Rows[x]["fSalarioBC"],
                                                    dtNominas.Rows[x]["iDiasTrabajados"],
                                                    dtNominas.Rows[x]["TipoIncapacidad"],
                                                    dtNominas.Rows[x]["iNumeroDias"],
                                                    dtNominas.Rows[x]["fSueldoBruto"],
                                                    dtNominas.Rows[x]["fTExtraFijo"],
                                                    dtNominas.Rows[x]["fTExtraOcasional"],
                                                    dtNominas.Rows[x]["fDescSemObligatorio"],
                                                    dtNominas.Rows[x]["fVacacionesProporcionales"],
                                                    salariobasemensual,//SalarioDiarioxDias
                                                    dtNominas.Rows[x]["fAguinaldoGravado"],
                                                    dtNominas.Rows[x]["fAguinaldoExento"],
                                                    totalaguinaldo,//Suma de aguinaldos
                                                    dtNominas.Rows[x]["fPrimaVacacionalGravado"],
                                                    dtNominas.Rows[x]["fPrimaVacacionalExento"],
                                                    totalprima,//Suma primas vacacionales
                                                    dtNominas.Rows[x]["fTotalPercepciones"],
                                                    dtNominas.Rows[x]["fTotalPercepcionesISR"],
                                                    dtNominas.Rows[x]["fIncapacidad"],
                                                    dtNominas.Rows[x]["fIsr"],
                                                    dtNominas.Rows[x]["fImss"],
                                                    dtNominas.Rows[x]["fInfonavit"],
                                                    dtNominas.Rows[x]["fInfonavitBanterior"],
                                                    dtNominas.Rows[x]["fAjusteInfonavit"],
                                                    dtNominas.Rows[x]["fCuotaSindical"],
                                                    dtNominas.Rows[x]["fPensionAlimenticia"],
                                                    dtNominas.Rows[x]["fPrestamo"],
                                                    dtNominas.Rows[x]["fFonacot"],
                                                    dtNominas.Rows[x]["fSubsidioGenerado"],
                                                    dtNominas.Rows[x]["fSubsidioAplicado"],
                                                    dtNominas.Rows[x]["fMaecco"],
                                                    dtNominas.Rows[x]["fPrestamoPerS"],
                                                    dtNominas.Rows[x]["fAdeudoInfonavitS"],
                                                    dtNominas.Rows[x]["fDiferenciaInfonavitS"],
                                                    dtNominas.Rows[x]["fComplementoSindicato"],
                                                    dtNominas.Rows[x]["fRetencionesMaecco"],
                                                    dtNominas.Rows[x]["fPorComision"],
                                                    dtNominas.Rows[x]["fComisionMaecco"],
                                                    dtNominas.Rows[x]["fComisionComplemento"],
                                                    dtNominas.Rows[x]["fImssCS"],
                                                    dtNominas.Rows[x]["fRcvCS"],
                                                    dtNominas.Rows[x]["fInfonavitCS"],
                                                    dtNominas.Rows[x]["fIsnCS"],
                                                    dtNominas.Rows[x]["fTotalCostoSocial"],
                                                    dtNominas.Rows[x]["fSubtotal"],
                                                    dtNominas.Rows[x]["fIVA"],
                                                    dtNominas.Rows[x]["fTotalDeposito"]);
                                }//Fin For Empleados
                            }//If Empleado
                            
                        }//Fin For Nominas

                        Tabla tbSumas = Manejador.getEjecutaStoredProcedure1("getNominasPeriodoSerieTipoSUMACOSTOFull", Periodo + "|" + Serie + "|" + Tipo);
                        if (tbSumas != null)
                        {
                            DataTable dtSumas = clFunciones.convertToDatatable(tbSumas);
                            for (int x = 0; x < dtSumas.Rows.Count; x++)
                            {
                                dsNom.Tables[0].Rows.Add("",
                                                    "",
                                                    "",
                                                    "",
                                                    "",
                                                    "",
                                                    "",
                                                    "",
                                                    "",
                                                     "",
                                                    "",
                                                    "",
                                                    "TOTAL: ",
                                                    dtSumas.Rows[x]["fvalor"],
                                                    dtSumas.Rows[x]["fSalarioBase"],
                                                    dtSumas.Rows[x]["fSalarioDiario"],
                                                    dtSumas.Rows[x]["fSalarioBC"],
                                                    "",
                                                    "",
                                                    "",
                                                    dtSumas.Rows[x]["fSueldoBruto"],
                                                    dtSumas.Rows[x]["fTExtraFijo"],
                                                    dtSumas.Rows[x]["fTExtraOcasional"],
                                                    dtSumas.Rows[x]["fDescSemObligatorio"],
                                                    dtSumas.Rows[x]["fVacacionesProporcionales"],
                                                    dtSumas.Rows[x]["Sueldo_Base_Mensual"],//SalarioDiarioxDias
                                                    dtSumas.Rows[x]["fAguinaldoGravado"],
                                                    dtSumas.Rows[x]["fAguinaldoExento"],
                                                    dtSumas.Rows[x]["Total_Aguinaldo"],//Suma de aguinaldos
                                                    dtSumas.Rows[x]["fPrimaVacacionalGravado"],
                                                    dtSumas.Rows[x]["fPrimaVacacionalExento"],
                                                    dtSumas.Rows[x]["Total_Prima_vac"],//Suma primas vacacionales
                                                    dtSumas.Rows[x]["fTotalPercepciones"],
                                                    dtSumas.Rows[x]["fTotalPercepcionesISR"],
                                                    dtSumas.Rows[x]["fIncapacidad"],
                                                    dtSumas.Rows[x]["fIsr"],
                                                    dtSumas.Rows[x]["fImss"],
                                                    dtSumas.Rows[x]["fInfonavit"],
                                                    dtSumas.Rows[x]["fInfonavitBanterior"],
                                                    dtSumas.Rows[x]["fAjusteInfonavit"],
                                                    dtSumas.Rows[x]["fCuotaSindical"],
                                                    dtSumas.Rows[x]["fPensionAlimenticia"],
                                                    dtSumas.Rows[x]["fPrestamo"],
                                                    dtSumas.Rows[x]["fFonacot"],
                                                    dtSumas.Rows[x]["fSubsidioGenerado"],
                                                    dtSumas.Rows[x]["fSubsidioAplicado"],
                                                    dtSumas.Rows[x]["fMaecco"],
                                                    dtSumas.Rows[x]["fPrestamoPerS"],
                                                    dtSumas.Rows[x]["fAdeudoInfonavitS"],
                                                    dtSumas.Rows[x]["fDiferenciaInfonavitS"],
                                                    dtSumas.Rows[x]["fComplementoSindicato"],
                                                    dtSumas.Rows[x]["fRetencionesMaecco"],
                                                    dtSumas.Rows[x]["fPorComision"],
                                                    dtSumas.Rows[x]["fComisionMaecco"],
                                                    dtSumas.Rows[x]["fComisionComplemento"],
                                                    dtSumas.Rows[x]["fImssCS"],
                                                    dtSumas.Rows[x]["fRcvCS"],
                                                    dtSumas.Rows[x]["fInfonavitCS"],
                                                    dtSumas.Rows[x]["fIsnCS"],
                                                    dtSumas.Rows[x]["fTotalCostoSocial"],
                                                    dtSumas.Rows[x]["fSubtotal"],
                                                    dtSumas.Rows[x]["fIVA"],
                                                    dtSumas.Rows[x]["fTotalDeposito"]);
                            }

                        }
                        Session["dsNom"] = dsNom;
                        dtgNom.DataSource = dsNom;
                  }//Fin if Nominas
                  else
                  {
                      Session["dsNom"] = null;
                      dtgNom.DataSource = null;
                      lblmensaje.Text = "Sin Nominas";

                  }
                  dtgNom.DataBind();

            }
           
          
        }
        catch (Exception EX)
        {
            clFunciones.JQMensaje(this, EX.Message.Replace("'", ""), TipoMensaje.Error);
        }
    }



    protected void dtgnominas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dtgnominas.DataSource = (DataSet)Session["dsPagos"];
        dtgnominas.PageIndex = e.NewPageIndex;
        dtgnominas.DataBind();
    }

    protected void dtgnominas_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

   
}