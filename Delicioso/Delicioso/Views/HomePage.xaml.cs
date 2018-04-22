﻿using Delicioso.Interface;
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
	public partial class HomePage : ContentPage
	{
        string spUserName = null;
        public HomePage()
        {
            InitializeComponent();
            this.BackgroundImage = "background.jpg";
            this.Title = "Delicioso";

            if (Application.Current.Properties.ContainsKey("USERNAME"))
            {
                spUserName = Convert.ToString(Application.Current.Properties["USERNAME"]);
            }
            else
            {
                spUserName = "As Guest";
                Application.Current.Properties["USERNAME"] = spUserName;
            }


            var images = new List<string>
            {
                "cv_pic1.png",
                "cv_pic2.jpg",
                "cv_pic3.jpg"
            };
            MainCarouselView.ItemsSource = images;

            var menuheads = new List<MenuHead>
            {
                new MenuHead
                {
                    Image = "mh_sandwich.jpg",
                    Name = "Sandwich"
                },
                new MenuHead
                {
                    Image = "mh_juice.jpg",
                    Name = "Fresh Juice"
                },
            };
            MenuHeadListView.ItemsSource = menuheads;
        }

        public void MenuHead_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var menu = e.Item as MenuHead;
            Navigation.PushAsync(new SubMenuPage(menu.Name));
        }

        protected override bool OnBackButtonPressed()
        {
           var closer = DependencyService.Get<ICloseApplication>();
           closer?.closeApplication();
            return false;
        }

        private void OnCartClick(object sender, EventArgs e)
        {
            if (Application.Current.Properties.ContainsKey("USERNAME"))
            {
                var getUserName = Convert.ToString(Application.Current.Properties["USERNAME"]);
                if (getUserName.Equals("As Guest"))
                {
                    Navigation.PushAsync(new LoginPage());
                }
                else
                {
                    Navigation.PushAsync(new CartPage());
                }

            }
        }
        private void OnSignoutClick(object sender, EventArgs e)
        {
            Application.Current.Properties["USERNAME"] = "As Guest";
        }
    }
}