using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using System.Windows.Input;
using System.Windows;
using DXApplication4.Models;
using System.Collections.ObjectModel;
using DevExpress.Xpf.Core;

namespace DXApplication4.ViewModels
{
    [POCOViewModel]
    public class DoorControlViewModel : ViewModelBase
    {
        public DelegateCommand AddDoorCommand { get; set; }
        public DelegateCommand DeleteDoorCommand{ get; set; }
        public DelegateCommand<string> AddGroupCommand { get; set; }
        public DelegateCommand DeleteGroupCommand { get; set; }
        public DelegateCommand AddGroupDoorCommand { get; set; }
        public DelegateCommand DeleteGroupDoorCommand { get; set; }

        public DoorControlViewModel()
        {
            AddDoorCommand = new DelegateCommand(AddDoorCommandAction);
            DeleteDoorCommand = new DelegateCommand(DeleteDoorCommandAction);
            AddGroupCommand = new DelegateCommand<string>(AddGroupCommandAction);
            DeleteGroupCommand = new DelegateCommand(DeleteGroupCommandAction);
            AddGroupDoorCommand = new DelegateCommand(AddGroupDoorCommandAction);
            DeleteGroupDoorCommand = new DelegateCommand(DeleteGroupDoorCommandAction);
            //출입문관리
            //출입문리스트 불러오는거 1, 저장된 출입문 불러오는거 1

            //조직관리
            //조직리스트 불러오는거 1, 저장된 논리조직 불러오는거 1, 논리조직에 해당된 조직맴버 불러오는거1
        }
        public void AddDoorCommandAction()
        {
            try
            {
            }
            catch
            {

            }
        }
        public void DeleteDoorCommandAction()
        {
            try
            {

            }
            catch
            {

            }
        }
        public bool Checker(string param)
        {
            bool result = false; ;
            if(param != string.Empty)
            {
                foreach (var a in SelectedGroupCollection)
                {
                    if (a.GroupName == param) result = true;
                }
            }
            return result;
        }

        public void AddGroupCommandAction(string param)
        {
            var inputGroup = new Group(param);
            try
            {
                if (param == string.Empty) DXMessageBox.Show("그룹명을 입력하세요");
                bool result = Checker(param);
                if(result) DXMessageBox.Show("이미 존재하는 그룹입니다.");
                if (!result)
                {
                    SelectedGroupCollection.Add(inputGroup);
                    DXMessageBox.Show(param+" 그룹이 추가 되었습니다.");
                }
            }
            catch
            {
                DXMessageBox.Show("그룹 추가 실패");
            }
        }
        public void DeleteGroupCommandAction()
        {
            var selectedGroup = GroupSelected;
            try
            {
                if (selectedGroup==null) DXMessageBox.Show("선택된 그룹이 없습니다. 삭제할 그룹을 선택하세요.");
                bool result = Checker(selectedGroup.GroupName);
                if (!result) DXMessageBox.Show("존재하지 않는 그룹입니다.");
                if (result)
                {
                    SelectedGroupCollection.Remove(selectedGroup);
                    DXMessageBox.Show(selectedGroup.GroupName + " 그룹이 삭제 되었습니다.");
                }
            }
            catch
            {

            }
        }
        public void AddGroupDoorCommandAction()
        {
            try
            {

            }
            catch
            {

            }
        }
        public void DeleteGroupDoorCommandAction()
        {
            try
            {

            }
            catch
            {

            }
        }

        /* 출입문 저장 목록 */
        private ObservableCollection<Door> _SelectedDoorCollection = new ObservableCollection<Door>();
        public ObservableCollection<Door> SelectedDoorCollection
        {
            get { return _SelectedDoorCollection; }
            set
            {
                _SelectedDoorCollection = value;
                //RaisePropertyChanged("VisitorCollection");
            }
        }
        /* 조직 저장 목록 */
        private ObservableCollection<Group> _SelectedGroupCollection = new ObservableCollection<Group>();
        public ObservableCollection<Group> SelectedGroupCollection
        {
            get { return _SelectedGroupCollection; }
            set
            {
                _SelectedGroupCollection = value;
                //RaisePropertyChanged("VisitorCollection");
            }
        }
        //private ObservableCollection<Group> _GroupSelected = new ObservableCollection<Group>();
        //public ObservableCollection<Group> GroupSelected
        //{
        //    get { return _GroupSelected; }
        //    set
        //    {
        //        _GroupSelected = value;
        //        //RaisePropertyChanged("VisitorCollection");
        //    }
        //}

        Group _GroupSelected;
        public Group GroupSelected
        {
            get { return _GroupSelected; }
            set
            {
                _GroupSelected = value;

            }
        }

        /* 조직에 소속된 조직 목록 저장 목록 */
        private ObservableCollection<InGroup> _SelectedGroupInListCollection = new ObservableCollection<InGroup>();
        public ObservableCollection<InGroup> SelectedGroupInListCollection
        {
            get { return _SelectedGroupInListCollection; }
            set
            {
                _SelectedGroupInListCollection = value;
                //RaisePropertyChanged("VisitorCollection");
            }
        }
    }
}