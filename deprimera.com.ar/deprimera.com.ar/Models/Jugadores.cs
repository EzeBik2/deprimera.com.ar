using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace deprimera.com.ar.Models
{
    public class Jugadores
    {
        static string querystr;
        static string ProveedorMySQL;
        static MySqlCommand cmdMySQL;
        static MySqlConnection connMySQL = new MySqlConnection();

        private static void ConectarDB()
        {
            connMySQL.ConnectionString = @"Database=localdb;Data Source=127.0.0.1;User Id=azure;Password=6#vWHD_$";
            connMySQL.Open();
        }
        public static Jugador TraerUnJugadorPorEmailClave(Jugador unJugador)
        {
            Jugador unJugador2 = new Jugador();

            try
            {
                ConectarDB();                
                querystr = "SELECT * FROM Jugadores";
                cmdMySQL = new MySqlCommand(querystr, connMySQL);
                MySqlDataReader drMySQL = cmdMySQL.ExecuteReader();

                while (drMySQL.Read())
                {
                    if (drMySQL["email"].ToString() == unJugador.Email && drMySQL["clave"].ToString() == unJugador.Contraseña)
                    {
                        unJugador.ID = Convert.ToInt32(drMySQL["id"].ToString());
                        unJugador.Nombre = drMySQL["nombre"].ToString();
                        unJugador.Apellido = drMySQL["apellido"].ToString();
                        unJugador.Foto = drMySQL["foto"].ToString();
                        unJugador.Edad = Convert.ToInt32(drMySQL["edad"].ToString());
                        unJugador.Telefono = Convert.ToInt32(drMySQL["telefono"].ToString());
                        unJugador.Calificacion = Convert.ToInt32(drMySQL["calificacion"].ToString());
                        unJugador.CantidadDeVotos = Convert.ToInt32(drMySQL["cantidaddeVotos"].ToString());
                        unJugador.Email = drMySQL["email"].ToString();
                        unJugador.Contraseña = drMySQL["clave"].ToString();
                        connMySQL.Close();
                    }
                }
                return unJugador2;
            }
            catch (Exception)
            {
                return unJugador2;
            }
        }
         public static Jugador TraerUnJugadorPorID(int idJugador)
        {
            Jugador unJugador = new Jugador();

            try
            {
                ConectarDB();               
                querystr = "SELECT * FROM Jugadores WHERE id='"+idJugador+"'";
                cmdMySQL = new MySqlCommand(querystr, connMySQL);
                MySqlDataReader drMySQL = cmdMySQL.ExecuteReader();

                while (drMySQL.Read())
                {                   
                    if (Convert.ToInt32(drMySQL["id"].ToString()) == idJugador)
                    {
                        unJugador.ID = Convert.ToInt32(drMySQL["id"].ToString());
                        unJugador.Nombre = drMySQL["nombre"].ToString();
                        unJugador.Apellido = drMySQL["apellido"].ToString();
                        unJugador.Foto = drMySQL["foto"].ToString();
                        unJugador.Edad = Convert.ToInt32(drMySQL["edad"].ToString());
                        unJugador.Telefono = Convert.ToInt32(drMySQL["telefono"].ToString());
                        unJugador.Calificacion = Convert.ToInt32(drMySQL["calificacion"].ToString());
                        unJugador.CantidadDeVotos = Convert.ToInt32(drMySQL["cantidaddeVotos"].ToString());
                        unJugador.Email = drMySQL["email"].ToString();
                        unJugador.Contraseña = drMySQL["clave"].ToString();
                        connMySQL.Close();
                    }
                }
                return unJugador;
            }
            catch (Exception)
            {
                return unJugador;
            }
        }
        public static Jugador AgregarJugador(Jugador unJugador)
        {
            
            try
            {
                ConectarDB();
                try
                {
                    querystr = "INSERT into Jugadores (nombre, apellido, foto, edad, telefono, calificacion, cantidaddevotos, email, clave) VALUES ('" + unJugador.Nombre + "', '" + unJugador.Apellido + "', '" + unJugador.Foto + "', '" + unJugador.Edad + "', '" + unJugador.Telefono + "', '" + unJugador.Calificacion + "', '" + unJugador.CantidadDeVotos + "', '" + unJugador.Email + "', '" + unJugador.Contraseña + "' )";
                    cmdMySQL = new MySqlCommand(querystr, connMySQL);

                    int resultado = (int)cmdMySQL.ExecuteNonQuery();
                    if (resultado == 1)
                    {
                        connMySQL.Close();
                    }
                    return unJugador;
                }
                catch (Exception e)
                {
                    connMySQL.Close();
                    return unJugador;
                }
            }

            catch (Exception)
            {
                return unJugador;
            }
        }
        //public static List<Jugador> TraerJugadoresPorNombre(Jugador unJugador)
        //{
        //    List<Jugador> ListadeJugadores = new List<Jugador>();
        //    List<Jugador> ListadeJugadores2 = new List<Jugador>();

        //    try
        //    {
        //        ConectarDB();

        //        //try
        //        //{
        //        //    querystr = "SELECT * FROM Jugadores";
        //        //    cmdMySQL = new MySqlCommand(querystr, connMySQL);
        //        //    MySqlDataReader dr = cmdMySQL.ExecuteReader();

        //        //    while (drMySQL.Read())
        //        //    {
        //        //        Jugador unJugador2 = new Jugador();
        //        //        unJugador2.id = Convert.ToInt32(drMySQL["id"].ToString());
        //        //        unJugador2.nombre = drMySQL["nombre"].ToString();
        //        //        unJugador2.apellido = drMySQL["apellido"].ToString();
        //        //        unJugador2.foto = drMySQL["foto"].ToString();
        //        //        unJugador2.edad = Convert.ToInt32(drMySQL["edad"].ToString());
        //        //        unJugador2.telefono = Convert.ToInt32(drMySQL["telefono"].ToString());
        //        //        unJugador2.calificacion = Convert.ToInt32(drMySQL["calificacion"].ToString());
        //        //        unJugador2.cantidaddevotos = Convert.ToInt32(drMySQL["cantidaddevotos"].ToString());
        //        //        unJugador2.email = drMySQL["email"].ToString();
        //        //        unJugador2.contraseña = drMySQL["clave"].ToString();
        //        //        if (unJugador.nombre.Contains(unJugador2.nombre) || unJugador2.nombre.Contains(unJugador.nombre))
        //        //        {
        //        //            ListadeJugadores.Add(unJugador2);
        //        //        }
        //        //    }
        //        //    connMySQL.Close();
        //        //}

        //        //catch (Exception ErrorMySQL)
        //        //{
        //        //    connMySQL.Close();
        //        //    ListadeJugadores[0].nombre = ErrorMySQL.ToString();
        //        //}

        //        try
        //        {
        //            OleDbCommand Consulta = connAccess.CreateCommand();
        //            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
        //            Consulta.CommandText = "TraerJugadores";

        //            OleDbDataReader drAccess = Consulta.ExecuteReader();
        //            while (drAccess.Read())
        //            {
        //                Jugador unJugador2 = new Jugador();
        //                unJugador2.id = Convert.ToInt32(drAccess["Id"].ToString());
        //                unJugador2.nombre = drAccess["Nombre"].ToString();
        //                unJugador2.apellido = drAccess["Apellido"].ToString();
        //                unJugador2.foto = drAccess["Foto"].ToString();
        //                unJugador2.edad = Convert.ToInt32(drAccess["Edad"].ToString());
        //                unJugador2.telefono = Convert.ToInt32(drAccess["Telefono"].ToString());
        //                unJugador2.calificacion = Convert.ToInt32(drAccess["Calificacion"].ToString());
        //                unJugador2.cantidaddevotos = Convert.ToInt32(drAccess["CantidaddeVotos"].ToString());
        //                unJugador2.email = drAccess["Email"].ToString();
        //                unJugador2.contraseña = drAccess["Contraseña"].ToString();
        //                if (unJugador.nombre.Contains(unJugador2.nombre) || unJugador2.nombre.Contains(unJugador.nombre))
        //                {
        //                    ListadeJugadores2.Add(unJugador2);
        //                }
        //            }
        //            connAccess.Close();
        //        }

        //        catch (Exception ErrorAccess)
        //        {
        //            connAccess.Close();
        //        }

        //        return ListadeJugadores2;
        //    }

        //    catch (Exception ErrorConexionBD)
        //    {
        //        ListadeJugadores2[0].nombre = ErrorConexionBD.ToString();
        //        return ListadeJugadores2;
        //    }


        //}
        //public static Jugador TraerUnJugadorPorNombre(Jugador unJugador)
        //{
        //    try
        //    {
        //        ConectarDB();

        //        //try
        //        //{
        //        //    querystr = "SELECT * FROM Jugadores";
        //        //    cmdMySQL = new MySqlCommand(querystr, connMySQL);
        //        //    MySqlDataReader dr = cmdMySQL.ExecuteReader();

        //        //    while (drMySQL.Read())
        //        //    {
        //        //        Jugador unJugador2 = new Jugador();
        //        //        unJugador2.id = Convert.ToInt32(drMySQL["id"].ToString());
        //        //        unJugador2.nombre = drMySQL["nombre"].ToString();
        //        //        unJugador2.apellido = drMySQL["apellido"].ToString();
        //        //        unJugador2.foto = drMySQL["foto"].ToString();
        //        //        unJugador2.edad = Convert.ToInt32(drMySQL["edad"].ToString());
        //        //        unJugador2.telefono = Convert.ToInt32(drMySQL["telefono"].ToString());
        //        //        unJugador2.calificacion = Convert.ToInt32(drMySQL["calificacion"].ToString());
        //        //        unJugador2.cantidaddevotos = Convert.ToInt32(drMySQL["cantidaddevotos"].ToString());
        //        //        unJugador2.email = drMySQL["email"].ToString();
        //        //        unJugador2.contraseña = drMySQL["clave"].ToString();
        //        //        if (unJugador.nombre.Contains(unJugador2.nombre) || unJugador2.nombre.Contains(unJugador.nombre))
        //        //        {
        //        //            unJugador = unJugador2;
        //        //            break;
        //        //        }
        //        //    }
        //        //    connMySQL.Close();
        //        //}

        //        //catch (Exception ErrorMySQL)
        //        //{
        //        //    connMySQL.Close();
        //        //}

        //        try
        //        {
        //            OleDbCommand Consulta = connAccess.CreateCommand();
        //            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
        //            Consulta.CommandText = "TraerJugadores";

        //            OleDbDataReader drAccess = Consulta.ExecuteReader();
        //            while (drAccess.Read())
        //            {
        //                Jugador unJugador2 = new Jugador();
        //                unJugador2.id = Convert.ToInt32(drAccess["Id"].ToString());
        //                unJugador2.nombre = drAccess["Nombre"].ToString();
        //                unJugador2.apellido = drAccess["Apellido"].ToString();
        //                unJugador2.foto = drAccess["Foto"].ToString();
        //                unJugador2.edad = Convert.ToInt32(drAccess["Edad"].ToString());
        //                unJugador2.telefono = Convert.ToInt32(drAccess["Telefono"].ToString());
        //                unJugador2.calificacion = Convert.ToInt32(drAccess["Calificacion"].ToString());
        //                unJugador2.cantidaddevotos = Convert.ToInt32(drAccess["CantidaddeVotos"].ToString());
        //                unJugador2.email = drAccess["Email"].ToString();
        //                unJugador2.contraseña = drAccess["Contraseña"].ToString();
        //                if (unJugador2.id == unJugador.id)
        //                {
        //                    unJugador = unJugador2;
        //                    break;
        //                }
        //            }
        //            connAccess.Close();
        //        }

        //        catch (Exception ErrorAccess)
        //        {
        //            connAccess.Close();
        //        }

        //        return unJugador;
        //    }

        //    catch (Exception ErrorConexionBD)
        //    {
        //        unJugador.nombre = ErrorConexionBD.ToString();
        //        return unJugador;
        //    }

        //}
    }
}