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

        public async Task<IList<EmployeeDTO>> GetAllInTeamAsync(int teamKey)
        {
            var employees = await _unitOfWork.Employees.GetAllInTeamAsync(teamKey);
            return _mapper.Map<IList<EmployeeDTO>>(employees);
        }

        public async Task<EmployeeDTO> GetAsync(int key)
        {
            var employeeFound = await this.FindByAsync(key);
            Guard.Against.EmployeeNotFound(key, employeeFound);
            return _mapper.Map<EmployeeDTO>(employeeFound);
        }

        public async Task<EmployeeDTO> CreateAsync(EmployeeDTO dto)
        {
            var employeeToAdd = _mapper.Map<Employee>(dto);
            await _unitOfWork.Employees.AddAsync(employeeToAdd);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<EmployeeDTO>(employeeToAdd);
        }

        public async Task UpdateAsync(int key, EmployeeDTO dto)
        {
            var employeeFound = await this.FindByAsync(key);
            Guard.Against.EmployeeNotFound(key, employeeFound);
            var employeeToUp = _mapper.Map<Employee>(dto);
            _unitOfWork.Employees.Update(employeeToUp);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int key)
        {
            var employeeFound = await this.FindByAsync(key);
            Guard.Against.EmployeeNotFound(key, employeeFound);
            _unitOfWork.Employees.Remove(employeeFound);
            await _unitOfWork.SaveAsync();
        }

        #region PRIVATE METHODS
        private async Task<Employee> FindByAsync(int key)
        {
            var employeesFound = await _unitOfWork.Employees.FindByAsync(x => x.Id.Equals(key));
            return employeesFound.FirstOrDefault();
        }
        #endregion
    }
}
