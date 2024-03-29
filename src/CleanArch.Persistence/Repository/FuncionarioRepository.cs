using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Persistence.Repository
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly FuncionarioDbContext _db;
        public FuncionarioRepository(FuncionarioDbContext context)
        {
            _db = context;
        }
        public async Task Create(Funcionario funcionario)
        {
            _db.Add(funcionario);
            await _db.SaveChangesAsync();
        }

        public async Task Update(Funcionario funcionario)
        {
            _db.Entry(funcionario).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task<Funcionario> GetById(Guid id)
        {
            return await _db.Funcionarios.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<Funcionario>> GetFuncionarios()
        {
            return await _db.Funcionarios.AsNoTracking().ToListAsync();
        }

        public async Task Remove(Funcionario funcionario)
        {
            _db.Funcionarios.Remove(funcionario);
            await _db.SaveChangesAsync();
        }

    }
}
