using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using MySql.Data.MySqlClient;

namespace deprimera.com.ar.Models
{
    public class Partidos
    {
        static string querystr;
        static string ProveedorMySQL;
        static MySqlCommand cmdMySQL;
        static MySqlConnection connMySQL = new MySqlConnection();

        private static void ConectarDB()
        {
            connMySQL.ConnectionString = @"Database=dbdeprimera;Data Source=localhost;User Id=root;Password=root";
            connMySQL.Open();
        }
        public static Partido ArmarPartido(Partido unPartido)
        {
            Partido unPartido2 = new Partido();
            
            try
            {
                ConectarDB();
                querystr = "INSERT into Partidos (fecha, idcancha, cantjug, idcamiseta1, idcamiseta2, sepuede, duracion, calificacion, cantidaddevotos) VALUES ('" + unPartido2.Fecha + "', '" + unPartido2.IdCancha + "', '" + unPartido2.CantJug + "', '" + unPartido2.IdCamiseta1 + "', '" + unPartido2.IdCamiseta2 + "', '" + unPartido2.SEPUEDE + "', '" + unPartido2.Duracion + "', '" + unPartido2.Calificacion + ", " + unPartido2.CantidedDeVotos +"' )";
                cmdMySQL = new MySqlCommand(querystr, connMySQL);

                int resultado = (int)cmdMySQL.ExecuteNonQuery();
                if (resultado == 1)
                {
                    connMySQL.Close();
                }
                return unPartido2;
            }

            catch (Exception e)
            {
                return unPartido2;
            }
        }
        public static Partido TraerPartidoPorID(int idPartido)
        {
            Partido unPartido = new Partido();

            try
            {
                ConectarDB();
                querystr = "SELECT * FROM Partidos WHERE id='" + idPartido + "'";
                cmdMySQL = new MySqlCommand(querystr, connMySQL);
                MySqlDataReader drMySQL = cmdMySQL.ExecuteReader();

                while (drMySQL.Read())
                {
                    if (Convert.ToInt32(drMySQL["id"].ToString()) == idPartido)
                    {
                        unPartido.ID = Convert.ToInt32(drMySQL["id"].ToString());
                        unPartido.Fecha = Convert.ToDateTime(drMySQL["fecha"].ToString());                        
                        unPartido.IdCancha = Convert.ToInt32(drMySQL["idcancha"].ToString());
                        unPartido.CantJug = Convert.ToInt32(drMySQL["cantjug"].ToString());                        
                        //unPartido.ListaDeJugadores = drMySQL["listadejugadores"].ToString();
                        unPartido.IdCamiseta1 = Convert.ToInt32(drMySQL["idcamiseta1"].ToString());
                        unPartido.IdCamiseta2 = Convert.ToInt32(drMySQL["idcamiseta2"].ToString());
                        unPartido.SEPUEDE = drMySQL["sepuede"].ToString();
                        unPartido.Duracion = Convert.ToInt32(drMySQL["duracion"].ToString());
                        unPartido.Calificacion = Convert.ToInt32(drMySQL["calificacion"].ToString());
                        unPartido.CantidedDeVotos = Convert.ToInt32(drMySQL["cantidaddevotos"].ToString());
                        connMySQL.Close();
                    }
                }
                return unPartido;
            }
            catch (Exception)
            {
                return unPartido;
            }
        }
        public static Partido ModificarPartidoPorID(Partido unPartido)
        {
            ConectarDB();
            try
            {
                querystr = "UPDATE Partidos SET fecha = '" + unPartido.Fecha + "', idcancha = '" + unPartido.IdCancha + "', cantjug = '" + unPartido.CantJug + "', idcamiseta1 = '" + unPartido.IdCamiseta1 + "', idcamiseta2 = '" + unPartido.IdCamiseta2 + "', sepuede = '" + unPartido.SEPUEDE + "', duracion = '" + unPartido.Duracion + "', calificacion = '" + unPartido.Calificacion + "', cantidaddevotos = '" + unPartido.CantidedDeVotos + "' WHERE id = '" + unPartido.ID + "'";
                cmdMySQL = new MySqlCommand(querystr, connMySQL);
                int resultado = (int)cmdMySQL.ExecuteNonQuery();
                if (resultado == 1)
                {
                    connMySQL.Close();
                }
                return unPartido;
            }

            catch (Exception e)
            {
                connMySQL.Close();
                return unPartido;
            }
        }
        public static bool EliminarPartidoPorID(Partido unPartido)
        {
            bool funciono = false;
            try
            {
                ConectarDB();
                querystr = "DELETE FROM Partidos WHERE id = '" + unPartido.ID + "'";
                cmdMySQL = new MySqlCommand(querystr, connMySQL);
                int resultado = (int)cmdMySQL.ExecuteNonQuery();
                if (resultado == 1)
                {
                    connMySQL.Close();
                    funciono = true;
                }
                return funciono;
            }
            catch (Exception e)
            {
                connMySQL.Close();
                return funciono;
            }
        }
    }
}