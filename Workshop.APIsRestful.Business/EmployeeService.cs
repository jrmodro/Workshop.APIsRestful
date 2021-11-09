using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.APIsRestful.Domain.Interfaces;
using Workshop.APIsRestful.Domain.Models;
using Workshop.APIsRestful.Domain.Repositories;

namespace Workshop.APIsRestful.Business
{
    public class EmployeeService : IEmployeeService
    {
        DatabaseRepository<Employee> _repository;

        public EmployeeService(DatabaseRepository<Employee> repository)
        {
            _repository = repository;

        }

        public async Task<List<Employee>> GetAsync()
        {
            var employees = await _repository.GetAsync();
            if (!employees.Any())
            {
                for (int i = 0; i <= 10; i++)
                {
                    await _repository.CreateAsync(new Employee
                    {
                        Id = Guid.NewGuid(),
                        Name = $"Employee {i}",
                        DateOfBirth = DateTime.Now
                    });
                }
            }
            return await _repository.GetAsync();
        }

        public async Task<Employee> GetAsync(Guid id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<Employee> CreateAsync(Employee model)
        {
            return await _repository.CreateAsync(model);
        }

        public async Task UpdateAsync(Guid id, Employee model)
        {
            Employee response = await _repository.GetAsync(id);
            if (response == null)
                throw new ArgumentException("Id não encontrado!");

            model.Id = id;

            await _repository.UpdateAsync(model);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
