using MercadoLocal.API.Models;
using MercadoLocal.API.Repositories.Interfaces;
using MercadoLocal.API.Services.Interfaces;

namespace MercadoLocal.API.Services.Implementations
{
    public class ProductorService : IProductorService
    {
        private readonly IProductorRepository _productorRepository;
        public ProductorService(IProductorRepository productorRepository)
        {
            _productorRepository = productorRepository;
        }
        public async Task<IEnumerable<Productor>> GetAllAsync()
        {
            return await _productorRepository.GetAllAsync();
        }
        public async Task<Productor?> GetByIdAsync(int id)
        {
            return await _productorRepository.GetByIdAsync(id);
        }
        public async Task<Productor> CreateAsync(Productor productor)
        {
            await _productorRepository.AddAsync(productor);
            return productor;
        }
        public async Task<Productor> UpdateAsync(Productor productor)
        {
            var existing = await _productorRepository.GetByIdAsync(productor.ProductorID);
            if (existing == null) return productor;
            existing.NombreNegocio = productor.NombreNegocio;
            existing.Descripcion = productor.Descripcion;
            existing.Ubicacion = productor.Ubicacion;
            await _productorRepository.UpdateAsync(existing);
            return existing;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            await _productorRepository.DeleteAsync(id);
            return true;
        }
    }
}
