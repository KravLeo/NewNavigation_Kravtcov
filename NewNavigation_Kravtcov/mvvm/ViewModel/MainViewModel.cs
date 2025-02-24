using NewNavigation_Kravtcov.mvvm.Model.FakeDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NewNavigation_Kravtcov.mvvm.Model;
using System.Windows.Input;
using NewNavigation_Kravtcov.mvvm.View;

namespace NewNavigation_Kravtcov.mvvm.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public readonly FakeDB fakeDB;
        public ObservableCollection<Department> Departments { get; set; }
        public ObservableCollection<Employee> Employees { get; set; }

        public ICommand NavigateToDepartmentsCommand { get; }//Команда для перехода к странице отделов
        public ICommand NavigateToEmployeesCommand { get; } //Команда для перехода к странице сотрудников
        public ICommand DeleteDepartmentCommand { get; } // Команда для удаления отдела
        public ICommand DeleteEmployeeCommand { get; } // Команда для удаления сотрудника

        public MainViewModel(FakeDB fakedb)
        {
            fakeDB = fakedb;
            Departments = new ObservableCollection<Department>();
            Employees = new ObservableCollection<Employee>();
            //Инициализация команд для навигации
            NavigateToDepartmentsCommand = new Command(async () => await NavigateToDepartmentsAsync());
            NavigateToEmployeesCommand = new Command(async () => await NavigateToEmployeesAsync());

            // Инициализация команд удаления
            DeleteDepartmentCommand = new Command<Department>(async (department) => await DeleteDepartmentAsync(department));
            DeleteEmployeeCommand = new Command<Employee>(async (employee) => await DeleteEmployeeAsync(employee));

            LoadDataAsync();
        }
        //Методы навигации
        private async Task NavigateToDepartmentsAsync()
        {
            var department = new Department();
            var viewModel = new DepartmentViewModel(department, fakeDB, this);
            var depPage = new DepPage(viewModel);
            await Shell.Current.Navigation.PushAsync(depPage);
        }

        private async Task NavigateToEmployeesAsync()
        {
            var employee = new Employee();
            var viewModel = new EmployeeViewModel(employee, fakeDB, this);
            var emplPage = new EmplPage(viewModel);
            await Shell.Current.Navigation.PushAsync(emplPage);
        }

        // Метод для удаления отдела
        private async Task DeleteDepartmentAsync(Department department)
        {
            //await fakeDB.DeleteDepartmentAsync(department.Id); 
           Departments.Remove(department);
        }

        // Метод для удаления сотрудника
        private async Task DeleteEmployeeAsync(Employee employee)
        {
           //await fakeDB.DeleteEmployeeAsync(employee.Id);
           Employees.Remove(employee);
        }

        //Загрузка всех отделов и сотрудников
        private async Task LoadDataAsync()
        {
            var departments = await fakeDB.GetDepartmentsAsync();
            var employees = await fakeDB.GetEmployeesAsync();

            Departments.Clear();
            Employees.Clear();

            foreach (var department in departments)
            {
                Departments.Add(department);
            }

            foreach (var employee in employees)
            {
                Employees.Add(employee);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
