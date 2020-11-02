using Respiratory_Analysis_CPET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ToolForCpet.ViewModel;

namespace ToolForCpet.Model
{
    public class DataBreath: ViewModelBase
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

        public BreathingFrequenceValue _breathingFrequenceValue;
        public BreathingFrequenceValue BreathingFrequenceValue
        {
            get { return _breathingFrequenceValue; }
            set
            {
                _breathingFrequenceValue = value;
                OnPropertyChanged("BreathingFrequenceValue");
            }
        }

        public Volume _volume;
        public Volume Volume
        {
            get { return _volume; }
            set
            {
                _volume = value;
                OnPropertyChanged("Volume");
            }
        }

        public CoefficientValue _coefficient;
        public CoefficientValue Coefficient
        {
            get { return _coefficient; }
            set
            {
                _coefficient = value;
                OnPropertyChanged("Coefficient");
            }
        }

        public LoopVolumeFlowValue _loopVolumeFlowValue;
        public LoopVolumeFlowValue LoopVolumeFlowValue
        {
            get { return _loopVolumeFlowValue; }
            set
            {
                _loopVolumeFlowValue = value;
                OnPropertyChanged("LoopVolumeFlowValue");
            }
        }

        public Pressure _pressure;

        public DataBreath(Breath breath)
        {
            InspirationY = breath.Inspiration;
            for (int i = 0; i < InspirationY.Count; i++)
            {
                InspirationX.Add(i * 0.01);
            }
            ExpirationY = breath.Expiration;
            for(int i=0;i<ExpirationY.Count;i++)
            {
                ExpirationX.Add((i+ InspirationY.Count) * 0.01);
            }
            

            BreathingFrequenceValue = breath.BreathingFrequenceValue;
            Volume = breath.Volume;
            Coefficient = breath.Coefficient;
            LoopVolumeFlowValue = breath.LoopVolumeFlowValue;
            Pressure = breath.Pressure;
        }

        public Pressure Pressure
        {
            get { return _pressure; }
            set
            {
                _pressure = value;
                OnPropertyChanged("Pressure");
            }
        }

       
    }
}
