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
using NewNavigation_Kravtcov.mvvm.Data;

namespace NewNavigation_Kravtcov.mvvm.ViewModel
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        //private readonly FakeDB fakedb;
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

        public ICommand SaveCommand { get; }//Команда для сохранения
        public ICommand CancelCommand { get; }//Команда для отмены(неуверен что она работает)
        public ICommand GoBackCommand { get; }//Команда для возврата к основной странице

    public ICommand OnSaveCommand { get; }
        public EmployeeViewModel(Employee employeeG, FakeDB fakeDB /*RealDB contextDB*/, MainViewModel mainVM)
        {
            employee = employeeG;
            fakedb = fakeDB;
            mainViewModel = mainVM;

            SaveCommand = new Command(async () => await SaveAsync());
            CancelCommand = new Command(Cancel);
            GoBackCommand = new Command(async () => await GoBackAsync());
            OnSaveCommand = new Command(async () => await OnSave());
        }

        private async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("///MainPage");
        }
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
            await Shell.Current.GoToAsync("///MainPage");
        }

        private async Task OnSave()
        {
            if (Employee != null)
            {
                await fakedb.UpdateEmployeeAsync(Employee);
            }
        }

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
