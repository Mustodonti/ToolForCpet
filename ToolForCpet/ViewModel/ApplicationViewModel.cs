using Respiratory_Analysis_CPET;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using ToolForCpet.Model;

namespace ToolForCpet.ViewModel
{
    public class ApplicationViewModel : ViewModelBase
    {

        private static ApplicationViewModel instance = null;
        public static ApplicationViewModel Instance(List<Breath> breaths)
        {
            // Если: объект еще не создан    (1)         
            if (instance == null)
            {
                // То: создаем новый экземпляр  (2)
                instance = new ApplicationViewModel(breaths);
            }
            // Иначе: возвращаем ссылку на существующий объект  (3)
            return instance;
        }
        public static ApplicationViewModel GetModel()
        {
            return instance;
        }

        public static ApplicationViewModel ChangeModel(List<Breath> breaths)
        {
            instance = new ApplicationViewModel(breaths);
            return instance;
        }
        private DataBreath selectedBreath;
        public int _breathCount;
        public int BreathCount
        {
            get { return _breathCount; }
            set
            {
                _breathCount = value;
                OnPropertyChanged("BreathCount");
            }
        }
        public int _currentItem;
        public int CurrentItem
        {
            get { return _currentItem; }
            set
            {
                _currentItem = value;
                selectedBreath = Breathes[value];
                Debug.WriteLine($"{selectedBreath.InspirationY.Count()}         {_currentItem}");
                DrawingFlow();
                OnPropertyChanged("CurrentItem");
            }
        }
        public List<DataBreath> Breathes { get; set; }
        public DataBreath SelectedBreath
        {
            get { return selectedBreath; }
            set
            {
                selectedBreath = value;
                OnPropertyChanged("SelectedBreath");
            }
        }

        public ApplicationViewModel(List<Breath> breaths)
        {
            BreathCount = breaths.Count() - 1;
            Breathes = new List<DataBreath>();

            breaths.ForEach(i => Breathes.Add(new DataBreath(i)));
            CurrentItem = 10;
            
        }

        private void Drawing()
        {
            while (true)
            {
                Thread.Sleep(100);
                App.Current?.Dispatcher?.Invoke(() => // <--- HERE
                {
                    LinesFlow.Add(new Line
                    {
                        From = new System.Windows.Point(_k, _k * 2),
                        To = new System.Windows.Point(_k++, _k * 2)
                    });
                });
            }

        }

        private void DrawingFlow()
        {
            LinesFlow.Clear();
            App.Current?.Dispatcher?.Invoke(() => 
            {
                double cFx1 = 1400/(Breathes[CurrentItem].ExpirationX.Max());
                double cFx2 = (Breathes[CurrentItem].InspirationY.Select(i=>i.Flow).Max() > Breathes[CurrentItem].ExpirationY.Select(i=>i.Flow).Max()) ? 100/ Breathes[CurrentItem].InspirationY.Select(i => i.Flow).Max() : 100/ Breathes[CurrentItem].ExpirationY.Select(i => i.Flow).Max();
                for (int i = 0; i < Breathes[CurrentItem].InspirationX.Count() - 1; i++)
                {
                   
                    LinesFlow.Add(new Line
                    {
                        From = new System.Windows.Point(Breathes[CurrentItem].InspirationX[i] *cFx1, Breathes[CurrentItem].InspirationY[i].Flow *-cFx2 + 100),
                        To = new System.Windows.Point(Breathes[CurrentItem].InspirationX[i+1] * cFx1, Breathes[CurrentItem].InspirationY[i+1].Flow *-cFx2 + 100)
                    });
                }
               
                for (int i=0;i<Breathes[CurrentItem].ExpirationX.Count()-1;i++)
                {
                    LinesFlow.Add(new Line
                    {
                        From = new System.Windows.Point(Breathes[CurrentItem].ExpirationX[i]*cFx1, Breathes[CurrentItem].ExpirationY[i].Flow*cFx2+100),
                        To = new System.Windows.Point(Breathes[CurrentItem].ExpirationX[i+1]*cFx1, Breathes[CurrentItem].ExpirationY[i+1].Flow*cFx2+100)
                    });
                }

                
            });

        }

        public ObservableCollection<Line> LinesFlow { get; } = new ObservableCollection<Line>();
        private int _k = 0;
        public class Line
        {
            public System.Windows.Point From { get; set; }

            public System.Windows.Point To { get; set; }

            public override string ToString()
            {
                return $"{From.X} {From.Y} {To.X} {To.Y}";
            }
        }
    }
}
