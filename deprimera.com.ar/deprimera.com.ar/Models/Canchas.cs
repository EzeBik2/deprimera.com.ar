using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
//using MySql.Data.MySqlClient;

namespace deprimera.com.ar.Models
{
    public class Canchas
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
        public static Cancha TraerCancha(Cancha unaCancha)
        {
            Cancha unaCancha2 = new Cancha();

            try
            {
                ConectarDB();

                //try
                //{
                //  querystr = "SELECT * FROM Canchas";
                //  cmdMySQL = new MySqlCommand(querystr, connMySQL);
                //  MySqlDataReader drMySQL = cmdMySQL.ExecuteReader();
                //  while (drMySQL.Read())
                //  {
                //      if (drMySQL["Nombre"].ToString() == unaCancha.nombre)
                //      {
                //          unaCancha.nombre = null;
                //          unaCancha.id = Convert.ToInt32(drMySQL["Id"].ToString());
                //          break;
                //      }
                //  }
                //  connMySQL.Close();
                //}
                //
                //catch (Exception ErrorMySQL)
                //{
                //  unaCancha2.nombre = ErrorMySQL.ToString();
                //  connMySQL.Close();
                //}

                try
                {
                    OleDbCommand Consulta = connAccess.CreateCommand();
                    Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                    Consulta.CommandText = "TraerCanchas";

                    OleDbDataReader drAccess = Consulta.ExecuteReader();
                    while (drAccess.Read())
                    {
                        if (drAccess["Nombre"].ToString() == unaCancha.nombre)
                        {
                            unaCancha2.id = Convert.ToInt32(drAccess["Id"].ToString());
                            break;
                        }
                    }
                    connAccess.Close();
                }
                catch (Exception ErrorAccess)
                {
                    connAccess.Close();
                }

                if (unaCancha.id > 0)
                {
                    return unaCancha;
                }
                else
                {
                    
                    return unaCancha2;
                }
            }

            catch (Exception ErrorConexionBD)
            {
                unaCancha2.nombre = ErrorConexionBD.ToString();
                return unaCancha2;
            }
        }
        public static List<Cancha> TraerCanchasPorNombre(Cancha unaCancha)
        {
            List<Cancha> ListadeCanchas = new List<Cancha>();
            List<Cancha> ListadeCanchas2 = new List<Cancha>();

            try
            {
                ConectarDB();

                //try
                //{
                //    querystr = "SELECT * FROM Canchas";
                //    cmdMySQL = new MySqlCommand(querystr, connMySQL);
                //    MySqlDataReader dr = cmdMySQL.ExecuteReader();

                //    while (drMySQL.Read())
                //    {
                //        Cancha unaCancha2 = new Cancha();
                //        unaCancha2.id = Convert.ToInt32(drMySQL["Id"].ToString());
                //        unaCancha2.nombre = drMySQL["Nombre"].ToString();
                //        unaCancha2.barrio = drMySQL["Barrio"].ToString();
                //        unaCancha2.calle = drMySQL["Calle"].ToString();
                //        unaCancha2.telefono = Convert.ToInt32(drMySQL["Telefono"].ToString());
                //        if (unaCancha.nombre.Contains(unaCancha2.nombre) || unaCancha2.nombre.Contains(unaCancha.nombre))
                //        {
                //            ListadeCanchas.Add(unaCancha2);
                //        }
                //    }
                //    connMySQL.Close();
                //}

                //catch (Exception ErrorMySQL)
                //{
                //    connMySQL.Close();
                //    ListadeCanchas2[0].nombre = ErrorMySQL.ToString();
                //}

                try
                {
                    OleDbCommand Consulta = connAccess.CreateCommand();
                    Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                    Consulta.CommandText = "TraerCanchas";

                    OleDbDataReader drAccess = Consulta.ExecuteReader();
                    while (drAccess.Read())
                    {
                        Cancha unaCancha2 = new Cancha();
                        unaCancha2.id = Convert.ToInt32(drAccess["Id"].ToString());
                        unaCancha2.nombre = drAccess["Nombre"].ToString();
                        unaCancha2.barrio = drAccess["Barrio"].ToString();
                        unaCancha2.calle = drAccess["Calle"].ToString();
                        unaCancha2.telefono = Convert.ToInt32(drAccess["Telefono"].ToString());
                        if (unaCancha.nombre.Contains(unaCancha2.nombre) || unaCancha2.nombre.Contains(unaCancha.nombre))
                        {
                            ListadeCanchas2.Add(unaCancha2);
                        }
                    }
                    connAccess.Close();
                }

                catch (Exception ErrorAccess)
                {
                    connAccess.Close();
                }


                if (ListadeCanchas.Count > 0)
                {
                    return ListadeCanchas;
                }
                else
                {

                    return ListadeCanchas2;
                }
            }

            catch (Exception ErrorConexionBD)
            {
                ListadeCanchas2[0].nombre = ErrorConexionBD.ToString();
                return ListadeCanchas2;
            }
        }
        public static Cancha TraerUnaCanchaPorId(Cancha unaCancha)
        {
            try
            {
                ConectarDB();

                //try
                //{
                //    querystr = "SELECT * FROM Canchas";
                //    cmdMySQL = new MySqlCommand(querystr, connMySQL);
                //    MySqlDataReader dr = cmdMySQL.ExecuteReader();

                //    while (drMySQL.Read())
                //    {
                //        if (unaCancha.id == Convert.ToInt32(drMySQL["Id"].ToString()))
                //        {
                //            unaCancha.nombre = drMySQL["Nombre"].ToString();
                //            unaCancha.barrio = drMySQL["Barrio"].ToString();
                //            unaCancha.calle = drMySQL["Calle"].ToString();
                //            unaCancha.telefono = Convert.ToInt32(drMySQL["Telefono"].ToString());
                //            break;
                //        }
                //    }
                //    connMySQL.Close();
                //}

                //catch (Exception ErrorMySQL)
                //{
                //    connMySQL.Close();
                //    unaCancha.nombre = ErrorMySQL.ToString();
                //}

                try
                {
                    OleDbCommand Consulta = connAccess.CreateCommand();
                    Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                    Consulta.CommandText = "TraerCanchas";

                    OleDbDataReader drAccess = Consulta.ExecuteReader();
                    while (drAccess.Read())
                    {
                        if (unaCancha.id == Convert.ToInt32(drAccess["Id"].ToString()))
                        {
                            unaCancha.nombre = drAccess["Nombre"].ToString();
                            unaCancha.barrio = drAccess["Barrio"].ToString();
                            unaCancha.calle = drAccess["Calle"].ToString();
                            unaCancha.telefono = Convert.ToInt32(drAccess["Telefono"].ToString());
                            break;
                        }
                    }
                    connAccess.Close();
                    return unaCancha;
                }

                catch (Exception ErrorAccess)
                {
                    connAccess.Close();
                    return unaCancha;
                }
            }

            catch (Exception ErrorConexionBD)
            {
                unaCancha.nombre = ErrorConexionBD.ToString();
                return unaCancha;
            }
        }
        public static List<string> TraerNombresDeTodasLasCanchas()
        {
            List<string> ListadeCanchas = new List<string>();
            List<string> ListadeCanchas2 = new List<string>();

            try
            {
                ConectarDB();

                //try
                //{
                //    querystr = "SELECT * FROM Canchas";
                //    cmdMySQL = new MySqlCommand(querystr, connMySQL);
                //    MySqlDataReader dr = cmdMySQL.ExecuteReader();

                //    while (drMySQL.Read())
                //    {
                //        ListadeCanchas.Add(drMySQL["Nombre"].ToString());
                //    }
                //    connMySQL.Close();
                //}

                //catch (Exception ErrorMySQL)
                //{
                //    connMySQL.Close();
                //    ListadeCanchas2[0] = ErrorMySQL.ToString();
                //}

                try
                {
                    OleDbCommand Consulta = connAccess.CreateCommand();
                    Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                    Consulta.CommandText = "TraerCanchas";

                    OleDbDataReader drAccess = Consulta.ExecuteReader();
                    while (drAccess.Read())
                    {
                        ListadeCanchas2.Add(drAccess["Nombre"].ToString());
                    }
                    connAccess.Close();
                }

                catch (Exception ErrorAccess)
                {
                    connAccess.Close();
                }


                if (ListadeCanchas.Count > 0)
                {
                    return ListadeCanchas;
                }
                else
                {

                    return ListadeCanchas2;
                }
            }

            catch (Exception ErrorConexionBD)
            {
                ListadeCanchas2[0] = ErrorConexionBD.ToString();
                return ListadeCanchas2;
            }
        }
    }
}