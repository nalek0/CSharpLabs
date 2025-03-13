using System.Diagnostics;

namespace CSharpSemProject.data
{
    class AdministratorDataBuilder
    {
        private string _firstName = null;
        private string _lastName = null;
        private string _nickname = null;
        private string _password = null;

        public AdministratorDataBuilder SetFirstName(string firstName)
        {
            _firstName = firstName;
            return this;
        }

        public AdministratorDataBuilder SetLastName(string lastName)
        {
            _lastName = lastName;
            return this;
        }

        public AdministratorDataBuilder SetNickname(string nickname)
        {
            _nickname = nickname;
            return this;
        }

        public AdministratorDataBuilder SetPassword(string password)
        {
            _password = password;
            return this;
        }

        public AdministratorData Build()
        {
            Debug.Assert(_firstName != null);
            Debug.Assert(_lastName != null);
            Debug.Assert(_nickname != null);
            Debug.Assert(_password != null);
            return new AdministratorData(_firstName, _lastName, _nickname, _password);
        }
    }
}
