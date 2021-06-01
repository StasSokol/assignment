using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Test_work
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Path;
        
         public void Get_Path(string Path)
        {
            List<String> list_dll = new List<string>();
            
            
            list_dll.AddRange(Directory.EnumerateFiles(Path, "*.*", SearchOption.AllDirectories).Where(path => path.EndsWith(".dll") || path.EndsWith(".DLL")));

            foreach (var dll in list_dll)
            {
                try
                {
                    Assembly sb = Assembly.LoadFile(dll);

                    foreach (var sb_type in sb.GetTypes())
                    {
                        listBox.Items.Add(sb_type.Name);
                        
                        foreach (var method in sb_type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly))
                        {
                            if (method.IsFamily || method.IsPublic)
                            {
                                listBox.Items.Add(method.Name);
                            }
                        }
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Error");
                }
            }
        }
        public MainWindow()
        {   
            InitializeComponent();
          
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(Path = textBox.Text))
            {
                Get_Path(Path);
        
            }
            else
            {
                MessageBox.Show("Wrong path!");
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            listBox.Items.Clear();
        }
    }
}
