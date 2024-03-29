using CleanArch.Application.Common;
using CleanArch.Application.Dtos;

namespace CleanArch.Application.Abstractions
{
    public interface IFuncionarioService
    {
        Task<Result<IEnumerable<FuncionarioDto>>> GetFuncionarios();
        Task<Result<FuncionarioDto>> GetById(Guid id);
        Task<Result<bool>> Create(CreateFuncionarioDto funcionario);
        Task<Result<bool>> Update(UpdateFuncionarioDto funcionario);
        Task<Result<bool>> Remove(Guid id);
    }
}
