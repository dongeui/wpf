using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Data.Entity.Core.Objects;
using System.Collections.ObjectModel;
using DevExpress.Xpo.DB.Helpers;
using System.Data.Entity.Infrastructure;
using System.Windows.Forms;
using System.Data.Entity.Core.EntityClient;
using DXApplication4.Views;
using DXApplication4.Models;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace DXApplication4.ViewModels
{
    public class CountClass
    {
        public string GroupName { get; set; }
        public int Count { get; set; }
        public CountClass(string _name, int _count)
        {
            GroupName = _name;
            Count = _count;
        }
    }

    [POCOViewModel]
    public class SearchViewModel
    {
        DateTime _StartDate = DateTime.Now.Date.AddDays(-1);
        public DateTime StartDate
        {
            get { return _StartDate; }
            set
            {
                _StartDate = value;
                //RaisePropertiesChanged("StartDate");
            }
        }

        DateTime _EndDate = DateTime.Now.Date;
        public DateTime EndDate
        {
            get { return _EndDate; }
            set
            {
                _EndDate = value;
                //RaisePropertiesChanged("EndDate");
            }
        }

        public DelegateCommand SearchCommand { get; set; }
        public DelegateCommand ReportCommand { get; set; }

        public SearchView searchView;
        public SearchViewModel()
        {
            SearchCommand = new DelegateCommand(SearchCommandAction);
            ReportCommand = new DelegateCommand(ReportCommandAction);
        }

        DataTable _UserDataTable = new DataTable();
        public DataTable UserDataTable
        {
            get { return _UserDataTable; }
            set { _UserDataTable = value; }
        }

        DataTable _GroupDataTable = new DataTable();
        public DataTable GroupDataTable
        {
            get { return _GroupDataTable; }
            set { _GroupDataTable = value; }
        }

        public static Dictionary<Tuple<string, string>, DataTable> GroupDic = new Dictionary<Tuple<string, string>, DataTable>();


        public ObservableCollection<CountClass> _CountDicCollection = new ObservableCollection<CountClass>();
        public ObservableCollection<CountClass> CountDicCollection
        {
            get { return _CountDicCollection; }
            set { _CountDicCollection = value; }
        }


        DataView _ResultView = new DataView();
        public DataView ResultView
        {
            get { return _ResultView; }
            set { _ResultView = value; }
        }

        public void SearchCommandAction()
        {
            try
            {
                //논리그룹,거기에 속한 조직들
                
                //논리그룹
                var groupList = DoorControlViewModel.SelectedGroupCollection;
                //출입문
                var doorList = DoorControlViewModel.DoorSelected;
                
                var builder = new EntityConnectionStringBuilder(ConfigurationManager.ConnectionStrings["ADTSC20"].ConnectionString);
                var regularConnectionString = builder.ProviderConnectionString;
                SqlConnection connection = new SqlConnection(regularConnectionString);

                UserListSearch(groupList, doorList, connection);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        public void ReportCommandAction()
        {
            //GroupListView MemberListView 되어있는 걸로 리포트
            try
            {
            }
            catch
            {

            }
        }


        public void UserListSearch(ObservableCollection<DXApplication4.Models.Group> groupList, ObservableCollection<OC_OutputportInfo> doorList, SqlConnection connection)
        {
            try
            {
                //dic에서 논리그룹에 해당하는 것들을 가져옴
                foreach(var group in groupList)
                {
                    ObservableCollection<UC_Organization> values = new ObservableCollection<UC_Organization>();
                    bool result = DoorControlViewModel.Dic.TryGetValue(group.GroupName, out values);
                    if (result)
                    {
                        foreach(var group2 in values)
                        {
                            //하고나면 groupdic에 조직명/서치값 매핑되서 저장
                            UserListSearchByOrqan(group.GroupName, group2.OrganizationName, doorList, connection);
                        }
                    }
                    else
                    {
                        MessageBox.Show("논리그룹 및 속한 조직이 존재하지 않습니다");
                    }
                }
                //dic에 저장된 조직명과 논리그룹명 매칭해서 groupdatable에 매핑
                //tuple (key), user - (value)
                foreach (var group in groupList)
                {
                    if (GroupDic != null)
                    {
                        int count = 0;
                        foreach (var tuple in GroupDic)
                        {
                            if (tuple.Key.Item1 == group.GroupName)
                            {
                                count += tuple.Value.Rows.Count;
                            }
                        }
                        CountClass abc = new CountClass(group.GroupName, count);
                        CountDicCollection.Add(abc);
                        count = 0;
                    }
                }


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void UserListSearchByOrqan(string groupName, string organ, ObservableCollection<OC_OutputportInfo> doorList, SqlConnection connection)
        {
            try
            {
                string query = "Select Eventtime, DoorName, AccessUserCard_SID, USERNAME, MemberID, Organization " +
                            "from ADTSC.CM_AccessEventLog " +
                            "where Door_DID = @DID" +
                            " AND " +
                            "Organization = @OrganizationName" +
                            " AND " +
                            "EventTime BETWEEN @STARTDATE AND @ENDDATE";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@DID", SqlDbType.NVarChar);
                cmd.Parameters.Add("@STARTDATE", SqlDbType.DateTime);
                cmd.Parameters.Add("@ENDDATE", SqlDbType.DateTime);
                cmd.Parameters.Add("@OrganizationName", SqlDbType.NVarChar);

                SqlDataReader reader;
                var state = connection.State.ToString();
                if (state.Equals("Closed"))
                {
                    connection.Open();
                    foreach (var a in doorList)
                    {
                        cmd.Parameters["@DID"].Value = a.DID;
                        cmd.Parameters["@STARTDATE"].Value = StartDate;
                        cmd.Parameters["@ENDDATE"].Value = EndDate;
                        cmd.Parameters["@OrganizationName"].Value = organ;
                        reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            if (UserDataTable.Columns.Contains("GroupName"))
                            {
                                UserDataTable.Columns["GroupName"].DefaultValue = groupName;
                                //UserDataTable.Columns.Remove("GroupName");
                            }else if (!UserDataTable.Columns.Contains("GroupName"))
                            {
                                UserDataTable.Columns.Add("GroupName", typeof(string));
                                UserDataTable.Columns["GroupName"].DefaultValue = groupName;
                            }

                            UserDataTable.Load(reader);

                            var dicTuple = new Tuple<string, string>(groupName, organ);
                            GroupDic.Add(dicTuple, UserDataTable);
                            reader.Close();
                        }
                        else
                        {
                            reader.Close();
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
          
        }
    }
    public class Tuple<T1, T2>
    {
        public T1 Item1 { get; private set; }
        public T2 Item2 { get; private set; }
        public Tuple(T1 a, T2 b)
        {
            Item1 = a;
            Item2 = b;
        }
    }

}