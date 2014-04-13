using System;
using System.Windows;
using System.Windows.Controls;
using Source;
using System.Data;
using System.Linq;


namespace POS
{
    /// <summary>
    /// Interaction logic for Products_Search.xaml
    /// </summary>
    public partial class Products_Search : Window
    {
        public static object pro_id;
        public Products_Search()
        {
            InitializeComponent();
            Categories.Get_All_Categories(Categories_CB);
            Fill_Products_LB();
        }

        private void Fill_Products_LB()
        {
            try
            {
                int i = 2;               
                DB db2 = new DB();

                db2.AddCondition("pro_name", Product_TB.Text, false, " like ");
                db2.AddCondition("pro_cat_id", Categories_CB.SelectedValue, Categories_CB.SelectedIndex < 1);

                db2.Fill(Products_LB, "pro_id", "pro_name", "select pro_id,pro_name from products");
            }
            catch
            {

            }

        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Fill_Products_LB();
            }
            catch
            {

            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Fill_Products_LB();
            }
            catch
            {

            }
        }

        private void Categories_CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Fill_Products_LB();
            }
            catch
            {

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product p = new Product();
                p.ShowDialog();
                Fill_Products_LB();
            }
            catch
            {

            }
        }

        private void Products_LB_PreviewMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                pro_id = Products_LB.SelectedValue;
                this.Close();
            }
            catch
            {

            }
        }


    }
}
