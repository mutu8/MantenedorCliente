using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaAccesoDatos
{
    public class datCliente
    {
        //patron de Diseño Singleton
        private static readonly datCliente _instancia = new datCliente();
        public static datCliente Instancia
        {
            get { return datCliente._instancia; }
        }

        //Listado
        public List<entCliente> ListarCliente()
        {
            SqlCommand cmd = null;
            List<entCliente> lista = new List<entCliente>();
            try {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListaCliente",cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entCliente Cli = new entCliente();
                    Cli.idCliente = Convert.ToInt32(dr["idCliente"]);
                    Cli.razonSocial = dr["razonSocial"].ToString();
                    Cli.idTipoCliente = Convert.ToInt32(dr["idTipoCliente"]);
                    Cli.fecRegCliente = Convert.ToDateTime(dr["fecRegCliente"]);
                    Cli.ciudadCliente = dr["ciudadCliente"].ToString();
                    Cli.clienteRUC = dr["clienteRUC"].ToString();
                    Cli.estCliente = Convert.ToBoolean(dr["estCliente"]);
                    lista.Add(Cli);
                }
            } 
            catch ( Exception e) {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return lista;

        }
     
     //Insertar

        public Boolean InsertarCliente(entCliente Cli)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertaCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@razonSocial", Cli.razonSocial);
                cmd.Parameters.AddWithValue("@idTipoCliente", Cli.idTipoCliente);
                cmd.Parameters.AddWithValue("@fecRegCliente", Cli.fecRegCliente);
                cmd.Parameters.AddWithValue("@ciudadCliente", Cli.ciudadCliente);
                cmd.Parameters.AddWithValue("@clienteRUC", Cli.clienteRUC);
                cmd.Parameters.AddWithValue("@estCliente", Cli.estCliente);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    inserta = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return inserta;
        }

        //Editar
        public Boolean EditarCliente(entCliente Cli)
        {
            SqlCommand cmd = null;
            Boolean edita = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEditaCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCliente", Cli.idCliente);
                cmd.Parameters.AddWithValue("@razonSocial", Cli.razonSocial);
                cmd.Parameters.AddWithValue("@idTipoCliente", Cli.idTipoCliente);
                cmd.Parameters.AddWithValue("@fecRegCliente", Cli.fecRegCliente);
                cmd.Parameters.AddWithValue("@ciudadCliente", Cli.ciudadCliente);
                cmd.Parameters.AddWithValue("@clienteRUC", Cli.clienteRUC);
                cmd.Parameters.AddWithValue("@estCliente", Cli.estCliente);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    edita = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return edita;
        }


        //Eliminar
        public Boolean DeshabilitaCliente(int idCliente)
        {
            SqlCommand cmd = null;
            Boolean elimina = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spDeshabilitaCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCliente", idCliente);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    elimina = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return elimina;
        }

        // Búsqueda de cliente por ID
        public entCliente BuscarClientePorId(int idCliente)
        {
            SqlCommand cmd = null;
            entCliente cliente = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spBuscarIdCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCliente", idCliente);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    cliente = new entCliente();
                    cliente.idCliente = Convert.ToInt32(dr["idCliente"]);
                    cliente.razonSocial = dr["razonSocial"].ToString();
                    cliente.idTipoCliente = Convert.ToInt32(dr["idTipoCliente"]);
                    cliente.fecRegCliente = Convert.ToDateTime(dr["fecRegCliente"]);
                    cliente.ciudadCliente = dr["ciudadCliente"].ToString();
                    cliente.clienteRUC = dr["clienteRUC"].ToString();
                    cliente.estCliente = Convert.ToBoolean(dr["estCliente"]);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return cliente;
        }



    }
}
