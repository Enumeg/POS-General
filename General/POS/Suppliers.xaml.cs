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
    public partial class Suppliers : Page
    {
        public Suppliers()
        {
            InitializeComponent();
            Fill_Supplier_LB();
        }

        private void Fill_Supplier_LB()
        {

            try
            {
                DB db2 = new DB("suppliers");

                // search by name
                db2.AddCondition("per_name", "%" + Name_Search_TB.Text + "%", false, " like ");

                // search by mobile
                db2.AddCondition("per_phone", "%" + Mobile_Search_TB.Text + "%", false, " like ");


                db2.Fill(LB, "sup_id", "per_name", @"select * from suppliers sup join persons per on sup.sup_per_id=per.per_id");

            }
            catch
            {

            }

        }

        public static void Get_All_Suppliers(ComboBox CB,string All = "")
        {

            try
            {
                DB db2 = new DB("suppliers");


                db2.Fill(CB, "per_id", "per_name", "select per_id,per_name from suppliers sup join persons per on sup.sup_per_id=per.per_id", All);
            }

            catch
            {

            }


        }

        private bool Add_Update()
        {

            try
            {

                DB db1 = new DB("persons");

                db1.AddColumn("per_name", Name_TB.Text.Trim());
                db1.AddColumn("per_address", Address_TB.Text.Trim());
                db1.AddColumn("per_phone", Telephone_TB.Text.Trim());
                db1.AddColumn("per_mobile", Mobile_TB.Text.Trim());



                DB db2 = new DB("suppliers");

                db2.AddColumn("sup_balance", Balance_TB.Text.Trim());
                

                if (LB.SelectedIndex == -1)
                {
                    db2.AddColumn("sup_per_id", db1);
                    return db2.Execute_Queries(db1, db2);
                }
                else
                {
                    db1.AddCondition("per_id", ((DataRowView)LB.SelectedItem)["per_id"]);
                    db2.AddCondition("sup_id", LB.SelectedValue);
                    
                    
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
                    if(Message.Show("هل تريد حذف هذا المورد", MessageBoxButton.YesNoCancel, 5) == MessageBoxResult.Yes)
                    {
                        DB db = new DB("persons");

                        db.AddCondition("per_id", ((DataRowView)LB.SelectedItem)["per_id"]);

                        db.Delete();
                        Fill_Supplier_LB();

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
                    Fill_Supplier_LB();
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
            Fill_Supplier_LB();
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


       

       

    }
}
