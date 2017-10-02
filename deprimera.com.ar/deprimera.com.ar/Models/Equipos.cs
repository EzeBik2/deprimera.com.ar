using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
//using MySql.Data.MySqlClient;

namespace deprimera.com.ar.Models
{
    public class Equipos
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
        public static Equipo ArmarEquipo(Equipo equipoarmar)
        {
            try
            {
                ConectarDB();

                //try
                //{
                //    querystr = "INSERT into Equipos (nombre, cantjug, calificacion, cantvotos) VALUES ('" + equipoarmar.nombre + "', '" + equipoarmar.cantjug + "', '" + 0 + "', '" + 0 + "' )";
                //    cmdMySQL = new MySqlCommand(querystr, connMySQL);

                //    int resultado = (int)cmdMySQL.ExecuteNonQuery();
                //    bool funciono = false;
                //    if (resultado == 1)
                //    {
                //        funciono = true;
                //    }

                //    connMySQL.Close();
                //}

                //catch (Exception ErrorMySQL)
                //{
                //    equipoarmar.Funciono = ErrorMySQL.ToString();
                //    connMySQL.Close();
                //}

                try
                {
                    OleDbCommand Consulta = connAccess.CreateCommand();
                    Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                    Consulta.CommandText = "AgregarEquipo";

                    OleDbParameter nombre = new OleDbParameter("nombre", OleDbType.VarChar, 88);
                    nombre.Value = equipoarmar.nombre;
                    OleDbParameter cantjug = new OleDbParameter("cantjug", OleDbType.VarChar, 88);
                    cantjug.Value = equipoarmar.cantjug;
                    OleDbParameter calificacion = new OleDbParameter("calificacion", OleDbType.VarChar, 88);
                    calificacion.Value = equipoarmar.calificacion;
                    OleDbParameter cantidaddevotos = new OleDbParameter("cantvotos", OleDbType.VarChar, 88);
                    cantidaddevotos.Value = equipoarmar.cantvotos;

                    Consulta.Parameters.Add(nombre);
                    Consulta.Parameters.Add(cantjug);
                    Consulta.Parameters.Add(calificacion);
                    Consulta.Parameters.Add(cantidaddevotos);


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

                if (equipoarmar.Funciono == null)
                {
                    //ConectarDB();
                    //try
                    //{
                    //    querystr = "SELECT * FROM Equipos";
                    //    cmdMySQL = new MySqlCommand(querystr, connMySQL);
                    //    MySqlDataReader drMySQL = cmdMySQL.ExecuteReader();

                    //    while (drMySQL.Read())
                    //    {
                    //        if (equipoarmar.nombre == drMySQL["Nombre"].ToString())
                    //        {
                    //            equipoarmar.id = Convert.ToInt32(drMySQL["Id"].ToString());
                    //            connMySQL.Close();
                    //        }
                    //    }
                    //}

                    //catch (Exception ErrorMySQL)
                    //{
                    //    equipoarmar.Funciono = ErrorMySQL;
                    //    connMySQL.Close();
                    //}

                    try
                    {
                        OleDbCommand Consulta = connAccess.CreateCommand();
                        Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                        Consulta.CommandText = "TraerEquipos";

                        OleDbDataReader drAccess = Consulta.ExecuteReader();
                        while (drAccess.Read())
                        {
                            if (equipoarmar.nombre == drAccess["Nombre"].ToString())
                            {
                                equipoarmar.id = Convert.ToInt32(drAccess["Id"].ToString());
                                connAccess.Close();
                            }
                        }
                    }

                    catch (Exception ErrorAccess)
                    {
                        connAccess.Close();
                    }
                }

                return equipoarmar;
            }
            
            catch (Exception ErrorConexionBD)
            {
                equipoarmar.nombre = ErrorConexionBD.ToString();
                return equipoarmar;
            }

        }
        public static List<Equipo> TraerEquiposPorNombre(Equipo unEquipo)
        {
            List<Equipo> ListadeEquipos = new List<Equipo>();
            List<Equipo> ListadeEquipos2 = new List<Equipo>();

            try
            {
                ConectarDB();

                //try
                //{
                //    querystr = "SELECT * FROM Equipos";
                //    cmdMySQL = new MySqlCommand(querystr, connMySQL);
                //    MySqlDataReader dr = cmdMySQL.ExecuteReader();

                //    while (drMySQL.Read())
                //    {
                //        Equipo unEquipo2 = new Equipo();
                //        unEquipo2.id = Convert.ToInt32(drMySQL["Id"].ToString());
                //        unEquipo2.nombre = drMySQL["Nombre"].ToString();
                //        unEquipo2.cantjug = Convert.ToInt32(drMySQL["Cantjug"].ToString());
                //        unEquipo2.calificacion = Convert.ToInt32(drMySQL["Calificacion"].ToString());
                //        unEquipo2.cantvotos = Convert.ToInt32(drMySQL["Cantvotos"].ToString());
                //        if (unEquipo.nombre.Contains(unEquipo2.nombre) || unEquipo2.nombre.Contains(unEquipo.nombre))
                //        {
                //            ListadeEquipos.Add(unEquipo2);
                //        }
                //    }
                //    connMySQL.Close();
                //}

                //catch (Exception ErrorMySQL)
                //{
                //    connMySQL.Close();
                //    ListadeEquipos[0].nombre = ErrorMySQL.ToString();
                //}

                try
                {
                    OleDbCommand Consulta = connAccess.CreateCommand();
                    Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                    Consulta.CommandText = "TraerEquipos";

                    OleDbDataReader drAccess = Consulta.ExecuteReader();
                    while (drAccess.Read())
                    {
                        Equipo unEquipo2 = new Equipo();
                        unEquipo2.id = Convert.ToInt32(drAccess["Id"].ToString());
                        unEquipo2.nombre = drAccess["Nombre"].ToString();
                        unEquipo2.cantjug = Convert.ToInt32(drAccess["Cantjug"].ToString());
                        unEquipo2.calificacion = Convert.ToInt32(drAccess["Calificacion"].ToString());
                        unEquipo2.cantvotos = Convert.ToInt32(drAccess["Cantvotos"].ToString());
                        if (unEquipo.nombre.Contains(unEquipo2.nombre) || unEquipo2.nombre.Contains(unEquipo.nombre))
                        {
                            ListadeEquipos2.Add(unEquipo2);
                        }
                    }
                    connAccess.Close();
                }

                catch (Exception ErrorAccess)
                {
                    connAccess.Close();
                }

                return ListadeEquipos2;
            }

            catch (Exception ErrorConexionBD)
            {
                ListadeEquipos2[0].nombre = ErrorConexionBD.ToString();
                return ListadeEquipos2;
            }

        }
        public static Equipo TraerUnEquipoPorId(Equipo unEquipo)
        {
            try
            {
                ConectarDB();

                //try
                //{
                //    querystr = "SELECT * FROM Equipos";
                //    cmdMySQL = new MySqlCommand(querystr, connMySQL);
                //    MySqlDataReader dr = cmdMySQL.ExecuteReader();

                //    while (drMySQL.Read())
                //    {
                //        Equipo unEquipo2 = new Equipo();
                //        unEquipo2.id = Convert.ToInt32(drMySQL["Id"].ToString());
                //        unEquipo2.nombre = drMySQL["Nombre"].ToString();
                //        unEquipo2.cantjug = Convert.ToInt32(drMySQL["Cantjug"].ToString());
                //        unEquipo2.calificacion = Convert.ToInt32(drMySQL["Calificacion"].ToString());
                //        unEquipo2.cantvotos = Convert.ToInt32(drMySQL["Cantvotos"].ToString());
                //        if (unEquipo2.id == unEquipo.id)
                //        {
                //            unEquipo = unEquipo2;
                //            break;
                //        }
                //    }
                //    connMySQL.Close();
                //}

                //catch (Exception ErrorMySQL)
                //{
                //    unEquipo.nombre = ErrorMySQL.ToString();
                //    connMySQL.Close();
                //}

                try
                {
                    OleDbCommand Consulta = connAccess.CreateCommand();
                    Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                    Consulta.CommandText = "TraerEquipos";

                    OleDbDataReader drAccess = Consulta.ExecuteReader();
                    while (drAccess.Read())
                    {
                        Equipo unEquipo2 = new Equipo();
                        unEquipo2.id = Convert.ToInt32(drAccess["Id"].ToString());
                        unEquipo2.nombre = drAccess["Nombre"].ToString();
                        unEquipo2.cantjug = Convert.ToInt32(drAccess["Cantjug"].ToString());
                        unEquipo2.calificacion = Convert.ToInt32(drAccess["Calificacion"].ToString());
                        unEquipo2.cantvotos = Convert.ToInt32(drAccess["Cantvotos"].ToString());
                        if (unEquipo2.id == unEquipo.id)
                        {
                            unEquipo = unEquipo2;
                            break;
                        }
                    }
                    connAccess.Close();
                }

                catch (Exception ErrorAccess)
                {
                    connAccess.Close();
                }

                return unEquipo;
            }

            catch (Exception ErrorConexionBD)
            {
                unEquipo.nombre = ErrorConexionBD.ToString();
                return unEquipo;
            }


        }
    }
}