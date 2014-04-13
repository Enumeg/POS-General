using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.Generic;
using Source;
using System.Drawing;
using System.Drawing.Printing;


namespace POS
{
    /// <summary>
    /// Interaction logic for Product.xaml
    /// </summary>
    public partial class Transactions : Page
    {
        Transactions_Types Transaction;
        DataTable Transactions_Details;
        List<string> Pro_IDS;
        PrintDocument PD1;
        public Transactions(Transactions_Types transaction)
        {
            InitializeComponent();
            Pro_IDS = new List<string>();
            Transaction = transaction;
            Products.Get_All_Products(Product_CB, "البحث");
            Fill_Transactions_LB();
            Get_Transactions_Details_Table();
            PD1 = new PrintDocument();
            PD1.PrintPage += new PrintPageEventHandler(PD1_PrintPage);          
            Initialize_Page();
        }

        private void Initialize_Page()
        {
            try
            {
                if (Transaction == Transactions_Types.Buy)
                {
                    Totals_GD.ColumnDefinitions[6].Width = new GridLength(1, GridUnitType.Star);
                }
                switch (Transaction)
                {
                    case Transactions_Types.Buy:
                    case Transactions_Types.Buy_Back:
                        Search_var1_TK.Text = var1_TK.Text = "المــــــورد :";
                        Search_var2_TK.Text = var2_TK.Text = "المخـــزن :";
                        Customers.Get_All_Customers(Search_var1_CB, "Suppliers", "الكل");
                        Customers.Get_All_Customers(Var1_CB, "Suppliers");
                        //Points.Get_All_Points(Search_var2_CB, 1, "الكل");
                        //Points.Get_All_Points(Var2_CB);
                        Price_TB.IsReadOnly = false;
                        break;
                    case Transactions_Types.Sell:
                    case Transactions_Types.Sell_Back:
                        Search_var1_TK.Text = var1_TK.Text = "العميـــــل :";
                        Search_var2_TK.Text = var2_TK.Text = "المعرض :";
                        Customers.Get_All_Customers(Search_var1_CB, "customers", "الكل");
                        Customers.Get_All_Customers(Var1_CB, "customers");
                        //Points.Get_All_Points(Search_var2_CB, 2, "الكل");
                        //Points.Get_All_Points(Var2_CB);
                        Edit_GD.ColumnDefinitions[4].Width = new GridLength(100);
                        break;
                    case Transactions_Types.Transfer:
                        Search_var1_TK.Text = var1_TK.Text = "مـــــــــــــــــن :";
                        Search_var2_TK.Text = var2_TK.Text = "إلــــــــــــــــى :";
                        //Points.Get_All_Points(Search_var1_CB, 0, "الكل");
                        //Points.Get_All_Points(Var1_CB);
                        //Points.Get_All_Points(Search_var2_CB, 0, "الكل");
                        //Points.Get_All_Points(Var2_CB);
                        Totals_GD.ColumnDefinitions[2].Width = Totals_GD.ColumnDefinitions[3].Width = Totals_GD.ColumnDefinitions[4].Width = Totals_GD.ColumnDefinitions[5].Width = new GridLength(0);
                        break;
                    case Transactions_Types.Depreciation:
                        Search_var1_TK.Text = var1_TK.Text = "مـــــــــــــــــن :";
                        Search_GD.RowDefinitions[3].Height = new GridLength(0);
                        Info_GD.ColumnDefinitions[6].Width = Info_GD.ColumnDefinitions[7].Width = new GridLength(0);
                        Totals_GD.ColumnDefinitions[2].Width = Totals_GD.ColumnDefinitions[3].Width = Totals_GD.ColumnDefinitions[4].Width = Totals_GD.ColumnDefinitions[5].Width = new GridLength(0);

                        //Points.Get_All_Points(Search_var1_CB, 0, "الكل");
                        //Points.Get_All_Points(Var1_CB);
                        break;
                }
                if (App.Group_ID.ToString() == "2")
                {
                    Main_GD.ColumnDefinitions[0].Width = new GridLength(0);
                    View_GD.RowDefinitions[4].Height = new GridLength(35);
                    Details_DG.ColumnHeaderHeight = 62;
                    Details_GD.RowDefinitions[1].Height = new GridLength(28);
                    Form.Set_Style(Info_GD, Operations.Add);
                    Form.Set_Style(Totals_GD, Operations.Add);
                    Details_DG.ItemsSource = null;
                    Transactions_Details.Rows.Clear();
                    Get_New_No();
                }

            }
            catch
            {

            }
        }

        private void Get_Transactions_Details()
        {
            try
            {
                DB DB = new DB();
                DB.AddCondition("trd_trs_id", Transactions_LB.SelectedValue);
                DataTable dt = DB.SelectTable(@"select trd_pro_id,pro_name,trd_amount,trd_price,trd_amount*trd_price trd_total
                                                            from transactions_Details join products on pro_id=trd_pro_id");
                Transactions_Details.Rows.Clear();
                Pro_IDS.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    Transactions_Details.Rows.Add(row.ItemArray);
                    Pro_IDS.Add(row["trd_pro_id"].ToString());
                }
                Details_DG.ItemsSource = Transactions_Details.DefaultView;
            }
            catch
            {

            }
        }

        private void Get_Transactions_Details_Table()
        {
            try
            {
                Transactions_Details = new DataTable();
                Transactions_Details.Columns.Add("trd_pro_id");
                Transactions_Details.Columns.Add("trd_pro_name");
                Transactions_Details.Columns.Add("trd_amount");
                Transactions_Details.Columns.Add("trd_price");
                Transactions_Details.Columns.Add("trd_total");
            }
            catch
            {

            }
        }

        private void Fill_Transactions_LB()
        {

            try
            {
                DB DB = new DB();
                DB.AddCondition("trs_trn_id", Transaction);
                DB.AddCondition("trs_no", Search_No_TB.Text, Search_No_TB.Text == "", " like ");
                DB.AddCondition("trs_id_1", Search_var1_CB.SelectedValue, Search_var1_CB.SelectedIndex < 1);
                DB.AddCondition("trs_id_2", Search_var2_CB.SelectedValue, Search_var2_CB.SelectedIndex < 1);
                if (Search_Date_DTP.Value != null) { DB.AddCondition("trs_date", Search_Date_DTP.Value.Value.Date); }
                DB.Fill(Transactions_LB, "trs_id", "trs_no", @"select * from transactions ");
            }
            catch
            {

            }

        }

        private void Get_New_No()
        {
            string No = "";
            try
            {
                DB d = new DB();
                d.AddCondition("Month", Date_DTP.Value.Value.Month);
                d.AddCondition("Year", Date_DTP.Value.Value.Year);
                No = d.Select("select Max(trs_no) from transactions where Month(trs_date)=@Month and Year(trs_date)=@Year ").ToString();
                No_TB.Text = No == "" ? Date_DTP.Value.Value.ToString("yyMM") + "0001" : (int.Parse(No) + 1).ToString();
            }
            catch
            {

            }
        }

        private void Get_Product_Price()
        {
            try
            {
                DB d = new DB();
                d.AddCondition("trd_pro_id", ((DataRowView)Product_CB.SelectedItem)[0]);
                object price = d.Select(@"SELECT COALESCE(trd_price,0) FROM transactions_details JOIN transactions ON trd_trs_id=trs_id
                                WHERE trs_trn_id =1 AND trd_pro_id =@trd_pro_id AND trs_date = (
                                SELECT MAX(trs_date) FROM transactions join transactions_details  ON trd_trs_id=trs_id
                                WHERE trs_trn_id =1 AND trd_pro_id =@trd_pro_id)");
                Price_TB.Text = price == null ? "0.00" : price.ToString();
            }
            catch
            {

            }
        }

        private void Get_Total()
        {
            decimal total = 0;
            try
            {
                foreach (DataRow row in Transactions_Details.Rows)
                {
                    total += decimal.Parse(row["trd_total"].ToString());
                }
                if (Paid_TB.Text == Total_TB.Text)
                {
                    Total_TB.Text = Paid_TB.Text = total.ToString("0.00");
                }
                else
                {
                    Total_TB.Text = total.ToString("0.00");
                    Paid_TB.Text = Paid_TB.Text == "" ? Total_TB.Text : Paid_TB.Text;
                }

                Rest_TB.Text = (total - decimal.Parse(Paid_TB.Text)).ToString("0.00");
            }
            catch
            {

            }
        }

        private bool Add_Update()
        {
            try
            {
                DB DB1 = new DB("transactions");

                DB1.AddColumn("trs_no", No_TB.Text.Trim());
                DB1.AddColumn("trs_trn_id", Transaction);
                DB1.AddColumn("trs_id_1", Var1_CB.SelectedValue, Var1_CB.SelectedValue == null);
                DB1.AddColumn("trs_id_2", Var2_CB.SelectedValue, Var2_CB.SelectedValue == null);
                DB1.AddColumn("trs_date", Date_DTP.Value.Value.Date);
                DB1.AddColumn("trs_total", Total_TB.Text.Trim());
                DB1.AddColumn("trs_paid", Paid_TB.Text.Trim());

                DB DB2 = new DB("transactions_details");
                DB2.Table = new DataTable();
                DB2.Table.Columns.Add("trd_trs_id", typeof(DB));
                DB2.Table.Columns.Add("trd_pro_id");
                DB2.Table.Columns.Add("trd_amount");
                DB2.Table.Columns.Add("trd_price");
                foreach (DataRow row in Transactions_Details.Rows)
                {
                    DB2.Table.Rows.Add(DB1, row["trd_pro_id"], row["trd_amount"], row["trd_price"]);
                }
                if (Transactions_LB.SelectedValue == null)
                {
                    if (DB1.IsNotExist("trs_id", "trs_no", "trs_trn_id", "trs_id_1", "trs_id_2"))
                    {
                        return DB1.Execute_Queries(DB1, DB2);
                    }
                    else
                    {
                        Message.Show("لقد تم التسجيل من قبل", MessageBoxButton.OK, 5);
                        return false;
                    }
                }
                else
                {
                    DB1.Last_Inserted = Transactions_LB.SelectedValue;
                    DB DB3 = new DB("transactions_details");
                    DB1.AddCondition("trs_Id", Transactions_LB.SelectedValue);
                    DB3.AddCondition("trd_trs_Id", Transactions_LB.SelectedValue);
                    return DB1.Execute_Queries(DB3, DB1, DB2);
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
                Details_DG.ColumnHeaderHeight = 62;
                Details_GD.RowDefinitions[1].Height = new GridLength(28);
                Main_GD.ColumnDefinitions[0].Width = new GridLength(0);
                View_GD.RowDefinitions[3].Height = new GridLength(35);
                Form.Set_Style(Info_GD, Operations.Add);
                Form.Set_Style(Totals_GD, Operations.Add);
                Transactions_LB.SelectedIndex = -1;
                Details_DG.ItemsSource = null;
                Transactions_Details.Rows.Clear();
                Get_New_No();
                //DC3.IsReadOnly = DC4.IsReadOnly = false;
                //Serial_TB.Focus();
            }
            catch
            {

            }
        }

        private void EditPanel_Edit(object sender, EventArgs e)
        {
            try
            {
                if (Transactions_LB.SelectedIndex != -1)
                {
                    Details_DG.ColumnHeaderHeight = 62;
                    Details_GD.RowDefinitions[1].Height = new GridLength(28);
                    Main_GD.ColumnDefinitions[0].Width = new GridLength(0);
                    View_GD.RowDefinitions[3].Height = new GridLength(35);
                    Form.Set_Style(Info_GD, Operations.Edit);
                    Form.Set_Style(Totals_GD, Operations.Edit);
                    //DC3.IsReadOnly = DC4.IsReadOnly = false;
                    //Serial_TB.Focus();
                }
            }
            catch
            {

            }
        }

        private void EditPanel_Delete(object sender, EventArgs e)
        {
            try
            {
                if (Transactions_LB.SelectedIndex != -1)
                {

                    if (Message.Show("هل تريد الحذف", MessageBoxButton.YesNoCancel, 5) == MessageBoxResult.Yes)
                    {
                        DB DB1 = new DB("transactions");
                        DB1.AddCondition("trs_id", Transactions_LB.SelectedValue);
                        DB DB2 = new DB("transactions_details");
                        DB2.AddCondition("trd_trs_Id", Transactions_LB.SelectedValue);
                        DB1.Execute_Queries(DB2, DB1);
                        Fill_Transactions_LB();

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
                if (Confirm.Check(Add_Update()))
                {
                    Details_DG.ColumnHeaderHeight = 32;
                    Details_GD.RowDefinitions[1].Height = new GridLength(0);
                    Main_GD.ColumnDefinitions[0].Width = new GridLength(250);
                    View_GD.RowDefinitions[3].Height = new GridLength(0);
                    Form.Set_Style(Info_GD, Operations.View);
                    Form.Set_Style(Totals_GD, Operations.View);
                    int i = Transactions_LB.SelectedIndex;

                    Get_Transactions_Details_Table();
                    Transactions_Details.Rows.Clear();
                    Pro_IDS.Clear();
                    Fill_Transactions_LB();
                    Transactions_LB.SelectedIndex = i;
                    //DC3.IsReadOnly = DC4.IsReadOnly = true;
                    if (Transaction == Transactions_Types.Sell || Transaction == Transactions_Types.Sell_Back)
                    {
                        if (Message.Show("هل تريد طباعة فاتورة", MessageBoxButton.YesNo) == MessageBoxResult.Yes) { PD1.Print(); }
                    }
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
                Details_DG.ColumnHeaderHeight = 32;
                Details_GD.RowDefinitions[1].Height = new GridLength(0);
                Main_GD.ColumnDefinitions[0].Width = new GridLength(250);
                View_GD.RowDefinitions[3].Height = new GridLength(0);
                Form.Set_Style(Info_GD, Operations.View);
                Form.Set_Style(Totals_GD, Operations.View);
                Transactions_Details.Rows.Clear();
                Pro_IDS.Clear();
                //DC3.IsReadOnly = DC4.IsReadOnly = true;
            }
            catch
            {

            }
        }

        private void LB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Get_Transactions_Details();
            }
            catch
            {

            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Fill_Transactions_LB();
            }
            catch
            {

            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Fill_Transactions_LB();
            }
            catch
            {

            }
        }

        private void Search_Date_DTP_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            try
            {
                Fill_Transactions_LB();
            }
            catch
            {

            }
        }


        private void Product_CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (Product_CB.SelectedIndex == 0)
                {
                    Products_Search p = new Products_Search();
                    p.ShowDialog();
                    Products.Get_All_Products(Product_CB, "البحث");
                    if (Products_Search.pro_id != null)
                    {
                        Product_CB.SelectedValue = Products_Search.pro_id;
                    }
                    else
                    {
                        Product_CB.SelectedIndex = -1;
                    }
                }
                else
                {
                    if ((int)Transaction > 2)
                    {
                        Price_TB.Text = ((DataRowView)Product_CB.SelectedItem)["pro_sell"].ToString();
                    }
                    else
                    {
                        e.Handled = true;
                        Get_Product_Price();                       
                    }
                }
            }
            catch
            {

            }
        }

        private void Date_DTP_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            try
            {
                if (Date_DTP.Style != FindResource("View_DateTimePicker") as Style && Transactions_LB.SelectedIndex == -1)
                {
                    Get_New_No();
                }
            }
            catch
            {

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {                
                int index = -1;
                if ((int)Transaction > 1)
                {
                    if (Notify.validate("من فضلك ادخل سعر الشراء", Price_TB.Text, Main.GetWindow(this))) { return; }
                }               
                if (Notify.validate("من فضلك اختار الصنف", Product_CB.SelectedIndex, Main.GetWindow(this))) { return; }
                if (Notify.validate("من فضلك ادخل الكمية", Amount_TB.Text, Main.GetWindow(this))) { return; }
                index = Pro_IDS.IndexOf(Product_CB.SelectedValue.ToString());
                if (index != -1)
                {
                    Transactions_Details.Rows[index]["trd_amount"] = decimal.Parse(Transactions_Details.Rows[index]["trd_amount"].ToString()) + decimal.Parse(Amount_TB.Text);
                    Transactions_Details.Rows[index]["trd_total"] = decimal.Parse(Transactions_Details.Rows[index]["trd_amount"].ToString()) *
                                                                    decimal.Parse(Transactions_Details.Rows[index]["trd_price"].ToString());

                }
                else
                {
                    Transactions_Details.Rows.Add(Product_CB.SelectedValue, Product_CB.Text, Amount_TB.Text, Price_TB.Text, decimal.Parse(Amount_TB.Text) * decimal.Parse(Price_TB.Text));
                    Pro_IDS.Add(Product_CB.SelectedValue.ToString());
                }
                Details_DG.ItemsSource = Transactions_Details.DefaultView;
                Price_TB.Text = "";
                Amount_TB.Text = "1";
                Product_CB.SelectedIndex = -1;
                Get_Total();               
            }
            catch
            {

            }
        }

        private void Details_DG_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Delete)
                {
                    Pro_IDS.RemoveAt(Details_DG.SelectedIndex);
                    Transactions_Details.Rows.RemoveAt(Details_DG.SelectedIndex);
                    Details_DG.ItemsSource = Transactions_Details.DefaultView;
                    Get_Total();
                }
            }
            catch
            {

            }
        }

        private void Details_DG_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                int index = Details_DG.SelectedIndex;
                if (e.Column.DisplayIndex == 3)
                {
                    Transactions_Details.Rows[index]["trd_discount"] = ((TextBox)Details_DG.Columns[3].GetCellContent(e.Row)).Text;
                    Transactions_Details.Rows[index]["trd_total"] = decimal.Parse(((TextBox)Details_DG.Columns[3].GetCellContent(e.Row)).Text) *
                                                                    decimal.Parse(Transactions_Details.Rows[index]["trd_amount"].ToString());
                }
                else
                {
                    Transactions_Details.Rows[index]["trd_total"] = decimal.Parse(((TextBox)Details_DG.Columns[2].GetCellContent(e.Row)).Text) *
                                                                    decimal.Parse(Transactions_Details.Rows[index]["trd_discount"].ToString());
                }
                Details_DG.ItemsSource = Transactions_Details.DefaultView;
                Get_Total();

            }
            catch
            {

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                PD1.Print();
            }
            catch
            {

            }
        }       

        private void PD1_PrintPage(object sender, PrintPageEventArgs e)
        {
            DataRowView Product = Details_DG.SelectedItem as DataRowView;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            StringFormat sf1 = new StringFormat(StringFormatFlags.DirectionRightToLeft);
            sf1.Alignment = StringAlignment.Near;
            sf1.LineAlignment = StringAlignment.Near;
            StringFormat sf2 = new StringFormat();
            sf2.Alignment = StringAlignment.Far;
            sf2.LineAlignment = StringAlignment.Near;
            float current_height = e.MarginBounds.Top;
            float temp_height = 0;


            e.Graphics.DrawString("Shalaby Trade", new System.Drawing.Font("Cambria", 16), System.Drawing.Brushes.Black, new RectangleF(e.MarginBounds.Left, current_height, e.MarginBounds.Width, 30), sf);
            current_height += 50;

            e.Graphics.DrawString("الرقــم  :", new System.Drawing.Font("Arial", 14), System.Drawing.Brushes.Black, new RectangleF(e.MarginBounds.Right - 70, current_height, 70, 30), sf1);
            e.Graphics.DrawString(No_TB.Text, new System.Drawing.Font("tahoma", 14), System.Drawing.Brushes.Black, new RectangleF(e.MarginBounds.Right - e.MarginBounds.Width, current_height, e.MarginBounds.Width - 70, 30), sf2);
            current_height += 30;

            e.Graphics.DrawString("التاريخ :", new System.Drawing.Font("Arial", 14), System.Drawing.Brushes.Black, new RectangleF(e.MarginBounds.Right - 70, current_height, 70, 30), sf1);
            e.Graphics.DrawString(DateTime.Now.ToString(), new System.Drawing.Font("tahoma", 12), System.Drawing.Brushes.Black, new RectangleF(e.MarginBounds.Right - e.MarginBounds.Width, current_height, e.MarginBounds.Width - 70, 30), sf2);
            current_height += 35;
            e.Graphics.DrawLine(new Pen(Brushes.Black), e.MarginBounds.Left, current_height, e.MarginBounds.Right, current_height);
            current_height += 5;
            e.Graphics.DrawString("الصنف", new System.Drawing.Font("Arial", 10), System.Drawing.Brushes.Black, new RectangleF(e.MarginBounds.Right - e.MarginBounds.Width + 120, current_height, e.MarginBounds.Width - 120, 30), sf1);
            e.Graphics.DrawString("السعر", new System.Drawing.Font("Arial", 10), System.Drawing.Brushes.Black, new RectangleF(e.MarginBounds.Right - e.MarginBounds.Width + 80, current_height, 40, 30), sf1);
            e.Graphics.DrawString("الكمية", new System.Drawing.Font("Arial", 9), System.Drawing.Brushes.Black, new RectangleF(e.MarginBounds.Right - e.MarginBounds.Width + 50, current_height, 30, 30), sf1);
            e.Graphics.DrawString("الإجمالي", new System.Drawing.Font("Arial", 10), System.Drawing.Brushes.Black, new RectangleF(e.MarginBounds.Right - e.MarginBounds.Width, current_height, 50, 30), sf1);
            current_height += 22;
            e.Graphics.DrawLine(new Pen(Brushes.Black), e.MarginBounds.Left, current_height, e.MarginBounds.Right, current_height);
            current_height += 5;
            foreach (DataRowView row in (DataView)Details_DG.ItemsSource)
            {
                temp_height = e.Graphics.MeasureString(row["trd_pro_name"].ToString(), new System.Drawing.Font("Arial", 8), e.MarginBounds.Width - 120).Height;
                temp_height = temp_height < 20 ? 15 : 30;
                e.Graphics.DrawString(row["trd_pro_name"].ToString(), new System.Drawing.Font("Arial", 8), System.Drawing.Brushes.Black, new RectangleF(e.MarginBounds.Right - e.MarginBounds.Width + 120, current_height, e.MarginBounds.Width - 120, temp_height), sf1);
                e.Graphics.DrawString(row["trd_price"].ToString(), new System.Drawing.Font("Tahoma", 7), System.Drawing.Brushes.Black, new RectangleF(e.MarginBounds.Right - e.MarginBounds.Width + 80, current_height, 40, temp_height), sf2);
                e.Graphics.DrawString(row["trd_amount"].ToString(), new System.Drawing.Font("Tahoma", 7), System.Drawing.Brushes.Black, new RectangleF(e.MarginBounds.Right - e.MarginBounds.Width + 50, current_height, 30, temp_height), sf2);
                e.Graphics.DrawString(row["trd_total"].ToString(), new System.Drawing.Font("Tahoma", 7), System.Drawing.Brushes.Black, new RectangleF(e.MarginBounds.Right - e.MarginBounds.Width, current_height, 50, temp_height), sf2);
                current_height += temp_height;
            }
            e.Graphics.DrawLine(new Pen(Brushes.Black), e.MarginBounds.Left, current_height, e.MarginBounds.Right, current_height);
            current_height += 5;
            e.Graphics.DrawString("الإجمالي", new System.Drawing.Font("Arial", 10), System.Drawing.Brushes.Black, new RectangleF(e.MarginBounds.Right - e.MarginBounds.Width + 50, current_height, 50, 30), sf1);
            e.Graphics.DrawString(Total_TB.Text, new System.Drawing.Font("Tahoma", 7), System.Drawing.Brushes.Black, new RectangleF(e.MarginBounds.Right - e.MarginBounds.Width, current_height, 50, 30), sf2);

        }

        private string Get_Price(object pro_Id)
        {
            string Price = "0";
            try
            {
                DB d = new DB();
                d.AddCondition("pro_id", pro_Id);
                object price = d.Select(@"SELECT COALESCE(pro_sell,0) FROM products");
                Price = price == null ? "0.00" : price.ToString();
            }
            catch
            {

            }
            return Price;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (Confirm.Check(Add_Update()))
            {
                if (Transaction == Transactions_Types.Sell || Transaction == Transactions_Types.Sell_Back)
                {
                    if (Message.Show("هل تريد طباعة فاتورة", MessageBoxButton.YesNo) == MessageBoxResult.Yes) { Print_Bill(); }
                }
                Get_Transactions_Details_Table();
                Transactions_Details.Rows.Clear();
                Pro_IDS.Clear();
                Form.Set_Style(Totals_GD, Operations.Add);
                Details_DG.ItemsSource = null;
                Get_New_No();

            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Date_DTP.Value = DateTime.Now;
                Get_New_No();
            }
            catch
            {

            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                Print_Bill();
            }
            catch
            {

            }
        }

        private void Print_Bill()
        {
            try
            {
                //Bitmap b = new Bitmap(280, 120);
                //Graphics g = Graphics.FromImage(b);

                //float height = 192;
                //float temp_height = 0;
                //foreach (DataRowView row in (DataView)Details_DG.ItemsSource)
                //{
                //    temp_height = g.MeasureString(row["trd_pro_name"].ToString(), new System.Drawing.Font("Arial", 8), PD2.DefaultPageSettings.PaperSize.Width - 135).Height;
                //    temp_height = temp_height < 20 ? 15 : 30;
                //    height += temp_height;

                //}

                //PD2.DefaultPageSettings.PaperSize.Height = Convert.ToInt32(height);
                //PD2.Print();
            }
            catch
            {

            }
        }
    }
}
