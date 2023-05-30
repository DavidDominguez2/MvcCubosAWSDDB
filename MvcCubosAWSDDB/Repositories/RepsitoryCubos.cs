using Microsoft.EntityFrameworkCore;
using MvcCubosAWSDDB.Data;
using MvcCubosAWSDDB.Models;

namespace MvcCubosAWSDDB.Repositories {
    public class RepsitoryCubos {

        private CubosContext context;

        public RepsitoryCubos(CubosContext context) {
            this.context = context;
        }


        public async Task<List<Cubo>> AllCubosAsync() {
            return await this.context.Cubos.ToListAsync();
        }

        public async Task<Cubo> GetCubo(int id) {
            return await this.context.Cubos.FirstOrDefaultAsync(x => x.IdCubo == id);
        }

        public async Task InsertCubo(string nombre, string marca, string imagen, int precio) {
            int newid = await this.context.Cubos.AnyAsync() ? await this.context.Cubos.MaxAsync(x => x.IdCubo) + 1 : 1;
            Cubo cubo = new Cubo {
                IdCubo = newid,
                Marca = marca,
                Imagen = imagen,
                Precio = precio,
                Nombre = nombre
            };
            this.context.Cubos.Add(cubo);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateCuboAsync(int idCubo, string nombre, string marca, string imagen, int precio) {
            Cubo? cubo = await this.GetCubo(idCubo);
            if (cubo != null) {
                cubo.Nombre = nombre;
                cubo.Imagen = imagen;
                cubo.Precio = precio;
                cubo.Marca = marca;
            }
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteCuboAsync(int idCubo) {
            Cubo? cubo = await this.GetCubo(idCubo);
            if (cubo != null) {
                this.context.Cubos.Remove(cubo);
            }
            await this.context.SaveChangesAsync();
        }
    }
}
