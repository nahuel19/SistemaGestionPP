using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.UFP
{
    /// <summary>
    /// enum para los tipos de permisos, valores iguales que las patentes en la BD
    /// </summary>
    public enum TipoPermiso
    {
        Bitácora,
        CategoriaEditar,
        CategoriaEliminar,
        CategoriaInsertar,
        CategoriaVer,
        ClienteEditar,
        ClienteEliminar,
        ClienteInsertar,
        ClienteVer,
        ComprasAnular,
        ComprasInsertar,
        ComprasVer,
        Presupuesto,
        ProductoEditar,
        ProductoEliminar,
        ProductoInsertar,
        ProductoVer,
        ProveedorEditar,
        ProveedorEliminar,
        ProveedorInsertar,
        ProveedorVer,
        UsuariosEditar,
        UsuariosEliminar,
        UsuariosInsertar,
        UsuariosVer,
        VentasAnular,
        VentasInsertar,
        VentasVer,
        CategoriaAjustarPrecio,
        Perfiles,
        Permisos,
        ProductoAjustarPrecio,
        ProductoAjustarStock
    }
}
