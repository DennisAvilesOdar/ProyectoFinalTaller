using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Interfaz
{
    public abstract class TipoPagoDAO : ServiceProvider
    {
        public abstract List<TipoPagoDTO> GetListado();
        public abstract TipoPagoDTO GetTipoPagoId(int id);
        public abstract void SetTipoPago(string nombre);
        public abstract void UpdateTipoPago(int id, string nombre);
        public abstract void DeleteTipoPagoId(int id);
    }
}
