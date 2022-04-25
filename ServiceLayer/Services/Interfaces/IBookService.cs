using ServiceLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface IBookService
    {
        Task<List<BookDTO>> GetAllAsync();
        Task InsertAsync(BookCreateDTO book);
        Task UpdateAsync(int id, BookEditDTO book);
        Task<BookDTO> GetByNameAsync(string name);
        Task<IEnumerable<BookDTO>> GetAllByConditionAsync(string search);
    }
}
