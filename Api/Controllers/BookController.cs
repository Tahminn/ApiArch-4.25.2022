using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs;
using ServiceLayer.Services;
using ServiceLayer.Services.Interfaces;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;
        public BookController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }


        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] BookCreateDTO book)
        {
            await _service.InsertAsync(book);
            return Ok(book);
        }

        [HttpPut]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] BookEditDTO book)
        {
            await _service.UpdateAsync(id, book);

            return Ok();

        }

        [HttpGet]
        [Route("Search")]
        public async Task<IActionResult> GetByName([FromQuery] string search)
        {
            return Ok(await _service.GetAllByConditionAsync(search));
        }
    }
}
