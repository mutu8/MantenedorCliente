﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entCliente
    {
        public int idCliente { get; set; }
        public string  razonSocial { get; set; }
        public int idTipoCliente { get; set; }
        public DateTime fecRegCliente { get; set; }
        public string ciudadCliente { get; set; }
        public Boolean estCliente { get; set; }

        public string clienteRUC { get; set; }
    }
}
