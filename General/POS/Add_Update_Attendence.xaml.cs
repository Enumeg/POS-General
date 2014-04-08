using System;
using System.Data;
using System.Windows;
using Source;

namespace POS
{
    /// <summary>
    /// Interaction logic for Add_Update_Attendence.xaml
    /// </summary>
    public partial class Add_Update_Attendence : Window
    {
        object Attendence_Id;

        public Add_Update_Attendence(object attendence_Id = null)
        {
            InitializeComponent();

            Attendence_Id = attendence_Id;

            Employees.Get_All_employees(Employees_CB);

            if(attendence_Id != null)
            {
                Get_Attendence_Info();
            }
        }

        private void Get_Attendence_Info()
        {
            try
            {
                DB db2 = new DB("Attendence");

                db2.SelectedColumns.Add("*");

                db2.AddCondition("Att_id", Attendence_Id);

                DataRow DR = db2.SelectRow();

                Employees_CB.SelectedValue = DR["att_emp_id"];

                Date_DTP.Value = DateTime.Parse(DR["att_date"].ToString());

                Attend_DTP.Value = new DateTime(TimeSpan.Parse(DR["att_attend"].ToString()).Ticks);

                Leave_DTP.Value = DR["att_leave"].ToString() != "" ? new DateTime(TimeSpan.Parse(DR["att_leave"].ToString()).Ticks) : Leave_DTP.Value;

            }
            catch
            {


            }
        }

        private bool Add_Update()
        {
            try
            {

                DB DataBase = new DB("attendence");

                DataBase.AddColumn("att_emp_id", Employees_CB.SelectedValue);
                DataBase.AddColumn("att_date", Date_DTP.Value.Value.Date);
                DataBase.AddColumn("att_attend", Attend_DTP.Value.Value.TimeOfDay);
                DataBase.AddColumn("att_leave", null);
                DataBase.AddColumn("att_time", null);
                if(Leave_DTP.Value != null)
                {
                    DataBase.Columns_Values[3].Value = Leave_DTP.Value.Value.TimeOfDay;
                    DataBase.Columns_Values[4].Value = Attend_DTP.Value.Value.TimeOfDay <= Leave_DTP.Value.Value.TimeOfDay ?
                                                       Leave_DTP.Value.Value.TimeOfDay - Attend_DTP.Value.Value.TimeOfDay :
                                                       Leave_DTP.Value.Value.TimeOfDay.Add(new TimeSpan(24, 0, 0)) - Attend_DTP.Value.Value.TimeOfDay;
                }
                if(Attendence_Id == null)
                {
                    if(DataBase.IsNotExist("att_id", "att_emp_id", "att_date"))
                    {
                        return DataBase.Insert();
                    }
                    else
                    {
                        Message.Show("هذا الاسم مستخدم من قبل", MessageBoxButton.OK, 5);
                        return false;
                    }
                }
                else
                {
                    DataBase.AddCondition("att_Id", this.Attendence_Id);
                    return DataBase.Update();
                }

            }
            catch
            {
                return false;
            }
        }

        private void Add_Update_Attendence_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Check for required inputs
                if(Notify.validate("من فضلك اختار الموظف", Employees_CB.SelectedIndex, this))
                {
                    return;
                }
                if(Notify.validate("من فضلك ادخل التاريخ", Date_DTP.Text, this))
                {
                    return;
                }
                if(Notify.validate("من فضلك ادخل وقت الحضور", Attend_DTP.Value.ToString(), this))
                {
                    return;
                }
                //try to add or update return true if ok
                if(Confirm.Check(Add_Update()))
                {
                    //check New checkBox status
                    if((bool)New.IsChecked)
                    {
                        //clear inputs
                    }
                    else
                    {
                        //close window
                        this.Close();
                    }
                }
            }
            catch
            {

            }
        }

    }
}
