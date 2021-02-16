using DAL.DigitosVerificadores;
using DAL.Model;
using Entities.EntidadesDigitoVerificador;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DigitosVerificadores
{
    public class DigitosVerificadoresVFacade
    {
        DigitosVerificadoresDAL dvDAL;
        DigitosVerificadoresVGenericos metodosDV;

        public DigitosVerificadoresVFacade()
        {
            dvDAL = new DigitosVerificadoresDAL();
            metodosDV = new DigitosVerificadoresVGenericos();
        }

        private void CargarDVVproducto()
        {
            List<Producto> productos = dvDAL.ListProductosDV();
            metodosDV.CargarDVV(productos);
        }

        private EntityDVVcorrupto VerificarDVVproducto()
        {
            List<Producto> productos = dvDAL.ListProductosDV();
            EntityDVVcorrupto check = new EntityDVVcorrupto();
            check.tabla = typeof(Producto).Name;
            check.status = metodosDV.VerificarDVV(productos) == true ? ConstantesTexto.OK : ConstantesTexto.Corrupto;

            return check;
        }

        public void CargarDVV()
        {
            CargarDVVproducto();
        }

        public void VerificarDVV()
        {
            List<EntityDVVcorrupto> listaVerificacion = new List<EntityDVVcorrupto>();
            listaVerificacion.Add(VerificarDVVproducto());

            foreach(var e in listaVerificacion)
            {
                if(e.status == ConstantesTexto.Corrupto)
                    throw new Services.Excepciones.SistemaCorruptoDVVException(listaVerificacion);
            }
        }

    }
}
