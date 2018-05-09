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

namespace DXApplication4.ViewModels
{
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

        DataTable _DataTable = new DataTable();
        public DataTable DataTable
        {
            get { return _DataTable; }
            set { _DataTable = value; }
        }

        ObservableCollection<DataTable> _ResultCollection = new ObservableCollection<DataTable>();
        public ObservableCollection<DataTable> ResultCollection
        {
            get { return _ResultCollection; }
            set { _ResultCollection = value; }
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
                //논리그룹에 속한 조직들
                var list = DoorControlViewModel.SelectedGroupInListCollection;
                //논리그룹
                var groupList = DoorControlViewModel.SelectedGroupCollection;
                //출입문
                var doorList = DoorControlViewModel.DoorSelected;

                var builder = new EntityConnectionStringBuilder(ConfigurationManager.ConnectionStrings["ADTSC20"].ConnectionString);
                var regularConnectionString = builder.ProviderConnectionString;
                SqlConnection connection = new SqlConnection(regularConnectionString);
                string query = "Select Eventtime, DoorName, AccessUserCard_SID, USERNAME " +
                               "from ADTSC.CM_AccessEventLog " +
                               "where Door_DID = @DID" +
                               " AND " +
                               "EventTime BETWEEN @STARTDATE AND @ENDDATE";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@DID", SqlDbType.NVarChar);
                cmd.Parameters.Add("@STARTDATE", SqlDbType.DateTime);
                cmd.Parameters.Add("@ENDDATE", SqlDbType.DateTime);

                //DataTable tT = new DataTable();
                SqlDataReader reader;
        
                var state = connection.State.ToString();
                if(state.Equals("Closed"))
                {
                    connection.Open();
                    foreach (var a in doorList)
                    {
                        cmd.Parameters["@DID"].Value = a.DID;
                        cmd.Parameters["@STARTDATE"].Value = StartDate;
                        cmd.Parameters["@ENDDATE"].Value = EndDate;
                        reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            DataTable.Load(reader);
                            ResultCollection.Add(DataTable);
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



    }

}