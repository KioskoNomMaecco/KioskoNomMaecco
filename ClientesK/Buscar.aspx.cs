using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using wcfKioskoCli;

    public partial class Buscar : System.Web.UI.Page
    {
     
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                cargar_clientes();

            }

        }


        private void cargar_clientes()
        {
            IsvcKioskoCliClient Manejador = new IsvcKioskoCliClient();

            Tabla TablaEmpresas = Manejador.getEjecutaStoredProcedure1("getUsuariosSeleccionar", "1");
           
            cboClientes.Items.Clear();

            if (TablaEmpresas != null)  
            {
                System.Data.DataTable dtusuario = clFunciones.convertToDatatable(TablaEmpresas);
                for (int x = 0; x < dtusuario.Rows.Count; x++)
                {
                    cboClientes.Items.Add(new ListItem(dtusuario.Rows[x]["nombre"].ToString(), dtusuario.Rows[x]["iIdClienteAcceso"].ToString()));//, dtusuario.Rows[x]["codigo"].ToString(), dtusuario.Rows[x]["Password"].ToString()));

                   
                        Session["objusuario"] = dtusuario;
                     Session["idusuario"] = dtusuario.Rows[0]["fkiIdCliente"].ToString();
                     Session["idtmp"] = dtusuario.Rows[0]["iIdClienteAcceso"].ToString();
                     Session["usuario"] = dtusuario.Rows[0]["usuario"].ToString();          
                     Session["inicio"] = 1;
                     
            //Response.Redirect("inicio/inicio.aspx");
                }
            }
            else
            {
                cboClientes.Items.Add(new ListItem("Sin Empresas", "-1"));

            }
        }

        protected void cmdIniciar_Click(object sender, EventArgs e)
        {
            IsvcKioskoCliClient Manejador = new IsvcKioskoCliClient();

            Tabla TablaCliente = Manejador.getEjecutaStoredProcedure1("getUsuariosSeleccionarCliente", cboClientes.SelectedValue);

            System.Data.DataTable dtusuario = clFunciones.convertToDatatable(TablaCliente);

            Session["objusuario"] = dtusuario;
            Session["idusuario"] = dtusuario.Rows[0]["fkiIdCliente"].ToString();
            Session["idtmp"] = dtusuario.Rows[0]["iIdClienteAcceso"].ToString();
            Session["usuario"] = dtusuario.Rows[0]["usuario"].ToString();
            Session["inicio"] = 1;
            Response.Redirect("inicio/inicio.aspx");
        }

    
    }
