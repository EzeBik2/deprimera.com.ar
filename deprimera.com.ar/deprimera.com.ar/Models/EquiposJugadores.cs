using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace deprimera.com.ar.Models
{
    public class EquiposJugadores
    {
        static string querystr;
        static string ProveedorMySQL;
        static MySqlCommand cmdMySQL;
        static MySqlConnection connMySQL = new MySqlConnection();

        private static void ConectarDB()
        {
            connMySQL.ConnectionString = @"Database=localdb;Data Source=127.0.0.1;User Id=SurixOne;Password=poker123";
            connMySQL.Open();
        }
        public static EquipoJugador AgregarJugadorAEquipo(EquipoJugador unEquipoJugador)
        {
            string Error = null;
            try
            {
                ConectarDB();

                try
                {
                    querystr = "INSERT into EquiposJugadores (estado, rol, idequipo, idjugador) VALUES ('" + unEquipoJugador.Estado + "', '" + unEquipoJugador.Rol + "', '" + unEquipoJugador.IdEquipo + "', '" + unEquipoJugador.IdJugador + "' )";
                    cmdMySQL = new MySqlCommand(querystr, connMySQL);

                    int resultado = (int)cmdMySQL.ExecuteNonQuery();
                    if (resultado == 1)
                    {
                        connMySQL.Close();
                    }
                    return unEquipoJugador;
                }

                catch (Exception ErrorMySQL)
                {
                    Error = ErrorMySQL.ToString();
                    connMySQL.Close();
                    return unEquipoJugador;
                }
            }
            catch
            {
                connMySQL.Close();
                return unEquipoJugador;
            }
        }
        public static EquipoJugador TraerEquipoJugadorPorIDs(int idEquipo, int idJugador)
        {
            EquipoJugador unEquipoJugador = new EquipoJugador();
            try
            {
                ConectarDB();
                querystr = "SELECT * FROM EquiposJugadores";
                cmdMySQL = new MySqlCommand(querystr, connMySQL);
                MySqlDataReader drMySQL = cmdMySQL.ExecuteReader();
                while (drMySQL.Read())
                {
                    if (Convert.ToInt32(drMySQL["idequipo"].ToString()) == idEquipo && Convert.ToInt32(drMySQL["idjugador"].ToString()) == idJugador)
                    {
                        unEquipoJugador.ID = Convert.ToInt32(drMySQL["id"].ToString());
                        unEquipoJugador.Estado = drMySQL["estado"].ToString();
                        unEquipoJugador.Rol = drMySQL["rol"].ToString();
                        unEquipoJugador.IdEquipo = Convert.ToInt32(drMySQL["idequipo"].ToString());
                        unEquipoJugador.IdJugador = Convert.ToInt32(drMySQL["idjugador"].ToString());
                        connMySQL.Close();
                    }
                }
                return unEquipoJugador;
            }
            catch (Exception)
            {
                connMySQL.Close();
                return unEquipoJugador;
            }
        }

        public static List<EquipoJugador> TraerJugadores(int idEquipo)
        {
            EquipoJugador unEquipoJugador = new EquipoJugador();
            List<EquipoJugador> listaEquíposJugadores = new List<EquipoJugador>();
            try
            {
                ConectarDB();
                querystr = "SELECT * FROM EquiposJugadores";
                cmdMySQL = new MySqlCommand(querystr, connMySQL);
                MySqlDataReader drMySQL = cmdMySQL.ExecuteReader();

                while (drMySQL.Read())
                {
                    if (Convert.ToInt32(drMySQL["idequipo"].ToString()) == idEquipo)
                    {
                        unEquipoJugador.ID = Convert.ToInt32(drMySQL["id"].ToString());
                        unEquipoJugador.Estado = drMySQL["estado"].ToString();
                        unEquipoJugador.Rol = drMySQL["rol"].ToString();
                        unEquipoJugador.IdEquipo = Convert.ToInt32(drMySQL["idequipo"].ToString());
                        unEquipoJugador.IdJugador = Convert.ToInt32(drMySQL["idjugador"].ToString());
                        listaEquíposJugadores.Add(unEquipoJugador);
                    }
                }

                connMySQL.Close();
                return listaEquíposJugadores;
            }
            catch (Exception)
            {
                connMySQL.Close();
                return listaEquíposJugadores;
            }
        }
        public static EquipoJugador ModificarEquipoJugador(EquipoJugador unEquipoJugador)
        {
            ConectarDB();
            try
            {
                querystr = "UPDATE EquiposJugadores SET estado = '" + unEquipoJugador.Estado + "', rol = '" + unEquipoJugador.Rol + "', idequipo = '" + unEquipoJugador.IdEquipo + "', idjugador = '" + unEquipoJugador.IdJugador + "' WHERE id = '" + unEquipoJugador.ID + "'";
                cmdMySQL = new MySqlCommand(querystr, connMySQL);
                int resultado = (int)cmdMySQL.ExecuteNonQuery();
                if (resultado == 1)
                {
                    connMySQL.Close();
                }
                return unEquipoJugador;
            }
            catch (Exception e)
            {
                connMySQL.Close();
                return unEquipoJugador;
            }
        }
        public static bool EliminarEquipoJugador(EquipoJugador unEquipoJugador)
        {
            bool funciono = false;
            try
            {
                ConectarDB();
                querystr = "DELETE FROM EquiposJugadores WHERE id = '" + unEquipoJugador.ID + "'";
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