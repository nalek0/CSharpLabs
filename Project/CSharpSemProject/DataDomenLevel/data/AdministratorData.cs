namespace DataDomenLevel.data
{
    public class AdministratorData
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }

        public AdministratorData() { }

        public AdministratorData(string firstName, string lastName, string nickname, string password)
        {
            this.UserId = -1;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Nickname = nickname;
            this.Password = password;
        }
    }
}
