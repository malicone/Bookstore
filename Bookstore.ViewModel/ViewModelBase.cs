using Bookstore.Model.Factory.Implementation;
using Bookstore.Model.Factory.Interface;
using FirebirdSql.Data.FirebirdClient;
using NLog;
using System;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public delegate void DataExceptionDelegate(ViewModelBase sender, Exception ex);

        public event DataExceptionDelegate DataException;

        public string Title { get; set; }

        protected virtual void FireDataExceptionEvent(Exception ex)
        {
            TheLogger.Error(ex, $"Exception in {this.GetType().Name}");
            if (DataException != null)
            {
                DataException(this, ex);
            }
        }

        public ViewModelBase()
        {
            TheLogger = LogManager.GetCurrentClassLogger();
            TheLogger.Trace($"{this.GetType().Name} created");
            // to recognize WIN1251 encoding
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            SetupConnection();
        }

        private void SetupConnection()
        {
            try
            {
                Connection = ConnectionFactory.GetConnectionAsSingleton();
                if (Connection != null)
                {
                    if (Connection.State != System.Data.ConnectionState.Open)
                        Connection.Open();
                    RepoFactory = new RepoFactory(Connection);
                }
            }
            catch (Exception ex)
            {
                FireDataExceptionEvent(ex);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(params string[] propertyNames)
        {
            foreach (var propertyName in propertyNames)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public virtual void Load()
        {
            // What is the cache? - Mostly model classes (AutoColor.Dal.Models) and lists of them (naturally 
            // they are hidden i.e. private/protected).
            // Why we use cache? - In any case we need them to fetch data from the db. It's much better to split 
            // fetching data from the db and coping to model bound properties. So we have one short transaction and then
            // coping to properties which fire GUI events in main thread.
            LoadDataToCache();
            CopyCacheToViewModel();
            SetTitle();
        }
        protected abstract void LoadDataToCache();
        protected abstract void CopyCacheToViewModel();
        protected abstract void SetTitle();
        protected virtual async Task LoadDataToCacheAsync()
        {
            // not all descendants need async method so we define stub here
            await Task.Delay(10);
        }
        public virtual async Task LoadAsync(Action<Action> updateUIBoundProperties = null)
        {
            await LoadDataToCacheAsync();
            if (updateUIBoundProperties != null)
            {
                updateUIBoundProperties(CopyCacheToViewModel);
            }
            else
            {
                CopyCacheToViewModel();
            }
            SetTitle();
        }
        public virtual bool Save()
        {
            throw new NotImplementedException();
        }
        protected IRepoFactory RepoFactory { get; private set; }
        protected FbConnection Connection { get; private set; }

        protected Logger TheLogger { get; set; }
    }
}
