using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
//using MySql.Data.MySqlClient;

namespace deprimera.com.ar.Models
{
    public class EquiposJugadores
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
        public static string AgregarJugadorAEquipo(EquipoJugador unEquipoJugador)
        {
            string Error = null;

            try
            {
                ConectarDB();

                //try
                //{
                //    querystr = "INSERT into EquiposJugadores (estado, idEquipo, idJugador) VALUES ('" + unEquipoJugador.estado + "', '" + unEquipoJugador.idEquipo + "', '" + unEquipoJugador.idJugador + "' )";
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
                //    Error = ErrorMySQL.ToString();
                //    connMySQL.Close();
                //}

                try
                {
                    OleDbCommand Consulta = connAccess.CreateCommand();
                    Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                    Consulta.CommandText = "Agregar";

                    OleDbParameter estado = new OleDbParameter("Estado", "En Formacion");
                    OleDbParameter equipo = new OleDbParameter("Idequipo", unEquipoJugador.idEquipo);
                    OleDbParameter jugador = new OleDbParameter("Idjugador", unEquipoJugador.idJugador);


                    Consulta.Parameters.Add(estado);
                    Consulta.Parameters.Add(equipo);
                    Consulta.Parameters.Add(jugador);


                    int resultado = (int)Consulta.ExecuteNonQuery();
                    bool funciono = false;
                    if (resultado == 1)
                    {
                        funciono = true;
                    }

                    connAccess.Close();
                }

                catch (Exception e)
                {
                    connAccess.Close();
                }

                return Error;
            }

            catch (Exception ErrorConexionBD)
            {
                return ErrorConexionBD.ToString();
            }
        }
    }
}