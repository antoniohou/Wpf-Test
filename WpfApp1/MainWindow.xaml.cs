using Interface;
using System;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadMethod_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = ".dll",
                Filter = "Dll file (*.dll)|*.dll"
            };
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                Assembly assembly = Assembly.LoadFrom(dialog.FileName);
                foreach (Type type in assembly.GetTypes())
                {
                    if (type.GetInterfaces().Contains(typeof(CustomInterface)))
                    {
                        LoadMethodResult.Text = (Activator.CreateInstance(type) as CustomInterface)?.GetResult();
                    }
                }
            }
        }

        private void LoadControl_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = ".dll",
                Filter = "dll file|*.dll"
            };
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                Assembly assembly = Assembly.LoadFrom(dialog.FileName);
                foreach (Type type in assembly.GetTypes())
                {
                    if (type.IsSubclassOf(typeof(UserControl)))
                    {
                        LoadControlResult.Content = Activator.CreateInstance(type) as UserControl;
                    }
                }
            }
        }
    }
}
