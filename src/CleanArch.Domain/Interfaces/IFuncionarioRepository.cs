﻿using CleanArch.Domain.Entities;
using System.Runtime.InteropServices;

namespace CleanArch.Domain.Interfaces
{
    public interface IFuncionarioRepository
    {
        Task<IEnumerable<Funcionario>> GetFuncionarios();
        Task<Funcionario> GetById(Guid id);
        Task Create(Funcionario funcionario);
        Task Update(Funcionario funcionario);
        Task Remove(Funcionario funcionario);
    }
}
