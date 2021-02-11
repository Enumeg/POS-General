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
        TransactionsTypes Transaction;
        // customer = 7
        // Supplier = 8

        public Payment(TransactionsTypes transaction_type, object payment_id = null)
        {
            InitializeComponent();

            Payment_Id = payment_id;
            Transaction = transaction_type;
            Get_New_No();
            if(Transaction == TransactionsTypes.Cust)
            {
                Customers.Get_All_Customers(Person_CB, "customers");
            }
            else
            {
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
                DB db2 = new DB("Transactions");

                db2.SelectedColumns.Add("*");

                db2.AddCondition("trs_id", Payment_Id);

                DataRow DR = db2.SelectRow();

                Date_DTP.Value = DateTime.Parse(DR["trs_date"].ToString());
                Person_CB.SelectedValue = DR["trs_id_1"];
                Value_TB.Text = DR["trs_paid"].ToString();
                No_TB.Text = DR["trs_No"].ToString();
            }
            catch
            {


            }
        }

        public bool Add_Update()
        {
            try
            {

                DB DataBase = new DB("transactions");
                DataBase.AddColumn("trs_no", No_TB.Text.Trim());
                DataBase.AddColumn("trs_trn_id", Transaction);
                DataBase.AddColumn("trs_id_1", Person_CB.SelectedValue);
                DataBase.AddColumn("trs_date", Date_DTP.Value.Value.Date);
                DataBase.AddColumn("trs_paid", Value_TB.Text.Trim());

                if(this.Payment_Id == null)
                {
                    if(DataBase.IsNotExist("trs_id", "trs_no", "trs_trn_id", "trs_date", "trs_paid", "trs_id_1"))
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
                    DataBase.AddCondition("trs_id", this.Payment_Id);
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

        private void Get_New_No()
        {
            string No = "";
            try
            {
                DB d = new DB();
                d.AddCondition("Month", Date_DTP.Value.Value.Month);
                d.AddCondition("Year", Date_DTP.Value.Value.Year);
                No = d.Select("select Max(trs_no) from transactions where Month(trs_date)=@Month and Year(trs_date)=@Year ").ToString();
                No_TB.Text = No == "" ? Date_DTP.Value.Value.ToString("yyMM") + "0001" : (int.Parse(No) + 1).ToString();
            }
            catch
            {

            }
        }

        //close class
    }
}
