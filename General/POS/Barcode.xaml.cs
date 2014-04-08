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
using System.Windows.Shapes;
using System.Data;
using System.Drawing.Printing;
using System.Drawing;

namespace POS
{
    /// <summary>
    /// Interaction logic for Barcode.xaml
    /// </summary>
    public partial class Barcode : Window
    {
        PrintDocument PD;
        DataRowView Product;
        public Barcode(DataRowView product)
        {
            InitializeComponent();
            Product = product;
            PD = new PrintDocument();
            PD.DefaultPageSettings.Margins = new Margins(6, 2, 2, 0);
            PD.DefaultPageSettings.PaperSize = new PaperSize("User Defined", 150, 100);
            PD.PrintPage += new PrintPageEventHandler(PD_PrintPage);
            Amount_TB.Text = Product["pro_limit"].ToString().Split('.')[0];
        }

        private void Add_Update_Product_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                short Amount = short.Parse(Amount_TB.Text);
                double re = Amount / 2.0;
                PD.PrinterSettings.Copies = Math.Floor(re) - re != 0 ? (short)((Amount + 1) / 2) : (short)(Amount / 2);
                PD.Print();
            }
            catch
            {

            }
        }
        private void PD_PrintPage(object sender, PrintPageEventArgs e)
        {
            StringFormat sf = new StringFormat(StringFormatFlags.DirectionRightToLeft);
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Near;
            StringFormat sf1 = new StringFormat();
            sf1.Alignment = StringAlignment.Far;
            sf1.LineAlignment = StringAlignment.Near;

            System.Drawing.Size s = e.Graphics.MeasureString(Product["pro_name"].ToString(), new System.Drawing.Font("Arial", 6, System.Drawing.FontStyle.Bold)).ToSize();

            e.Graphics.DrawString("Shalaby Trade", new System.Drawing.Font("Cambria", 8, System.Drawing.FontStyle.Bold), System.Drawing.Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top + 3);
            e.Graphics.DrawString("*" + Product["pro_serial"].ToString() + "-0001" + "*", new System.Drawing.Font("Bar-Code 39", 12), System.Drawing.Brushes.Black, e.MarginBounds.Right, e.MarginBounds.Top + 16, sf1);
            e.Graphics.DrawString(Product["pro_name"].ToString(), new System.Drawing.Font("Arial", 6, System.Drawing.FontStyle.Bold), System.Drawing.Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top + 36);
            e.Graphics.DrawString(Product["pro_sell"].ToString(), new System.Drawing.Font("Tahoma", 6, System.Drawing.FontStyle.Bold), System.Drawing.Brushes.Black, e.MarginBounds.Right, e.MarginBounds.Top + 36, sf);

            e.Graphics.DrawString("Shalaby Trade", new System.Drawing.Font("Cambria", 8, System.Drawing.FontStyle.Bold), System.Drawing.Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top + 52);
            e.Graphics.DrawString("*" + Product["pro_serial"].ToString() + "-0001" + "*", new System.Drawing.Font("Bar-Code 39", 12), System.Drawing.Brushes.Black, e.MarginBounds.Right, e.MarginBounds.Top + 65, sf1);
            e.Graphics.DrawString(Product["pro_name"].ToString(), new System.Drawing.Font("Arial", 6, System.Drawing.FontStyle.Bold), System.Drawing.Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top + 85);
            e.Graphics.DrawString(Product["pro_sell"].ToString(), new System.Drawing.Font("Tahoma", 6, System.Drawing.FontStyle.Bold), System.Drawing.Brushes.Black, e.MarginBounds.Right, e.MarginBounds.Top + 85, sf);

        }

    }
}
