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
    public partial class Income : Page
    {
        public Income()
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

                db.AddCondition("trs_date", From_DTP.Value.Value.Date, false, ">=", "SD");
                db.AddCondition("trs_date", To_DTP.Value.Value.Date, false, "<=", "ED");

                DataTable dt = db.SelectTable(@"select trs_no,trn_name,per_name,trs_date,trs_paid from transactions join transactions_names
                                                on trs_trn_id =trn_id left join persons on trs_id_1=per_id where trn_id in(2,5,7) ");

                dt.Rows.Add(null, "الاجمالى", null, null, dt.Compute("Sum(trs_paid)", ""));
                Income_DG.ItemsSource = dt.DefaultView;
            }
            catch
            {


            }
        }





    }
}
