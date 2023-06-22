//using Microsoft.Analytics.Interfaces;
//using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CapaEntidad;
using CapaAccesoDatos;
namespace CapaLogicaNegocio
{
    public class logCiudad
    {
            #region singleton
            //patron de Diseño Singleton
            private static readonly logCiudad _instancia = new logCiudad();
            public static logCiudad Instancia
            {
                get { return logCiudad._instancia; }
            }
            #endregion singleton

            public List<entCiudad> ListarCiudad()
            {
                return datCiudad.Instancia.ListarCiudad();
            }

            public List<entCiudad> ListarCiudadCliente()
            {
                return datCiudad.Instancia.ListarCiudadCliente();
            }

        public void InsertaCiudad(entCiudad Cli)
            {
                try
                {
                    datCiudad.Instancia.InsertarCiudad(Cli);
                }
                catch (Exception e)
                {
                    throw e;

                }

            }
            public void EditaCiudad(entCiudad Cli)
            {
                try
                {
                    datCiudad.Instancia.EditarCiudad(Cli);
                }
                catch (Exception e)
                {
                    throw e;

                }

            }
            public void DeshabilitaCiudad(int idCiudad)
            {
                try
                {
                    datCiudad.Instancia.DeshabilitaCiudad(idCiudad);
                }
                catch (Exception e)
                {
                    throw e;

                }

            }
    }
}
