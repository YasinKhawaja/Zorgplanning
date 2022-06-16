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

        public async Task<List<HolidayDTO>> GetAllHolidaysAsync()
        {
            List<CalendarDate> holidays = await _unitOfWork.CalendarDates.GetAllHolidaysAsync();
            return _mapper.Map<List<HolidayDTO>>(holidays);
        }

        public Task<CalendarDateDTO> GetAsync(int id)
        {
            //var teams = await _unitOfWork.CalendarDates
            //    .FindByAsync(x => x.Id.Equals(id), include: nameof(CalendarDate.Employees));
            //var team = teams.FirstOrDefault();
            //Guard.Against.IsCalendarDateFound(team);
            //return _mapper.Map<CalendarDateDTO>(team);
            throw new NotImplementedException();
        }

        public async Task AddHolidayAsync(HolidayDTO holidayDTO)
        {
            IList<CalendarDate> dates = await _unitOfWork.CalendarDates.FindByAsync(x => x.Date == holidayDTO.Date.Value);
            CalendarDate holiday = dates.FirstOrDefault();
            holiday.HolidayName = holidayDTO.Name;
            _unitOfWork.CalendarDates.Update(holiday);
            await _unitOfWork.SaveAsync();
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

        public Task<IList<CalendarDateDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CalendarDateDTO> CreateAsync(CalendarDateDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveHolidayAsync(DateTime date)
        {
            IList<CalendarDate> dates = await _unitOfWork.CalendarDates.FindByAsync(x => x.Date == date);
            CalendarDate holiday = dates.FirstOrDefault();
            holiday.HolidayName = null;
            _unitOfWork.CalendarDates.Update(holiday);
            await _unitOfWork.SaveAsync();
        }
    }
}
