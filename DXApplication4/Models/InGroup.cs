using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication4.Models
{
    public class InGroup
    {
        private string groupName;
        private string groupPostion;

        public InGroup(string groupName, string groupPostion)
        {
            this.groupName = groupName;
            this.groupPostion = groupPostion;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string GroupName
        {
            get
            {
                return groupName;
            }
            set
            {
                groupName = value;
                OnPropertyChanged("groupName");
            }
        }
        public string GroupPosition
        {
            get
            {
                return groupPostion;
            }
            set
            {
                groupPostion = value;
                OnPropertyChanged("groupPostion");
            }
        }
    }
}
