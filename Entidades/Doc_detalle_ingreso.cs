﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Doc_detalle_ingreso : EntityBase
    {
        public override int Id { get; set; }
        public int Fk_id_doc_cabecera_ingreso { get; set; }
        public int Fk_id_producto { get; set; }
        public int Cantidad { get; set; }
        public double Costo { get; set; }
    }
}
