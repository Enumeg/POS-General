using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Data;

namespace POS.Styles
{
    partial class ComboBox : ResourceDictionary
    {
        string Search_Text = "";
        System.Windows.Controls.ComboBox CB;
        public ComboBox()
        {
            InitializeComponent();
        }
        private void PART_Popup_Closed(object sender, EventArgs e)
        {
            try
            {
                CB = (System.Windows.Controls.ComboBox)((FrameworkElement)sender).TemplatedParent;
                Search_Text = "";
                ((DataView)CB.ItemsSource).RowFilter = "";
                TextBox Edit_TB = (TextBox)CB.Template.FindName("PART_EditableTextBox", CB);
                Edit_TB.SelectionStart = Edit_TB.CaretIndex = 0;
                Edit_TB.SelectionLength = Edit_TB.Text.Length;
            }
            catch
            {

            }
        }
        private void PART_EditableTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                e.Handled = true;
                CB = (System.Windows.Controls.ComboBox)((FrameworkElement)sender).TemplatedParent;
                Search_Text += e.Text;
                Filter(sender);
            }
            catch
            {

            }
        }
        private void PART_EditableTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch(e.Key)
                {
                    case Key.Back:
                        e.Handled = true;
                        CB = (System.Windows.Controls.ComboBox)((FrameworkElement)sender).TemplatedParent;
                        Search_Text = Search_Text.Length > 0 ? Search_Text.Remove(Search_Text.Length - 1) : Search_Text;
                        Filter();
                        break;
                    case Key.Space:
                        e.Handled = true;
                        CB = (System.Windows.Controls.ComboBox)((FrameworkElement)sender).TemplatedParent;
                        Search_Text += " ";
                        Filter();
                        break;

                }

            }
            catch
            {

            }
        }
        private void Filter(object tb = null)
        {
            try
            {
                if(!CB.IsDropDownOpen && CB.Items.Count > 0)
                {
                    CB.IsDropDownOpen = true;
                }
                if(CB.ItemsSource.GetType() == typeof(DataView))
                {
                    ((DataView)CB.ItemsSource).RowFilter = CB.DisplayMemberPath + " Like '%" + Search_Text + "%'";
                    if(CB.Items.Count > 0)
                    {
                        CB.SelectedIndex = 0;
                        CB.Text = Search_Text + ((DataRowView)CB.SelectedItem)[CB.DisplayMemberPath].ToString().Substring(Search_Text.Length);
                    }
                    else
                    {
                        CB.Text = Search_Text;
                    }
                }
                else
                {
                    CB.Items.Filter += a => { return a.ToString().Contains(Search_Text); };
                    CB.SelectedIndex = 0;
                    CB.Text = CB.Items.Count > 0 ? CB.SelectedItem.ToString() : Search_Text;
                }
                TextBox Edit_TB = (TextBox)CB.Template.FindName("PART_EditableTextBox", CB);
                Edit_TB.SelectionStart = Edit_TB.CaretIndex = Search_Text.Length;
                Edit_TB.SelectionLength = CB.Text.Length - Search_Text.Length;
            }
            catch
            {

            }
        }

        private void PART_EditableTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                CB = (System.Windows.Controls.ComboBox)((FrameworkElement)sender).TemplatedParent;
                Search_Text = "";
                ((DataView)CB.ItemsSource).RowFilter = "";
                TextBox Edit_TB = (TextBox)CB.Template.FindName("PART_EditableTextBox", CB);
                Edit_TB.SelectionStart = Edit_TB.CaretIndex = 0;
                Edit_TB.SelectionLength = Edit_TB.Text.Length;
            }
            catch
            {

            }
        }

    }
}
