using AutoMapper;
using DomainLayer.Entities;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.DTOs;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<BookDTO>> GetAllAsync()
        {

            return _mapper.Map<List<BookDTO>>(await _repository.GetAllAsync());
        }

        public async Task InsertAsync(BookCreateDTO book)
        {
            await _repository.CreateAsync(_mapper.Map<Book>(book));
        }

        public async Task UpdateAsync(int id, BookEditDTO book)
        {
            var entity = await _repository.GetAsync(id);

            _mapper.Map(book, entity);

            await _repository.UpdateAsync(entity);
        }

        public async Task<BookDTO> GetByNameAsync(string search)
        {
            var model = await _repository.FindAsync(m => m.Name == search);

            return _mapper.Map<BookDTO>(model);

        }

        public async Task<IEnumerable<BookDTO>> GetAllByConditionAsync(string search)
        {
            return _mapper.Map<IEnumerable<BookDTO>>(await _repository.FindAllAsync(m => m.Name.Contains(search)));
        }
    }
}
