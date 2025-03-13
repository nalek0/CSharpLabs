using System.Collections.Generic;

namespace CSharpSemProject.mvc
{
    public class ModelState
    {
        public delegate void OnUpdate(ModelState viewState);

        private AdministratorData _administratorDataState = null;
        public AdministratorData AdministratorDataState
        {
            get
            {
                return _administratorDataState;
            }
            set
            {
                _administratorDataState = value;
                UpdateEvent?.Invoke(this);
            }
        }

        private List<UserData> _userDataListState = null;
        public List<UserData> UserDataListState
        {
            get
            {
                return _userDataListState;
            }
            set
            {
                _userDataListState = value;
                UpdateEvent?.Invoke(this);
            }
        }

        private List<VideoData> _videoDataListState = null;
        public List<VideoData> VideoDataListState
        {
            get
            {
                return _videoDataListState;
            }
            set
            {
                _videoDataListState = value;
                UpdateEvent?.Invoke(this);
            }
        }

        private List<ReportData> _reportDataListState = null;
        public List<ReportData> ReportDataListState
        {
            get
            {
                return _reportDataListState;
            }
            set
            {
                _reportDataListState = value;
                UpdateEvent?.Invoke(this);
            }
        }

        public OnUpdate UpdateEvent = null;
    }
}
