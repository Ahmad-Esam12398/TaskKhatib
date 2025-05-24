using AutoMapper;
using Repository.Contracts;
using Services.Contracts;
using Shared.DataTransferObjects.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class GenreService : IGenreService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GenreService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GenreDto>> GetAllGenresAsync(bool trackChanges)
        {
            var genresEntities = await _repositoryManager.Genre.GetAllGenresAsync(trackChanges);
            return _mapper.Map<IEnumerable<GenreDto>>(genresEntities);
        }
    }
}
