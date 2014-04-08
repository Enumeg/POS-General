using System;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Source;

namespace POS
{
    /// <summary>
    /// Interaction logic for daily_report.xaml
    /// </summary>
    public partial class Attendence : Page
    {
        public Attendence()
        {
            InitializeComponent();
            //Fill ComboBoxes
        }


        private void Fill_DG()
        {
            DB db = new DB();
            try
            {
                db.AddCondition("att_date", Date_DTP.Value.Value.Date);

                Attendence_DG.ItemsSource = db.SelectTableView(@"SELECT att_id,time_format(att_attend,'%h:%i %p')  att_attend,time_format(att_leave,'%h:%i %p') att_leave,per_name
                                                                 FROM attendence
                                                                 JOIN employees ON att_emp_id=emp_id
                                                                 JOIN person ON per_id=emp_per_id");

            }
            catch
            {

            }
        }

        private void From_DTP_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            try
            {
                if(this.IsLoaded)
                    Fill_DG();
            }
            catch
            {

            }
        }

        private void Print_BTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //CPrinting.CPrinting Printer = new CPrinting.CPrinting();
                //Printer.Get_Printed_Table(Attendence_DG);
                //Printer.PrintDocument.DefaultPageSettings.Landscape = true;
                //Printer.header.Add("تقرير الحضور والإنصراف عن يوم  " + Date_DTP.Text);
                //Printer.print();
            }
            catch
            {

            }
        }


        private void EditPanel_Add(object sender, EventArgs e)
        {
            try
            {
                Add_Update_Attendence a = new Add_Update_Attendence();
                a.ShowDialog();
                Fill_DG();
            }
            catch
            {

            }
        }

        private void EditPanel_Edit(object sender, EventArgs e)
        {
            try
            {
                Add_Update_Attendence a = new Add_Update_Attendence(((DataRowView)Attendence_DG.SelectedItem)[0]);
                a.ShowDialog();
                Fill_DG();
            }
            catch
            {

            }
        }

        private void EditPanel_Delete(object sender, EventArgs e)
        {
            try
            {
                if(Message.Show("هل تريد الحذف", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
                {
                    DB DataBase = new DB("attendence");
                    DataBase.AddCondition("att_id", ((DataRowView)Attendence_DG.SelectedItem)[0]);
                    DataBase.Delete();
                    Fill_DG();
                }
            }
            catch
            {

            }
        }


    }
}
