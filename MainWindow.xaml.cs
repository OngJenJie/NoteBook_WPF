using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BasicWpfNotepad
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        string filePath = "";

        public MainWindow()
        {
            InitializeComponent();

        }


        // 開啟檔案按鈕
        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            // 產生開啟檔案視窗 OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // 顯示視窗
            Nullable<bool> result = dlg.ShowDialog();

            // 當按下開啟之後的反應 
            if (result == true)
            {
                // 取得檔案路徑 
                filePath = dlg.FileName;

                // 讀取檔案
                TextArea.Text = System.IO.File.ReadAllText(filePath);
            }
        }


        // 存檔檔案按鈕
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            // 產生開啟檔案視窗 OpenFileDialog 
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();

            // 顯示視窗
            Nullable<bool> result = dlg.ShowDialog();

            // 當按下開啟之後的反應 
            if (result == true)
            {
                // 取得檔案路徑 
                filePath = dlg.FileName;

                // 儲存檔案
                System.IO.File.WriteAllText(filePath, TextArea.Text);
            }
        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            TextArea.Text = "";
        }

        private void SmallSize_Click(object sender, RoutedEventArgs e)
        {
            // 把文字縮小
            TextArea.FontSize--;
        }

        private void NormalSize_Click(object sender, RoutedEventArgs e)
        {
            // 把文字復原為起始大小
            TextArea.FontSize = 15;
        }

        private void LargeSize_Click(object sender, RoutedEventArgs e)
        {
            // 把文字放大
            TextArea.FontSize++;
        }

        private void ColourToBlack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // 改變主題顏色
            TextArea.Background = Brushes.DimGray;
            TitleBg.Background = Brushes.DimGray;
            TextArea.Foreground = Brushes.LightGray;
            FileNametxt.Foreground = Brushes.LightGray;
            MinimizeBtn.Foreground = Brushes.LightGray;
            MaximizeBtn.Foreground = Brushes.LightGray;
            ExitBtn.Foreground = Brushes.LightGray;
        }

        private void ColourToWhite_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // 改變主題顏色
            TextArea.Background = Brushes.White;
            TitleBg.Background = Brushes.White;
            TextArea.Foreground = Brushes.DimGray;
            FileNametxt.Foreground = Brushes.DimGray;
            MinimizeBtn.Foreground = Brushes.DimGray;
            MaximizeBtn.Foreground = Brushes.DimGray;
            ExitBtn.Foreground = Brushes.DimGray;
        }

        private void MinimizeBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MaximizeBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
