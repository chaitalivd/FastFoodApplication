using FastFoodApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FastFoodApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public UserQuery _UserQuery;
        public UserDB _UserDB;

        public LoginPage()
        {
            InitializeComponent();
            //this.BackgroundImage = "background.png";
            this.Title = "Login";
            ActivitySpinner.IsVisible = false;
        }

        //var username = new Entry { Placeholder = "Username" };
        //var password = new Entry { IsPassword = true, Placeholder = "Password" };
        //var login = new Button { Text = "Login" };
        //var lbl_signup = new Label { Text = "Not a Member? Click the button and sign up now!" };
        //var signup = new Button { Text = "Sign up" };

        //signup.Clicked += (object sender, EventArgs e) =>
        public void SignUpProcedure(object sender, EventArgs eventArgs)
        {
            Navigation.PushAsync(new SignupPage());
        }

        //login.Clicked += (object sender, EventArgs e) =>
        public void SignInProcedure(object sender, EventArgs eventArgs)
        {
            UserDB _UserDB = new UserDB();
            UserQuery _UserQuery = new UserQuery();
            UserDB c = _UserQuery.GetCustName(Entry_Username.Text);
            if (c != null)
            {
                if (Entry_Password.Text == c.Password)
                {
                    DisplayAlert("Alert", "login succesful", "OK");
                    Navigation.PushAsync(new Views.PaymentPage());
                }
                else
                {
                    DisplayAlert("Alert", "login failed", "OK");
                }
            }
        }

        new void DisplayAlert(string v1, string v2, string v3)
        {
            throw new NotImplementedException();
        }
    }
}
