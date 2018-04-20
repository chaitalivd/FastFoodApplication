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
	public partial class SubMenuPage : ContentPage
	{
        string menuTitle;

        public SubMenuPage(string menu)
        {
            InitializeComponent();
            //NavigationPage.SetHasBackButton(this, false);
            this.menuTitle = menu;
            this.Title = menuTitle;
            this.BackgroundImage = "background.jpg";

            if (menuTitle.Equals("Sandwich"))
            {
                var menusub = new List<MenuSubList>
                {
                    new MenuSubList
                    {
                        Image = "pimento_cheese_sandwiches.jpg",
                        Name = "Pimento cheese sandwich",
                        Description = "They look dainty, but these finger sandwiches have a serious bite from sharp Cheddar cheese, cayenne pepper, and horseradish.",
                        Price = "Rs.35"
                    },
                    new MenuSubList
                    {
                        Image = "veggie_focaccia.jpg",
                        Name = "Veggie Focaccia",
                        Description = "This no-cook veggie focaccia works well as both an appetizer or a light lunch sandwich.",
                        Price = "Rs.35"
                    },
                };
                MenuSubListView.ItemsSource = menusub;
            }
            else if(menuTitle.Equals("Fresh Juice"))
            {
                var menusub = new List<MenuSubList>
                {
                    new MenuSubList
                    {
                        Image = "watermelon_and_mint_juice.jpg",
                        Name = "Watermelon and Mint Juice",
                        Description = "A refreshing way to beat the heat. Throw in some watermelon pieces along with ginger, lemon, orange juice and lots of ice!",
                        Price = "Rs.25"
                    },
                    new MenuSubList
                    {
                        Image = "very_berry_khatta.jpg",
                        Name = "Very Berry Khatta",
                        Description = "Enjoy the tangy notes of mulberries, lime, orange, grape juice and kala khatta in this tantalising beverage.",
                        Price = "Rs.25"
                    },
                };
                MenuSubListView.ItemsSource = menusub;
            }
        }

        public async void MenuSub_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var menu = e.Item as MenuSubList;
            await Navigation.PushAsync(new DetailPage(menu.Image, menu.Name, menu.Description, menu.Price));
            //await DisplayAlert("Menu Tapped", "Menu: " + menu.Name, "Ok");
        }


    }
}