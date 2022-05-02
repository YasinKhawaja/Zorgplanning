﻿using CP.BLL.DTOs;

namespace CP.BLL.Services
{
    /// <summary>
    /// Manages dates.
    /// </summary>
    public interface ICalendarDateService : IService<CalendarDateDTO>
    {
        Task<List<HolidayDTO>> GetAllHolidaysAsync();
    }
}