using System.Collections.Generic;

namespace OnlineStore.Models
{
    public class PaginationResponse<T>
    {
        public IEnumerable<T> ListaObjetos { get; set; }

        public int CantPorPag { get; set; }

        public int ItemsTotal { get; set; }
    }
}
