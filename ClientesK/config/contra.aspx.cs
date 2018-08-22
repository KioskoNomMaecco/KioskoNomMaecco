using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using wcfKioskoCli;


    public partial class config_contra : System.Web.UI.Page
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

                DataTable usuario = (DataTable)Session["objusuario"];
                
                //txtid.Text = Session["idcodigo"].ToString();
                txtusuario.Text = usuario.Rows[0]["usuario"].ToString();
               
            }
        }

        protected void cmdguardar_Click(object sender, EventArgs e)
        {
            try
            {
                //verificamos que el id empleado y usuario sean iguales
                
                    //verificamos que coincida con su usuario actual
                //if (txtusuario.Text == lblnombre.Text)
                //    {
                        //Validamos contraseñas iguales
                        if (txtpass.Text == txtrepass.Text)
                        {
                            //hacemos la actualizacion en la base de dato
                            IsvcKioskoCliClient Manejador = new IsvcKioskoCliClient();
                            //Tabla MiTabla = Manejador.getEjecutaStoredProcedure1("setActualizarContra", Session["idusuario"].ToString() + "|" + txtusuario.Text + "|" + txtpass.Text);
                            Tabla MiTabla = Manejador.getEjecutaStoredProcedure1("setActualizarPass", txtusuario.Text.Replace(" ", "X") + "|" + txtpass.Text.Replace(" ", "X"));

                            if (MiTabla != null)
                            {
                                 DateTime thisDay = DateTime.Today;
                                Tabla MiTabla2 = Manejador.getEjecutaStoredProcedure1("setActualizarFechaPass", txtusuario.Text.Replace(" ", "X") + "|" + thisDay.ToShortDateString());

                                if (MiTabla2 != null)
                                {
                                    //DataTable dtusuario = clFunciones.convertToDatatable(MiTabla);
                                    ScriptManager.RegisterStartupScript(this, typeof(string), "alert", "alert('La nueva contraseña se guardo correctamente');", true);
                                   // txtid.Text = "";
                                    txtusuario.Text = "";
                                    txtpass.Text = "";
                                    txtrepass.Text = "";
                                }

                            }
                            //else
                            //{
                            //    ScriptManager.RegisterStartupScript(this, typeof(string), "alert", "alert('La nueva contraseña se guardo correctamente');", true);
                            //}


                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(string), "alert", "alert('Las contraseñas no coinciden');", true);
                        }

                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(this, typeof(string), "alert", "alert('El id empleado y usuario no corresponden al asignado a ti.');", true);

                    //}


                


            }
            catch (Exception EX)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "alerta", "alert('" + EX.Message + "');", true);
            }
            
            
        }
    }
