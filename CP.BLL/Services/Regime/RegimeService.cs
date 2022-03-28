using Ardalis.GuardClauses;
using AutoMapper;
using CP.BLL.DTOs;
using CP.BLL.Extensions;
using CP.DAL.UnitOfWork;

namespace CP.BLL.Services
{
    /// <summary>
    /// Implements <seealso cref="IRegimeService"/>.
    /// </summary>
    public class RegimeService : IRegimeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RegimeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<RegimeDTO>> GetAllAsync()
        {
            var regimes = await _unitOfWork.Regimes.FindAllAsync(orderBy: x => x.OrderBy(x => x.Name));
            return _mapper.Map<IList<RegimeDTO>>(regimes);
        }

        public async Task<RegimeDTO> GetAsync(int id)
        {
            var regimes = await _unitOfWork.Regimes.FindByAsync(x => x.Id.Equals(id));
            var regime = regimes.FirstOrDefault();
            Guard.Against.RegimeNotFound(regime);
            return _mapper.Map<RegimeDTO>(regime);
        }

        public Task<RegimeDTO> CreateAsync(RegimeDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int key, RegimeDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int key)
        {
            throw new NotImplementedException();
        }
    }
}
