using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace bryan123.Clases.BaseDatos
{
    public class ClsConeccion
    {
        public SqlConnection conexion;
        private String _conexion { get; }

       
        

        public ClsConeccion()
        {

            _conexion = "Data Source= UMG-VM\\SQLEXPRESS ;Initial Catalog=DBprograma;Integrated Security=True";

        }



        
        public void cerrarConexionBD()
        {
            conexion.Close();
        }


        public void abrirConexion()
        {
            conexion = new SqlConnection(_conexion);
            conexion.Open();
        }




      
        public DataTable consultaTablaDirecta(String sqll)
        {
            abrirConexion();
            SqlDataReader dr;
            SqlCommand comm = new SqlCommand(sqll, conexion);
            dr = comm.ExecuteReader();

            var dataTable = new DataTable();
            dataTable.Load(dr);
            cerrarConexionBD();
            return dataTable;
        }



        
        public void EjecutaSQLDirecto(String sqll)
        {
            abrirConexion();
            try
            {

                SqlCommand comm = new SqlCommand(sqll, conexion);
                comm.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            finally
            {
                cerrarConexionBD();
            }



        }




       
        public void EjecutaSQLManual(String sqll)
        {
          
            SqlCommand comm = new SqlCommand(sqll, conexion);
            comm.ExecuteReader();
        }


    }
}