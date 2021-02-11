using System.Configuration;
using System.Windows;
using Source;
using System.Globalization;

namespace POS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public enum BankTypes { إيداع = 9, سحب = 10 }
    public enum TransactionsTypes { Buy = 1, BuyBack = 2, Transfer = 3, Depreciation = 4, Sell = 5, SellBack = 6, Cust = 7, Sup = 8 }
    public partial class App 
    {
        public static object UserId;
        public static object GroupId = 1;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var c = new CultureInfo("ar-EG");
            var n = new NumberFormatInfo {DigitSubstitution = DigitShapes.NativeNational};
            c.NumberFormat = n;
            System.Threading.Thread.CurrentThread.CurrentCulture = c;
            DB.ConnectionString = ConfigurationManager.ConnectionStrings["POS.Properties.Settings.Con"];
            try
            {
                DB.OpenConnection();
                //if(System.DateTime.Now < new System.DateTime(2013, 9, 15))
                //{
                //   
                //   
                //}
                //else
                //{
                //    Application.Current.Shutdown();
                //}
                Window w = new Managent();
                w.ShowDialog();
            }
            catch
            {
                // ignored
            }
        }
    }
}
