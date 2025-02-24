using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewNavigation_Kravtcov.mvvm.Model.FakeDB
{
    public class FakeDB
    {
        private List<Department> newdepartments = new List<Department>();
        private List<Employee> newemployees = new List<Employee>();

        //Методы для отделов

        //Получение
        public async Task<List<Department>> GetDepartmentsAsync()
        {
            await Task.Delay(100);
            return newdepartments;
        }
        //Получение по ID
        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            await Task.Delay(100);
            return newdepartments.FirstOrDefault(d => d.Id == id);
        }
        //Добавление
        public async Task AddDepartmentAsync(Department department)
        {
            department.Id = newdepartments.Any() ? newdepartments.Max(d => d.Id) + 1 : 1;
            newdepartments.Add(department);
            await Task.CompletedTask;
        }
        //Обновление
        public async Task UpdateDepartmentAsync(Department department)
        {
            var exDep = newdepartments.FirstOrDefault(d => d.Id == department.Id);
            if (exDep != null)
            {
                exDep.Name = department.Name;
                exDep.Notice = department.Notice;
            }
            await Task.CompletedTask;
        }
        //Удаление
        public async Task DeleteDepartmentAsync(int id)
        {
            var department = newdepartments.FirstOrDefault(d => d.Id == id);
            if (department != null)
            {
                newdepartments.Remove(department);
            }
            await Task.CompletedTask;
        }
        //Методы для сотрудников
        //Получение
        public async Task<List<Employee>> GetEmployeesAsync()
        {
            await Task.Delay(100);
            return newemployees;
        }
        //Получение по ID
        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            await Task.Delay(100);
            return newemployees.FirstOrDefault(d => d.Id == id);
        }
        //Добавление
        public async Task AddEmployeeAsync(Employee employee)
        {
            employee.Id = newdepartments.Any() ? newdepartments.Max(e => e.Id) + 1 : 1;
            newemployees.Add(employee);
            await Task.CompletedTask;
        }
        //Обновление
        public async Task UpdateEmployeeAsync(Employee employee)
        {
            var exEmpl = newemployees.FirstOrDefault(e => e.Id == employee.Id);
            if (exEmpl != null)
            {
                exEmpl.FirstName = employee.FirstName;
                exEmpl.LastName = employee.LastName;
                exEmpl.Position = employee.Position;
                exEmpl.DepartmentId = employee.DepartmentId;
                exEmpl.HireDate = employee.HireDate;
                exEmpl.Salary = employee.Salary;
            }
            await Task.CompletedTask;
        }
        //Удаление
        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = newemployees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                newemployees.Remove(employee);
            }
            await Task.CompletedTask;
        }
    }
}
