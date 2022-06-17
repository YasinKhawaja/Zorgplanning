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

        public async Task AddHolidayAsync(HolidayDTO holidayDTO)
        {
            IList<CalendarDate> dates = await _unitOfWork.CalendarDates.FindByAsync(x => x.Date == holidayDTO.Date.Value);
            CalendarDate holiday = dates.FirstOrDefault();
            holiday.HolidayName = holidayDTO.Name;
            _unitOfWork.CalendarDates.Update(holiday);
            await _unitOfWork.SaveAsync();
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
