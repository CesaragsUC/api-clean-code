using AutoMapper;
using CleanArch.Application.Abstractions;
using CleanArch.Application.Common;
using CleanArch.Application.Dtos;
using CleanArch.Application.Validator;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Services
{
    public class FuncionarioServices : IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IMapper _mapper;

        public FuncionarioServices(IFuncionarioRepository funcionarioRepository, IMapper mapper)
        {
            _funcionarioRepository = funcionarioRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<FuncionarioDto>>> GetFuncionarios()
        {
            try
            {
                var funcionarios = await _funcionarioRepository.GetFuncionarios();

                var funcionarioDtos = _mapper.Map<IEnumerable<FuncionarioDto>>(funcionarios);

                if (funcionarioDtos is null)
                    return Result<IEnumerable<FuncionarioDto>>.Failure("Nenhum funcionário encontrado");


                return await Result<IEnumerable<FuncionarioDto>>.SuccessAsync(funcionarioDtos);
            }
            catch (Exception)
            {

                return await Result<IEnumerable<FuncionarioDto>>.FailureAsync(500, "Falha no serviço.");
            }

        }

        public async Task<Result<FuncionarioDto>> GetById(Guid id)
        {
            try
            {
                var entity = await _funcionarioRepository.GetById(id);


                var dto = _mapper.Map<FuncionarioDto>(entity);
                if (dto is null)
                {
                    //return Result<FuncionarioDto>.Failure("Funcionário não encontrado");
                    throw new Exception("Funcionário não encontrado");  
                }
                  

                return await Result<FuncionarioDto>.SuccessAsync(dto);
            }
            catch (Exception)
            {
                //return await Result<FuncionarioDto>.FailureAsync(500, "falha no serviço.");
                throw new Exception("Funcionário não encontrado");
            }


        }

        public async Task<Result<bool>> Create(CreateFuncionarioDto funcionarioDto)
        {
            try
            {
                var validor = new CreateFuncionarioValidator();
                var result = validor.Validate(funcionarioDto);

                if (!result.IsValid)
                    return Result<bool>.Failure("Erro ao criar funcionário");

                var funcionario = _mapper.Map<Funcionario>(funcionarioDto);
                await _funcionarioRepository.Create(funcionario);

                return await Result<bool>.SuccessAsync(default, "Cadastrado com sucesso.");
            }
            catch (Exception)
            {
                return await Result<bool>.FailureAsync(500, "Falha ao cadastrar, falha no serviço.");
            }

        }

        public async Task<Result<bool>> Update(UpdateFuncionarioDto funcionarioDto)
        {
            try
            {
                var validor = new UpdateFuncionarioValidator();
                var result = validor.Validate(funcionarioDto);

                if (!result.IsValid)
                    return Result<bool>.Failure("Erro ao atualizar funcionário");


                var funcionario = _mapper.Map<Funcionario>(funcionarioDto);
                await _funcionarioRepository.Update(funcionario);

                return await Result<bool>.SuccessAsync(default, "Atualizado com sucesso.");
            }
            catch (Exception)
            {

                return await Result<bool>.FailureAsync(500, "Falha ao atualizar, falha no serviço.");
            }

        }

        public async Task<Result<bool>> Remove(Guid id)
        {
            try
            {
                var funcionario = await _funcionarioRepository.GetById(id);
                if (funcionario == null)
                    return Result<bool>.Failure("Funcionário não encontrado");


                await _funcionarioRepository.Remove(funcionario);

                return await Result<bool>.SuccessAsync("Removido com sucesso.");
            }
            catch (Exception)
            {
                return await Result<bool>.FailureAsync(500, "Falha no serviço.");
            }

        }

 
    }
}
