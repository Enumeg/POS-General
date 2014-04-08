using System;
using System.Windows;
using System.Windows.Controls;
using Source;
using System.Data;


namespace POS
{
    /// <summary>
    /// Interaction logic for Properties.xaml
    /// </summary>
    public partial class Propertiess : Window
    {
        object Property_Id;

        public Propertiess()
        {
            InitializeComponent();
            Categories.Get_All_Categories(Categories_CB, " ");
            Fill_Properties_LB();
        }

        private void Fill_Properties_LB()
        {
            try
            {
                DB db = new DB("Properties");
                db.AddCondition("prp_name", Property_TB.Text.Trim(), false, " like ");
                db.AddCondition("prp_cat_id", Categories_CB.SelectedValue, Categories_CB.SelectedIndex < 1);
                db.SelectedColumns.Add("*");
                db.Fill(LB, "prp_id", "prp_name");
            }
            catch
            {

            }
        }

        public static DataTable Get_Category_Properties(object cat_id)
        {
            try
            {
                DB db = new DB();
                db.AddCondition("prp_cat_id", cat_id);
                return db.SelectTable("select * from properties where prp_Cat_id=@prp_cat_id or prp_cat_id is null ");
            }
            catch
            {
                return null;
            }
        }

        public static void Get_All_Properties(ComboBox CB, string All = "")
        {
            try
            {
                DB db = new DB("Properties");
                db.SelectedColumns.Add("*");
                db.Fill(CB, "prp_id", "prp_name", "", All);
            }
            catch
            {

            }
        }

        private bool Add_Update()
        {
            try
            {

                DB DataBase = new DB("Properties");

                DataBase.AddColumn("prp_name", Property_TB.Text.Trim());
                DataBase.AddColumn("prp_cat_id", Categories_CB.SelectedValue, Categories_CB.SelectedIndex < 1);

                if(Property_Id == null)
                {
                    if(Categories_CB.SelectedIndex < 1)
                    {
                        if(DataBase.IsNotExist("prp_id", "prp_name"))
                        {
                            return Confirm.Check(DataBase.Insert());
                        }
                        else
                        {
                            Message.Show("لقد تم تسجيل هذه الصفة من قبل", MessageBoxButton.OK, 5);
                            return false;
                        }
                    }
                    else
                    {
                        if(DataBase.IsNotExist("prp_id", "prp_name", "prp_cat_id"))
                        {
                            return Confirm.Check(DataBase.Insert());
                        }
                        else
                        {
                            Message.Show("لقد تم تسجيل هذه الصفة من قبل", MessageBoxButton.OK, 5);
                            return false;
                        }
                    }



                }
                else
                {
                    DataBase.AddCondition("prp_id", this.Property_Id);
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
                    Fill_Properties_LB();
                    Property_Id = null;
                    Property_TB.Text = "";
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
                Fill_Properties_LB();
                Property_Id = null;
                Property_TB.Text = "";
            }
            catch
            {

            }
        }

        private void EditPanel_Add(object sender, EventArgs e)
        {
            try
            {
                Property_Id = null;
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
                Property_Id = LB.SelectedValue;
                Property_TB.Text = ((DataRowView)LB.SelectedItem)[1].ToString();
                Main_GD.RowDefinitions[2].Height = new GridLength(35);
            }
            catch
            {

            }
        }

        private void EditPanel_Delete(object sender, EventArgs e)
        {

            try
            {
                if(Message.Show("هل تريد حذف هذه المجموعة", MessageBoxButton.YesNoCancel, 10) == MessageBoxResult.Yes)
                {
                    Property_Id = LB.SelectedValue;
                    DB db = new DB("Properties");
                    db.AddCondition("prp_id", Property_Id);
                    db.Delete();
                    Fill_Properties_LB();
                }
            }
            catch
            {

            }
        }

        private void Property_TB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Fill_Properties_LB();
            }
            catch
            {

            }
        }

        private void Categories_CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Fill_Properties_LB();
            }
            catch
            {

            }
        }

    }
}
