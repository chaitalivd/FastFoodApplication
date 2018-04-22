using Delicioso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Delicioso.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        string getImage, getName, getPrice;
        int getQuantity;
		public LoginPage()
        {
			InitializeComponent ();
            this.BackgroundImage = "background.jpg";
            this.Title = "Login";
            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => SignInProcedure(s, e);
        }

        public LoginPage(string image, string name, string price, int qty)
        {
            InitializeComponent();
            this.BackgroundImage = "background.jpg";
            this.Title = "Login";
            this.getImage = image;
            this.getName = name;
            this.getPrice = price;
            this.getQuantity = qty;

            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => SignInProcedure(s, e);

        }

        public void SignInProcedure(object sender, EventArgs args)
        {
            UserDB userDB = new UserDB();
            UserQuery userQuery = new UserQuery();

            if (Entry_Username.Text == null || Entry_Password.Text == null)
            {
                Error.Text = "All fields are mandatory";
            }
            else
            {
                userDB = userQuery.GetCustName(Entry_Username.Text);
                if (userDB != null)
                {
                    if (Entry_Password.Text == userDB.Password)
                    {
                        DisplayAlert("Login", "Login Success", "Ok");
                        Application.Current.Properties["USERNAME"] = Entry_Username.Text;
                        NavigateFunc();
                    }
                    else
                    {
                        Error.Text = "Invalid Credentials";
                    }
                }
                else
                {
                    Error.Text = "Please SignUp";
                }
            }
        }

        public void SignUpProcedure(object sender, EventArgs args)
        {
            Navigation.PushAsync(new SignupPage(getImage,getName,getPrice,getQuantity));           
        }

        public void NavigateFunc()
        {
            if(getName == null)
            {
                Navigation.PushAsync(new CartPage());
            }
            else
            {
                var getUsername = Convert.ToString(Application.Current.Properties["USERNAME"]);
                CartDB cartDB = new CartDB();
                string[] exPrice = getPrice.Split('.');
                int total = Convert.ToInt32(exPrice[1]);
                cartDB.Username = getUsername;
                cartDB.Name = getName;
                cartDB.Price = getPrice;
                cartDB.Qty = getQuantity.ToString();
                cartDB.Total = (getQuantity * total).ToString();
                cartDB.Image = getImage;
                CartQuery cartQuery = new CartQuery();
                var i = cartQuery.InsertDetails(cartDB);
                if (i > 0)
                {
                    Navigation.PushAsync(new CartPage());
                }
                else
                {
                    DisplayAlert("Issue", "Something went wrong..", "Ok");
                }
            }       
        }
    }
}