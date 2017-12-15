using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace deprimera.com.ar.Models
{
    public class PartidosJugadores
    {
        static string querystr;
        static string ProveedorMySQL;
        static MySqlCommand cmdMySQL;
        static MySqlConnection connMySQL = new MySqlConnection();

        private static void ConectarDB()
        {
            //connMySQL.ConnectionString = @"server=127.0.0.1;User ID=azure;password=6#vWHD_$;database=localdb;Port=21096";
            connMySQL.ConnectionString = @"Data Source=localhost;database=database;User ID=Usuario;Password=Usuario;";
            connMySQL.Open();
        }
        public static PartidoJugador AgregarJugadorAPartido(PartidoJugador unPartidoJugador)
        {
            PartidoJugador unPartidoJugador2 = new PartidoJugador();
            try
            {
                ConectarDB();
                try
                {
                    querystr = "INSERT into PartidosJugadores (estado, rol, idpartido, idjugador) VALUES ('" + unPartidoJugador.Estado + "', '" + unPartidoJugador.Rol + "', '" + unPartidoJugador.IdPartido + "', '" + unPartidoJugador.IdJugador + "' )";
                    cmdMySQL = new MySqlCommand(querystr, connMySQL);
                    int resultado = (int)cmdMySQL.ExecuteNonQuery();
                    if (resultado == 1)
                    {
                        return unPartidoJugador2;
                    }
                    connMySQL.Close();
                }
                catch (Exception e)
                {
                    connMySQL.Close();
                }
                return unPartidoJugador2;
            }

            catch (Exception)
            {
                return unPartidoJugador2;
            }
        }
        public static PartidoJugador ModificarPartidoJugador(PartidoJugador unPartidoJugador)
        {
            ConectarDB();
            try
            {
                querystr = "UPDATE PartidosJugadores SET estado = '" + unPartidoJugador.Estado + "', rol = '" + unPartidoJugador.Rol + "', idpartido = '" + unPartidoJugador.IdPartido + "', idjugador = '" + unPartidoJugador.IdJugador + "' WHERE id = '" + unPartidoJugador.ID + "'";
                cmdMySQL = new MySqlCommand(querystr, connMySQL);
                int resultado = (int)cmdMySQL.ExecuteNonQuery();
                if (resultado == 1)
                {
                    connMySQL.Close();
                }
                return unPartidoJugador;
            }
            catch (Exception e)
            {
                connMySQL.Close();
                return unPartidoJugador ;
            }
        }
        public static PartidoJugador TraerPartidoJugadorPorIDs(int idPartido, int idJugador)
        {
            PartidoJugador unPartidoJugador = new PartidoJugador();
            try
            {
                ConectarDB();
                querystr = "SELECT * FROM PartidosJugadores";
                cmdMySQL = new MySqlCommand(querystr, connMySQL);
                MySqlDataReader drMySQL = cmdMySQL.ExecuteReader();

                while (drMySQL.Read())
                {
                    if (Convert.ToInt32(drMySQL["idpartido"].ToString()) == idPartido && Convert.ToInt32(drMySQL["idjugador"].ToString()) == idJugador)
                    {
                        unPartidoJugador.ID = Convert.ToInt32(drMySQL["id"].ToString());
                        unPartidoJugador.Estado = drMySQL["estado"].ToString();
                        unPartidoJugador.Rol = drMySQL["rol"].ToString();
                        unPartidoJugador.IdPartido = Convert.ToInt32(drMySQL["idpartido"].ToString());
                        unPartidoJugador.IdJugador = Convert.ToInt32(drMySQL["idjugador"].ToString());
                        connMySQL.Close();
                    }
                }
                return unPartidoJugador;
            }
            catch (Exception)
            {
                connMySQL.Close();
                return unPartidoJugador;
            }
        }
        public static List<PartidoJugador> TraerJugadores(int IdPartido)
        {
            PartidoJugador unPartidoJugador = new PartidoJugador();
            List<PartidoJugador> listaPartidosJugadores = new List<PartidoJugador>();
            try
            {
                ConectarDB();
                querystr = "SELECT * FROM PartidosJugadores";
                cmdMySQL = new MySqlCommand(querystr, connMySQL);
                MySqlDataReader drMySQL = cmdMySQL.ExecuteReader();
            
                while (drMySQL.Read())
                {
                    if (Convert.ToInt32(drMySQL["idpartido"].ToString()) == IdPartido)
                    {
                        unPartidoJugador.ID = Convert.ToInt32(drMySQL["id"].ToString());
                        unPartidoJugador.Estado = drMySQL["estado"].ToString();
                        unPartidoJugador.Rol = drMySQL["rol"].ToString();
                        unPartidoJugador.IdPartido = Convert.ToInt32(drMySQL["idpartido"].ToString());
                        unPartidoJugador.IdJugador = Convert.ToInt32(drMySQL["idjugador"].ToString());
                        listaPartidosJugadores.Add(unPartidoJugador);
                    }
                }
                return listaPartidosJugadores;
                connMySQL.Close();
            }
            catch (Exception)
            {
                connMySQL.Close();
                return listaPartidosJugadores;
            }
        }
        public static bool Eliminar(PartidoJugador unPartidoJugador)
        {
        {
                bool funciono = false;
            try
            {
                ConectarDB();
                querystr = "DELETE FROM PartidosJugadores WHERE id = '" + unPartidoJugador.ID + "'";
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
}