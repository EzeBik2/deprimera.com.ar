using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
//using MySql.Data.MySqlClient;

namespace deprimera.com.ar.Models
{
    public class PartidosJugadores
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
        public static string AgregarJugadorAPartido(PartidoJugador unJugadorPartido)
        {
            string Error = null;

            try
            {
                ConectarDB();

                //try
                //{
                //    querystr = "INSERT into PartidosJugadores (estado, idPartido, idJugador) VALUES ('En formacion', '" + unJugadorPartido.idPartido + "', '" + unJugadorPartido.idJugador + "' )";
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
                    Consulta.CommandText = "AgregarB";

                    OleDbParameter estado = new OleDbParameter("Estado", "En Formacion");
                    OleDbParameter partido = new OleDbParameter("idpartido", unJugadorPartido.idPartido);
                    OleDbParameter jugador = new OleDbParameter("idjugador", unJugadorPartido.idJugador);


                    Consulta.Parameters.Add(estado);
                    Consulta.Parameters.Add(partido);
                    Consulta.Parameters.Add(jugador);


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

                return Error;
            }

            catch (Exception ErrorConexionBD)
            {     
                return ErrorConexionBD.ToString();
            }

        }

    }
}