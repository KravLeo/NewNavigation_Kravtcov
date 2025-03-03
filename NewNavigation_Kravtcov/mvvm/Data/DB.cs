using Microsoft.EntityFrameworkCore;
using NewNavigation_Kravtcov.mvvm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NewNavigation_Kravtcov.mvvm.Data
{
    public class DB
    {
        private RealDB context;
        public DB(RealDB realDB) 
        {
            context = realDB;
        }

        // Методы для работы с отделами

        //Получение списка отделов
        public async Task<List<Department>> GetDepartmentsAsync()
        {
            return await context.Departments.ToListAsync();
        }

        //Получение отдела по ID
        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            return  await context.Departments.FirstOrDefaultAsync(d => d.Id == id);
        }

        //Добавление отдела
        public async Task AddDepartmentAsync(Department department)
        {
            context.Departments.Add(department);
            await context.SaveChangesAsync();
        }

        //Редактирование отдела
        public async Task UpdateDepartmentAsync(Department department)
        {
            context.Departments.Update(department);
            await context.SaveChangesAsync();
        }

        //Удаление отдела по ID
        public async Task DeleteDepartmentAsync(int id)
        {
            var department = await context.Departments.FindAsync(id);
            if (department != null)
            {
                context.Departments.Remove(department);
                await context.SaveChangesAsync();
            }
        }

        //Методы для работы с сотрудниками

        //Получение списка сотрудников
        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await context.Employees.ToListAsync();
        }

        //Получение сотрудника по ID
        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await context.Employees.FirstOrDefaultAsync(e => e.Id == id); ;
        }

        //Добавление сотрудника
        public async Task AddEmployeeAsync(Employee employee)
        {
            context.Employees.Add(employee);
            await context.SaveChangesAsync();
        }

        //Редактирование сотрудника
        public async Task UpdateEmployeeAsync(Employee employee)
        {
            context.Employees.Update(employee);
            await context.SaveChangesAsync();
        }

        //Удаление сотрудника по ID
        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await context.Employees.FindAsync(id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                await context.SaveChangesAsync();
            }
        }

        // Методы для работы с пользователями

        //Получение списка пользователей
        public async Task<List<User>> GetUsersAsync()
        {
            return await context.Users.ToListAsync();
        }

        //Получение пользователя по ID
        public async Task<bool> Register(User user)
        {
            if (await context.Users.AnyAsync(u => u.Username == user.Username))
            {
                return false; // Пользователь уже существует
            }

            context.Users.Add(user);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Login(string username, string password)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
            return user != null;
        }

        public async Task<bool> LoginAsGuest()
        {
            await Task.Delay(500);
            return true; // Гостевой вход всегда успешен
        }
    }
}
