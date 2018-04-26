using Delicioso.Model;
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
    public partial class SignupPage : ContentPage
    {
        public UserDB userDB;
        public UserQuery userQuery;
        string getImage, getName, getPrice;
        int getQuantity;

        public SignupPage(string image, string name, string price, int qty)
        {
            InitializeComponent();
            this.BackgroundImage = "background.jpg";
            this.Title = "SignUp";
            this.getImage = image;
            this.getName = name;
            this.getPrice = price;
            this.getQuantity = qty;
            userDB = new UserDB();
            userQuery = new UserQuery();
            Entry_Fullname.Completed += (s, e) => Entry_Username.Focus();
            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => Entry_Confirm_Password.Focus();
            Entry_Confirm_Password.Completed += (s, e) => Entry_Mobile_Number.Focus();
            Entry_Mobile_Number.Completed += (s, e) => Entry_Address.Focus();
            Entry_Address.Completed += (s, e) => SignUpInsert(s, e);
        }

        public void SignUpInsert(object sender, EventArgs eventArgs)
        {
            if (Entry_Fullname.Text == null || Entry_Username.Text == null || Entry_Password.Text == null || Entry_Confirm_Password.Text == null || Entry_Mobile_Number.Text == null || Entry_Address.Text == null)
            {
                Error.Text = "All fields are mandatory";
            }
            else
            {
                if (Entry_Password.Text == Entry_Confirm_Password.Text)
                {
                    var rec = InsertData(Entry_Fullname.Text, Entry_Username.Text, Entry_Password.Text, Entry_Mobile_Number.Text, Entry_Address.Text);
                    if(rec == -1)
                    {
                        DisplayAlert("SignUp", "You are a registered user", "Ok");
                        NavigateFunc();
                    }
                    else
                    {
                        DisplayAlert("SignUp", "Success", "Ok");
                        NavigateFunc();
                    }                  
                }
                else
                {
                    Error.Text = "Please check whether the password and the confirm password is correct";
                }
            }
        }

        public int InsertData(string name, string uname, string password, string mobile, string address)
        {
            userDB.Name = name;
            userDB.Username = uname;
            userDB.Password = password;
            userDB.Mobile = mobile;
            userDB.Address = address;
            var res = userQuery.InsertDetails(userDB);
            return res;

        }
        public void NavigateFunc()
        {
            Navigation.PushAsync(new LoginPage(getImage, getName, getPrice, getQuantity));
        }
    }
}