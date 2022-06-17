using Ardalis.GuardClauses;
using AutoMapper;
using CP.BLL.DTOs;
using CP.BLL.Extensions;
using CP.DAL.Models;
using CP.DAL.UnitOfWork;

namespace CP.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<IList<EmployeeDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IList<EmployeeDTO>> GetAllInTeamAsync(int teamId)
        {
            var employees = await _unitOfWork.Employees.GetAllInTeamAsync(teamId);
            return _mapper.Map<IList<EmployeeDTO>>(employees);
        }

        public async Task<EmployeeDTO> GetAsync(int id)
        {
            var employeesFound = await _unitOfWork.Employees.FindByAsync(emp => emp.Id == id, include: nameof(Employee.Regime));
            var employeeFound = employeesFound.FirstOrDefault();
            Guard.Against.EmployeeNotFound(employeeFound);
            return _mapper.Map<EmployeeDTO>(employeeFound);
        }

        public async Task<EmployeeDTO> CreateAsync(EmployeeDTO dto)
        {
            var employeeToAdd = _mapper.Map<Employee>(dto);
            await _unitOfWork.Employees.AddAsync(employeeToAdd);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<EmployeeDTO>(employeeToAdd);
        }

        public async Task UpdateAsync(int id, EmployeeDTO dto)
        {
            var employeesFound = await _unitOfWork.Employees.FindByAsync(emp => emp.Id == id);
            Employee employeeToUp = employeesFound.FirstOrDefault();
            Guard.Against.EmployeeNotFound(employeeToUp);
            employeeToUp.FirstName = dto.FirstName;
            employeeToUp.LastName = dto.LastName;
            employeeToUp.IsFixedNight = dto.IsFixedNight;
            employeeToUp.RegimeId = dto.RegimeId;
            _unitOfWork.Employees.Update(employeeToUp);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var employeesFound = await _unitOfWork.Employees.FindByAsync(emp => emp.Id == id);
            Employee employeeToDelete = employeesFound.FirstOrDefault();
            Guard.Against.EmployeeNotFound(employeeToDelete);
            _unitOfWork.Employees.Remove(employeeToDelete);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IList<AbsenceDTO>> GetAllAbsencesAsync(int employeeId)
        {
            var employeesFound = await _unitOfWork.Employees
                .FindByAsync(emp => emp.Id == employeeId, include: "Absences.CalendarDate");
            Employee employeeFound = employeesFound.FirstOrDefault();
            Guard.Against.EmployeeNotFound(employeeFound);
            var absences = employeeFound.Absences.ToList();
            IList<AbsenceDTO> absencesDTOs = new List<AbsenceDTO>();
            foreach (var absence in absences)
            {
                AbsenceDTO absenceDTO = new()
                {
                    EmployeeId = absence.EmployeeId,
                    Day = absence.CalendarDate.Date,
                    Type = absence.Type.ToString(),
                };
                absencesDTOs.Add(absenceDTO);
            }
            return absencesDTOs;
        }

        public async Task AddAbsenceAsync(int employeeId, AbsenceDTO absenceDTO)
        {
            IList<CalendarDate> dates = await _unitOfWork.CalendarDates
                .FindByAsync(cd => cd.Date == absenceDTO.Day);

            IList<Absence> absences = await _unitOfWork.Absences
                .FindByAsync(abs => abs.EmployeeId == employeeId && abs.DateId == dates.FirstOrDefault().Id);

            Absence absenceToAddOrUpdate = absences.FirstOrDefault();

            if (absenceToAddOrUpdate is null)
            {
                absenceToAddOrUpdate = new()
                {
                    EmployeeId = employeeId,
                    DateId = dates.FirstOrDefault().Id,
                    Type = (AbsenceType)Enum.Parse(typeof(AbsenceType), absenceDTO.Type)
                };
                await _unitOfWork.Absences.AddAsync(absenceToAddOrUpdate);
            }
            else
            {
                absenceToAddOrUpdate.Type = (AbsenceType)Enum.Parse(typeof(AbsenceType), absenceDTO.Type);
                _unitOfWork.Absences.Update(absenceToAddOrUpdate);
            }

            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAbsenceAsync(int employeeId, DateTime day)
        {
            IList<Absence> absences = await _unitOfWork.Absences
                .FindByAsync(x => x.EmployeeId.Equals(employeeId) && x.CalendarDate.Date == day);
            Absence absence = absences.FirstOrDefault();
            Guard.Against.AbsenceNotFound(absence);
            _unitOfWork.Absences.Remove(absence);
            await _unitOfWork.SaveAsync();
        }
    }
}
