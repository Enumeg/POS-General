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
    public partial class Loans : Page
    {
        public Loans()
        {
            InitializeComponent();
        }

        private void From_DTP_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            try
            {
                if(this.IsLoaded)
                {
                    Fill_DG();
                }
            }
            catch
            {

            }
        }

        private void Fill_DG()
        {

            try
            {
                DB db = new DB();

                db.AddCondition("pay_date", From_DTP.Value.Value.Date, false, ">=", "SD");
                db.AddCondition("pay_date", To_DTP.Value.Value.Date, false, "<=", "ED");

                DataSet ds = db.SelectSet(@"select * from payments p join persons pp on p.pay_per_id=pp.per_id where pay_trn_id=5 and pay_date>=@SD and pay_date<=@ED;
                                            select * from payments p join persons pp on p.pay_per_id=pp.per_id where pay_trn_id=6 and pay_date>=@SD and pay_date<=@ED");

                ds.Tables[0].Rows.Add( null, null, ds.Tables[0].Compute("Sum(pay_value)", ""), "الاجمالى");
                ds.Tables[1].Rows.Add( null, null, ds.Tables[1].Compute("Sum(pay_value)", ""), "الاجمالى");

                Income_DG.ItemsSource = ds.Tables[0].DefaultView;

                Outcome_DG.ItemsSource = ds.Tables[1].DefaultView;
            
            }
            catch
            {


            }
        }

        #region Income

        private void Income_EP_Add(object sender, EventArgs e)
        {
            try
            {
                Payment o = new Payment(Transactions_Types.Cust);
                o.ShowDialog();
                Fill_DG();
            }
            catch
            {


            }
        }

        private void Income_EP_Edit(object sender, EventArgs e)
        {
            try
            {
                Payment o = new Payment(Transactions_Types.Cust, ((DataRowView)Income_DG.SelectedItem)["pay_id"]);
                o.ShowDialog();
                Fill_DG();
            }
            catch
            {


            }
        }

        private void Income_EP_Delete(object sender, EventArgs e)
        {
            try
            {
                if(Message.Show("هل تريد الحذف", MessageBoxButton.YesNoCancel, 5) == MessageBoxResult.Yes)
                {
                    DB d = new DB("payments");
                    d.AddCondition("pay_id", ((DataRowView)Income_DG.SelectedItem)["pay_id"]);
                    d.Delete();
                    Fill_DG();
                }

            }
            catch
            {


            }
        }

        #endregion


        #region Outcome

        private void Outcome_EP_Add(object sender, EventArgs e)
        {
            try
            {
                Payment o = new Payment(Transactions_Types.Sup);
                o.ShowDialog();
                Fill_DG();
            }
            catch
            {

            }
        }
        private void Outcome_EP_Edit(object sender, EventArgs e)
        {
            try
            {
                Payment o = new Payment(Transactions_Types.Sup, ((DataRowView)Outcome_DG.SelectedItem)["pay_id"]);
                o.ShowDialog();
                Fill_DG();
            }
            catch
            {

            }
        }
        private void Outcome_EP_Delete(object sender, EventArgs e)
        {
            try
            {
                if(Message.Show("هل تريد الحذف", MessageBoxButton.YesNoCancel, 5) == MessageBoxResult.Yes)
                {
                    DB d = new DB("payments");
                    d.AddCondition("pay_id", ((DataRowView)Outcome_DG.SelectedItem)["pay_id"]);
                    d.Delete();
                    Fill_DG();
                }

            }
            catch
            {


            }
        }

        #endregion


    }
}
