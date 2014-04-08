using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using Source;

namespace POS
{
    /// <summary>
    /// Interaction logic for Product.xaml
    /// </summary>
    public partial class Employees : Page
    {
        public Employees()
        {
            InitializeComponent();

            jobs.Get_All_Jobs(Job_CB);

            jobs.Get_All_Jobs(Job_Search_CB, "All");

            Fill_Employees_LB();


        }

        private void Fill_Employees_LB()
        {

            try
            {
                DB db2 = new DB("employees");

                // search by name
                db2.AddCondition("per_name", "%" + Name_Search_TB.Text + "%", false, " like ");

                // search by mobile
                db2.AddCondition("per_phone", "%" + Mobile_Search_TB.Text + "%", false, " like ");

                // search by Job
                db2.AddCondition("emp_job_id", Job_Search_CB.SelectedValue, Job_Search_CB.SelectedIndex < 1, "=", "emp_job_id");



                db2.Fill(LB, "emp_id", "per_name", @"select * from employees e join persons p on p.per_id=e.emp_per_id join jobs j on j.job_id=e.emp_job_id");

            }
            catch
            {

            }

        }

        public static void Get_All_employees(ComboBox CB, int job = 0, string All = "")
        {

            try
            {
                DB db2 = new DB("employees");

                db2.AddCondition("emp_job_id", job, job == 0);

                db2.Fill(CB, "emp_id", "per_name", "select emp_id,per_name from employees e join persons p on p.per_id=e.emp_per_id join jobs j on j.job_id=e.emp_job_id", All);
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



                DB db2 = new DB("employees");

                db2.AddColumn("emp_job_id", Job_CB.SelectedValue);
                db2.AddColumn("emp_salary", Salary_TB.Text.Trim());


                if(LB.SelectedIndex == -1)
                {
                    db2.AddColumn("emp_per_id", db1);
                    return db2.Execute_Queries(db1, db2);
                }
                else
                {
                    db1.AddCondition("per_id", ((DataRowView)LB.SelectedItem)["per_id"]);
                    db2.AddCondition("emp_id", LB.SelectedValue);


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
                Main_GD.RowDefinitions[3].Height = new GridLength(35);
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
                Main_GD.RowDefinitions[3].Height = new GridLength(35);
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
                    if(Message.Show("هل تريد حذف هذا الموظف", MessageBoxButton.YesNoCancel, 5) == MessageBoxResult.Yes)
                    {
                        DB db = new DB("persons");

                        db.AddCondition("per_id", ((DataRowView)LB.SelectedItem)["per_id"]);

                        db.Delete();
                        Fill_Employees_LB();

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

                    Main_GD.RowDefinitions[3].Height = new GridLength(0);

                    LB.IsEnabled = true;

                    int i = LB.SelectedIndex;


                    Fill_Employees_LB();

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
                Main_GD.RowDefinitions[3].Height = new GridLength(0);
                LB.IsEnabled = true;
            }
            catch
            {

            }
        }

        private void Job_Search_CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Fill_Employees_LB();
        }
       
        private void Name_Search_TB_TextChanged(object sender, TextChangedEventArgs e)
        {
            Fill_Employees_LB();
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
