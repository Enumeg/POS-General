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
    public partial class Outcome_Page : Page
    {

        public Outcome_Page()
        {
            InitializeComponent();
        }

        private void From_DTP_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            try
            {
                if(this.IsLoaded)
                {

                    Fill_Outcome();

                }
            }
            catch
            {

            }
        }


        #region OutCOme

        private void Fill_Outcome()
        {

            try
            {                
                DB db2 = new DB();
                db2.AddCondition("out_date", From_DTP.Value.Value.Date, false, ">=", "SD");
                db2.AddCondition("out_date", To_DTP.Value.Value.Date, false, "<=", "ED");
                DataTable dt = db2.SelectTable(@"select * from outcome outt join outcome_types outtt on outt.out_ott_id=outtt.ott_id
                                                  left join points pon on pon.pon_id=outt.out_pon_id");
                dt.Rows.Add(null, null,  dt.Compute("Sum(out_value)", ""), "الاجمالى");

                Outcome_DG.ItemsSource = dt.DefaultView;

            }
            catch
            {

            }
        }

        private void Outcome_EP_Add(object sender, EventArgs e)
        {
            try
            {
                Outcome o = new Outcome();
                o.ShowDialog();
                Fill_Outcome();
            }
            catch
            {

            }
        }
        private void Outcome_EP_Edit(object sender, EventArgs e)
        {
            try
            {
                Outcome o = new Outcome(((DataRowView)Outcome_DG.SelectedItem)["id"]);
                o.ShowDialog();
                Fill_Outcome();
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
                    DB d = new DB("outcome");
                    d.AddCondition("out_id", ((DataRowView)Outcome_DG.SelectedItem)["id"]);
                    d.Delete();
                    Fill_Outcome();
                }
            }
            catch
            {

            }
        }

        #endregion



    }
}
