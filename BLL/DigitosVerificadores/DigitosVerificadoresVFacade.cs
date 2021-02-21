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
    /// <summary>
    /// Clase facade que maneja los DVV
    /// </summary>
    public class DigitosVerificadoresVFacade
    {
        DigitosVerificadoresDAL dvDAL;
        DigitosVerificadoresVGenericos metodosDV;

        /// <summary>
        /// Contructor, inicia instancias
        /// </summary>
        public DigitosVerificadoresVFacade()
        {
            dvDAL = new DigitosVerificadoresDAL();
            metodosDV = new DigitosVerificadoresVGenericos();
        }

        /// <summary>
        /// Carga DVV de productos en BD
        /// </summary>
        private void CargarDVVproducto()
        {
            List<Producto> productos = dvDAL.ListProductosDV();
            metodosDV.CargarDVV(productos);
        }

        /// <summary>
        /// Verifica los DVV de producto, calculados en tiempo de ejecución, comparandolos con los gurdados
        /// </summary>
        /// <returns>EntityDVVcorrupto</returns>
        private EntityDVVcorrupto VerificarDVVproducto()
        {
            List<Producto> productos = dvDAL.ListProductosDV();
            EntityDVVcorrupto check = new EntityDVVcorrupto();
            check.tabla = typeof(Producto).Name;
            check.status = metodosDV.VerificarDVV(productos) == true ? ConstantesTexto.OK : ConstantesTexto.Corrupto;

            return check;
        }

        /// <summary>
        /// Carga los DVV de las entidades establecidas
        /// </summary>
        public void CargarDVV()
        {
            CargarDVVproducto();
        }

        /// <summary>
        /// Verifica los DVV de las entidades establecidas, comparando los calculados en tiempo de ejecución con los almacenados
        /// </summary>
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
