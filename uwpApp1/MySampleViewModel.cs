using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace uwpApp1
{
    public class MySampleViewModel : MyBase
    {
        private string _text;
        private ObservableCollection<string> _mySampleList;

        private ObservableCollection<Category> _treeList;

        public ObservableCollection<Item> DataSource = new ObservableCollection<Item>();

        private ObservableCollection<Global> _globalList;

        private ObservableCollection<FolderInfo> _subFolders = new ObservableCollection<FolderInfo>();
        public ObservableCollection<FolderInfo> storageFolders
        {
            get => _subFolders;
            set
            {
                _subFolders = value;
                OnPropertyChanged();
            }
        }

        public string Text
        {
            get => _text;
            set
            {
                if (_text != value)
                {
                    _text = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<string> MySampleList
        {
            get => _mySampleList;
            private set
            {
                _mySampleList = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Category> TreeList
        {
            get => _treeList;
            private set
            {
                _treeList = value;
                OnPropertyChanged();
            }
        }



        public ObservableCollection<Global> GlobalList
        {
            get => _globalList;
            private set
            {
                _globalList = value;
                OnPropertyChanged();
            }
        }

        private FolderInfo _fileObject;
        public FolderInfo fileObject
        {
            get => _fileObject;
            set
            {
                //if (_fileObject != value)
                //{
                    _fileObject = value;
                    OnPropertyChanged();
                //}
            }
        }


        public int _IndexObj;
        public int IndexObj
        {
            get => _IndexObj;
            set
            {
                if (_IndexObj != value)
                {
                    _IndexObj = value;
                    OnPropertyChanged();
                }
            }
        }


        public ICommand MyCommand { get; }

        public ICommand ChangeCommand { get; }

        public MySampleViewModel()
        {
            MyCommand = new RelayCommand(ExecuteMyCommand);
            ChangeCommand = new RelayCommand(ExecuteChangeCommand);

            MySampleList = new ObservableCollection<string>();
            TreeList = new ObservableCollection<Category>();

            GlobalList = new ObservableCollection<Global>();

            AddFilesFolders();
        }

        private void ExecuteChangeCommand()
        {
            FolderInfo faf = storageFolders.Last();

            //fileObject = faf;

            //int ind = storageFolders.Count - 1;
            //IndexObj = ind < 0 ? 0 : ind; 
        }

        private void ExecuteMyCommand()
        {
            Text = "Button Clicked! " + DateTime.Now.ToString();
            MySampleList.Add(DateTime.Now.ToString());

            ObservableCollection<Product> lstProd = new ObservableCollection<Product>();
            lstProd.Add(new Product() { ProductName = "prod " + DateTime.Now.ToString() });
            lstProd.Add(new Product() { ProductName = "prod " + DateTime.Now.ToString() });
            lstProd.Add(new Product() { ProductName = "prod " + DateTime.Now.ToString() });
            Category cat = new Category("cat " + DateTime.Now.ToString(), lstProd);

            TreeList.Add(cat);

            Category catx = new Category("catx " + DateTime.Now.ToString(), new ObservableCollection<Product>());

            TreeList.Add(catx);


            Global glob = new Global("catGlobal " + DateTime.Now.ToString(), new ObservableCollection<Global>());

            GlobalList.Add(glob);

            AddFilesFolders();
        }


        private void AddFilesFolders()
        {
            FolderInfo ff1 = new FolderInfo();
            ff1.FolderName = "Folder " + DateTime.Now.ToString();
            ff1.IsFolder = true;

            storageFolders.Add(ff1);

            FolderInfo ffkeko = new FolderInfo();
            ffkeko.FolderName = "subitem" + DateTime.Now.ToString();

            ff1.subFolders.Add(ffkeko);

            FolderInfo ff = new FolderInfo();
            ff.FolderName = "servername " + DateTime.Now.ToString();

            storageFolders.Add(ff);
        }
    }

    public class MyBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    public class Category : MyBase
    {
        private string categoryName;
        public string CategoryName
        {
            get { return categoryName; }
            set
            {
                categoryName = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Product> products;
        public ObservableCollection<Product> Products
        {
            get { return products; }
            set
            {
                products = value;
                OnPropertyChanged();
            }
        }
        //public event PropertyChangedEventHandler PropertyChanged;
        //public void OnPropertyChanged(PropertyChangedEventArgs e)
        //{
        //    if (PropertyChanged != null)
        //        PropertyChanged(this, e);
        //}
        public Category(string categoryName, ObservableCollection<Product> products)
        {
            CategoryName = categoryName;
            Products = products;
        }
    }

    public class Global : MyBase
    {
        private string categoryName;
        public string CategoryName
        {
            get { return categoryName; }
            set
            {
                categoryName = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Global> products;
        public ObservableCollection<Global> Products
        {
            get { return products; }
            set
            {
                products = value;
                OnPropertyChanged();
            }
        }

        public Global(string categoryName, ObservableCollection<Global> products)
        {
            CategoryName = categoryName;
            Products = products;
        }
    }

    public class Product : MyBase
    {
        private string productName;
        public string ProductName
        {
            get { return productName; }
            set
            {
                productName = value;
                OnPropertyChanged();
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public ObservableCollection<Item> Children { get; set; } = new ObservableCollection<Item>();

        public override string ToString()
        {
            return Name;
        }
    }

    public class FolderInfo : MyBase //INotifyPropertyChanged
    {
        private string _FolderName;
        public string FolderName
        {
            get { return _FolderName; }
            set
            {
                if (_FolderName != value)
                {
                    _FolderName = value;
                    //RaisePropertyChanged("FolderName");
                    OnPropertyChanged("FolderName");
                }
            }
        }

        private bool _IsFolder;
        public bool IsFolder
        {
            get { return _IsFolder; }
            set
            {
                if (_IsFolder != value)
                {
                    _IsFolder = value;
                    //RaisePropertyChanged("FolderName");
                    OnPropertyChanged("IsFolder");
                }
            }
        }

        //public ObservableCollection<FolderInfo> subFolders { get; set; } = new ObservableCollection<FolderInfo>();

        private ObservableCollection<FolderInfo> _subFolders = new ObservableCollection<FolderInfo>();
        public ObservableCollection<FolderInfo> subFolders
        {
            get => _subFolders;
            set
            {
                _subFolders = value;
                OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return FolderName;
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute != null ? _canExecute.Invoke() : true;
        }

        public void Execute(object parameter)
        {
            _execute.Invoke();
        }
    }

}
