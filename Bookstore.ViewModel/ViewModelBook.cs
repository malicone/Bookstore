using Bookstore.Model.Models;
using Bookstore.ViewModel.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.ViewModel
{
    public class ViewModelBook : ViewModelEntityDetails<BOOK>
    {
        public ViewModelBook() : base()
        {
            Publishers = new ObservableCollection<PUBLISHER>();
            Languages = new ObservableCollection<LANGUAGE>();
            Groups = new ObservableCollection<GROUP>();
            Shops = new ObservableCollection<SHOP>();
            Cities = new ObservableCollection<CITY>();
        }
        public ObservableCollection<PUBLISHER> Publishers { get; set; }
        public ObservableCollection<LANGUAGE> Languages { get; set; }
        public ObservableCollection<GROUP> Groups { get; set; }
        public ObservableCollection<SHOP> Shops { get; set; }
        public ObservableCollection<CITY> Cities { get; set; }

        protected override void LoadDataToCacheCommon(IDbTransaction transaction = null) 
        {
            _publishers = RepoFactory.GetRepoInstance<PUBLISHER>().GetAllOrderBy("NAME", transaction);
            _languages = RepoFactory.GetRepoInstance<LANGUAGE>().GetAllOrderBy("NAME", transaction);
            _groups = RepoFactory.GetRepoInstance<GROUP>().GetAllOrderBy("NAME", transaction);
            _shops = RepoFactory.GetRepoInstance<SHOP>().GetAllOrderBy("NAME", transaction);
            _cities = RepoFactory.GetRepoInstance<CITY>().GetAllOrderBy("NAME", transaction);
        }

        protected override void LoadDataToCacheForNewEntity(IDbTransaction transaction = null) 
        {            
            Entity.PUBLISHER_ID = Model.EntityBase.SYSTEM_RECORD_ID;
            Entity.LANGUAGE_ID = Model.EntityBase.SYSTEM_RECORD_ID;
            Entity.GROUP_ID = Model.EntityBase.SYSTEM_RECORD_ID;
            Entity.SHOP_ID = Model.EntityBase.SYSTEM_RECORD_ID;
            Entity.CITY_ID = Model.EntityBase.SYSTEM_RECORD_ID;
        }

        protected override void CopyCacheToViewModel()
        {
            Publishers.AddRange(_publishers);            
            Languages.AddRange(_languages);
            Groups.AddRange(_groups);
            Shops.AddRange(_shops);
            Cities.AddRange(_cities);
        }

        private IEnumerable<PUBLISHER> _publishers;
        private IEnumerable<LANGUAGE> _languages;
        private IEnumerable<GROUP> _groups;
        private IEnumerable<SHOP> _shops;
        private IEnumerable<CITY> _cities;
    }
}
