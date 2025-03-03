using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using NewNavigation_Kravtcov.mvvm.Data;
using NewNavigation_Kravtcov.mvvm.Model.FakeDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;


namespace NewNavigation_Kravtcov.mvvm.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly DB userDB;

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }
        public ICommand GuestLoginCommand { get; }

        public LoginViewModel(DB db)
        {
            userDB = db;
            LoginCommand = new Command(async () => await Login());
            RegisterCommand = new Command(async () => await Shell.Current.GoToAsync("///RegisterPage"));
            GuestLoginCommand = new Command(async () => await LoginAsGuest());
        }

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        // Метод для входа пользователя
        private async Task Login()
        {
            if (await userDB.Login(Username, Password))
            {
                await Shell.Current.GoToAsync("//MainPage");
            }
            else
            {
                await Shell.Current.DisplayAlert("Ошибка", "Неверный логин или пароль", "OK");
            }
        }

        // Метод для входа как гость
        private async Task LoginAsGuest()
        {
            await Shell.Current.GoToAsync("//MainPage");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
