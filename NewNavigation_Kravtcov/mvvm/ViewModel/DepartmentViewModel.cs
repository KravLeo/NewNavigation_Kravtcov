using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using NewNavigation_Kravtcov.mvvm.Data;
using NewNavigation_Kravtcov.mvvm.Model;
using NewNavigation_Kravtcov.mvvm.Model.FakeDB;

namespace NewNavigation_Kravtcov.mvvm.ViewModel
{
    public class DepartmentViewModel : INotifyPropertyChanged
    {
        //private readonly FakeDB fakedb;
        private readonly DB fakedb;
        private readonly MainViewModel mainViewModel;

        private Department department;
        public Department Department
        {
            get => department;
            set
            {
                department = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public ICommand GoBackCommand { get; } //Команда для возврата на основную страницу

        public DepartmentViewModel(Department departmentG, DB fakeDB /*RealDB contextDB*/, MainViewModel mainVM)
        {
            department = departmentG;
            mainViewModel = mainVM;
            fakedb = fakeDB;


            SaveCommand = new Command(async () => await SaveAsync());
            CancelCommand = new Command(Cancel);
            GoBackCommand = new Command(async () => await GoBackAsync());
        }
        private async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("///MainPage");
        }

        private async Task SaveAsync()
        {
            if (department.Id == 0)
            {
                await fakedb.AddDepartmentAsync(department);
                mainViewModel.Departments.Add(department); // Добавляем новый отдел в коллекцию
            }
            else
            {
                await fakedb.UpdateDepartmentAsync(department);
            }
        }

        private void Cancel()
        {
            Department = new Department
            {
                Id = department.Id,
                Name = department.Name,
                Notice = department.Notice
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
