using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class home : System.Web.UI.MasterPage
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
            lblnombre.Text = usuario.Rows[0]["nombre"].ToString();
            lblnombre2.Text = usuario.Rows[0]["nombre"].ToString();
            lblnombre3.Text = usuario.Rows[0]["nombre"].ToString();
        }
    }
    protected void cmdsalir_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
        Response.Redirect("../default.aspx");
    }
    protected void cmdcambiar_Click(object sender, EventArgs e)
    {
        Response.Redirect("../config/Actualizar.aspx");
    }
}
