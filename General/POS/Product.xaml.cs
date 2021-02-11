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
        DataTable Products_Properties;

        public Product(object product_Id = null)
        {
            InitializeComponent();
            Products_Properties = new DataTable();
            Products_Properties.Columns.Add("psp_pro_id", typeof(DB));
            Products_Properties.Columns.Add("psp_prp_id");
            Products_Properties.Columns.Add("psp_value");

            Categories.Get_All_Categories(Categories_CB);

            Product_Id = product_Id;

            if(Product_Id != null)
            {
                Get_Product_Info();
            }
            else
            {
                Get_Serial();
            }
        }

        private void Get_Serial()
        {
            try
            {
                DB db = new DB();
                var serial = db.Select("select max(pro_serial) from products");
                Serial_TB.Text = serial.ToString() == "" ? "10001" : (int.Parse(serial.ToString()) + 1).ToString();
            }
            catch
            {

            }
        }

        private void Create_Properties_Controls()
        {
            try
            {
                object Prp_Id;
                DB db = new DB();
                db.AddCondition("prp_cat_id", ((DataRowView)Categories_CB.SelectedItem)[0]);
                foreach(DataRow property in db.SelectTable("select * from properties where prp_Cat_id=@prp_cat_id or prp_cat_id is null ").Rows)
                {
                    Prp_Id = property[0];
                    RowDefinition rf = new RowDefinition();
                    rf.Height = new GridLength(35);
                    Properties_GD.RowDefinitions.Add(rf);

                    TextBlock Property_Name = new TextBlock();
                    Property_Name.Style = FindResource("Label_TextBlock") as Style;
                    Property_Name.Text = property["prp_name"].ToString() + " :";
                    Property_Name.SetValue(Grid.RowProperty, Properties_GD.RowDefinitions.Count - 1);
                    Property_Name.SetValue(Grid.ColumnProperty, 0);
                    Properties_GD.Children.Add(Property_Name);

                    ComboBox CB = new ComboBox();
                    CB.Style = FindResource("Edit_ComboBox") as Style;
                    CB.SetValue(Grid.RowProperty, Properties_GD.RowDefinitions.Count - 1);
                    CB.SetValue(Grid.ColumnProperty, 1);
                    CB.Name = "CB_" + Prp_Id;
                    Get_Values(CB, Prp_Id);
                    CB.IsEditable = true;
                    CB.LostFocus += new RoutedEventHandler(Categories_CB_LostFocus);
                    Properties_GD.Children.Add(CB);

                }
            }
            catch
            {

            }
        }

        public static void Get_Values(ComboBox CB, object prp_id, string All = "")
        {
            try
            {
                DB d = new DB();
                d.AddCondition("psp_prp_id", prp_id);
                d.Fill(CB, "psp_value", "psp_value", "select psp_value from products_properties group by psp_value order by psp_value", All);
            }
            catch
            {

            }
        }

        private void Get_Product_Info()
        {
            try
            {
                int i = 0;
                DB db2 = new DB("Products");

                db2.SelectedColumns.Add("*");

                db2.AddCondition("pro_id", Product_Id);

                DataRowView product = db2.SelectRowView();
                this.DataContext = product;
                Categories_CB.SelectedValue = product["pro_cat_id"];
                IEnumerator<ComboBox> cbs = Form.FindVisualChildren<ComboBox>(Properties_GD).GetEnumerator();
                DataTable dt = db2.SelectTable("select psp_value from products_properties where psp_pro_id=@pro_id");
                foreach(ComboBox cb in Form.FindVisualChildren<ComboBox>(Properties_GD))
                {
                    cb.Text = dt.Rows[i][0].ToString();
                    i++;
                }

            }
            catch
            {


            }
        }

        private bool Add_Update()
        {
            try
            {
                Products_Properties.Rows.Clear();
                DB db1 = new DB("products");

                db1.AddColumn("pro_cat_id", Categories_CB.SelectedValue);
                db1.AddColumn("pro_name", Product_TB.Text.Trim());
                db1.AddColumn("pro_serial", Serial_TB.Text.Trim());
                db1.AddColumn("pro_sell", Sell_Price_TB.Text.Trim());
                db1.AddColumn("pro_limit", Buy_Limit_TB.Text.Trim());

                DB db2 = new DB("products_properties");

                if(Product_Id == null)
                {
                    if(db1.IsNotExist("pro_id", "pro_name", "pro_cat_id"))
                    {
                        foreach(ComboBox cb in Form.FindVisualChildren<ComboBox>(Properties_GD))
                        {
                            Products_Properties.Rows.Add(db1, cb.Name.Split('_')[1], cb.Text.Trim());
                        }
                        db2.Table = Products_Properties;
                        return db1.Execute_Queries(db1, db2);
                    }
                    else
                    {
                        Message.Show("هذا المنتج مسجل من قبل", MessageBoxButton.OK, 5);
                        return false;
                    }
                }
                else
                {
                    db1.Last_Inserted = Product_Id;
                    foreach(ComboBox cb in Form.FindVisualChildren<ComboBox>(Properties_GD))
                    {
                        Products_Properties.Rows.Add(db1, cb.Name.Split('_')[1], cb.Text);
                    }
                    db2.Table = Products_Properties;
                    DB db3 = new DB("products_properties");
                    db3.AddCondition("psp_pro_Id", this.Product_Id);
                    db1.AddCondition("pro_Id", this.Product_Id);
                    return db1.Execute_Queries(db1, db3, db2);
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
                        Get_Serial();
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

        private void Categories_CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Properties_GD.Children.Clear();
                Properties_GD.RowDefinitions.Clear();
                Create_Properties_Controls();
            }
            catch
            {

            }
        }

        private void CB_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {

        }

        private void Categories_CB_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                Product_TB.Text = Categories_CB.Text;
                foreach(ComboBox cb in Form.FindVisualChildren<ComboBox>(Properties_GD))
                {
                    Product_TB.Text += " " + cb.Text;
                }
            }
            catch
            {

            }
        }

    }
}
