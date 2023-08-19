using ApiForXamarin.Data;
using ApiForXamarin.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiForXamarin.Services
{
    public class ProductoService : IProductoService
    {
        private readonly ApiForXamarinContext _context;

        public ProductoService(ApiForXamarinContext context)
        {
            _context = context;
        }
        public async Task<Producto>? GetProductoAsync(string nomproducto)
        {
            if (_context.Productos == null)
            {
                return null;
            }
            var producto = await _context.Productos.FirstOrDefaultAsync(producto => producto.Nombre == nomproducto);

            return producto;
        }
    }
}
