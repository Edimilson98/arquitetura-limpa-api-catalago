using Catalago.Domain.Entities;
using Catalago.Domain.Interfaces;
using Catalago.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalago.Infrastructure.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private AppDbContext _categoryContext;

        public CategoriaRepository(AppDbContext context)
        {
            _categoryContext = context;
        }

        public async Task<Categoria> CreateAsync(Categoria category)
        {
            _categoryContext.Add(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }

        public async Task<Categoria> GetByIdAsync(int? id)
        {
            return await _categoryContext.Categorias.FindAsync(id);
        }

        public async Task<IEnumerable<Categoria>> GetCategoriasAsync()
        {
            return await _categoryContext.Categorias.ToListAsync();
        }

        public async Task<Categoria> RemoveAsync(Categoria category)
        {
            _categoryContext.Remove(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }

        public async Task<Categoria> UpdateAsync(Categoria category)
        {
            _categoryContext.Update(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }
    }
}
