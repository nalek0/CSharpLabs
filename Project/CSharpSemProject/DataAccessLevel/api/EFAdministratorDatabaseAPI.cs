using DataDomenLevel.data;
using DataDomenLevel.api;
using System;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;

namespace DataAccessLevel.api
{
    public class EFAdministratorDatabaseAPI : IAdministratorDatabaseAPIStrategy
    {
        public List<AdministratorData> GetAdministrators()
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                return db.Administrators.ToList();
            }
        }
        public AdministratorData GetAdministrator(int id)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                var administrator = db.Administrators.Find(id);

                return administrator;
            }
        }

        public AdministratorData GetAdministrator(string nickname, string password)
        {
            Console.WriteLine("[ LOG ]");

            foreach (var admin in GetAdministrators())
                Console.WriteLine(admin);

            Console.WriteLine("[ END ]");

            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                var administrator = from admin in db.Administrators
                                    where admin.Nickname == nickname && admin.Password == password
                                    select admin;

                return administrator.FirstOrDefault();
            }
        }

        public AdministratorData CreateAdministrator(string firstName, string lastName, string nickname, string password)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                var administratorData = new AdministratorData
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Nickname = nickname,
                    Password = password,
                };
                db.Administrators.Add(administratorData);
                db.SaveChanges();

                return administratorData;
            }
        }

        public AdministratorData RemoveAdministrator(int id)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                var administratorData = db.Administrators.Find(id);
                db.Administrators.Remove(administratorData);
                db.SaveChanges();

                return administratorData;
            }
        }

        public AdministratorData EditAdministrator(int id, string firstName, string lastName, string nickname)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                var administratorData = db.Administrators.Find(id);

                if (administratorData != null)
                {
                    administratorData.FirstName = firstName;
                    administratorData.LastName = lastName;
                    administratorData.Nickname = nickname;
                    db.SaveChanges();
                }
                
                return administratorData;
            }
        }
    }
}
