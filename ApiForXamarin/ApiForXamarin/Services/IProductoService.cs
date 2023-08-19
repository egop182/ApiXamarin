using ApiForXamarin.Data.Models;

namespace ApiForXamarin.Services
{
    public interface IProductoService
    {
        Task<Producto>? GetProductoAsync(string nomproducto);
    }
}
