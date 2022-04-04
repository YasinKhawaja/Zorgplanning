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
            var employeeFound = await this.FindByAsync(id);
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
            var employeeFound = await this.FindByAsync(id);
            Guard.Against.EmployeeNotFound(employeeFound);
            var employeeToUp = _mapper.Map<Employee>(dto);
            _unitOfWork.Employees.Update(employeeToUp);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var employeeFound = await this.FindByAsync(id);
            Guard.Against.EmployeeNotFound(employeeFound);
            _unitOfWork.Employees.Remove(employeeFound);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IList<AbsenceDTO>> GetAllAbsencesAsync(int employeeId)
        {
            var employeeFound = await this.FindByAsync(employeeId, include: nameof(Employee.Absences));
            Guard.Against.EmployeeNotFound(employeeFound);
            var absences = employeeFound.Absences.ToList();
            return _mapper.Map<IList<Absence>, IList<AbsenceDTO>>(absences);
        }

        public async Task AddAbsenceAsync(int employeeId, AbsenceDTO absenceDTO)
        {
            IList<Employee> employeesFound = await _unitOfWork.Employees
                .FindByAsync(x => x.Id.Equals(employeeId), asTracking: true, include: nameof(Employee.Absences));
            Employee employeeTracked = employeesFound.FirstOrDefault();
            Guard.Against.EmployeeNotFound(employeeTracked);
            // Add absence
            Absence absenceToAdd = _mapper.Map<AbsenceDTO, Absence>(absenceDTO);
            List<Absence> absences = employeeTracked.Absences.ToList();
            absences.Add(absenceToAdd);
            employeeTracked.Absences = absences;
            //
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAbsenceAsync(int employeeId, DateTime day)
        {
            IList<Absence> absences = await _unitOfWork.Absences
                .FindByAsync(x => x.EmployeeId.Equals(employeeId) && x.DateId.Equals(day));
            Absence absence = absences.FirstOrDefault();
            Guard.Against.AbsenceNotFound(absence);
            _unitOfWork.Absences.Remove(absence);
            await _unitOfWork.SaveAsync();
        }

        #region PRIVATE METHODS
        private async Task<Employee> FindByAsync(int id, bool asTracking = false, string include = "")
        {
            var employeesFound = await _unitOfWork.Employees
            .FindByAsync(x => x.Id.Equals(id), asTracking, include: include);
            return employeesFound.FirstOrDefault();
        }
        #endregion
    }
}
