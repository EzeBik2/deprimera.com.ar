using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace deprimera.com.ar.Models
{
    public class Canchas
    {
        static string querystr;
        static string ProveedorMySQL;
        static MySqlCommand cmdMySQL;
        static MySqlConnection connMySQL = new MySqlConnection();

        private static void ConectarDB()
        {
            connMySQL.ConnectionString = @"Database=localdb;Data Source=127.0.0.1:49164;User Id=azure;Password=6#vWHD_$";
            connMySQL.Open();
        }
        public static Cancha AgregarCancha(Cancha unaCancha)
        {
            Cancha unaCancha2 = new Cancha();
            try
            {
                ConectarDB();
                querystr = "INSERT into Canchas (nombre, barrio, calle1, calle2, telefono, calificacion, cantidaddevotos) VALUES ('" + unaCancha.Nombre + "', '" + unaCancha.Barrio + "', '" + unaCancha.Calle1 + "', '" + unaCancha.Calle2 + "', '" + unaCancha.Telefono + "', '" + unaCancha.Calificacion + "', '" + unaCancha.CantidadDeVotos + "' )";
                cmdMySQL = new MySqlCommand(querystr, connMySQL);
                int resultado = (int)cmdMySQL.ExecuteNonQuery();
                if (resultado == 1)
                {
                    connMySQL.Close();
                }
                return unaCancha2;
            }
            catch (Exception e)
            {
                connMySQL.Close();
                return unaCancha2;
            }
        }
        public static List<Cancha> TraerTodasLasCanchas()
        {
            List<Cancha> ListaDeCanchas = new List<Cancha>();
            ConectarDB();

            try
            {
                ConectarDB();
                try
                {
                    querystr = "SELECT * FROM Canchas";
                    cmdMySQL = new MySqlCommand(querystr, connMySQL);
                    MySqlDataReader drMySQL = cmdMySQL.ExecuteReader();
                    while (drMySQL.Read())
                    {
                        Cancha unaCancha2 = new Cancha();
                        unaCancha2.ID = Convert.ToInt32(drMySQL["id"].ToString());
                        unaCancha2.Nombre = drMySQL["nombre"].ToString();
                        unaCancha2.Barrio = drMySQL["barrio"].ToString();
                        unaCancha2.Calle1 = drMySQL["calle1"].ToString();
                        unaCancha2.Calle2 = drMySQL["calle2"].ToString();
                        unaCancha2.Telefono = Convert.ToInt32(drMySQL["telefono"].ToString());
                        unaCancha2.Calificacion = Convert.ToInt32(drMySQL["calificacion"].ToString());
                        unaCancha2.CantidadDeVotos = Convert.ToInt32(drMySQL["cantidaddevotos"].ToString());
                        ListaDeCanchas.Add(unaCancha2);
                    }
                    connMySQL.Close();
                }
                catch (Exception ErrorMySQL)
                {
                    connMySQL.Close();
                    ListaDeCanchas[0].Nombre = ErrorMySQL.ToString();
                }
                return ListaDeCanchas;
            }
            catch (Exception e)
            {
                connMySQL.Close();
                return ListaDeCanchas;
            }
        }

        public static Cancha TraerCanchaPorId(Cancha unaCancha)
        {
            try
            {
                ConectarDB();

                try
                {
                    querystr = "SELECT * FROM Canchas";
                    cmdMySQL = new MySqlCommand(querystr, connMySQL);
                    MySqlDataReader drMySQL = cmdMySQL.ExecuteReader();

                    while (drMySQL.Read())
                    {
                        if (unaCancha.ID == Convert.ToInt32(drMySQL["id"].ToString()))
                        {
                            unaCancha.Nombre = drMySQL["nombre"].ToString();
                            unaCancha.Barrio = drMySQL["barrio"].ToString();
                            unaCancha.Calle1 = drMySQL["calle1"].ToString();
                            unaCancha.Calle1 = drMySQL["calle2"].ToString();
                            unaCancha.Telefono = Convert.ToInt32(drMySQL["telefono"].ToString());
                            unaCancha.Calificacion = Convert.ToInt32(drMySQL["calificacion"].ToString());
                            unaCancha.CantidadDeVotos = Convert.ToInt32(drMySQL["cantidaddevotos"].ToString());
                            break;
                        }
                    }
                    connMySQL.Close();
                    return unaCancha;
                }

                catch (Exception ErrorMySQL)
                {
                    connMySQL.Close();
                    unaCancha.Nombre = ErrorMySQL.ToString();
                    return unaCancha;
                }
            }
            catch (Exception e)
            {
                return unaCancha;
            }
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


                if (unaCancha.Id > 0)
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
                unaCancha2.Nombre = ErrorConexionBD.ToString();
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

                try
                {
                    querystr = "SELECT * FROM Canchas";
                    cmdMySQL = new MySqlCommand(querystr, connMySQL);
                    MySqlDataReader dr = cmdMySQL.ExecuteReader();

                    while (drMySQL.Read())
                    {
                        Cancha unaCancha2 = new Cancha();
                        unaCancha2.id = Convert.ToInt32(drMySQL["Id"].ToString());
                        unaCancha2.nombre = drMySQL["Nombre"].ToString();
                        unaCancha2.barrio = drMySQL["Barrio"].ToString();
                        unaCancha2.calle = drMySQL["Calle"].ToString();
                        unaCancha2.telefono = Convert.ToInt32(drMySQL["Telefono"].ToString());
                        if (unaCancha.nombre.Contains(unaCancha2.nombre) || unaCancha2.nombre.Contains(unaCancha.nombre))
                        {
                            ListadeCanchas.Add(unaCancha2);
                        }
                    }
                    connMySQL.Close();
                }

                catch (Exception ErrorMySQL)
                {
                    connMySQL.Close();
                    ListadeCanchas2[0].nombre = ErrorMySQL.ToString();
                }

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
        public static List<string> TraerNombresDeTodasLasCanchas()
        {
            List<string> ListadeCanchas = new List<string>();
            List<string> ListadeCanchas2 = new List<string>();

            try
            {
                ConectarDB();

                try
                {
                    querystr = "SELECT * FROM Canchas";
                    cmdMySQL = new MySqlCommand(querystr, connMySQL);
                    MySqlDataReader drMySQL = cmdMySQL.ExecuteReader();

                    while (drMySQL.Read())
                    {
                        ListadeCanchas.Add(drMySQL["Nombre"].ToString());
                    }
                    connMySQL.Close();
                }

                catch (Exception ErrorMySQL)
                {
                    connMySQL.Close();
                    ListadeCanchas2[0] = ErrorMySQL.ToString();
                }

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