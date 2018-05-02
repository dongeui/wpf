using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;

namespace DXApplication4.ViewModels
{
    [POCOViewModel]
    public class SearchViewModel
    {
        public DelegateCommand SearchCommand { get; set; }
        public DelegateCommand ReportCommand { get; set; }
        public SearchViewModel()
        {
            SearchCommand = new DelegateCommand(SearchCommandAction);
            ReportCommand = new DelegateCommand(ReportCommandAction);
            DoorControlViewModel doorViewModel = new DoorControlViewModel();
            //저장된 논리그룹 불러오는거 1, 해당 리스트 불러오는거 1, 리포트 커맨드 1
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

        public void SearchCommandAction()
        {
            //시작,마감 날짜로 GroupListView MemberListView 업데이트
            try
            {
                var start = _StartDate;
            }
            catch
            {

            }
        }

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


    }
    
}