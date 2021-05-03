using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using DotNetLibrary.Entities;

namespace DotNetLibrary.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class BooksControler : Controller
    {
        private readonly ILogger<BooksControler> _logger;
        private LiberyDbContex _context;

        public BooksControler(ILogger<BooksControler> logger,object hello, LiberyDbContex dbcontext,
                              List<object> books)
        {
            _logger = logger;
            _context = dbcontext;
            dbcontext.Database.EnsureCreated();
            logger.LogDebug("Hello", hello);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var _todos = _context.Books.ToList<object>();

            _logger.LogInformation("GET");
            Console.WriteLine(_todos);

            return Ok(_todos);
        }

        [HttpPost]
        public IActionResult Post([FromBody] BookItem input)
        {
            // id
            // { "Comprar pan", "Hacer pagos", "..."  }
            //        0             1        n

            _context.Books.Add(input);

            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = input.ID }, input);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // System.Linq
            BookItem found = _context.Books.Find(id);

            if (found == null)
            {
                return NotFound();
            }
            return Ok(found);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var found = _context.Books.Find(id);

            if (found != null)
            {
                _context.Books.Remove(found); // _todos[id] = null;
                _context.SaveChanges();

                return Ok();
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] object input)
        {
            return Ok();
        }
    }
}
