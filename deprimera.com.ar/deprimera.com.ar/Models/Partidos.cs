using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
//using MySql.Data.MySqlClient;

namespace deprimera.com.ar.Models
{
    public class Partidos
    {
        static string querystr;

        static string ProveedorAccess;
        static OleDbConnection connAccess = new OleDbConnection();

        //static string ProveedorMySQL;
        //static MySqlCommand cmdMySQL;
        //static MySqlConnection connMySQL = new MySqlConnection();

        private static void ConectarDB()
        {
            ProveedorAccess = @"Provider=Microsoft.ACE.OLEDB.12.0;
            Data Source=|DataDirectory|\BasededatosAccess.accdb";

            connAccess.ConnectionString = ProveedorAccess;
            connAccess.Open();

            //connMySQL.ConnectionString = @"Data Source=localhost; Database=DBRSF; User ID=root; Password='root'";
            //connMySQL.Open();
        }

        public static Partido ArmarPartido(Partido unPartido)
        {
            ConectarDB();
            //try
            //{             
            //    querystr = "INSERT into Partidos (fecha, cantjug, idcancha) VALUES ('" + unPartido.Fecha.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + unPartido.CantJug + "', '" + unPartido.IdCancha + "' )";
            //    cmdMySQL = new MySqlCommand(querystr, connMySQL);

            //    int resultado = (int)cmdMySQL.ExecuteNonQuery();
            //bool funciono = false;
            //if (resultado == 1)
            //{
            //    funciono = true;
            //}

            //    connMySQL.Close();
            //}


            //catch (Exception ErrorMySQL)
            //{
            //    unPartido.Funciono = ErrorMySQL.ToString();
            //    connMySQL.Close();
            //}

            try
            {
                OleDbCommand Consulta = connAccess.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                Consulta.CommandText = "AgregarPartido";

                OleDbParameter cantjug = new OleDbParameter("Cantjug", OleDbType.VarChar, 88);
                cantjug.Value = unPartido.CantJug;
                OleDbParameter fecha = new OleDbParameter("Fecha", OleDbType.VarChar, 88);
                fecha.Value = unPartido.Fecha;
                OleDbParameter idcancha = new OleDbParameter("Idcancha", OleDbType.VarChar, 88);
                idcancha.Value = unPartido.IdCancha;

                Consulta.Parameters.Add(cantjug);
                Consulta.Parameters.Add(fecha);
                Consulta.Parameters.Add(idcancha);


                int resultado = (int)Consulta.ExecuteNonQuery();
                bool funciono = false;
                if (resultado == 1)
                {
                    funciono = true;
                }

                connAccess.Close();
            }


            catch (Exception ErrorAccess)
            {
                connAccess.Close();
            }

            if (unPartido.Funciono == null)
            {
                ConectarDB();

                //try
                //{
                //    querystr = "SELECT * FROM Partidos";
                //    cmdMySQL = new MySqlCommand(querystr, connMySQL);
                //    MySqlDataReader drMySQL = cmdMySQL.ExecuteReader();

                //    while (drMySQL.Read())
                //    {
                //        if (Convert.ToDateTime(drMySQL["Fecha"].ToString()) == unPartido.Fecha && Convert.ToInt32(drMySQL["Idcancha"].ToString()) == unPartido.IdCancha)
                //        {
                //            unPartido.id = Convert.ToInt32(drMySQL["Id"].ToString());
                //            connMySQL.Close();
                //        }
                //    }
                //}
                //catch (Exception ErrorMySQL)
                //{
                //    unPartido.Funciono = ErrorMySQL.ToString();
                //    connMySQL.Close();
                //}

                try
                {
                    OleDbCommand Consulta = connAccess.CreateCommand();
                    Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                    Consulta.CommandText = "TraerPartidos";

                    OleDbDataReader drAccess = Consulta.ExecuteReader();
                    while (drAccess.Read())
                    {
                        if (Convert.ToDateTime(drAccess["Fecha"].ToString()) == unPartido.Fecha && Convert.ToInt32(drAccess["Idcancha"].ToString()) == unPartido.IdCancha)
                        {
                            unPartido.id = Convert.ToInt32(drAccess["Id"].ToString());
                            connAccess.Close();
                        }
                    }

                    connAccess.Close();
                }

                catch (Exception ErrorAccess)
                {
                    connAccess.Close();
                }
            }            

            return unPartido;
        }
        public static Partido TraerUnPartidoPorId(Partido unPartido)
        {
            ConectarDB();

            //try
            //{
            //    querystr = "SELECT * FROM Partidos";
            //    cmdMySQL = new MySqlCommand(querystr, connMySQL);
            //    MySqlDataReader dr = cmdMySQL.ExecuteReader();

            //    while (drMySQL.Read())
            //    {
            //        if (Convert.ToInt32(drMySQL["id"].ToString()) == unPartido.id)
            //        {
            //            unPartido.id = Convert.ToInt32(drMySQL["id"].ToString());
            //            unPartido.Fecha = Convert.ToDateTime(drMySQL["fecha"].ToString());
            //            unPartido.CantJug = Convert.ToInt32(drMySQL["cantjug"].ToString());
            //            unPartido.IdCancha = Convert.ToInt32(drMySQL["idcancha"].ToString());
            //            connMySQL.Close();
            //        }
            //    }
            //    connMySQL.Close();
            //}

            //catch (Exception ErrorMySQL)
            //{
            //    unPartido.nombre = ErrorMySQL.ToString();
            //    connMySQL.Close();
            //}

            try
            {
                OleDbCommand Consulta = connAccess.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                Consulta.CommandText = "TraerPartidos";

                OleDbDataReader drAccess = Consulta.ExecuteReader();
                while (drAccess.Read())
                {
                    if (Convert.ToInt32(drAccess["Id"].ToString()) == unPartido.id)
                    {
                        unPartido.id = Convert.ToInt32(drAccess["Id"].ToString());
                        unPartido.CantJug = Convert.ToInt32(drAccess["Cantjug"].ToString());
                        unPartido.Fecha = Convert.ToDateTime(drAccess["Fecha"].ToString());
                        unPartido.IdCancha = Convert.ToInt32(drAccess["Idcancha"].ToString());
                        connAccess.Close();
                    }
                }
                connAccess.Close();
            }

            catch (Exception ErrorAccess)
            {
                connAccess.Close();
            }

            return unPartido;
        }
    }
}