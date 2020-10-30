using Respiratory_Analysis_CPET;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ToolForCpet.Model;

namespace ToolForCpet.ViewModel
{
    public class ApplicationViewModel: ViewModelBase
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
                Debug.WriteLine($"{selectedBreath.InspirationY.Count()}");
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
            BreathCount = breaths.Count()-1;
            Breathes = new List<DataBreath>();
           
            breaths.ForEach(i => Breathes.Add(new DataBreath(i)));
            CurrentItem = 10;
        }

    }
}
