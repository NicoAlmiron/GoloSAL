using GoloSAL.Models;
using System.Data;
using Microsoft.Data.SqlClient;

namespace GoloSAL.Datos
{
    public class ClienteDatos
    {
        public List<ClienteModel> Listar()
        {
            var oLista = new List<ClienteModel>();

            Conexion cn = new Conexion();

            using (SqlConnection conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        oLista.Add(new ClienteModel() 
                        { 
                            ClienteID = Convert.ToInt32( dr["ClienteID"]),
                            Nombre = dr["Nombre"].ToString(),
                            Direccion = dr["Direccion"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                        });
                    }
                }
            }
            return oLista;
        }

        public ClienteModel obtener(int clienteID)
        {
            var oCliente = new ClienteModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("ClienteID", clienteID);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        oCliente.ClienteID = Convert.ToInt32(dr["ClienteID"]);
                        oCliente.Nombre = dr["Nombre"].ToString();
                        oCliente.Direccion = dr["Direccion"].ToString();
                        oCliente.Telefono = dr["Telefono"].ToString();
                    }
                }
            }
            return oCliente;
        }

        public bool Guardar(ClienteModel ocliente)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("Nombre", ocliente.Nombre);
                    cmd.Parameters.AddWithValue("Direccion", ocliente.Direccion);
                    cmd.Parameters.AddWithValue("telefono", ocliente.Telefono);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e) 
            {
                string error = e.Message;
                rpta=false;
            }
            return rpta;
        }

        public bool Editar(ClienteModel oCliente)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("ClienteID", oCliente.ClienteID);
                    cmd.Parameters.AddWithValue("Nombre", oCliente.Nombre);
                    cmd.Parameters.AddWithValue("Direccion", oCliente.Direccion);
                    cmd.Parameters.AddWithValue("Telefono", oCliente.Telefono);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }

        public bool Eliminar(int clienteID)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("ClienteID", clienteID);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }

    }
}
