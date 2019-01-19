using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using ZPISrokovnik.Utils;

namespace ZPISrokovnik.Views.MainView
{
	public class MainSearchViewModel : BaseViewModel
	{
        #region Constructor
        public MainSearchViewModel (IPageService page)
		{
            SearchCommand = new Command(Search);
            this.pageService = page;
            ListenForSearchText();
		}   
        #endregion

        #region Properties
        private string itemSelected;
        private IPageService pageService;

        private string searchText;
        public string SearchText
        {
            get { return searchText; }
            set
            {
                SetValue(ref searchText, value);
                OnPropertyChanged(nameof(SearchText));
            }
        }

        private string caption = "Zatvor u Zagrebu";
        public string Caption
        {
            get { return caption; }
            set
            {
                caption = value;
                OnPropertyChanged();
            }
        }
        public string ItemSelected
        {
            get { return itemSelected; }
            set {
                if (itemSelected != value) {
                    itemSelected = value;
                    OnPropertyChanged();
                    pageService.PushAsync(new MainDetails());
                }
                }
        }
        #endregion

        #region Commands
        public Command SearchCommand { get; private set; }
        #endregion

        #region Methods
        private void Search()
        {
            pageService.PushAsync(new MainSearch());
        }
        private void ListenForSearchText()
        {
            MessagingCenter.Subscribe<MainViewModel, string>(this, "oibImePrezime", (sender, arg) => {
                SearchText = arg;
            });
        }
        #endregion
    }
}