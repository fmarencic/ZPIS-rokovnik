using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using ZPISrokovnik.Utils;
using ZpisRokovnikService.DataLayer;

namespace ZPISrokovnik.Views.MainView
{
	public class MainSearchViewModel : BaseViewModel
	{
        #region Constructor
        public MainSearchViewModel (IPageService page, string search)
		{
            SearchCommand = new Command(Search);
            this.pageService = page;
            ForwardedSearch = search;
            InspectAndShowData();
        }   
        #endregion

        #region Properties
        private string itemSelected;
        private IPageService pageService;

        private string forwardedSearch;
        public string ForwardedSearch
        {
            get { return forwardedSearch; }
            set
            {
                SetValue(ref forwardedSearch, value);
                OnPropertyChanged(nameof(ForwardedSearch));
            }
        }
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

        private ObservableCollection<OsobaDTO> osobe;
        public ObservableCollection<OsobaDTO> Osobe
        {
            get { return osobe; }
            set
            {
                SetValue(ref osobe, value);
                OnPropertyChanged(nameof(Osobe));
            }
        }
        #endregion

        #region Commands
        public Command SearchCommand { get; private set; }
        #endregion

        #region Methods
        private void Search()
        {
            pageService.PushAsync(new MainSearch(SearchText));
        }
        private void InspectAndShowData()
        {
            if (Regex.IsMatch(ForwardedSearch, @"^\d+$")) {
                OsobaDTO osoba = App.client.PretraziPoOIBu(ForwardedSearch, "");
                OsobaDTOToObject(osoba);
            }
            else
            {
                string[] parsedName = ForwardedSearch.Split(' ');
                string firstName = parsedName[0];
                string lastName = parsedName[1];
                OsobaDTO[] osoba = App.client.PretraziPoImenuIPrezimenu(firstName, lastName, "");
                OsobaDTOToList(osoba);
            }
        }
        private void OsobaDTOToObject(OsobaDTO obj)
        {
            if(obj != null)
            {
                Osobe = new ObservableCollection<OsobaDTO>();
                Osobe.Add(obj);
            }
        }
        private void OsobaDTOToList(OsobaDTO[] obj)
        {
            if(obj != null)
            {
                Osobe = new ObservableCollection<OsobaDTO>();
                for(int i = 0; i < obj.Length; i++)
                {
                    Osobe.Add(obj[i]);
                }
            }
        }
        #endregion
    }
}