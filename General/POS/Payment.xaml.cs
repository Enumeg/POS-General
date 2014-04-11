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
using System.Windows.Shapes;
using Source;
using System.Data;
using System.IO;

namespace POS
{
    /// <summary>
    /// Interaction logic for outcome.xaml
    /// </summary>
    public partial class Payment : Window
    {

        object Payment_Id;
        Transactions_Types Transaction;
        // customer = 7
        // Supplier = 8

        public int Payment_type = 5;  // customer  = 5
                                      // supplier = 6

        public Payment(Transactions_Types transaction_type, object payment_id = null)
        {
            InitializeComponent();

            Payment_Id = payment_id;
            Transaction = transaction_type;
            //Get_New_No();
            
            if(Transaction == Transactions_Types.Cust)
            {
                Customers.Get_All_Customers(Person_CB, "customers");
            }
            else
            {
                Payment_type = 6;

                Person_TK.Text = "المورد";
                Suppliers.Get_All_Suppliers(Person_CB);
            }
            if(Payment_Id != null)
            {
                Get_Payment();
            }
        }

        private void Get_Payment()
        {
            try
            {
                DB db2 = new DB("payments");

                db2.SelectedColumns.Add("*");

                db2.AddCondition("pay_id", Payment_Id);

                DataRow DR = db2.SelectRow();

                Date_DTP.Value = DateTime.Parse(DR["pay_date"].ToString());
                Person_CB.SelectedValue = DR["pay_per_id"];
                Value_TB.Text = DR["pay_value"].ToString();
                //No_TB.Text = DR["trs_No"].ToString();
            }
            catch
            {


            }
        }

        public bool Add_Update()
        {
            try
            {

                DB DataBase = new DB("payments");
                //DataBase.AddColumn("trs_no", No_TB.Text.Trim());
                DataBase.AddColumn("pay_trn_id", Payment_type);
                DataBase.AddColumn("pay_per_id", Person_CB.SelectedValue);
                DataBase.AddColumn("pay_date", Date_DTP.Value.Value.Date);
                DataBase.AddColumn("pay_value", Value_TB.Text.Trim());

                if(this.Payment_Id == null)
                {
                    if (DataBase.IsNotExist("pay_id", "pay_per_id", "pay_trn_id", "pay_date", "pay_value"))
                    {
                        return Confirm.Check(DataBase.Insert());
                    }
                    else
                    {
                        // ye3ny hwa mawgood asln mesh ha3ml 7aga 
                        Message.Show("هذا المستند موجود من قبل", MessageBoxButton.OK, 5);
                        return false;
                        //DataBase.AddCondition("pl_id", this.placeId);
                        //DataBase.Update();

                    }


                }

// hena ye3ny hwa mawgod ba3mel edit
                else
                {
                    DataBase.AddCondition("pay_id", this.Payment_Id);
                    return Confirm.Check(DataBase.Update());
                }
            }
            catch
            {
                return Confirm.Check(false);
            }
        }

        private void add_update_Payment_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if(Add_Update())
                {
                    if((bool)New.IsChecked)
                    {
                        Value_TB.Text = "";
                        Person_CB.SelectedIndex = -1;

                    }
                    else
                    {
                        this.Close();
                    }
                }


            }
            catch
            {

            }
        }

        //private void Get_New_No()
        //{
        //    string No = "";
        //    try
        //    {
        //        DB d = new DB();
        //        d.AddCondition("Month", Date_DTP.Value.Value.Month);
        //        d.AddCondition("Year", Date_DTP.Value.Value.Year);
        //        No = d.Select("select Max(trs_no) from transactions where Month(trs_date)=@Month and Year(trs_date)=@Year ").ToString();
        //        No_TB.Text = No == "" ? Date_DTP.Value.Value.ToString("yyMM") + "0001" : (int.Parse(No) + 1).ToString();
        //    }
        //    catch
        //    {

        //    }
        //}

        //close class
    }
}
