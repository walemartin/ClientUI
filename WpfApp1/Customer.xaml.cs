using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.Data;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Customer.xaml
    /// </summary>
    public partial class Customer :  Window, INotifyPropertyChanged
    {
        ProductDbContext context;
        Product NewProduct = new Product();
        Product selectedProduct = new Product();
        // Declare the event
        public event PropertyChangedEventHandler PropertyChanged;
        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private List<Product> _employees;

        public List<Product> Employees
        {
            get { return _employees; }
            set
            {
                _employees = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged();
            }
        }

        private Product _selectedEmployee;

        public Product SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged();
            }
        }



        #region ICommands  
        public DelegateCommand GetButtonClicked { get; set; }
        public DelegateCommand ShowRegistrationForm { get; set; }
        public DelegateCommand PostButtonClick { get; set; }
        public DelegateCommand<Product> PutButtonClicked { get; set; }
        public DelegateCommand<Product> DeleteButtonClicked { get; set; }
        #endregion

        public Customer(ProductDbContext context)
        {
            this.context = context;
            InitializeComponent();
            GetProducts();
            NewProductGrid.DataContext = NewProduct;
            PutButtonClicked = new DelegateCommand<Product>(UpdateItem);
            DeleteButtonClicked = new DelegateCommand<Product>(DeleteProduct);
        }

       

        private void GetProducts()
        {
            ProductDG.ItemsSource = context.Products.ToList();
        }
        private void AddItem(object s, RoutedEventArgs e)
        {
            context.Products.Add(NewProduct);
            context.SaveChanges();
            GetProducts();
            NewProduct = new Product();
            NewProductGrid.DataContext = NewProduct;
        }
        private void UpdateItem(Product prod)
        {
            context.Update(prod);
            context.SaveChanges();
            GetProducts();
        }
        private void SelectProductToEdit(object s, RoutedEventArgs e)
        {
            selectedProduct = (s as FrameworkElement).DataContext as Product;
            UpdateProductGrid.DataContext = selectedProduct;
        }
        private void DeleteProduct(Product prod)
        {
            //var productToDelete = (s as FrameworkElement).DataContext as Product;
            context.Products.Remove(prod);
            context.SaveChanges();
            GetProducts();
        }
    }
}
