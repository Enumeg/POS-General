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
using Source;
using System.Data;

namespace POS
{
    /// <summary>
    /// Interaction logic for accounting.xaml
    /// </summary>
    public partial class Bank_Page : Page
    {

        public Bank_Page()
        {
            InitializeComponent();
        }

        private void From_DTP_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            try
            {
                if(this.IsLoaded)
                {
                    Fill_Bank();
                }
            }
            catch
            {

            }
        }


        #region Bank

        private void Fill_Bank()
        {

            try
            {
                DB db2 = new DB();

                db2.AddCondition("bnk_date", From_DTP.Value.Value.Date, false, ">=", "SD");
                db2.AddCondition("bnk_date", To_DTP.Value.Value.Date, false, "<=", "ED");

                DataTable dt = db2.SelectTable(@"select bnk_id,bnk_date,if(bnk_trn_id=9,bnk_value,null) value1,if(bnk_trn_id=10,bnk_value,null) value2, bnk_description from bank");              
                dt.Rows.Add(null, null, dt.Compute("Sum(value1)", ""), dt.Compute("Sum(value2)", ""), "الإجمالي");

                Bank_DG.ItemsSource = dt.DefaultView;

            }
            catch
            {

            }
        }

        private void Bank_EP_Add(object sender, EventArgs e)
        {
            try
            {
                Bank o = new Bank();
                o.ShowDialog();
                Fill_Bank();
            }
            catch
            {

            }
        }
        private void Bank_EP_Edit(object sender, EventArgs e)
        {
            try
            {
                Bank o = new Bank(((DataRowView)Bank_DG.SelectedItem)["bnk_id"]);
                o.ShowDialog();
                Fill_Bank();
            }
            catch
            {

            }
        }
        private void Bank_EP_Delete(object sender, EventArgs e)
        {
            try
            {
                if(Message.Show("هل تريد الحذف", MessageBoxButton.YesNoCancel, 5) == MessageBoxResult.Yes)
                {
                    DB d = new DB("bank");
                    d.AddCondition("bnk_id", ((DataRowView)Bank_DG.SelectedItem)["bnk_id"]);
                    d.Delete();
                    Fill_Bank();
                }
            }
            catch
            {

            }
        }

        #endregion



    }
}
