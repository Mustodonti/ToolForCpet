using Respiratory_Analysis_CPET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolForCpet.ViewModel;

namespace ToolForCpet.Model
{
    public class DataFlow : ViewModelBase
    {
        public List<double> ExpirationX = new List<double>();

        public List<double> InspirationX = new List<double>();


        public List<SampleBreathing> _expirationY;
        public List<SampleBreathing> ExpirationY
        {
            get { return _expirationY; }
            set
            {
                _expirationY = value;
                OnPropertyChanged("ExpirationY");
            }
        }

        public List<SampleBreathing> _inspirationY;
        public List<SampleBreathing> InspirationY
        {
            get { return _inspirationY; }
            set
            {
                _inspirationY = value;
                OnPropertyChanged("InspirationY");
            }
        }

    }
}
