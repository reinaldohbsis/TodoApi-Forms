using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo.API.Models;

namespace TodoApi.Controllers
{
    [Route("api/Pessoas")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly TodoContext _context;

        public PessoasController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/Pessoas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoa>>> GetPessoas()
        {
            return await _context.Pessoas.ToListAsync();
        }

        // GET: api/Pessoas/5
        [HttpGet("{id}")]
        public ActionResult GetPessoa(long id)
        {
            var pessoa = _context.Pessoas.Find(id);

            if (pessoa == null)
            {
                return NotFound();
            }

            var tarefa = new List<Tarefa>();

            foreach (var item in _context.TodoItems.Where(q => q.IdPessoa == pessoa.Id))
                tarefa.Add(item);
            
            return Ok(tarefa);
        }

        // GET: api/Pessoas/Config/5
        // [Route("api/Pessoas/Config")]
        //[HttpGet("{id}")]
        //public ActionResult GetPessoaConfigurar(long id)
        //{
        //    var pessoa = _context.Pessoas.Find(id);
        //    if (pessoa == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(pessoa); 
        //}

        // PUT: api/Pessoas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPessoa(long id, Pessoa pessoa)
        {
            if (id != pessoa.Id)
            {
                return BadRequest();
            }
            
            _context.Entry(pessoa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PessoaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Pessoas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Pessoa>> PostPessoa(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPessoa", new { id = pessoa.Id }, pessoa);
        }

        // DELETE: api/Pessoas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pessoa>> DeletePessoa(long id)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);
            if (pessoa == null)
            {
                return NotFound();
            }

            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync();

            return pessoa;
        }

        private bool PessoaExists(long id)
        {
            return _context.Pessoas.Any(e => e.Id == id);
        }
    }
}
