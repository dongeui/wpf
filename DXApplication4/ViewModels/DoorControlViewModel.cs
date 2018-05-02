using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using System.Windows.Input;
using System.Windows;
using DXApplication4.Models;
using System.Collections.ObjectModel;
using DevExpress.Xpf.Core;
using System.Collections.Generic;

namespace DXApplication4.ViewModels
{
    [POCOViewModel]
    public class DoorControlViewModel : ViewModelBase
    {
        /*선택된 그룹들*/
        Group _GroupSelected;
        public Group GroupSelected
        {
            get { return _GroupSelected; }
            set { _GroupSelected = value; }
        }
        /*그룹별 선택된 조직*/
        Group _GroupSelectedInList;
        public Group GroupSelectedInList
        {
            get { return _GroupSelectedInList; }
            set { _GroupSelectedInList = value; }
        }
        /*조직 리스트에서 선택된 조직들*/
        Group _ListSelected;
        public Group ListSelected
        {
            get { return _ListSelected; }
            set { _ListSelected = value; }
        }
        /*추가할 출입문들*/
        ObservableCollection<Door> _DoorSelected;
        public ObservableCollection<Door> DoorSelected
        {
            get { return _DoorSelected; }
            set { _DoorSelected = value; }
        }
        /*삭제할 출입문들*/
        Door _DeleteDoorSelected;
        public Door DeleteDoorSelected
        {
            get { return _DeleteDoorSelected; }
            set { _DeleteDoorSelected = value; }
        }

        /// <summary>
        /// key:논리그룹 value:속한 조직 목록
        /// </summary>
        Dictionary<Group, ObservableCollection<ListInGroup>> _dic = new Dictionary<Group, ObservableCollection<ListInGroup>>();


        public DelegateCommand AddDoorCommand { get; set; }
        public DelegateCommand DeleteDoorCommand{ get; set; }
        public DelegateCommand<string> AddGroupCommand { get; set; }
        public DelegateCommand DeleteGroupCommand { get; set; }
        public DelegateCommand AddGroupListCommand { get; set; }
        public DelegateCommand DeleteGroupListCommand { get; set; }

        public DoorControlViewModel()
        {
            AddDoorCommand = new DelegateCommand(AddDoorCommandAction);
            DeleteDoorCommand = new DelegateCommand(DeleteDoorCommandAction);
            AddGroupCommand = new DelegateCommand<string>(AddGroupCommandAction);
            DeleteGroupCommand = new DelegateCommand(DeleteGroupCommandAction);
            AddGroupListCommand = new DelegateCommand(AddGroupListCommandAction);
            DeleteGroupListCommand = new DelegateCommand(DeleteGroupListCommandAction);
        }

        public void AddDoorCommandAction()
        {
            //출입문 등록 DoorSelected가져와서 SelectedDoorCollection 넣기
            try
            {
            }
            catch
            {

            }
        }

        public void DeleteDoorCommandAction()
        {
            //출입문 삭제DeleteDoorSelected가져와서 SelectedDoorCollection에서빼기
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
                    //value없이 dic에추가
                    _dic.Add(inputGroup, null);
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
            ///dic에서도 제거
            var selectedGroup = GroupSelected;
            try
            {
                if (selectedGroup==null) DXMessageBox.Show("선택된 그룹이 없습니다. 삭제할 그룹을 선택하세요.");
                bool result = Checker(selectedGroup.GroupName);
                if (!result) DXMessageBox.Show("존재하지 않는 그룹입니다.");
                if (result)
                {
                    SelectedGroupCollection.Remove(selectedGroup);
                    //dic에서 제거
                    _dic.Remove(selectedGroup);
                    DXMessageBox.Show(selectedGroup.GroupName + " 그룹이 삭제 되었습니다.");
                }
            }
            catch
            {
                DXMessageBox.Show("그룹 삭제 실패");
            }
        }
        public void AddGroupListCommandAction()
        {
            //ListSelected 가져와서 선택된 해당 그룹에다가 속해서 집어넣기
            //selectedGroupcollection에서 오류체크하고 가져와서 여기에 key는 그룹, value는 SelectedGroupInListCollection로 매핑
            try
            {

            }
            catch
            {

            }
        }
        public void DeleteGroupListCommandAction()
        {
            //GroupSelectedInList 사용
            //반대로 해당 dic에서 제거
            try
            {

            }
            catch
            {

            }
        }

        /* 저장된 출입문 목록 */
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
        /* 저장된 논리그룹 목록 */
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
        /* 논리그룹에 소속된 조직 목록 */
        private ObservableCollection<ListInGroup> _SelectedGroupInListCollection = new ObservableCollection<ListInGroup>();
        public ObservableCollection<ListInGroup> SelectedGroupInListCollection
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