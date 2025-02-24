using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using NewNavigation_Kravtcov.mvvm.Model;
using NewNavigation_Kravtcov.mvvm.Model.FakeDB;

namespace NewNavigation_Kravtcov.mvvm.ViewModel
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        private readonly FakeDB fakedb;
        private readonly MainViewModel mainViewModel;

        private Employee employee;
        public Employee Employee
        {
            get => employee;
            set
            {
                employee = value;
                OnPropertyChanged();
            }
        }

        // Свойство для списка отделов
        public ObservableCollection<Department> Departments { get; set; }

        public ICommand SaveCommand { get; }//Команда для сохранения
        public ICommand CancelCommand { get; }//Команда для отмены(неуверен что она работает)
        public ICommand GoBackCommand { get; }//Команда для возврата к основной странице

        public EmployeeViewModel(Employee newEmployee, FakeDB fakeDB, MainViewModel mainVM)
        {
            employee = newEmployee;
            fakedb = fakeDB;
            mainViewModel = mainVM;

            // Инициализация списка отделов
            Departments = mainVM.Departments;
            //Инициализация комманд
            SaveCommand = new Command(async () => await SaveAsync());
            CancelCommand = new Command(Cancel);
            GoBackCommand = new Command(async () => await GoBackAsync());
        }
        //Метод для возврата на основную страницу
        private async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("///MainPage");
        }
        //Метод сохранения
        private async Task SaveAsync()
        {
            if (employee.Id == 0)
            {
                await fakedb.AddEmployeeAsync(employee);
                mainViewModel.Employees.Add(employee); // Добавляем нового сотрудника в коллекцию
            }
            else
            {
                await fakedb.UpdateEmployeeAsync(employee);
            }
        }
        //Метод отмены
        private void Cancel()
        {
            Employee = new Employee
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Position = employee.Position,
                DepartmentId = employee.DepartmentId,
                HireDate = employee.HireDate,
                Salary = employee.Salary
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
