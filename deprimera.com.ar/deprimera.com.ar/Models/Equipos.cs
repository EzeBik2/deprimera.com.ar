using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace deprimera.com.ar.Models
{
    public class Equipos
    {
        static string querystr;
        static string ProveedorMySQL;
        static MySqlCommand cmdMySQL;
        static MySqlConnection connMySQL = new MySqlConnection();

        private static void ConectarDB()
        {
            connMySQL.ConnectionString = @"Database=dbdeprimera;Data Source=127.0.0.1:49164;User Id=azure;Password=6#vWHD_$";
            connMySQL.Open();
        }
        public static Equipo ArmarEquipo(Equipo equipoarmar)
        {
            try
            {
                ConectarDB();

                try
                {
                    querystr = "INSERT into Equipos (nombre, cantjug, calificacion, cantvotos, idcanchapreferida, idcamisetapreferida, descripcion, sepuede) VALUES ('" + equipoarmar.Nombre + "', '" + equipoarmar.CantJug + "', '" + 0 + "', '" + 0 + "', '" + equipoarmar.IDCanchaPreferida + "', '" + equipoarmar.IDCamisetaPreferida + "', '" + equipoarmar.Descripcion + "', '" + equipoarmar.SEPUEDE + "' )";
                    cmdMySQL = new MySqlCommand(querystr, connMySQL);

                    int resultado = (int)cmdMySQL.ExecuteNonQuery();
                    bool funciono = false;
                    if (resultado == 1)
                    {
                        funciono = true;
                        connMySQL.Close();
                    }
                    return equipoarmar;
                }

                catch (Exception ErrorMySQL)
                {
                    equipoarmar.SEPUEDE = ErrorMySQL.ToString();
                    connMySQL.Close();
                    return equipoarmar;
                }
            }
            catch (Exception e)
            {
                connMySQL.Close();
                return equipoarmar;
            }
        }
        public static Equipo TraerEquipoPorID(int idEquipo)
        {
            Equipo unEquipo = new Equipo();
            try
            {
                ConectarDB();
                try
                {
                    querystr = "SELECT * FROM Equipos";
                    cmdMySQL = new MySqlCommand(querystr, connMySQL);
                    MySqlDataReader drMySQL = cmdMySQL.ExecuteReader();
                    while (drMySQL.Read())
                    {
                        if (idEquipo == Convert.ToInt32(drMySQL["id"].ToString()))
                        {
                            unEquipo.ID = Convert.ToInt32(drMySQL["id"].ToString());
                            unEquipo.Nombre = drMySQL["nombre"].ToString();
                            unEquipo.CantJug = Convert.ToInt32(drMySQL["cantjug"].ToString());
                            unEquipo.Calificacion = Convert.ToInt32(drMySQL["calificacion"].ToString());
                            unEquipo.Cantvotos = Convert.ToInt32(drMySQL["cantvotos"].ToString());
                            unEquipo.IDCanchaPreferida = Convert.ToInt32(drMySQL["idcanchapreferida"].ToString());
                            unEquipo.IDCamisetaPreferida = Convert.ToInt32(drMySQL["idcamisetapreferida"].ToString());
                            unEquipo.Descripcion = drMySQL["descripcion"].ToString();
                            unEquipo.SEPUEDE = drMySQL["sepuede"].ToString();
                            break;
                        }
                    }
                    connMySQL.Close();
                    return unEquipo;
                }

                catch (Exception ErrorMySQL)
                {
                    connMySQL.Close();
                    unEquipo.Nombre = ErrorMySQL.ToString();
                    return unEquipo;
                }
            }
            catch (Exception e)
            {
                connMySQL.Close();
                return unEquipo;
            }
        }
        public static Equipo ModificarEquipoPorID(Equipo unEquipo)
        {
            ConectarDB();
            try
            {
                querystr = "UPDATE Equipos SET nombre = '" + unEquipo.Nombre + "', cantjug = '" + unEquipo.CantJug + "', calificacion = '" + unEquipo.Calificacion + "', cantvotos = '" + unEquipo.Cantvotos + "', idcanchapreferida = '" + unEquipo.IDCanchaPreferida + "', idcamisetapreferida = '" + unEquipo.IDCamisetaPreferida + "', descripcion = '" + unEquipo.Descripcion + "', sepuede = '" + unEquipo.SEPUEDE + "' WHERE id = '" + unEquipo.ID + "'";
                cmdMySQL = new MySqlCommand(querystr, connMySQL);
                int resultado = (int)cmdMySQL.ExecuteNonQuery();
                if (resultado == 1)
                {
                    connMySQL.Close();
                }
                return unEquipo;
            }

            catch (Exception e)
            {
                connMySQL.Close();
                return unEquipo;
            }
        }
        public static bool EliminarEquipoPorID(Equipo unEquipo)
        {
            bool funciono = false;
            try
            {
                ConectarDB();
                querystr = "DELETE FROM Equipos WHERE id = '" + unEquipo.ID + "'";
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