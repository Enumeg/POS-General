using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using Source;

namespace POS
{
    /// <summary>
    /// Interaction logic for Product.xaml
    /// </summary>
    public partial class Customers : Page
    {
        string Table;
        public Customers(string table)
        {
            InitializeComponent();
            Table = table;
            Fill_Customers_LB();
        }

        private void Fill_Customers_LB()
        {

            try
            {
                DB db2 = new DB();

                // search by name
                db2.AddCondition("per_name", "%" + Name_Search_TB.Text + "%", false, " like ");

                // search by mobile
                db2.AddCondition("per_mobile", "%" + Mobile_Search_TB.Text + "%", false, " like ");
                if(Table == "customers")
                {
                    db2.Fill(LB, "cus_id", "per_name", @"select * from customers sup join persons per on sup.cus_per_id=per.per_id");
                }
                else
                {
                    db2.Fill(LB, "sup_id", "per_name", @"select *,sup_balance cus_balance from suppliers sup join persons per on sup.sup_per_id=per.per_id");
                }
            }
            catch
            {

            }

        }

        private void Filter_Customers_LB()
        {

            try
            {
                DB db2 = new DB();

                // search by name
                db2.AddCondition("per_name", "%" + Name_Search_TB.Text + "%", false, " like ");

                // search by mobile
                db2.AddCondition("per_mobile", "%" + Mobile_Search_TB.Text + "%", false, " like ");

                ((DataView)LB.ItemsSource).RowFilter = db2.GetFilter();
            }
            catch
            {

            }

        }


        public static void Get_All_Customers(ComboBox CB, string Table, string All = "")
        {

            try
            {
                DB db2 = new DB();

                if(Table == "customers")
                {
                    db2.Fill(CB, "per_id", "per_name", "select per_id,per_name from customers sup join persons per on sup.cus_per_id=per.per_id", All);
                }
                else
                {
                    db2.Fill(CB, "per_id", "per_name", "select per_id,per_name from suppliers sup join persons per on sup.sup_per_id=per.per_id", All);
                }
            }

            catch
            {

            }


        }

        public bool Add_Update()
        {

            try
            {

                DB db1 = new DB("persons");

                db1.AddColumn("per_name", Name_TB.Text.Trim());
                db1.AddColumn("per_address", Address_TB.Text.Trim());
                db1.AddColumn("per_phone", Telephone_TB.Text.Trim());
                db1.AddColumn("per_mobile", Mobile_TB.Text.Trim());

                DB db2 = new DB(Table);

                db2.AddColumn(Table.Substring(0, 3) + "_balance", Balance_TB.Text.Trim());

                if(LB.SelectedIndex == -1)
                {
                    db2.AddColumn(Table.Substring(0, 3) + "_per_id", db1);
                    return db2.Execute_Queries(db1, db2);
                }
                else
                {
                    db1.AddCondition("per_id", ((DataRowView)LB.SelectedItem)["per_id"]);
                    db2.AddCondition(Table.Substring(0, 3) + "_id", LB.SelectedValue);
                    return db2.Execute_Queries(db1, db2);
                }

            }
            catch
            {
                return false;
            }
        }

        private void EditPanel_Add(object sender, EventArgs e)
        {
            try
            {
                Form.Set_Style(Main_GD, Operations.Add);
                Main_GD.RowDefinitions[2].Height = new GridLength(35);
                LB.IsEnabled = false;
                LB.SelectedIndex = -1;
            }
            catch
            {

            }
        }

        private void EditPanel_Edit(object sender, EventArgs e)
        {
            try
            {
                Form.Set_Style(Main_GD, Operations.Edit);
                Main_GD.RowDefinitions[2].Height = new GridLength(35);
                LB.IsEnabled = false;
            }
            catch
            {

            }
        }

        private void EditPanel_Delete(object sender, EventArgs e)
        {
            try
            {
                if(LB.SelectedIndex != -1)
                {
                    if(Message.Show("هل تريد حذف هذا العميل", MessageBoxButton.YesNoCancel, 5) == MessageBoxResult.Yes)
                    {
                        DB db = new DB("persons");

                        db.AddCondition("per_id", ((DataRowView)LB.SelectedItem)["per_id"]);

                        db.Delete();
                        Fill_Customers_LB();

                    }
                }
            }
            catch
            {

            }
        }

        private void Save_Panel_Save(object sender, EventArgs e)
        {
            try
            {

                if(Confirm.Check(Add_Update()))
                {

                    Form.Set_Style(Main_GD, Operations.View);

                    Main_GD.RowDefinitions[2].Height = new GridLength(0);

                    LB.IsEnabled = true;

                    int i = LB.SelectedIndex;


                    Fill_Customers_LB();

                    LB.SelectedIndex = i;
                }
            }

            catch
            {

            }
        }

        private void Save_Panel_Cancel(object sender, EventArgs e)
        {
            try
            {
                Form.Set_Style(Main_GD, Operations.View);
                Main_GD.RowDefinitions[2].Height = new GridLength(0);
                LB.IsEnabled = true;


            }
            catch
            {

            }
        }

        private void Name_Search_TB_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter_Customers_LB();
        }

        private void LB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Get_Accounts();
            }
            catch
            {

            }
        }

        private void Get_Accounts()
        {
            try
            {
                DB db = new DB();
                db.AddCondition("trs_date", From_DTP.Value.Value.Date, false, ">=", "SD");
                db.AddCondition("trs_date", To_DTP.Value.Value.Date, false, "<=", "ED");
                db.AddCondition("sup_id", LB.SelectedValue);
                db.AddCondition("per_id", ((DataRowView)LB.SelectedItem)["per_id"]);
                DataTable dt;
                if(Table == "customers")
                {
                    dt = db.SelectTable(@"select trs_total Debtor,trs_paid Creditor,0 balance,'بيع' des,trs_no,trs_date from transactions
                                          where trs_trn_id = 5 and trs_id_1=@sup_id and trs_date>=@SD and trs_date<=@ED union                                       
                                          Select 0,trs_paid,0 balance,'قسط',trs_no,trs_date from transactions 
                                          where trs_trn_id = 7 and trs_id_1=@per_id and trs_date>=@SD and trs_date<=@ED");
                  
                }
                else
                {
                    dt = db.SelectTable(@"select trs_paid Debtor,trs_total Creditor,0 balance,'شراء' des,trs_no,trs_date from transactions
                                          where trs_trn_id = 1 and trs_id_1=@sup_id and trs_date>=@SD and trs_date<=@ED union                                         
                                          Select trs_paid,0,0 balance,'قسط',trs_no,trs_date from transactions 
                                          where trs_trn_id = 8 and trs_id_1=@per_id and trs_date>=@SD and trs_date<=@ED");

                }
                DataRow dr = dt.NewRow();
                decimal balance = Get_Balance();
                dr["balance"] = balance;
                foreach(DataRow Row in dt.Rows)
                {
                    balance -= decimal.Parse(Row[0].ToString());
                    balance += decimal.Parse(Row[1].ToString());
                    Row["balance"] = balance;
                }
                dt.Rows.InsertAt(dr, 0);
                Account_DG.ItemsSource = dt.DefaultView; 
            }
            catch
            {

            }
        }

        private decimal Get_Balance()
        {
            decimal Balance = 0;
            try
            {
                DB db = new DB();
                db.AddCondition("trs_date", From_DTP.Value.Value.Date, false, "<", "SD");                
                db.AddCondition("per_id", ((DataRowView)LB.SelectedItem)["per_id"]);
                db.AddCondition("sup_id", LB.SelectedValue);
                if(Table == "customers")
                {
                    Balance = decimal.Parse(db.Select(@"select COALESCE(sum(trs_paid),0)-COALESCE(sum(trs_total),0) + (Select COALESCE(sum(trs_paid),0) from transactions 
                                                        where trs_trn_id = 7 and trs_id_1=@per_id and trs_date<@SD ) from transactions
                                                        where trs_trn_id = 5 and trs_id_1=@sup_id and trs_date<@SD ").ToString());
                }
                else
                {
                    Balance = decimal.Parse(db.Select(@"select COALESCE(sum(trs_total),0)-COALESCE(sum(trs_paid),0) -(Select COALESCE(sum(trs_paid),0) from transactions 
                                                        where trs_trn_id = 8 and trs_id_1=@per_id and trs_date<@SD ) from transactions
                                                        where trs_trn_id = 1 and trs_id_1=@sup_id and trs_date<@SD").ToString());
                }




            }
            catch
            {

            }
            return Balance;
        }

        private void From_DTP_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            try
            {
                Get_Accounts();
            }
            catch
            {

            }
        }


        private void Fill_DG()
        {

            DB db = new DB();
            
            try
            {

                decimal total_payments = 0, total_bills = 0, total_paid = 0;

                DataTable dt2 = new DataTable();

                dt2.Columns.Add("date");
                dt2.Columns.Add("type");
                dt2.Columns.Add("paid_to_me");
                dt2.Columns.Add("suppose");


                db.AddCondition("pay_per_id", ((DataRowView)LB.SelectedItem)["per_id"]);
                DataTable ds = db.SelectTable(@"select * from payments");
                foreach (DataRow row2 in ds.Rows)
                {
                    total_payments += decimal.Parse(row2["pay_value"].ToString());
                    dt2.Rows.Add(row2["pay_date"], row2["قسط"], row2["pay_value"], row2[" "]);
                }



                DB db2 = new DB();
                db2.AddCondition("customer_id", LB.SelectedValue);
                DataTable dt = db.SelectTable(@"select * from sell");
                foreach (DataRow row in dt.Rows)
                {
                    total_bills += decimal.Parse(row["total"].ToString());
                    total_paid += decimal.Parse(row["paid"].ToString());

                    dt2.Rows.Add(row["date"], row["فاتوره بيع"], row["paid"], row["total"]);
                }




                dt2.Rows.Add("", "الرصيد", (total_bills - (total_paid + total_payments)), "");


            }
            catch
            {
                
                
            }
        }



    }
}
