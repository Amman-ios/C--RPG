using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Engine
{
    public class LivingCreature : INotifyPropertyChanged
    {
        private int _currentHP;

        public int CurrentHP
        {
            get { return _currentHP; }
            set
            {
                _currentHP = value;
                OnPropertyChanged("CurrentHP");
            }
        }
        public int MaxHP { get; set; }

        public LivingCreature(int currentHP, int maxHP)
        {
            CurrentHP = currentHP;
            MaxHP = maxHP;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
