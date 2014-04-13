using System;
using System.Data;
using System.Windows;
using Source;
using System.Windows.Controls;
using System.Collections.Generic;


namespace POS
{
    /// <summary>
    /// Interaction logic for Product.xaml
    /// </summary>
    public partial class Product : Window
    {
        object Product_Id;

        public Product(object product_Id = null)
        {
            InitializeComponent();

            Categories.Get_All_Categories(Categories_CB);

            Product_Id = product_Id;

            if(Product_Id != null)
            {
                Get_Product_Info();
            }          
        }

        private void Get_Product_Info()
        {
            try
            {               
                DB db2 = new DB("Products");

                db2.SelectedColumns.Add("*");

                db2.AddCondition("pro_id", Product_Id);

                DataRowView product = db2.SelectRowView();

                this.DataContext = product;
            }
            catch
            {


            }
        }

        private bool Add_Update()
        {
            try
            {
                DB db = new DB("products");

                db.AddColumn("pro_cat_id", Categories_CB.SelectedValue);
                db.AddColumn("pro_name", Product_TB.Text.Trim());
                db.AddColumn("pro_sell", Sell_Price_TB.Text.Trim());


                if(Product_Id == null)
                {
                    if(db.IsNotExist("pro_id", "pro_name", "pro_cat_id"))
                    {
                        return db.Insert();
                    }
                    else
                    {
                        Message.Show("هذا المنتج مسجل من قبل", MessageBoxButton.OK, 5);
                        return false;
                    }
                }
                else
                {                 
                    db.AddCondition("pro_Id", this.Product_Id);
                    return db.Update();
                }

            }
            catch
            {
                return false;
            }
        }

        private void Add_Update_Product_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                //try to add or update return true if ok
                if(Confirm.Check(Add_Update()))
                {
                    //check New checkBox status
                    if((bool)New.IsChecked)
                    {
                        Sell_Price_TB.Clear();
                        Product_Id = null;
                    }
                    else
                    {
                        //close window
                        this.Close();
                    }
                }
            }
            catch
            {

            }
        }
    }
}
