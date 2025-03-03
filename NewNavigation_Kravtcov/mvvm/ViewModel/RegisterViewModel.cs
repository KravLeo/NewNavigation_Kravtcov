using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using NewNavigation_Kravtcov.mvvm.Model.FakeDB;
using NewNavigation_Kravtcov.mvvm.Model;
using NewNavigation_Kravtcov.mvvm.Data;

namespace NewNavigation_Kravtcov.mvvm.ViewModel
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        private readonly DB userDB;

        public ICommand RegisterCommand { get; }
        public ICommand GoBackCommand { get; }

        public RegisterViewModel(DB userdb)
        {
            userDB = userdb;
            RegisterCommand = new Command(async () => await Register());
            GoBackCommand = new Command(async () => await Shell.Current.GoToAsync("///LoginPage"));
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

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        // Метод для регистрации пользователя
        private async Task Register()
        {
            var user = new User { Username = Username, Password = Password, Name = Name };
            if (await userDB.Register(user))
            {
                await Shell.Current.GoToAsync("//LoginPage");
            }
            else
            {
                await Shell.Current.DisplayAlert("Ошибка", "Пользователь уже существует", "OK");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
