using System;
using System.Data.SqlClient;
using System.Data;
namespace BDFamosos
{
    public class CFamosoDAL
    {
        private string strConexion;
        public CFamosoDAL()
        {
            strConexion = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
             @"AttachDbFilename=|DataDirectory|\bd_famosos.mdf; " +
             @"Integrated Security=True";
        }
        public ColCFamosos ObtenerFilasFamosos()
        {
            try
            {
                using (SqlConnection Conexion = new SqlConnection(strConexion))
                {
                    SqlCommand OrdenSql =
                    new SqlCommand("stproObtenerFilasFamosos", Conexion);
                    OrdenSql.CommandType = CommandType.StoredProcedure;

                    ColCFamosos colFamosos = new ColCFamosos();                   // Crear una colección 

                    Conexion.Open();                                              // Abrir la base de datos
                    SqlDataReader lector = OrdenSql.ExecuteReader();

                    while (lector.Read())
                    {
                        CFamosoBO fila = new CFamosoBO
                            (
                            (int)lector["ID"], (string)lector["nombre"], (string)lector["apellidos"],
                            (DateTime)lector["cumple"], (string)lector["imagen"]
                            );
                        colFamosos.Add(fila);
                    }
                    return colFamosos;
                }
            }
            catch (SqlException error)
            {
                throw new ApplicationException("Error SELECT famoso");
            }
        }
        public void ActualizarFamosos(CFamosoBO bo)
        {
            try
            {
                using (SqlConnection Conexion = new SqlConnection(strConexion))
                {
                    SqlCommand OrdenSql = new SqlCommand("stproActualizarFamosos", Conexion);
                    OrdenSql.CommandType = CommandType.StoredProcedure;

                    // Parámetros
                    OrdenSql.Parameters.AddWithValue("@ID", bo.Id);
                    OrdenSql.Parameters.AddWithValue("@nombre", bo.Nombre);
                    OrdenSql.Parameters.AddWithValue("@apellidos", bo.Apellidos);
                    OrdenSql.Parameters.AddWithValue("@cumple", bo.Cumple);
                    OrdenSql.Parameters.AddWithValue("@imagen", bo.Imagen);


                    Conexion.Open();
                    OrdenSql.ExecuteNonQuery();
                }
            }
            catch (SqlException error)
            {
                throw new ApplicationException("Error Update famoso");
            }
        }
    }
}