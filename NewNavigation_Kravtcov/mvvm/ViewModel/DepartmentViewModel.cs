using System;
using System.Collections.Generic;
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
    public class DepartmentViewModel : INotifyPropertyChanged
    {
        private readonly FakeDB fakedb;
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

        public ICommand SaveCommand { get; } //Команда для сохранения
        public ICommand CancelCommand { get; } //Команда для отмены
        public ICommand GoBackCommand { get; } //Команда для возврата на основную страницу

        public DepartmentViewModel(Department newdepartment, FakeDB fakeDB, MainViewModel mainVM)
        {
            department = newdepartment;
            fakedb = fakeDB;
            mainViewModel = mainVM;
            //Инициализация команд
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
        //Метод отмены
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
