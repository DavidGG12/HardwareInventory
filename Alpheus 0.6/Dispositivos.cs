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
        static string mensaje_mouse, mensaje_teclado, mensaje_monitor;
        public string Mouse(string NoSerie, string NoControl)
        {
            string comprobar, verificar_pre;

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
                        mensaje_mouse = "SI";
                    }
                    else
                    {
                        mensaje_mouse = "NO";
                    } 
                }
                else
                {
                    if (comprobar == NoControl)
                    {
                        mensaje_mouse = "SI";
                    }
                    else
                    {
                        mensaje_mouse = "NO";
                    }
                }  
            }
            return mensaje_mouse;
        }

        public string Monitor(string NoSerie, string NoControl)
        {
            string comprobar, verificar_pre;

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
                        mensaje_monitor = "SI";
                    }
                    else
                    {
                        mensaje_monitor = "NO";
                    }
                }
                else
                {
                    if (comprobar == NoControl)
                    {
                        mensaje_monitor = "SI";
                    }
                    else
                    {
                        mensaje_monitor = "NO";
                    }
                }
            }
            return mensaje_monitor;
        }

        public string Teclado(string NoSerie, string NoControl)
        {
            string comprobar, verificar_pre;

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
                        mensaje_teclado = "SI";
                    }
                    else
                    {
                        mensaje_teclado = "NO";
                    }
                }
                else
                {
                    if (comprobar == NoControl)
                    {
                        mensaje_teclado = "SI";
                    }
                    else
                    {
                        mensaje_teclado = "NO";
                    }
                }
            }
            return mensaje_teclado;
        }
    }
}