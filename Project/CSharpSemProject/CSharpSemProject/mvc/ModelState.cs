namespace CSharpSemProject.mvc
{
    class ModelState
    {
        public delegate void OnUpdate(ModelState viewState);

        private AdministratorData _administratorDataState = null;
        public AdministratorData AdministratorDataState {
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

        public OnUpdate UpdateEvent = null;
    }
}
