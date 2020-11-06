using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using Respiratory_Analysis_CPET;
using Newtonsoft.Json;
using ToolForCpet.ViewModel;

namespace ToolForCpet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string dataCDT;
        public List<Breath> breath = new List<Breath>() { };
        Pulmonary_Analysis pulmonary;
        public MainWindow()
        {
            DataContext = ApplicationViewModel.Instance(GetListBreathFromCDT(@"C:\temp\data.cdt"));
            InitializeComponent();
           
           
        }
        private void OverViewButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Открываем окно диалога с пользователем.
            if (openFileDialog.ShowDialog() == true)
            {
                // Получаем расширение файла, выбранного пользователем.
                var extension = Path.GetExtension(openFileDialog.FileName);

                if (extension == ".cdt")
                {
                    // Открываем файл. 
                    dataCDT = openFileDialog.FileName;
                    breath = GetListBreathFromCDT(dataCDT);
                    DataContext =ApplicationViewModel.Instance(breath);

                }
                else throw new Exception("это не файл с расширением .cdt");
            }
        }
        private  List<Breath> GetListBreathFromCDT(string pathCDT)
        {
            using(StreamReader sr=new StreamReader(pathCDT))
            {
                var str=sr.ReadToEnd();
                var breathes = JsonConvert.DeserializeObject<List<Breath>>(str);
                return breathes;

            }
        }
        //private void PulmonaryInit()
        //{
        //    pulmonary=Pulmonary_Analysis.Instance()
        //}
    }
}
