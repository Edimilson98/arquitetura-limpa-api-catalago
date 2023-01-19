using AutoMapper;
using Catalago.Application.DTOs;
using Catalago.Application.Interfaces;
using Catalago.Domain.Entities;
using Catalago.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalago.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private ICategoriaRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoriaService(ICategoriaRepository categoriaRepository,
            IMapper mapper)
        {
            _categoryRepository = categoriaRepository;
            _mapper = mapper;
        }


        public async Task Add(CategoriaDTO categoryDto)
        {
            var categoryEntity = _mapper.Map<Categoria>(categoryDto);
            await _categoryRepository.CreateAsync(categoryEntity);
        }

        public async Task<CategoriaDTO> GetById(int? id)
        {
            var categoryEntity = await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoriaDTO>(categoryEntity);
        }

        public async Task<IEnumerable<CategoriaDTO>> GetCategorias()
        {
            var categoriesEntity = await _categoryRepository.GetCategoriasAsync();
            return _mapper.Map<IEnumerable<CategoriaDTO>>(categoriesEntity);
        }

        public async Task Remove(int? id)
        {
            var categoryEntity = _categoryRepository.GetByIdAsync(id).Result;
            await _categoryRepository.RemoveAsync(categoryEntity);
        }

        public async Task Update(CategoriaDTO categoriaDto)
        {
            var categoryEntity = _mapper.Map<Categoria>(categoriaDto);
            await _categoryRepository.UpdateAsync(categoryEntity);
        }
    }
}
