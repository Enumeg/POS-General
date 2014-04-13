using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Source;
using System.Text;
using System.Linq;
using System.Drawing.Printing;
using System.Drawing;

namespace POS
{
    /// <summary>
    /// Interaction logic for Product.xaml
    /// </summary>
    public partial class Products : Page
    {

        public Products()
        {
            InitializeComponent();
            Fill_Products_LB();
            Categories.Get_All_Categories(Categories_CB, "الكل");
        }
        public static void Get_All_Products(ComboBox CB, string All = "")
        {

            try
            {
                DB db2 = new DB();

                db2.Fill(CB, "pro_id", "pro_name", "select * from products", All);
            }

            catch
            {

            }


        }
        private void Fill_Products_LB()
        {

            try
            {                              
                DB db = new DB();

                db.AddCondition("pro_name", Product_TB.Text, false, " like ");
                db.AddCondition("pro_cat_id", Categories_CB.SelectedValue, Categories_CB.SelectedIndex < 1);
                Products_DG.ItemsSource = db.SelectTableView( @"select products.*,cat_name from products join categories on pro_cat_id= cat_id");
            }
            catch
            {

            }

        }
        private void EditPanel_Add(object sender, EventArgs e)
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
        private void EditPanel_Edit(object sender, EventArgs e)
        {
            try
            {
                if(Products_DG.SelectedIndex != -1)
                {
                    Product p = new Product(((DataRowView)Products_DG.SelectedItem)[0]);
                    p.ShowDialog();
                    Fill_Products_LB();
                }
            }
            catch
            {

            }
        }
        private void EditPanel_Delete(object sender, EventArgs e)
        {
            try
            {
                if(Products_DG.SelectedIndex != -1)
                {

                    if(Message.Show("هل تريد حذف هذا الصنف", MessageBoxButton.YesNoCancel, 5) == MessageBoxResult.Yes)
                    {
                        DB db = new DB("products");
                        db.AddCondition("pro_id", ((DataRowView)Products_DG.SelectedItem)[0]);
                        db.Delete();
                        Fill_Products_LB();

                    }
                }
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
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Categories c = new Categories();
                c.ShowDialog();
                Categories.Get_All_Categories(Categories_CB, "الكل");
            }
            catch
            {

            }
        }

    }
}
