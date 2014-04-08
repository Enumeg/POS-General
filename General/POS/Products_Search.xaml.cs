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
                string query = "select pro_id,pro_name from products join products_properties p1 on psp_pro_id=pro_id";
                DB db2 = new DB();

                db2.AddCondition("pro_name", Product_TB.Text, false, " like ");
                db2.AddCondition("pro_Serial", Serial_TB.Text, false, " like ");
                db2.AddCondition("pro_cat_id", Categories_CB.SelectedValue, Categories_CB.SelectedIndex < 1);
                foreach(ComboBox cb in Properties_GD.Children.OfType<ComboBox>().Where(c => c is ComboBox && c.SelectedIndex > 0))
                {
                    db2.AddCondition("p" + i + ".psp_value", cb.SelectedValue, cb.SelectedIndex < 1, "=", "psp_value_" + i);
                    db2.AddCondition("p" + i + ".psp_prp_id", cb.Name.Split('_')[1], cb.SelectedIndex < 1, "=", "psp_prp_id" + i);
                    query += " join products_properties p" + i + " on p1.psp_pro_id = p" + i + ".psp_pro_id ";
                    i++;
                }

                db2.Fill(Products_LB, "pro_id", "pro_name", query + "group by pro_id");
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
                    Product.Get_Values(CB, Prp_Id);
                    CB.IsEditable = true;
                    CB.SelectionChanged += new SelectionChangedEventHandler(ComboBox_SelectionChanged);
                    Properties_GD.Children.Add(CB);
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
