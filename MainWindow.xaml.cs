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
        public MainWindow()
        {
            InitializeComponent();

        }

        string filePath = "";
        string fileName = "";
        string newFileName = "";
        string nowText = "";
        string savedText = "";

        // 储存文件
        void Save()
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                System.IO.File.WriteAllText(dlg.FileName, TextArea.Text);
                fileName = dlg.FileName;
                savedText = nowText; ;
                FileNametxt.Text = dlg.SafeFileName + ".txt";
            }
        }

        // 打开文件
        void Open()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                TextArea.Text = System.IO.File.ReadAllText(dlg.FileName);
                fileName = dlg.FileName;
                savedText = TextArea.Text;
               FileNametxt.Text = dlg.SafeFileName + ".txt";
            }
        }

        // 開啟檔案按鈕
        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            if (savedText != nowText)
                if (MessageBox.Show("Do you want to Save?", "Save or Not", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Save();
                    Open();
                }
                else
                {
                    Open();
                }
            else
            {
                Open();
            }
        }


        // 存檔檔案按鈕
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (fileName == newFileName)
            {
                Save();
            }
            else
            {
                System.IO.File.WriteAllText(fileName, TextArea.Text);
                savedText = nowText;
            }
        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            if (savedText != nowText)
            {
                if (MessageBox.Show("Do you want to Save?", "Save or Not", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Save();
                    TextArea.Text = "";
                }
                else
                {
                    TextArea.Text = "";
                }
            }
            else
            {
                TextArea.Text = "";
            }
        }

        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            Save();
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
            this.WindowState = WindowState.Minimized;
        }

        private void MaximizeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal; //设置窗口还原
            }
            else
            {
                this.WindowState = WindowState.Maximized; //设置窗口最大化
            }
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TitleBg_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

    }
}
