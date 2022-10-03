using System;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Windows;
using WpfApp1.ViewModels;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int clickedCount = 0;
        private MainViewModel _viewModel = new MainViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _viewModel;
            MyTextBlock.Text = "This was set from code-behind.";
            MyTextBlock.FontSize = 24;
            MyTextBlock.TextAlignment = TextAlignment.Center;
        }
        private void AddItemButton_OnClick(object sender, RoutedEventArgs e)
        {
            Resources["TextBlockLabel"] = string.Format("Clicked {0} time(s)",
            ++clickedCount);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You clicked the button!");
        }
        private void btndisplaydata_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FillDataGrid();
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void FillDataGrid()

        {

            string ConString = ConfigurationManager.ConnectionStrings["StoreContext"].ConnectionString;

            string CmdString = string.Empty;

            using (SqlConnection con = new SqlConnection(ConString))

            {

                CmdString = "SELECT * FROM Customers";

                SqlCommand cmd = new SqlCommand(CmdString, con);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                sda.Fill(dt);

                gridCustomers.ItemsSource = dt.DefaultView;

            }

        }
    }

   
}
