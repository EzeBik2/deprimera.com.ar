using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
//using MySql.Data.MySqlClient;

namespace deprimera.com.ar.Models
{
    public class Partidos
    {
        static string querystr;

        //static string ProveedorMySQL;
        //static MySqlCommand cmdMySQL;
        //static MySqlConnection connMySQL = new MySqlConnection();

        private static void ConectarDB()
        {
            //connMySQL.ConnectionString = @"Data Source=localhost; Database=DBRSF; User ID=root; Password='root'";
            //connMySQL.Open();
        }
        //public static Partido ArmarPartido(Partido unPartido)
        //{
        //    //AGREGAR DATOS A LA TABLA PARTIDOS.
        //}
        //public static Partido TraerUnPartidoPorId(Partido unPartido)
        //{
        //    //TRAER FILA POR ID DE LA TABLA PARTIDOS
        //}
        //public static Partido Modificar(Partido unPartido)
        //{
        //    //MODIFICAR TODOS LOS DATOS DE UNA FILA DE LA TABLA PARTIDOSJUGADORES SEGUN SU ID.
        //}
    }
}