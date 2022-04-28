using AutoMapper;
using CP.BLL.DTOs;
using CP.DAL.Models;
using CP.DAL.UnitOfWork;

namespace CP.BLL.Services
{
    /// <summary>
    /// Implements <seealso cref="ICalendarDateService"/>.
    /// </summary>
    public class CalendarDateService : ICalendarDateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CalendarDateService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<CalendarDateDTO>> GetAllAsync()
        {
            //var teams = await _unitOfWork.CalendarDates.FindAllAsync(
            //    nameof(CalendarDate.Employees),
            //    x => x.OrderBy(x => x.Name));
            //return _mapper.Map<IList<CalendarDateDTO>>(teams);
            throw new NotImplementedException();
        }

        public async Task<List<HolidayDTO>> GetAllHolidaysAsync()
        {
            List<CalendarDate> holidays = await _unitOfWork.CalendarDates.GetAllHolidaysAsync();
            return _mapper.Map<List<HolidayDTO>>(holidays);
        }

        public async Task<CalendarDateDTO> GetAsync(int id)
        {
            //var teams = await _unitOfWork.CalendarDates
            //    .FindByAsync(x => x.Id.Equals(id), include: nameof(CalendarDate.Employees));
            //var team = teams.FirstOrDefault();
            //Guard.Against.IsCalendarDateFound(team);
            //return _mapper.Map<CalendarDateDTO>(team);
            throw new NotImplementedException();
        }

        public async Task<CalendarDateDTO> CreateAsync(CalendarDateDTO dto)
        {
            CalendarDate team = _mapper.Map<CalendarDate>(dto);
            await _unitOfWork.CalendarDates.AddAsync(team);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<CalendarDateDTO>(team);
        }

        public async Task UpdateAsync(int id, CalendarDateDTO dto)
        {
            //IList<CalendarDate> teams = await _unitOfWork.CalendarDates.FindByAsync(x => x.Id.Equals(id));
            //CalendarDate teamToUp = teams.FirstOrDefault();
            //Guard.Against.IsCalendarDateFound(teamToUp);
            //teamToUp.Name = dto.Name;
            //_unitOfWork.CalendarDates.Update(teamToUp);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            //IList<CalendarDate> teams = await _unitOfWork.CalendarDates.FindByAsync(x => x.Id.Equals(id));
            //CalendarDate teamFound = teams.FirstOrDefault();
            //Guard.Against.IsCalendarDateFound(teamFound);
            //_unitOfWork.CalendarDates.Remove(teamFound);
            await _unitOfWork.SaveAsync();
        }
    }
}
