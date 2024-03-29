﻿using CP.BLL.DTOs;

namespace CP.BLL.Services
{
    /// <summary>
    /// Manages dates.
    /// </summary>
    public interface ICalendarDateService
    {
        Task<List<HolidayDTO>> GetAllHolidaysAsync();
        Task AddHolidayAsync(HolidayDTO holidayDTO);
        Task RemoveHolidayAsync(DateTime date);
    }
}
