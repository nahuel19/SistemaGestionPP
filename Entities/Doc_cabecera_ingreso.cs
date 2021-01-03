﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Entidad Documento Cabecera Ingreso
    /// </summary>
    public class Doc_cabecera_ingreso : IEntityBase
    {
        public int id { get; set; }
        public int fk_id_tipo_doc { get; set; }
        public int fk_id_proveedor { get; set; }
        public string letra { get; set; }
        public int sucursal { get; set; }
        public int numero { get; set; }
        public System.DateTime fecha { get; set; }
    }
}
