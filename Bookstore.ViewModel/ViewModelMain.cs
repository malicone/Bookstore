using Bookstore.Model.Models;
using Bookstore.Model.Models.Extended;
using Bookstore.Model.Repo.Interface;
using Bookstore.ViewModel.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.ViewModel
{
    public class ViewModelMain : ViewModelBase
    {
        public ObservableCollection<BookEx> Books { get; set; }
        public ViewModelMain() : base()
        {
            _repoBOOK = RepoFactory.GetRepoBOOK();
            Books = new ObservableCollection<BookEx>();
            _books = new List<BookEx>();
        }
        protected override void LoadDataToCache()
        {
            if ( RepoFactory.IsConnected )
            {
                _books = _repoBOOK.GetAllBooks();
            }
        }

        protected override async Task LoadDataToCacheAsync()
        {
            if (RepoFactory.IsConnected)
            {
                _books = await _repoBOOK.GetAllBooksAsync();
            }
        }

        protected override void CopyCacheToViewModel()
        {
            Books.AddRange(_books);
        }

        protected override void SetTitle()
        {
            Title = "Books";
        }

        private readonly IRepoBOOK _repoBOOK;
        private IEnumerable<BookEx> _books;
    }
}
