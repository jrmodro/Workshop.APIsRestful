using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Workshop.APIsRestful.Domain.Interfaces;
using Workshop.APIsRestful.Domain.Models;
using Workshop.APIsRestful.Domain.Repositories;

namespace Workshop.APIsRestful.Business
{
    public class AppointmentService : IAppointmentService
    {
        DatabaseRepository<Appointment> _repository;
        DatabaseRepository<Employee> _employeeRepository;

        public AppointmentService(DatabaseRepository<Appointment> repository, DatabaseRepository<Employee> employeeRepository)
        {
            _repository = repository;
            _employeeRepository = employeeRepository;
        }

        public async Task<List<Appointment>> GetAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task<Appointment> GetAsync(Guid id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<Appointment> CreateAsync(Appointment model)
        {
            return await _repository.CreateAsync(model);
        }

        public async Task<Appointment> CreateAsync(Guid employeeId)
        {
            Employee response = await _employeeRepository.GetAsync(employeeId);
            if (response == null)
                throw new ArgumentException("Id do funcionário não encontrado.");

            Appointment model= new Appointment() {
                EmployeeId = employeeId,
                Employee = response
            };

            return await _repository.CreateAsync(model);
        }

        public async Task Update(Guid id, Appointment model)
        {
            model.Id = id;

            await _repository.UpdateAsync(model);
        }

        public async Task Delete(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
