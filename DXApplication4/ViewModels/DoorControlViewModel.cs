using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using System.Windows.Input;
using System.Windows;
using DXApplication4.Models;
using System.Collections.ObjectModel;
using DXApplication4.Commands;

namespace DXApplication4.ViewModels
{
    [POCOViewModel]
    public class DoorControlViewModel : ViewModelBase
    {
        public DoorControlViewModel()
        {
            //출입문관리
            //출입문리스트 불러오는거 1, 저장된 출입문 불러오는거 1

            //조직관리
            //조직리스트 불러오는거 1, 저장된 논리조직 불러오는거 1, 논리조직에 해당된 조직맴버 불러오는거1
        }

        /// <summary>
        /// 출입문 관련 내부 커맨드
        /// </summary>
        private ICommand setDoorUpdater;
        public ICommand SetSelectedDoorCommand
        {
            get
            {
                if (this == null)
                    setDoorUpdater = new SetSelectedDoorCommand();
                return setDoorUpdater;
            }
            set
            {
                setDoorUpdater = value;
            }
        }
        public ICommand DeleteSelectedDoorCommand
        {
            get
            {
                if (this == null)
                    setDoorUpdater = new DeleteSetSelectedDoorCommand();
                return setDoorUpdater;
            }
            set
            {
                setDoorUpdater = value;
            }
        }
        /// <summary>
        /// 논리그룹 관련 내부 커맨드
        /// </summary>
        private ICommand setGroupCommand;
        public ICommand AddLogicalGroupCommand
        {
            get
            {
                if (this == null)
                    setGroupCommand = new AddLogicalGroupCommand();
                return setGroupCommand;
            }
            set
            {
                setGroupCommand = value;
            }
        }
        public ICommand DeleteLogicalGroupCommand
        {
            get
            {
                if (this == null)
                    setGroupCommand = new DeleteLogicalGroupCommand();
                return setGroupCommand;
            }
            set
            {
                setGroupCommand = value;
            }
        }
        /// <summary>
        /// 논리그룹에 속한 노직 내부 커맨드
        /// </summary>
        private ICommand setGroupListCommand;
        public ICommand SetLogicalGroupCommand
        {
            get
            {
                if (this == null)
                    setGroupListCommand = new SetLogicalGroupCommand();
                return setGroupListCommand;
            }
            set
            {
                setGroupListCommand = value;
            }
        }
        public ICommand DeleteSetLogicalGroupCommand
        {
            get
            {
                if (this == null)
                    setGroupListCommand = new DeleteSetLogicalGroupCommand();
                return setGroupListCommand;
            }
            set
            {
                setGroupListCommand = value;
            }
        }


        /* 출입문 저장 목록 */
        ObservableCollection<SelectedDoorModel> _SelectedDoorCollection = new ObservableCollection<SelectedDoorModel>();
        public ObservableCollection<SelectedDoorModel> SelectedDoorCollection
        {
            get { return _SelectedDoorCollection; }
            set
            {
                _SelectedDoorCollection = value;
                //RaisePropertyChanged("VisitorCollection");
            }
        }
    }
}