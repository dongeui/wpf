using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using DXApplication4.Models;
using System.Windows.Input;
using DXApplication4.Commands;

namespace DXApplication4.ViewModels
{
    [POCOViewModel]
    public class SearchViewModel
    {
       
        public SearchViewModel()
        {
            //저장된 논리그룹 불러오는거 1, 해당 리스트 불러오는거 1, 리포트 커맨드 1
        }

        /// <summary>
        /// 조회 커맨드
        /// </summary>
        private ICommand setListUpdater;
        public ICommand SearchCommand
        {
            get
            {
                if (this == null)
                    setListUpdater = new SearchCommand();
                return setListUpdater;
            }
            set
            {
                setListUpdater = value;
            }
        }
        /// <summary>
        /// 리포트 커맨드
        /// </summary>
        private ICommand reportCommand;
        public ICommand ReportCommand
        {
            get
            {
                if (this == null)
                    reportCommand = new ReportCommand();
                return reportCommand;
            }
            set
            {
                reportCommand = value;
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