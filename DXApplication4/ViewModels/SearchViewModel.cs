using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Data.Entity.Core.Objects;

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
            DoorControlViewModel doorViewModel = new DoorControlViewModel();
        }


        public void SearchCommandAction()
        {
            //시작,마감 날짜로 GroupListView MemberListView 업데이트
            //삭제했던 논리그룹.멤버도 디비에 저장하고 있다가 날짜선택에 따라서 불러와야함
            //중복은?
            //일단모든놈다불러오기?
            try
            {
                //var conn = ConfigurationManager.ConnectionStrings["ADTSC20Entities"].ConnectionString;
                //SqlConnection sql = new SqlConnection(conn);
                //sql.Open();


              // // ADTSC20Entities db = new ADTSC20Entities();
              //  var context = db.UC_Organization;



                //MemberListView.ItemSource = query.ToList();


                string getQuery = "Select * from UC_Organization";
                SqlCommand cmd = new SqlCommand(getQuery);
                //SqlDataReader reader =  cmd.ExecuteXmlReader();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            }
            catch
            {

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