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
    /// Facade para realizar proceso de verificaión y carga de DVH
    /// </summary>
    public class DigitosVerificadoresHFacade
    {
        DigitosVerificadoresDAL dvDAL;
        DigitosVerificadoresHGenericos metodosDV;

        /// <summary>
        /// Constructor, inicializa instancias
        /// </summary>
        public DigitosVerificadoresHFacade()
        {
            dvDAL = new DigitosVerificadoresDAL();
            metodosDV = new DigitosVerificadoresHGenericos();
        }

        /// <summary>
        /// Verifica DVH de la tabla de Producto
        /// </summary>
        /// <returns>EntityDVHcorrupto</returns>
        private EntityDVHcorrupto VerificarDVHproducto()
        {
            EntityDVHcorrupto resultado = new EntityDVHcorrupto();
            resultado.tabla = ConstantesTexto.Producto;
            resultado.filas = new List<int?>();

            List<Producto> listProdDV = dvDAL.ListProductosDV();

            if (listProdDV.Count != 0)
            {
                foreach (var p in listProdDV)
                {
                    int? res = metodosDV.VerificarEntityConDVH(p);

                    if (res != null)
                        resultado.filas.Add((int)res);                        
                }
            }

            if (resultado.filas.Any())
                resultado.status = ConstantesTexto.Corrupto;
            else
                resultado.status = ConstantesTexto.OK;

            return resultado;      
        }

        /// <summary>
        /// Calcula y carga DVH en tabla Producto
        /// </summary>
        private void CargarDVHproducto()
        {            
            List<Producto> listProdDV = dvDAL.ListProductosDV();
            if(listProdDV.Count != 0)
            {
                foreach (var p in listProdDV)
                {
                    Producto prod = metodosDV.CargarEntityConDVH(p);
                    metodosDV.UpdateDVH(prod, typeof(Producto).Name);
                }
            }            
        }

        /// <summary>
        /// Carga los dígitos verificadores horizontales de las tablas que los contengan
        /// </summary>
        public void CargarDVHalCerrar()
        {
            CargarDVHproducto();
        }

        /// <summary>
        /// Verifica los DVH de las tablas que los contengan
        /// </summary>
        public void VerificarDVH()
        {
            List<EntityDVHcorrupto> entityDVHcorruptos = new List<EntityDVHcorrupto>();

            entityDVHcorruptos.Add(VerificarDVHproducto());
            
            foreach(var item in entityDVHcorruptos)
            {
                if(item.status == ConstantesTexto.Corrupto)
                    throw new Services.Excepciones.SistemaCorruptoDVHException(entityDVHcorruptos);
            }

            
        }

    }

    
}
