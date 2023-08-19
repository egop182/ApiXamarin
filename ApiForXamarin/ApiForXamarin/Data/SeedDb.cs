using ApiForXamarin.Enumerations;

namespace ApiForXamarin.Data
{
    public class SeedDb
    {
        private readonly ApiForXamarinContext context;
        private readonly Random random;

        public SeedDb(ApiForXamarinContext context)
        {
            this.context = context;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            if (!this.context.Clients.Any())
            {
                this.AddClient("First Client");
                this.AddClient("Second Client");
                this.AddClient("Third Client");
                await this.context.SaveChangesAsync();
            }

            if (!this.context.UserRoles.Any())
            {
                this.AddUserRole("Administrator", RoleType.SuperAdmin);
                this.AddUserRole("Staff", RoleType.Staff);
                this.AddUserRole("Guest", RoleType.Guest);
                await this.context.SaveChangesAsync();
            }

            if (!this.context.Users.Any())
            {
                this.AddUser("AdminUser", "123", 1);
                this.AddUser("StaffUser", "123", 2);
                this.AddUser("GuestUser", "123", 3);
                await this.context.SaveChangesAsync();
            }

            if (!this.context.Productos.Any())
            {
                this.AddProducto("Cafe Molido Pequeño"   , "250g", "$24.000", 5,"cafe");
                this.AddProducto("Cafe Molido Grande"    , "500g", "$40.000", 5, "cafe");
                this.AddProducto("Miel Abeja Pequeña"    , "290g", "$25.000", 5, "miel");
                this.AddProducto("Miel Abeja Mediana"    , "500g", "$21.000", 5, "miel");
                this.AddProducto("Miel Abeja Grande"     , "635g", "$25.000", 5, "miel");
                this.AddProducto("Polen"                 , "250g", "$15.000", 5, "polen");
                this.AddProducto("Propoleo Miel"         , "250g", "$14.000", 5, "propoleo");
                this.AddProducto("Vela Pequeña"          , "250g", "$6.000" , 5, "vela");
                this.AddProducto("Vela Grande"           , "250g", "$14.000", 5, "vela");
                this.AddProducto("Vela Gota"             , "250g", "$16.000", 5, "vela");
                this.AddProducto("Vela virgen"           , "250g", "$30.000", 5, "vela");
                this.AddProducto("Vela Esfera"           , "250g", "$12.000", 5, "vela");
                this.AddProducto("Torta Naranja Pequeña" , "250g", "$10.000", 5, "tortanaranja");
                this.AddProducto("Torta Naranja Grande"  , "600g", "$17.000", 5, "tortanaranja");
                this.AddProducto("Paquete de Pan"        , "450g", "$7.000", 5, "pan");
                this.AddProducto("Ají Dulce"             , "750g", "$10.000", 5, "aji");
                this.AddProducto("Ají picante"           , "750g", "$10.000", 5, "aji");
                this.AddProducto("Panela"                , "6lb" , "$13.000", 5, "panela");
                this.AddProducto("Panela Pulverizada"    , "4lb" , "$8.000" , 5, "panela");
                await this.context.SaveChangesAsync();
            }
        }
        private void AddClient(string name)
        {
            this.context.Clients.Add(new Models.Client
            {
                Name = name,
                Dna = this.random.Next(1000000, 1999999).ToString()
            });
        }

        private void AddUserRole(string roleName, RoleType roleType)
        {
            this.context.UserRoles.Add(new Models.UserRole
            {
                Name = roleName,
                Type = roleType
            });
        }

        private void AddUser(string userId, string password, long userRoleId)
        {
            this.context.Users.Add(new Models.User
            {
                UserName = userId,
                Password = password,
                RoleId = userRoleId
            });
        }

        private void AddProducto(string nombre, string peso, string valor, long cantidad, string imagen)
        {
            this.context.Productos.Add(new Models.Producto
            {
                Nombre = nombre,
                Peso = peso,
                Precio = valor,
                Cantidad = cantidad,
                Imagen = imagen
            });
        }

    }
}
