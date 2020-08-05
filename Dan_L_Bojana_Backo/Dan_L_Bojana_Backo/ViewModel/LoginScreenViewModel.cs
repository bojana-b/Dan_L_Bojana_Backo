using Dan_L_Bojana_Backo.Command;
using Dan_L_Bojana_Backo.View;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Dan_L_Bojana_Backo.ViewModel
{
    class LoginScreenViewModel : ViewModelBase
    {
        LoginScreen loginScreen;
        PasswordValidation passwordValidation;
        Service service;

        public LoginScreenViewModel(LoginScreen loginScreenOpen)
        {
            loginScreen = loginScreenOpen;

            passwordValidation = new PasswordValidation();
            user = new tblUser();
            service = new Service();
        }

        private tblUser user;
        public tblUser User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        private string userName;
        public string UserName
        {

            get
            {
                return userName;
            }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        public string Error
        {
            get { return null; }
        }

        public string this[string someProperty]
        {
            get
            {

                return string.Empty;
            }
        }

        private ICommand submit;
        public ICommand Submit
        {
            get
            {
                if (submit == null)
                {
                    submit = new RelayCommand(SubmitCommandExecute,
                        param => CanSubmitCommandExecute());
                }
                return submit;
            }
        }

        private void SubmitCommandExecute(object obj)
        {
            try
            {
                string password = (obj as PasswordBox).Password;
                
                if (!string.IsNullOrEmpty(UserName) && passwordValidation.PasswordOk(password))
                {
                    var hash = SecurePasswordHasher.Hash(password);
                    User.Username = UserName;
                    User.Password = hash;
                    service.AddUser(User);

                    MainWindow employeeView = new MainWindow();
                    loginScreen.Close();
                    employeeView.Show();
                }
                else
                {
                    MessageBox.Show("Wrong usename or password! You must have at least 6 characters with 2 uppercase letters! ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanSubmitCommandExecute()
        {
            return true;
        }
    }
}
