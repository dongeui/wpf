using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication4.Models
{
    public class SelectedDoorModel
    {
        private string doorName;
        private string doorPosition;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string DoorName
        {
            get
            {
                return doorName;
            }
            set
            {
                doorName = value;
                OnPropertyChanged("doorName");
            }
        }

        public string DoorPosition
        {
            get
            {
                return doorPosition;
            }
            set
            {
                doorPosition = value;
                OnPropertyChanged("doorPosition");
            }
        }
    }
}
