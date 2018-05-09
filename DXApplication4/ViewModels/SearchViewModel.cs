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

namespace DXApplication4.ViewModels
{
    [POCOViewModel]
    public class SearchViewModel
    {
        /* 시작 날짜 파라미터 바인딩 */
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

        /*끝날짜 파라미터 바인딩 */
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
        public SearchViewModel()
        {
            SearchCommand = new DelegateCommand(SearchCommandAction);
            ReportCommand = new DelegateCommand(ReportCommandAction);
        }

        ObservableCollection<CM_AccessEventLog> _ResultCollection = new ObservableCollection<CM_AccessEventLog>();
        public ObservableCollection<CM_AccessEventLog> ResultCollection
        {
            get { return _ResultCollection; }
            set { _ResultCollection = value; }
        }

        public void SearchCommandAction()
        {
            //시작,마감 날짜로 GroupListView MemberListView 업데이트
            //삭제했던 논리그룹.멤버도 디비에 저장하고 있다가 날짜선택에 따라서 불러와야함
            //중복은?
            //일단모든놈다불러오기?
            try
            {
                //SqlConnection con = new SqlConnection(conn)

                //    con.Open();
                //    string getQuery = "Select * from OC_OutputportInfo";
                //    SqlCommand cmd = new SqlCommand(getQuery, con)
                //    {
                //        CommandType = CommandType.Text
                //    };
                //    var result = cmd.ExecuteNonQuery();

                ADTSC20 db = new ADTSC20();

                //논리그룹에 속한 조직들
                var list = DoorControlViewModel.SelectedGroupInListCollection;
                //논리그룹
                var groupList = DoorControlViewModel.SelectedGroupCollection;
                //출입문
                var doorList = DoorControlViewModel.DoorSelected;

                //3개 조건을 가지고 일단 ACCESSEVENTLOG에서 가져오기
                //우선 Door_DID만 맞는거 가져와보기

                var connectionString = ConfigurationManager.ConnectionStrings["ADTSC20"].ConnectionString;
                var builder = new EntityConnectionStringBuilder(connectionString);
                var regularConnectionString = builder.ProviderConnectionString;

                using(SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    string query = "Select * from db.CM_AccessEventLog where Door_DID = @DID";
                    SqlCommand cmd = new SqlCommand(query);
                    cmd.Parameters.Add("@DID", SqlDbType.NVarChar);

                    foreach (var a in doorList)
                    {
                        cmd.Parameters["@DID"].Value = a.DID;
                        var aaaa = cmd.ExecuteNonQuery();
                        MessageBox.Show("실행 : " + aaaa);
                    }
                }
            }
            catch(Exception e)
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

    public class TestDbSet : CM_AccessEventLog
    {

    }
    
}