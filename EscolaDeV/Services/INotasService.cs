using EscolaDeV.Context;
using EscolaDeV.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EscolaDeV.Services
{
    public interface INotasService
    {
        public Task<Notas> Create(Notas notas);
        public Task<Notas> GetById(int id);
        public Task<List<Notas>> GetAll();
        public Task Update(Notas notasIn, int id);
        public Task Delete(int id);
    }

    public class NotasService : INotasService
    {
        private readonly DataContext _context;
        public NotasService(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<Notas> Create(Notas notas)
        {
            _context.Notas.Add(notas);
            await _context.SaveChangesAsync();
            return notas;
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
            var notas = _context.Notas.FirstOrDefault(x => x.Id == id);
            _context.Remove(notas);
            await _context.SaveChangesAsync();
        }

        [HttpGet]
        public async Task<List<Notas>> GetAll()
        {
          var notas = await _context.Notas.AsNoTracking()
                                          .ToListAsync();
            return notas;
        }

        [HttpGet]
        public async Task<Notas> GetById(int id)
        {
            var notas = await _context.Notas.FindAsync(id);
            return notas;
        }

        [HttpPut]
        public async Task Update(Notas notasIn, int id)
        {
            if (notasIn.Id != id)
            {
                throw new Exception("O Id é diferente");
            }
            else
            {
                _context.Notas.Update(notasIn);
                await _context.SaveChangesAsync();
            }
        }
    }
}
