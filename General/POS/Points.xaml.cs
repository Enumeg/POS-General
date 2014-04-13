using System;
using System.Windows;
using System.Windows.Controls;
using Source;
using System.Data;
using System.Linq;
using System.Text;

using System.Collections.Generic;
namespace POS
{
    /// <summary>
    /// Interaction logic for Categories.xaml
    /// </summary>
    public partial class Points : Page
    {
        object Point_Id;
        int Selected_Index;
        public Points()
        {
            InitializeComponent();
            Fill_Point_LB();
            Categories.Get_All_Categories(Categories_CB, "الكل");
            Type_CB.ItemsSource = new string[] { "الكل", "تخزين", "بيع" };
        }

        private void Fill_Point_LB()
        {
            try
            {
                DB db = new DB("points");
                db.AddCondition("pon_name", Point_TB.Text.Trim(), false, " like ");
                db.AddCondition("pon_type", Type_CB.SelectedIndex - 1, Type_CB.SelectedIndex < 1);
                db.SelectedColumns.Add("*");
                db.Fill(Points_LB, "pon_id", "pon_name");
            }
            catch
            {

            }
        }

        private void Fill_Account_CB()
        {
            try
            {
                int i = Account_CB.SelectedIndex;
                DataTable dt = new DataTable();
                dt.Columns.Add("id"); dt.Columns.Add("name");
                dt.Rows.Add(0, "التحركات");
                if(((DataRowView)Points_LB.SelectedItem)[2].ToString() == "0")
                {
                    dt.Rows.Add(1, "شراء");
                    dt.Rows.Add(2, "مرتجع شراء");
                }
                else
                {
                    dt.Rows.Add(5, "بيع");
                    dt.Rows.Add(6, "مرتجع بيع");
                }

                dt.Rows.Add(3, "نقل");
                dt.Rows.Add(4, "هالك");
                dt.Rows.Add(-1, "المخزون");
                Account_CB.ItemsSource = dt.DefaultView;
                Account_CB.SelectedIndex = i;
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

                Stock_DG.ItemsSource = db2.SelectTableView(query + "group by pro_id");
                Get_Stock();
            }
            catch
            {

            }

        }

        private string Get_Products()
        {
            int i = 2;
            StringBuilder sb = new StringBuilder();
            sb.Append("And pro_id ");
            try
            {

                string query = "select pro_id from products join products_properties p1 on psp_pro_id=pro_id";
                DB db = new DB();

                db.AddCondition("pro_name", Product_TB.Text, false, " like ");
                db.AddCondition("pro_Serial", Serial_TB.Text, false, " like ");
                db.AddCondition("pro_cat_id", Categories_CB.SelectedValue, Categories_CB.SelectedIndex < 1);
                foreach(ComboBox cb in Properties_WP.Children.OfType<ComboBox>().Where(c => c is ComboBox && c.SelectedIndex > 0))
                {
                    db.AddCondition("p" + i + ".psp_value", cb.SelectedValue, cb.SelectedIndex < 1, "=", "psp_value_" + i);
                    db.AddCondition("p" + i + ".psp_prp_id", cb.Name.Split('_')[1], cb.SelectedIndex < 1, "=", "psp_prp_id" + i);
                    query += " join products_properties p" + i + " on p1.psp_pro_id = p" + i + ".psp_pro_id ";
                    i++;
                }

                DataTable dt = db.SelectTable(query + "group by pro_id");
                if(dt.Rows.Count == 1)
                {
                    sb.Append("=");
                    sb.Append(dt.Rows[0][0]);
                }
                else
                {
                    sb.Append("in (");
                    foreach(DataRow row in dt.Rows)
                    {
                        sb.Append(row[0]);
                        sb.Append(" ,");
                    }
                    if(sb.ToString().EndsWith(","))
                    {
                        sb.Remove(sb.Length - 2, 2);
                        sb.Append(")");
                    }
                    else
                    {
                        sb.Clear();
                    }
                }


            }
            catch
            {

            }
            return sb.ToString();
        }

        private Dictionary<string, decimal> Get_Products_Stock()
        {
            Dictionary<string, decimal> stock = new Dictionary<string, decimal>();
            int i = 2;
            try
            {
                string query = "select pro_id from products join products_properties p1 on psp_pro_id=pro_id";
                DB db = new DB();

                db.AddCondition("pro_name", Product_TB.Text, false, " like ");
                db.AddCondition("pro_Serial", Serial_TB.Text, false, " like ");
                db.AddCondition("pro_cat_id", Categories_CB.SelectedValue, Categories_CB.SelectedIndex < 1);
                foreach(ComboBox cb in Properties_WP.Children.OfType<ComboBox>().Where(c => c is ComboBox && c.SelectedIndex > 0))
                {
                    db.AddCondition("p" + i + ".psp_value", cb.SelectedValue, cb.SelectedIndex < 1, "=", "psp_value_" + i);
                    db.AddCondition("p" + i + ".psp_prp_id", cb.Name.Split('_')[1], cb.SelectedIndex < 1, "=", "psp_prp_id" + i);
                    query += " join products_properties p" + i + " on p1.psp_pro_id = p" + i + ".psp_pro_id ";
                    i++;
                }

                DataTable dt = db.SelectTable(query + "group by pro_id");
                db = new DB();
                db.AddCondition("trs_date", From_DTP.Value.Value.Date, false, "<", "SD");
                db.AddCondition("trs_id", Points_LB.SelectedValue);
                db.AddCondition("pro_id", Points_LB.SelectedValue);
                foreach(DataRow row in dt.Rows)
                {
                    db.Conditions[2].Value = row[0];
                    stock.Add(row[0].ToString(), decimal.Parse(
                    db.Select(@"SELECT COALESCE(SUM(trd_amount),0) - (SELECT COALESCE(SUM(trd_amount),0) FROM transactions_details JOIN transactions ON trs_id= trd_trs_id
                               WHERE trd_pro_id=@pro_id AND trs_date<@SD AND ((trs_trn_id IN (2,4,5) AND trs_id_2=@trs_id) OR(trs_trn_id = 3 AND trs_id_1=@trs_id)))
                               FROM transactions_details JOIN transactions ON trs_id= trd_trs_id WHERE trd_pro_id=@pro_id AND trs_date<@SD AND
                               trs_trn_id IN (1,3,6) AND trs_id_2=@trs_id").ToString()));
                }
            }
            catch
            {

            }
            return stock;
        }

        private void Fill_Transactions_DG()
        {

            try
            {
                Dictionary<string, decimal> stock = Get_Products_Stock();
                DB db = new DB();
                db.AddCondition("trs_date", From_DTP.Value.Value.Date, false, ">=", "SD");
                db.AddCondition("trs_date", To_DTP.Value.Value.Date, false, "<=", "ED");
                db.AddCondition("trs_id", Points_LB.SelectedValue);
                DataTable dt = db.SelectTable(@"select trs_no,trs_date,trn_name,0 income ,0 outcome,0 balance, trd_serial,pro_name,trd_amount,trn_id,trs_id_1,pro_id from transactions
                                                join transactions_names on trs_trn_id= trn_id
                                                join transactions_details on trd_trs_id = trs_id
                                                join products on trd_pro_id = pro_id where (trs_id_1=@trs_id or trs_id_2=@trs_id)" + Get_Products());
                foreach(DataRow row in dt.Rows)
                {
                    switch(int.Parse(row["trn_id"].ToString()))
                    {
                        case 1:
                        case 6:
                            row["income"] = row["trd_amount"];
                            stock[row["pro_id"].ToString()] += decimal.Parse(row["trd_amount"].ToString());
                            break;
                        case 2:
                        case 4:
                        case 5:
                            row["outcome"] = row["trd_amount"];
                            stock[row["pro_id"].ToString()] -= decimal.Parse(row["trd_amount"].ToString());
                            break;
                        case 3:
                            if(row["trs_id_1"].ToString() == Points_LB.SelectedValue.ToString())
                            {
                                row["outcome"] = row["trd_amount"];
                                stock[row["pro_id"].ToString()] -= decimal.Parse(row["trd_amount"].ToString());
                            }
                            else
                            {
                                row["income"] = row["trd_amount"];
                                stock[row["pro_id"].ToString()] += decimal.Parse(row["trd_amount"].ToString());
                            }
                            break;

                    }
                    row["balance"] = stock[row["pro_id"].ToString()];

                }
                Transactions_DG.ItemsSource = dt.DefaultView;
            }
            catch
            {

            }

        }

        private void Fill_Transaction_DG()
        {
            try
            {
                DB db = new DB();
                db.AddCondition("trs_date", From_DTP.Value.Value.Date, false, ">=", "SD");
                db.AddCondition("trs_date", To_DTP.Value.Value.Date, false, "<=", "ED");
                db.AddCondition("trs_trn_id", Account_CB.SelectedValue);
                Transaction_DG.ItemsSource = db.SelectTableView(@"select trs_no,trs_date,trd_serial,pro_name,trd_amount from transactions                                                
                                                join transactions_details on trd_trs_id = trs_id
                                                join products on trd_pro_id = pro_id where" + Get_Products().Remove(0,3));
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
                db.AddCondition("stk_pon_id", Points_LB.SelectedValue);
                DataTable dt = db.SelectTable(@"SELECT pro_id, COALESCE(SUM(stk_amount),0) pro_amount, CASE 
                                 WHEN COALESCE(stk_amount,0)-pro_limit>0 THEN 1 
                                 WHEN COALESCE(stk_amount,0)-pro_limit<0 THEN -1 
                                 ELSE 0 END pro_status FROM products
                                 left JOIN stock ON stk_pro_id=pro_id and stk_pon_id=@stk_pon_id
                                 GROUP BY pro_id");

                foreach(DataRow row in ((DataView)Stock_DG.ItemsSource).Table.Rows)
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

        public static void Get_All_Points(ComboBox CB, int type = 0, string All = "")
        {
            try
            {
                DB db = new DB("points");
                db.AddCondition("pon_type", type - 1, type == 0);
                db.SelectedColumns.Add("*");
                db.Fill(CB, "pon_id", "pon_name", "", All);
            }
            catch
            {

            }
        }

        private bool Add_Update()
        {
            try
            {

                DB DataBase = new DB("points");

                DataBase.AddColumn("pon_name", Point_TB.Text.Trim());
                DataBase.AddColumn("pon_type", Type_CB.SelectedIndex - 1);
                if(Point_Id == null)
                {
                    if(DataBase.IsNotExist("pon_id", "pon_name", "pon_type"))
                    {
                        return Confirm.Check(DataBase.Insert());
                    }
                    else
                    {
                        Message.Show("لقد تم تسجيل هذه النقطة من قبل", MessageBoxButton.OK, 5);
                        return false;
                    }


                }
                else
                {
                    DataBase.AddCondition("pon_id", this.Point_Id);
                    return Confirm.Check(DataBase.Update());
                }
            }
            catch
            {
                //MessageBox.Show("kiki_method");
                return false;
            }
        }

        private void Save_Save(object sender, EventArgs e)
        {
            try
            {

                if(Add_Update())
                {
                    if(!(bool)New.IsChecked)
                    {
                        Main_GD.RowDefinitions[2].Height = new GridLength(0);
                    }
                    Fill_Point_LB();
                    Point_Id = null;
                    Point_TB.Text = "";
                    Type_CB.SelectedIndex = 0;
                }
            }
            catch
            {
                return;
            }
        }

        private void Save_Cancel(object sender, EventArgs e)
        {
            try
            {
                Main_GD.RowDefinitions[2].Height = new GridLength(0);
                Fill_Point_LB();
                Point_Id = null;
                Point_TB.Text = "";
                Type_CB.SelectedIndex = 0;
            }
            catch
            {

            }
        }

        private void EditPanel_Add(object sender, EventArgs e)
        {
            try
            {
                Point_Id = null;
                Main_GD.RowDefinitions[2].Height = new GridLength(35);
            }
            catch
            {

            }
        }

        private void EditPanel_Edit(object sender, EventArgs e)
        {
            try
            {
                Main_GD.RowDefinitions[2].Height = new GridLength(35);
                Point_Id = Points_LB.SelectedValue;
                Point_TB.Text = ((DataRowView)Points_LB.SelectedItem)[1].ToString();
                Type_CB.SelectedIndex = int.Parse(((DataRowView)Points_LB.SelectedItem)[2].ToString());

            }
            catch
            {

            }
        }

        private void EditPanel_Delete(object sender, EventArgs e)
        {

            try
            {
                if(Message.Show("هل تريد حذف هذا المحل", MessageBoxButton.YesNoCancel, 10) == MessageBoxResult.Yes)
                {

                    DB db = new DB("points");
                    db.AddCondition("pon_id", Points_LB.SelectedValue);
                    db.Delete();
                    Fill_Point_LB();
                }
            }
            catch
            {

            }
        }

        private void Point_TB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Fill_Point_LB();
            }
            catch
            {

            }
        }

        private void Type_CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Fill_Point_LB();
            }
            catch
            {

            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                switch(Account_CB.SelectedIndex)
                {
                    case 0:
                        Fill_Transactions_DG();
                        break;
                    case 5:
                        Fill_Products_LB();
                        break;
                    default:
                        Fill_Transaction_DG();
                        break;
                }
            }
            catch
            {

            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                switch(Account_CB.SelectedIndex)
                {
                    case 0:
                        Fill_Transactions_DG();
                        break;
                    case 5:
                        Fill_Products_LB();
                        break;
                    default:
                        Fill_Transaction_DG();
                        break;
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
                switch(Account_CB.SelectedIndex)
                {
                    case 0:
                        Fill_Transactions_DG();
                        break;
                    case 5:
                        Fill_Products_LB();
                        break;
                    default:
                        Fill_Transaction_DG();
                        break;
                }

                Create_Properties_Controls();
            }
            catch
            {

            }
        }

        private void Points_LB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Fill_Account_CB();
            }
            catch
            {

            }
        }

        private void Account_CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if(Selected_Index != 0)
                {
                    View_GD.RowDefinitions[Selected_Index].Height = new GridLength(0);
                }

                switch(Account_CB.SelectedIndex)
                {
                    case 0:
                        View_GD.RowDefinitions[1].Height = new GridLength(1, GridUnitType.Star);
                        Selected_Index = 1;
                        Fill_Transactions_DG();
                        break;
                    case 5:
                        View_GD.RowDefinitions[3].Height = new GridLength(1, GridUnitType.Star);
                        Selected_Index = 3;
                        Fill_Products_LB();
                        break;
                    default:
                        View_GD.RowDefinitions[2].Height = new GridLength(1, GridUnitType.Star);
                        Selected_Index = 2;
                        Fill_Transaction_DG();
                        break;
                }
            }
            catch
            {

            }
        }

        private void From_DTP_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            try
            {
                switch(Account_CB.SelectedIndex)
                {
                    case 0:
                        Fill_Transactions_DG();
                        break;
                    case 5:
                        Fill_Products_LB();
                        break;
                    default:
                        Fill_Transaction_DG();
                        break;
                }
            }
            catch
            {

            }
        }




    }
}
