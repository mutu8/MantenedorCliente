using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaAccesoDatos;

namespace CapaLogicaNegocio
{
    
    public class logCliente
    {
        #region singleton
        //patron de Diseño Singleton
        private static readonly logCliente _instancia = new logCliente();
        public static logCliente Instancia
        {
            get { return logCliente._instancia; }
        }
        #endregion singleton

        public List<entCliente> ListarCliente()
        {
            return datCliente.Instancia.ListarCliente();
        }
        
        public void InsertaCliente(entCliente Cli)
        {
            try 
            {
                datCliente.Instancia.InsertarCliente(Cli);
            }
        catch(Exception e )
            { throw e;  
            
            }

        }
        public void EditaCliente(entCliente Cli)
        {
            try
            {
                datCliente.Instancia.EditarCliente(Cli);
            }
            catch (Exception e)
            {
                throw e;

            }

        }
        public void DeshabilitaCliente(int idCliente)
        {
            try
            {
                datCliente.Instancia.DeshabilitaCliente(idCliente);
            }
            catch (Exception e)
            {
                throw e;

            }

        }

        public entCliente BuscarClientePorId(int idCliente)
        {
            return datCliente.Instancia.BuscarClientePorId(idCliente);
        }

    }
}
