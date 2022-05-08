using Project.BLL.DesingPatterns.GenericRepository.ConcreteRep;
using Project.ENTITIES.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Project.UI.Roles
{
    public class AdminRoleProvider : RoleProvider
    {
        AdminManager _aManager;
        CustomerManager _cManager;
        public AdminRoleProvider()
        {
            _aManager = new AdminManager();
            _cManager = new CustomerManager();
        }

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            if (username.Contains("admin"))
            {
                Admin admin = _aManager.GetActives().Where(x => x.UserName == username).FirstOrDefault();
                return new string[] { admin.Authorization }; //Kullanıcıların yetkilerini Döndürüyor.
            }
            Customer customer = _cManager.GetActives().Where(x => x.Email == username).FirstOrDefault();
            return new string[] { customer.Authorization }; //Kullanıcıların yetkilerini Döndürüyor.

        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}