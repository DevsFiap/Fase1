using AutoMapper;
using TechChallangeFase01.Application.Dto;
using TechChallangeFase01.Application.Interfaces;
using TechChallangeFase01.Infra.Data.Interfaces;

namespace TechChallangeFase01.Application.Services
{
    public class ContatosService : IContatosService
    {
        private readonly IContatosRepository _contatosRepository;
        private readonly IMapper _mapper;

        public ContatosService(IContatosRepository contatosRepository, IMapper mapper)
        {
            _contatosRepository =  contatosRepository;
            _mapper = mapper;

        }
        public async Task<List<ContatoDto>> GetContatos()
        {
            var contatos = await _contatosRepository.ObterTodos();
            return _mapper.Map<List<ContatoDto>>(contatos);
        }
    }
}
