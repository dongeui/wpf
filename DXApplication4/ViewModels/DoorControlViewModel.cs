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
using System.Threading;

namespace DXApplication4.ViewModels
{
    [POCOViewModel]
    public class DoorControlViewModel : ViewModelBase
    {
        /// <summary>
        /// 논리그룹에서 포커스 한 그룹
        /// </summary>
        Group _FocusGroup;
        public Group FocusGroup
        {
            get { return _FocusGroup; }
            set { _FocusGroup = value; }
        }

        /// <summary>
        /// 논리그룹에서 제거를 위해 선택한 그룹
        /// </summary>
        Group _GroupSelected;
        public Group GroupSelected
        {
            get { return _GroupSelected; }
            set { _GroupSelected = value; }
        }

        /// <summary>
        /// 추가할 출입문 목록
        /// </summary>
        ObservableCollection<OC_OutputportInfo> _DoorSelected = new ObservableCollection<OC_OutputportInfo>();
        public ObservableCollection<OC_OutputportInfo> DoorSelected
        {
            get { return _DoorSelected; }
            set { _DoorSelected = value; }
        }

        /// <summary>
        /// 삭제할 출입문
        /// </summary>
        OC_OutputportInfo _DeletedDoorSelected = new OC_OutputportInfo();
        public OC_OutputportInfo DeletedDoorSelected
        {
            get { return _DeletedDoorSelected; }
            set { _DeletedDoorSelected = value; }
        }


        /// <summary>
        /// 저장된 출입문 목록
        /// </summary>
        private ObservableCollection<OC_OutputportInfo> _SelectedDoorCollection = new ObservableCollection<OC_OutputportInfo>();
        public ObservableCollection<OC_OutputportInfo> SelectedDoorCollection
        {
            get { return _SelectedDoorCollection; }
            set { _SelectedDoorCollection = value; }
        }

        /// <summary>
        /// 저장된 논리그룹 목록
        /// </summary>
        private ObservableCollection<Group> _SelectedGroupCollection = new ObservableCollection<Group>();
        public ObservableCollection<Group> SelectedGroupCollection
        {
            get { return _SelectedGroupCollection; }
            set { _SelectedGroupCollection = value; }
        }

        /// <summary>
        /// 논리그룹에 추가하기 위해 선택된 조직 목록
        /// </summary>
        private ObservableCollection<UC_Organization> _SelectedGroupInListCollection = new ObservableCollection<UC_Organization>();
        public ObservableCollection<UC_Organization> SelectedGroupInListCollection
        {
            get { return _SelectedGroupInListCollection; }
            set { _SelectedGroupInListCollection = value; }
        }

        /// <summary>
        ///  논리그룹에 소속된 조직 목록 
        /// </summary>
        private ObservableCollection<UC_Organization> _ShowDicVaules = new ObservableCollection<UC_Organization>();
        public ObservableCollection<UC_Organization> ShowDicValues
        {
            get { return _ShowDicVaules; }
            set { _ShowDicVaules = value; }
        }

        UC_Organization _DeleteDic = new UC_Organization();
        public UC_Organization DeleteDic
        {
            get { return _DeleteDic; }
            set { _DeleteDic = value; }
        }

        public Dictionary<string, ObservableCollection<UC_Organization>> Dic { get; set; }

        public DelegateCommand AddDoorCommand { get; set; }
        public DelegateCommand DeleteDoorCommand { get; set; }
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
            //db에서불러와서dic에넣어야겟징
            Dic = new Dictionary<string, ObservableCollection<UC_Organization>>();
        }
        /// <summary>
        /// 출입문 추가
        /// </summary>
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
        /// <summary>
        /// 출입문 삭제
        /// </summary>
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
        /// <summary>
        /// 논리그룹 추가
        /// </summary>
        /// <param name="param"></param>
        public void AddGroupCommandAction(string param)
        {
            var inputGroup = new Group(param);
            try
            {
                if (param == string.Empty) DXMessageBox.Show("그룹명을 입력하세요");
                bool result = Checker(param);
                if (result) DXMessageBox.Show("이미 존재하는 그룹입니다.");
                if (!result)
                {
                    SelectedGroupCollection.Add(inputGroup);
                    // DXMessageBox.Show(param+" 그룹이 추가 되었습니다.");
                }
            }
            catch
            {
                DXMessageBox.Show("그룹 추가 실패");
            }
        }
        /// <summary>
        /// 논리그룹 삭제
        /// </summary>
        public void DeleteGroupCommandAction()
        {
            var selectedGroup = GroupSelected;
            try
            {
                if (selectedGroup == null) DXMessageBox.Show("선택된 그룹이 없습니다. 삭제할 그룹을 선택하세요.");
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
        /// <summary>
        /// 논리조직에 속하는 조직 추가
        /// </summary>
        public void AddGroupListCommandAction()
        {
            try
            {
                if (FocusGroup == null) MessageBox.Show("추가할 논리 그룹을 선택해주세요");
                else if (SelectedGroupInListCollection == null) MessageBox.Show("추가할 조직을 선택해주세요");
                else if (FocusGroup != null && SelectedGroupInListCollection != null)
                {
                    ObservableCollection<UC_Organization> values = new ObservableCollection<UC_Organization>();
                    ObservableCollection<UC_Organization> selectedValues = new ObservableCollection<UC_Organization>();
                    foreach (var a in SelectedGroupInListCollection)
                    {
                        selectedValues.Add(a);
                    }
                    Dic.Add(FocusGroup.GroupName, selectedValues);

                    bool result = Dic.TryGetValue(FocusGroup.GroupName, out values);
                    if (result)
                    {
                        SelectedGroupInListCollection.Clear();
                        ShowDicValues.Clear();
                        foreach (var a in values)
                        {
                            ShowDicValues.Add(a);
                        }
                    }
                    else
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
        /// <summary>
        /// 논리조직에 속한 조직 제거
        /// </summary>
        public void DeleteGroupListCommandAction()
        {
            try
            {
                if (DeleteDic != null && FocusGroup != null)
                {
                    //먼저있던 딕 제거하고
                    Dic.Remove(FocusGroup.GroupName);
                    ShowDicValues.Remove(DeleteDic);

                    //새로셋팅한 딕 넣어주기, value에 showdic으로넣어줘서 계속초기화가됬었..
                    ObservableCollection<UC_Organization> selectedValues = new ObservableCollection<UC_Organization>();
                    foreach (var a in ShowDicValues)
                    {
                        selectedValues.Add(a);
                    }

                    Dic.Add(FocusGroup.GroupName, selectedValues);

                    //삭제하고나면 딕이 초기화된다 , 쇼가 초기화된디
                    //딕은초기화안됨, 쇼가 초기화되서안나타나는건데..
                }
                else
                {

                }
            }
            catch
            {
                MessageBox.Show("논리그룹에 속한 조직을 삭제하지 못 했습니다.");
            }
        }

        public void ChangeGroupEvent(object sender, DevExpress.Xpf.Grid.CurrentItemChangedEventArgs e)
        {
            //변경된 row focusgroup이름 가져와서확인하고 해당하는거에 맞는 dic꺼내서 showdic에 넣기
            FocusGroup = (Group)e.NewItem;
            if (FocusGroup != null)
            {
                ObservableCollection<UC_Organization> values = new ObservableCollection<UC_Organization>();
                bool result = Dic.TryGetValue(FocusGroup.GroupName, out values);
                ShowDicValues.Clear();

                if (result)
                {
                    foreach (var a in values)
                    {
                        ShowDicValues.Add(a);
                    }
                }
                else
                {
                    //MessageBox.Show("그룹에 속한 조직을 가져오지 못 하였습니다.");
                }
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