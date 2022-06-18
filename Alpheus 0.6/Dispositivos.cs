using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Alpheus_0._6
{
    public class Dispositivos
    {
        public string Mouse(string NoSerie, string NoControl)
        {
            string comprobar, verificar_pre, mensaje_mouse;
            try
            {
                string conectar = ConfigurationManager.ConnectionStrings["MatiasConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(conectar);

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT idTransferencia, Tipo FROM Dispositivos WHERE NoSerie = '" + NoSerie + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    comprobar = dr["idTransferencia"].ToString();
                    verificar_pre = dr["Tipo"].ToString();

                    if (verificar_pre == "MOUSE")
                    {
                        if (comprobar == NoControl)
                        {
                            return mensaje_mouse = "SI";
                        }
                        else
                        {
                            return mensaje_mouse = "NO";
                        }
                    }
                    else
                    {
                        if (comprobar == NoControl)
                        {
                            return mensaje_mouse = "SI";
                        }
                        else
                        {
                            return mensaje_mouse = "NO";
                        }
                    }
                }
            }
            catch(Exception er)
            {
                return mensaje_mouse = er.Message;
            }
            return mensaje_mouse="";
        }

        public string Monitor(string NoSerie, string NoControl)
        {
            string comprobar, verificar_pre, mensaje_monitor;

            string conectar = ConfigurationManager.ConnectionStrings["MatiasConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conectar);

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT idTransferencia, Tipo FROM Dispositivos WHERE NoSerie = '" + NoSerie + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                comprobar = dr["idTransferencia"].ToString();
                verificar_pre = dr["Tipo"].ToString();

                if (verificar_pre == "MONITOR")
                {
                    if (comprobar == NoControl)
                    {
                        return mensaje_monitor = "SI";
                    }
                    else
                    {
                        return mensaje_monitor = "NO";
                    }
                }
                else
                {
                    if (comprobar == NoControl)
                    {
                        return mensaje_monitor = "SI";
                    }
                    else
                    {
                        return mensaje_monitor = "NO";
                    }
                }
            }
            return mensaje_monitor = "";
        }

        public string Teclado(string NoSerie, string NoControl)
        {
            string comprobar, verificar_pre, mensaje_teclado;

            string conectar = ConfigurationManager.ConnectionStrings["MatiasConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conectar);

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT idTransferencia, Tipo FROM Dispositivos WHERE NoSerie = '" + NoSerie + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                comprobar = dr["idTransferencia"].ToString();
                verificar_pre = dr["Tipo"].ToString();

                if (verificar_pre == "TECLADO")
                {
                    if (comprobar == NoControl)
                    {
                        return mensaje_teclado = "SI";
                    }
                    else
                    {
                        return mensaje_teclado = "NO";
                    }
                }
                else
                {
                    if (comprobar == NoControl)
                    {
                        return mensaje_teclado = "SI";
                    }
                    else
                    {
                        return mensaje_teclado = "NO";
                    }
                }
            }
            return mensaje_teclado="";
        }
    }
}