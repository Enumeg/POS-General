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
    /// Interaction logic for Bank.xaml
    /// </summary>
    public partial class Bank : Window
    {

        object Bank_Id = null;

        public Bank(object bank_id = null)
        {
            InitializeComponent();

            Bank_Id = bank_id;

            Type_CB.ItemsSource = Enum.GetValues(typeof(Bank_Types));

            if(Bank_Id != null)
            {
                Get_Bank();

            }


        }

        private void Get_Bank()
        {
            try
            {
                DB db2 = new DB("bank");

                db2.SelectedColumns.Add("*");

                db2.AddCondition("bnk_id", Bank_Id);

                DataRow DR = db2.SelectRow();

                Date_TB.Value = DateTime.Parse(DR["bnk_date"].ToString());
                Type_CB.Text = Enum.GetName(typeof(Bank_Types), int.Parse(DR["bnk_trn_id"].ToString()));
                Value_TB.Text = DR["bnk_value"].ToString();
                Description_TB.Text = DR["bnk_description"].ToString();

            }
            catch
            {


            }
        }

        private void add_update_Bank_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if(Add_Update())
                {
                    if((bool)New.IsChecked)
                    {
                        Form.Set_Style(this, Operations.Add);
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

        public bool Add_Update()
        {
            try
            {

                DB DataBase = new DB("bank");

                DataBase.AddColumn("bnk_date", Date_TB.Text);
                DataBase.AddColumn("bnk_value", Value_TB.Text);
                DataBase.AddColumn("bnk_description", Description_TB.Text);


                DataBase.AddColumn("bnk_trn_id", Type_CB.SelectedValue);


                if(this.Bank_Id == null)
                {
                    if(DataBase.IsNotExist("bnk_id", "bnk_date", "bnk_value", "bnk_trn_id", "bnk_description"))
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
                    DataBase.AddCondition("bnk_id", this.Bank_Id);
                    return Confirm.Check(DataBase.Update());
                }
            }
            catch
            {
                return Confirm.Check(false);
            }
        }


        //close class
    }
}
