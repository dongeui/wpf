using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using System.Windows.Input;
using System.Windows;
using DXApplication4.Models;
using System.Collections.ObjectModel;
using DevExpress.Xpf.Core;
using System.Collections.Generic;
using System.Collections.Specialized;
using DevExpress.Xpf.Grid;

namespace DXApplication4.ViewModels
{
    [POCOViewModel]
    public class DoorControlViewModel : ViewModelBase
    {
        /*논리그룹에서 포커스 한 그룹*/
        Group _FocusGroup;
        public Group FocusGroup
        {
            get { return _FocusGroup; }
            set { _FocusGroup = value; }
        }

        /*논리그룹에서 삭제를 위해 선택한 그룹*/
        Group _GroupSelected;
        public Group GroupSelected
        {
            get { return _GroupSelected; }
            set { _GroupSelected = value; }
        }

     
        /*추가할 출입문들*/
        ObservableCollection<OC_OutputportInfo> _DoorSelected = new ObservableCollection<OC_OutputportInfo>();

      
        public ObservableCollection<OC_OutputportInfo> DoorSelected
        {
            get { return _DoorSelected; }
            set { _DoorSelected = value; }
        }

        OC_OutputportInfo _DeletedDoorSelected = new OC_OutputportInfo();
        public OC_OutputportInfo DeletedDoorSelected
        {
            get { return _DeletedDoorSelected; }
            set { _DeletedDoorSelected = value; }
        }

        
        /* 저장된 출입문 목록 */
        private ObservableCollection<OC_OutputportInfo> _SelectedDoorCollection = new ObservableCollection<OC_OutputportInfo>();
        public ObservableCollection<OC_OutputportInfo> SelectedDoorCollection
        {
            get { return _SelectedDoorCollection; }
            set {_SelectedDoorCollection = value; }
        }

        /* 저장된 논리그룹 목록 */
        private ObservableCollection<Group> _SelectedGroupCollection = new ObservableCollection<Group>();
        public ObservableCollection<Group> SelectedGroupCollection
        {
            get { return _SelectedGroupCollection; }
            set {_SelectedGroupCollection = value; }
        }
      
        /* 선택된 조직 목록 */
        private ObservableCollection<UC_Organization> _SelectedGroupInListCollection = new ObservableCollection<UC_Organization>();
        public ObservableCollection<UC_Organization> SelectedGroupInListCollection
        {
            get { return _SelectedGroupInListCollection; }
            set { _SelectedGroupInListCollection = value;}
        }

        /* 논리그룹에 소속된 조직 목록 보여주기*/
        private ObservableCollection<UC_Organization> _ShowDicVaules = new ObservableCollection<UC_Organization>();
        public ObservableCollection<UC_Organization> ShowDicValues
        {
            get { return _ShowDicVaules; }
            set { _ShowDicVaules = value;}
        }

        UC_Organization _DeleteDic = new UC_Organization();
        public UC_Organization DeleteDic
        {
            get { return _DeleteDic; }
            set { _DeleteDic = value; }
        }
     
        public Dictionary<Group, ObservableCollection<UC_Organization>> Dic { get; set; }

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
            Dic = new Dictionary<Group, ObservableCollection<UC_Organization>>();
        }

        public void AddDoorCommandAction()
        {
            try
            {
                if (DoorSelected.Count == 0) MessageBox.Show("추가할 출입문을 선택하세요");

                foreach (var door in DoorSelected)
                {
                    if (!SelectedDoorCollection.Contains(door))
                    {
                        SelectedDoorCollection.Add(door);
                    }
                }
            }
            catch
            {
                DXMessageBox.Show("출입문 추가 실패");
            }
        }

        public void DeleteDoorCommandAction()
        {
            try
            {
                if (DeletedDoorSelected == null) MessageBox.Show("삭제할 출입문을 선택하세요");
                SelectedDoorCollection.Remove(DeletedDoorSelected);
            }
            catch
            {
                DXMessageBox.Show("출입문 삭제 실패");
            }
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
                DXMessageBox.Show("그룹 삭제 실패");
            }
        }


        public void AddGroupListCommandAction()
        {
            try
            {
                if (FocusGroup == null) MessageBox.Show("추가할 논리 그룹을 선택해주세요");
                else if (SelectedGroupInListCollection == null) MessageBox.Show("추가할 조직을 선택해주세요");
                else if (FocusGroup != null && SelectedGroupInListCollection != null)
                {
                    ObservableCollection<UC_Organization> values = new ObservableCollection<UC_Organization>();
                    Dic.Add(FocusGroup, SelectedGroupInListCollection);
                    bool result = Dic.TryGetValue(FocusGroup, out values);
                    if (result)
                    {
                        foreach(var a in values)
                        {
                            ShowDicValues.Add(a);
                        }
                    }else
                    {
                        MessageBox.Show("그룹에 속한 조직을 가져오는데 실패하였습니다.");
                    }
                }
            }
            catch
            {
                MessageBox.Show("논리그룹에 조직을 추가하지 못 했습니다.");
            }
        }
        public void DeleteGroupListCommandAction()
        {
            try
            {
                if (DeleteDic != null && FocusGroup != null)
                {
                    //먼저있던 딕 제거하고
                    Dic.Remove(FocusGroup);
                    ShowDicValues.Remove(DeleteDic);
                    //새로셋팅한 딕 넣어주기
                    Dic.Add(FocusGroup, ShowDicValues);
                } 
            }
            catch
            {
                MessageBox.Show("논리그룹에 속한 조직을 삭제하지 못 했습니다.");
            }
        }

        public bool Checker(string param)
        {
            bool result = false; ;
            if (param != string.Empty)
            {
                foreach (var a in SelectedGroupCollection)
                {
                    if (a.GroupName == param) result = true;
                }
            }
            return result;
        }

    }
}