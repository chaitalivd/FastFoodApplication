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
	public partial class SignupPage : ContentPage
    {
        public UserQuery _UserQuery;
        public UserDB _UserDB;

        public SignupPage()
        {
            InitializeComponent();
            //this.BackgroundImage = "background.png";
            this.Title = "Sign up";
            _UserDB = new UserDB();
            _UserQuery = new UserQuery();
        }
        //var fullname = new Entry { Placeholder = "full name", HorizontalOptions = LayoutOptions.FillAndExpand };
        //var usname = new Entry { Placeholder = "Username" };
        //var pw = new Entry { IsPassword = true, Placeholder = "Password" };
        //var repw = new Entry { IsPassword = true, Placeholder = "Re type Password" };
        //var add = new Entry { Placeholder = "Enter Address" };

        //var signup = new Button { Text = "signup", HorizontalOptions = LayoutOptions.FillAndExpand };

        //signup.Clicked += (object sender, EventArgs e) =>

        public void SignUpInsert(object sender, EventArgs eventArgs)
        {
            try
            {
                if (Entry_Fullname.Text == null || Entry_Username.Text == null || Entry_Password.Text == null || Entry_Confirm_Password.Text == null || Entry_Mobile_Number.Text == null || Entry_Address.Text == null)
                {
                    DisplayAlert("Alert", "Please Fill All the Fields", "OK");
                }
                else
                {
                    if (Entry_Password.Text == Entry_Confirm_Password.Text)
                    {
                        InsertData(Entry_Fullname.Text.ToString(),Entry_Username.Text.ToString(), Entry_Password.Text.ToString(), Entry_Mobile_Number.Text.ToString(), Entry_Address.Text.ToString());
                        DisplayAlert("Alert", "Saved Succesfully.", "OK");
                        Navigation.PushAsync(new LoginPage());
                    }
                    else
                    {
                        DisplayAlert("Alert", "Please check whether the password and the re typed password is correct", "OK");
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                DisplayAlert("Sorry...", "Something went wrong. Try after sometime.", "OK");
                // Navigation.PushAsync(new HomePage());
            }
        }
        public void InsertData(string name, string uname, string password, string mobile, string address)
        {
            _UserDB.Name = name;
            _UserDB.Username = uname;
            _UserDB.Password = password;
            _UserDB.Mobile = mobile;
            _UserDB.Address = address;
            _UserQuery.InsertDetails(_UserDB);
        }
    }
}
