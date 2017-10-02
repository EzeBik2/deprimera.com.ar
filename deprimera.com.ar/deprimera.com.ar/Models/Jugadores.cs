using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
//using MySql.Data.MySqlClient;

namespace deprimera.com.ar.Models
{
    public class Jugadores
    {
        //static string querystr;

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
        public static Jugador TraerUnJugador(Jugador unJugador)
        {
            Jugador unJugador2 = new Jugador();

            try
            {
                ConectarDB();

                //try Probamos MYSQL
                //{
                //querystr = "SELECT * FROM Jugadores";
                //cmdMySQL = new MySqlCommand(querystr, connMySQL);
                //MySqlDataReader drMySQL = cmdMySQL.ExecuteReader();

                //while (drMySQL.Read())
                //{
                //    if (drMySQL["email"].ToString() == unJugador.email && drMySQL["clave"].ToString() == unJugador.contraseña)
                //    {
                //        unJugador.id = Convert.ToInt32(drMySQL["id"].ToString());
                //        unJugador.nombre = drMySQL["nombre"].ToString();
                //        unJugador.apellido = drMySQL["apellido"].ToString();
                //        unJugador.foto = drMySQL["foto"].ToString();
                //        unJugador.edad = Convert.ToInt32(drMySQL["edad"].ToString());
                //        unJugador.telefono = Convert.ToInt32(drMySQL["telefono"].ToString());
                //        unJugador.calificacion = Convert.ToInt32(drMySQL["calificacion"].ToString());
                //        unJugador.cantidaddevotos = Convert.ToInt32(drMySQL["cantidaddeVotos"].ToString());
                //        unJugador.email = drMySQL["email"].ToString();
                //        unJugador.contraseña = drMySQL["clave"].ToString();
                //        connMySQL.Close();
                //    }
                //    if (Convert.ToInt32(drMySQL["id"].ToString()) == unJugador.id)
                //    {
                //        unJugador.id = Convert.ToInt32(drMySQL["id"].ToString());
                //        unJugador.nombre = drMySQL["nombre"].ToString();
                //        unJugador.apellido = drMySQL["apellido"].ToString();
                //        unJugador.foto = drMySQL["foto"].ToString();
                //        unJugador.edad = Convert.ToInt32(drMySQL["edad"].ToString());
                //        unJugador.telefono = Convert.ToInt32(drMySQL["telefono"].ToString());
                //        unJugador.calificacion = Convert.ToInt32(drMySQL["calificacion"].ToString());
                //        unJugador.cantidaddevotos = Convert.ToInt32(drMySQL["cantidaddeVotos"].ToString());
                //        unJugador.email = drMySQL["email"].ToString();
                //        unJugador.contraseña = drMySQL["clave"].ToString();
                //        connMySQL.Close();
                //    }
                //}
                //}
                //catch (Exception ErrorMySQL)
                //{
                //unJugador2.Confcontraseña = ErrorMySQL.ToString();
                //connMySQL.Close();
                //}

                try
                {
                    OleDbCommand Consulta = connAccess.CreateCommand();
                    Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                    Consulta.CommandText = "TraerJugadores";
                    OleDbDataReader drAccess = Consulta.ExecuteReader();

                    while (drAccess.Read())
                    {
                        if (drAccess["Email"].ToString() == unJugador.email && drAccess["Contraseña"].ToString() == unJugador.contraseña)
                        {
                            unJugador2.id = Convert.ToInt32(drAccess["Id"].ToString());
                            unJugador2.nombre = drAccess["Nombre"].ToString();
                            unJugador2.apellido = drAccess["Apellido"].ToString();
                            unJugador2.foto = drAccess["Foto"].ToString();
                            unJugador2.edad = Convert.ToInt32(drAccess["Edad"].ToString());
                            unJugador2.telefono = Convert.ToInt32(drAccess["Telefono"].ToString());
                            unJugador2.calificacion = Convert.ToInt32(drAccess["Calificacion"].ToString());
                            unJugador2.cantidaddevotos = Convert.ToInt32(drAccess["CantidaddeVotos"].ToString());
                            unJugador2.email = drAccess["Email"].ToString();
                            unJugador2.contraseña = drAccess["Contraseña"].ToString();
                            connAccess.Close();
                        }
                        if (Convert.ToInt32(drAccess["id"].ToString()) == unJugador.id)
                        {
                            unJugador2.id = Convert.ToInt32(drAccess["id"].ToString());
                            unJugador2.nombre = drAccess["nombre"].ToString();
                            unJugador2.apellido = drAccess["apellido"].ToString();
                            unJugador2.foto = drAccess["foto"].ToString();
                            unJugador2.edad = Convert.ToInt32(drAccess["edad"].ToString());
                            unJugador2.telefono = Convert.ToInt32(drAccess["telefono"].ToString());
                            unJugador2.calificacion = Convert.ToInt32(drAccess["calificacion"].ToString());
                            unJugador2.cantidaddevotos = Convert.ToInt32(drAccess["cantidaddeVotos"].ToString());
                            unJugador2.email = drAccess["email"].ToString();
                            unJugador2.contraseña = drAccess["clave"].ToString();
                            connAccess.Close();
                        }
                    }
                }
                catch (Exception ErrorAccess)
                {
                    unJugador2.Confcontraseña = ErrorAccess.ToString();
                    connAccess.Close();
                }

                if (unJugador.nombre != null)
                {
                    return unJugador;
                }
                else
                {
                    return unJugador2;
                }
            }

            catch (Exception)
            {
                return unJugador2;
            }
        }
        public static Jugador RegistrarJugador(Jugador unJugador)
        {
            Jugador unJugador2 = new Jugador();
            

            try
            {
                ConectarDB();

                //try
                //{
                //    querystr = "INSERT into Jugadores (nombre, apellido, foto, edad, telefono, calificacion, cantidaddevotos, email, clave) VALUES ('" + unJugador.nombre + "', '" + unJugador.apellido + "', '" + unJugador.foto + "', '" + unJugador.edad + "', '" + unJugador.telefono + "', '" + unJugador.calificacion + "', '" + unJugador.cantidaddevotos + "', '" + unJugador.email + "', '" + unJugador.contraseña + "' )";
                //    cmdMySQL = new MySqlCommand(querystr, connMySQL);

                //    int resultado = (int)cmdMySQL.ExecuteNonQuery();
                //    if (resultado == 1)
                //    {
                //        unJugador2.Confcontraseña = "FUNCIONO";
                //    }

                //    connMySQL.Close();
                //}

                //catch (Exception ErrorMySQL)
                //{
                //unJugador2.Confcontraseña = ErrorMySQL.ToString()
                //    connMySQL.Close();
                //}

                try
                {
                    OleDbCommand Consulta = connAccess.CreateCommand();
                    Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                    Consulta.CommandText = "AgregarJugador";

                    OleDbParameter nombre = new OleDbParameter("nombre", OleDbType.VarChar, 88);
                    nombre.Value = unJugador.nombre;
                    OleDbParameter apellido = new OleDbParameter("apellido", OleDbType.VarChar, 88);
                    apellido.Value = unJugador.apellido;
                    OleDbParameter foto = new OleDbParameter("foto", OleDbType.VarChar, 88);
                    foto.Value = "";
                    OleDbParameter edad = new OleDbParameter("edad", OleDbType.VarChar, 88);
                    edad.Value = Convert.ToInt32(unJugador.edad);
                    OleDbParameter telefono = new OleDbParameter("telefono", OleDbType.VarChar, 88);
                    telefono.Value = Convert.ToInt32(unJugador.telefono);
                    OleDbParameter calificacion = new OleDbParameter("calificacion", OleDbType.VarChar, 88);
                    calificacion.Value = 0;
                    OleDbParameter cantidaddevotos = new OleDbParameter("cantidaddevotos", OleDbType.VarChar, 88);
                    cantidaddevotos.Value = 0;
                    OleDbParameter email = new OleDbParameter("email", OleDbType.VarChar, 88);
                    email.Value = unJugador.email;
                    OleDbParameter contraseña = new OleDbParameter("contraseña", OleDbType.VarChar, 88);
                    contraseña.Value = unJugador.contraseña;

                    Consulta.Parameters.Add(nombre);
                    Consulta.Parameters.Add(apellido);
                    Consulta.Parameters.Add(foto);
                    Consulta.Parameters.Add(edad);
                    Consulta.Parameters.Add(telefono);
                    Consulta.Parameters.Add(calificacion);
                    Consulta.Parameters.Add(cantidaddevotos);
                    Consulta.Parameters.Add(email);
                    Consulta.Parameters.Add(contraseña);
                    connAccess.Close();
                }

                catch (Exception ErrorAccess)
                {
                    unJugador2.Confcontraseña = ErrorAccess.ToString();
                    connAccess.Close();
                }

                if (unJugador.Confcontraseña == "FUNCIONO")
                {
                    return unJugador;
                }
                else
                {
                    return unJugador2;
                }
            }

            catch (Exception)
            {
                return unJugador2;
            }
        }
        public static List<Jugador> TraerJugadoresPorNombre(Jugador unJugador)
        {
            List<Jugador> ListadeJugadores = new List<Jugador>();
            List<Jugador> ListadeJugadores2 = new List<Jugador>();

            try
            {
                ConectarDB();

                //try
                //{
                //    querystr = "SELECT * FROM Jugadores";
                //    cmdMySQL = new MySqlCommand(querystr, connMySQL);
                //    MySqlDataReader dr = cmdMySQL.ExecuteReader();

                //    while (drMySQL.Read())
                //    {
                //        Jugador unJugador2 = new Jugador();
                //        unJugador2.id = Convert.ToInt32(drMySQL["id"].ToString());
                //        unJugador2.nombre = drMySQL["nombre"].ToString();
                //        unJugador2.apellido = drMySQL["apellido"].ToString();
                //        unJugador2.foto = drMySQL["foto"].ToString();
                //        unJugador2.edad = Convert.ToInt32(drMySQL["edad"].ToString());
                //        unJugador2.telefono = Convert.ToInt32(drMySQL["telefono"].ToString());
                //        unJugador2.calificacion = Convert.ToInt32(drMySQL["calificacion"].ToString());
                //        unJugador2.cantidaddevotos = Convert.ToInt32(drMySQL["cantidaddevotos"].ToString());
                //        unJugador2.email = drMySQL["email"].ToString();
                //        unJugador2.contraseña = drMySQL["clave"].ToString();
                //        if (unJugador.nombre.Contains(unJugador2.nombre) || unJugador2.nombre.Contains(unJugador.nombre))
                //        {
                //            ListadeJugadores.Add(unJugador2);
                //        }
                //    }
                //    connMySQL.Close();
                //}

                //catch (Exception ErrorMySQL)
                //{
                //    connMySQL.Close();
                //    ListadeJugadores[0].nombre = ErrorMySQL.ToString();
                //}

                try
                {
                    OleDbCommand Consulta = connAccess.CreateCommand();
                    Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                    Consulta.CommandText = "TraerJugadores";

                    OleDbDataReader drAccess = Consulta.ExecuteReader();
                    while (drAccess.Read())
                    {
                        Jugador unJugador2 = new Jugador();
                        unJugador2.id = Convert.ToInt32(drAccess["Id"].ToString());
                        unJugador2.nombre = drAccess["Nombre"].ToString();
                        unJugador2.apellido = drAccess["Apellido"].ToString();
                        unJugador2.foto = drAccess["Foto"].ToString();
                        unJugador2.edad = Convert.ToInt32(drAccess["Edad"].ToString());
                        unJugador2.telefono = Convert.ToInt32(drAccess["Telefono"].ToString());
                        unJugador2.calificacion = Convert.ToInt32(drAccess["Calificacion"].ToString());
                        unJugador2.cantidaddevotos = Convert.ToInt32(drAccess["CantidaddeVotos"].ToString());
                        unJugador2.email = drAccess["Email"].ToString();
                        unJugador2.contraseña = drAccess["Contraseña"].ToString();
                        if (unJugador.nombre.Contains(unJugador2.nombre) || unJugador2.nombre.Contains(unJugador.nombre))
                        {
                            ListadeJugadores2.Add(unJugador2);
                        }
                    }
                    connAccess.Close();
                }

                catch (Exception ErrorAccess)
                {
                    connAccess.Close();
                }

                return ListadeJugadores2;
            }

            catch (Exception ErrorConexionBD)
            {
                ListadeJugadores2[0].nombre = ErrorConexionBD.ToString();
                return ListadeJugadores2;
            }


        }
        public static Jugador TraerUnJugadorPorNombre(Jugador unJugador)
        {
            try
            {
                ConectarDB();

                //try
                //{
                //    querystr = "SELECT * FROM Jugadores";
                //    cmdMySQL = new MySqlCommand(querystr, connMySQL);
                //    MySqlDataReader dr = cmdMySQL.ExecuteReader();

                //    while (drMySQL.Read())
                //    {
                //        Jugador unJugador2 = new Jugador();
                //        unJugador2.id = Convert.ToInt32(drMySQL["id"].ToString());
                //        unJugador2.nombre = drMySQL["nombre"].ToString();
                //        unJugador2.apellido = drMySQL["apellido"].ToString();
                //        unJugador2.foto = drMySQL["foto"].ToString();
                //        unJugador2.edad = Convert.ToInt32(drMySQL["edad"].ToString());
                //        unJugador2.telefono = Convert.ToInt32(drMySQL["telefono"].ToString());
                //        unJugador2.calificacion = Convert.ToInt32(drMySQL["calificacion"].ToString());
                //        unJugador2.cantidaddevotos = Convert.ToInt32(drMySQL["cantidaddevotos"].ToString());
                //        unJugador2.email = drMySQL["email"].ToString();
                //        unJugador2.contraseña = drMySQL["clave"].ToString();
                //        if (unJugador.nombre.Contains(unJugador2.nombre) || unJugador2.nombre.Contains(unJugador.nombre))
                //        {
                //            unJugador = unJugador2;
                //            break;
                //        }
                //    }
                //    connMySQL.Close();
                //}

                //catch (Exception ErrorMySQL)
                //{
                //    connMySQL.Close();
                //}

                try
                {
                    OleDbCommand Consulta = connAccess.CreateCommand();
                    Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                    Consulta.CommandText = "TraerJugadores";

                    OleDbDataReader drAccess = Consulta.ExecuteReader();
                    while (drAccess.Read())
                    {
                        Jugador unJugador2 = new Jugador();
                        unJugador2.id = Convert.ToInt32(drAccess["Id"].ToString());
                        unJugador2.nombre = drAccess["Nombre"].ToString();
                        unJugador2.apellido = drAccess["Apellido"].ToString();
                        unJugador2.foto = drAccess["Foto"].ToString();
                        unJugador2.edad = Convert.ToInt32(drAccess["Edad"].ToString());
                        unJugador2.telefono = Convert.ToInt32(drAccess["Telefono"].ToString());
                        unJugador2.calificacion = Convert.ToInt32(drAccess["Calificacion"].ToString());
                        unJugador2.cantidaddevotos = Convert.ToInt32(drAccess["CantidaddeVotos"].ToString());
                        unJugador2.email = drAccess["Email"].ToString();
                        unJugador2.contraseña = drAccess["Contraseña"].ToString();
                        if (unJugador2.id == unJugador.id)
                        {
                            unJugador = unJugador2;
                            break;
                        }
                    }
                    connAccess.Close();
                }

                catch (Exception ErrorAccess)
                {
                    connAccess.Close();
                }

                return unJugador;
            }

            catch (Exception ErrorConexionBD)
            {
                unJugador.nombre = ErrorConexionBD.ToString();
                return unJugador;
            }

        }
    }
}