using EscolaDeV.Context;
using EscolaDeV.Models;
using Microsoft.EntityFrameworkCore;

namespace EscolaDeV.Services
{
    public interface IUserService
    {
        public Task<User> Create(User user);
        public Task<User> GetById(int id);
        public Task<List<User>> GetAll();
        public Task Update(User userIn, int id);
        public Task Delete(int id);
    }

    public class UserService : IUserService
    {
        private readonly DataContext _context;
        public UserService(DataContext context)
        {
            _context = context;
        }
        public async Task<User> Create(User user)
        {
            User userDb = await _context.Usuarios
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.NomeUsuario == user.NomeUsuario);

            if(userDb is not null)
            {
                throw new Exception("Usuário " + user.NomeUsuario + " já existe");
            }

            _context.Usuarios.Add(user);
           await _context.SaveChangesAsync();
            return user;
        }

        public async Task Delete(int id)
        {
            User userDb = await _context.Usuarios
                .SingleOrDefaultAsync(x => x.Id == id);

            if(userDb == null)
            {
                throw new Exception("Usuário " + id + " não encotrado");
            }
            _context.Usuarios.Remove(userDb);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            User userDb = await _context.Usuarios
                .SingleOrDefaultAsync(x => x.Id == id);

            if (userDb == null)
            {
                throw new Exception("Usuário" + id + " não encotrado");
            }
            return userDb;
        }

        public async Task Update(User userIn, int id)
        {
            if(userIn.Id != id)
            {
                throw new Exception("A rota do ID é diferente do ID do usuário");
            }

            User userDb = await _context.Usuarios
                .AsNoTracking()
               .SingleOrDefaultAsync(x => x.Id == id);

            if (userDb == null)
            {
                throw new Exception("Usuário" + id + " não encotrado");
            }
            _context.Entry(userIn).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
