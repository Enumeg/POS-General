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
                int i = 2;
                string query = @"select products.*,cat_name, 0 pro_amount,0 pro_status from products
                                 join categories on pro_cat_id= cat_id                                
                                 join products_properties p1 on psp_pro_id=pro_id";
                DB db2 = new DB();

                db2.AddCondition("pro_name", Product_TB.Text, false, " like ");
                db2.AddCondition("pro_Serial", Serial_TB.Text, false, " like ");
                db2.AddCondition("pro_cat_id", Categories_CB.SelectedValue, Categories_CB.SelectedIndex < 1);
                foreach(ComboBox cb in Properties_WP.Children.OfType<ComboBox>().Where(c => c is ComboBox && c.SelectedIndex > 0))
                {
                    db2.AddCondition("p" + i + ".psp_value", cb.SelectedValue, cb.SelectedIndex < 1, "=", "psp_value_" + i);
                    db2.AddCondition("p" + i + ".psp_prp_id", cb.Name.Split('_')[1], cb.SelectedIndex < 1, "=", "psp_prp_id" + i);
                    query += " join products_properties p" + i + " on p1.psp_pro_id = p" + i + ".psp_pro_id ";
                    i++;
                }

                Products_DG.ItemsSource = db2.SelectTableView(query + "group by pro_id");
                Get_Stock();
            }
            catch
            {

            }

        }

        private void Get_Stock()
        {
            try
            {
                DB db = new DB();
                DataTable dt = db.SelectTable(@"SELECT pro_id, COALESCE(SUM(stk_amount),0) pro_amount, CASE 
                                 WHEN COALESCE(stk_amount,0)-pro_limit>0 THEN 1 
                                 WHEN COALESCE(stk_amount,0)-pro_limit<0 THEN -1 
                                 ELSE 0 END pro_status FROM products
                                 LEFT JOIN stock ON stk_pro_id=pro_id
                                 GROUP BY pro_id");
                foreach(DataRow row in ((DataView)Products_DG.ItemsSource).Table.Rows)
                {
                    row["pro_amount"] = dt.Rows.OfType<DataRow>().Where(r => r["pro_id"].ToString() == row["pro_id"].ToString()).Single<DataRow>()["pro_amount"];
                    row["pro_status"] = dt.Rows.OfType<DataRow>().Where(r => r["pro_id"].ToString() == row["pro_id"].ToString()).Single<DataRow>()["pro_status"];
                }
            }
            catch
            {

            }
        }

        private void Create_Properties_Controls()
        {
            try
            {
                Properties_WP.Children.RemoveRange(1, Properties_WP.Children.Count - 1);
                object Prp_Id;
                DB db = new DB();
                db.AddCondition("prp_cat_id", ((DataRowView)Categories_CB.SelectedItem)[0]);
                foreach(DataRow property in db.SelectTable("select * from properties where prp_Cat_id=@prp_cat_id or prp_cat_id is null ").Rows)
                {
                    Prp_Id = property[0];
                    TextBlock Property_Name = new TextBlock();
                    Property_Name.Style = FindResource("Label_TextBlock") as Style;
                    Property_Name.Text = property["prp_name"].ToString() + " :";
                    Properties_WP.Children.Add(Property_Name);

                    ComboBox CB = new ComboBox();
                    CB.Style = FindResource("Edit_ComboBox") as Style;
                    CB.Name = "CB_" + Prp_Id;
                    Product.Get_Values(CB, Prp_Id, "الكل");
                    CB.IsEditable = true;
                    CB.SelectionChanged += new SelectionChangedEventHandler(ComboBox_SelectionChanged);
                    CB.Width = 120;
                    Properties_WP.Children.Add(CB);
                }
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

        private void LB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

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
                Create_Properties_Controls();
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                Propertiess c = new Propertiess();
                c.ShowDialog();
            }
            catch
            {

            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                Barcode c = new Barcode((DataRowView)Products_DG.SelectedItem);
                c.ShowDialog();
            }
            catch
            {

            }
        }

    }
}
