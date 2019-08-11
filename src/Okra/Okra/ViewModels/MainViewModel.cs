using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Okra.Models;
using Okra.Services;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace Okra.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IRecipeService recipeService;

        public MainViewModel(
            INavigationService navigationService
             , IRecipeService recipeService)
            : base(navigationService)
        {
            this.recipeService = recipeService;
            AddCommand = new DelegateCommand(async () => await AddExecute())
                .ObservesCanExecute(() => IsNotBusy);
        }

        private ObservableCollection<Recipe> recipes = new ObservableCollection<Recipe>();
        public ObservableCollection<Recipe> Recipes
        {
            get => recipes;
            set => SetProperty(ref recipes, value);
        }

        public ICommand AddCommand { get; }

        private async Task AddExecute()
        {
            await ExecuteBusyAction(async () =>
            {
                var pictures = new List<Picture>
                {
                    Picture.Create("https://s3.amazonaws.com/finecooking.s3.tauntonclud.com/app/uploads/2017/04/18124843/Lee-Okra-Corn-Tomatoes-main.jpg")
                    , Picture.Create("http://www.thedefineddish.com/wp-content/uploads/2018/06/IMG_7163.jpg")
                    , Picture.Create("http://www.thedefineddish.com/wp-content/uploads/2018/06/IMG_7153.jpg")
                };

                var author = Author.Create("Erick Jacquin",
                    Picture.Create("http://www.aloalobahia.com/images/p/Erick%20Jacquin_alo_alo_bahia.jpg"));

                var recipe = Recipe.Create("Fried okra"
                    , @"Fried okra is a classic for a good reason. A light cornmeal coating on the pods and a quick dunk in hot oil make fried okra crispy, a wee bit crunchy, and completely delicious. Some people like to chop the okra first, creating bite-size snacks almost like popcorn. To keep slime at an absolute minimum, leave the pods whole. This has an added bonus of requiring less work. This recipe works either way. Enjoy the fried okra as is, with a squirt of lemon juice, or with your favorite dipping sauce."
                    , pictures
                    , author);

                await recipeService.Add(recipe);

                await LoadRecipes();
            });
        }

        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            await ExecuteBusyAction(async () =>
            {
                await LoadRecipes();
            });
        }

        private async Task LoadRecipes()
        {
            var collection = await recipeService.All();
            Recipes = new ObservableCollection<Recipe>(collection);
        }
    }
}
