using EscolaDeV.Context;
using EscolaDeV.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EscolaDeV.Services
{
    public interface ICursoService
    {
        public Task<Curso> Create(Curso curso);
        public Task<Curso> GetById(int id);
        public Task<List<Curso>> GetAll();
        public Task Update(Curso cursoIn, int id);
        public Task Delete(int id);
    }

    public class CursoService : ICursoService
    {
        private readonly DataContext _context;
        public CursoService(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<Curso> Create(Curso curso)
        {
            _context.Cursos.Add(curso);
            await _context.SaveChangesAsync();
            return curso;
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
            var curso = _context.Cursos.FirstOrDefault(x => x.Id == id);
            _context.Cursos.Remove(curso);
            await _context.SaveChangesAsync();
        }

        [HttpGet]
        public async Task<List<Curso>> GetAll()
        {
            var curso = await _context.Cursos
                .AsNoTracking()
                .ToListAsync();
            return curso;
        }

        [HttpGet("{id}")]
        public async Task<Curso> GetById(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);            
            return curso;
        }

        [HttpPut]
        public async Task Update(Curso cursoIn, int id)
        {          
            _context.Update(cursoIn);
            await _context.SaveChangesAsync();                         
        }
    }
}
