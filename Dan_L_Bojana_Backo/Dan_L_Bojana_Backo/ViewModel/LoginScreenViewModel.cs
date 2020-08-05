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

        public LoginScreenViewModel(LoginScreen loginScreenOpen)
        {
            loginScreen = loginScreenOpen;
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
                
                if (UserName.Equals("Zaposleni") && password.Equals("Zaposleni"))
                {
                    MainWindow employeeView = new MainWindow();
                    loginScreen.Close();
                    employeeView.Show();
                }
                else
                {
                    MessageBox.Show("Wrong usename or password");
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
