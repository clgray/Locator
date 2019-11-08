using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Cnit.Testor.Core.Server
{
    [Serializable]
    [DataContract]
    public sealed class TestorCoreUser
    {
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string SecondName { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string NewPassword { get; set; }
        [DataMember]
        public TestorUserStatus Status { get; set; }
        [DataMember]
        public bool Sex { get; set; }
        [DataMember]
        public DateTime Birthday { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string StudNumber { get; set; }
        [DataMember]
        public string AfinaId { get; set; }
        [DataMember]
        public TestorUserRole UserRole { get; set; }
        [DataMember]
        public TestorTreeItem[] UserGroups { get; set; }
        [DataMember]
        public bool IsLocalUser { get; set; }

        public TestorCoreUser()
        {

        }

        public void SetSettings(TestorCoreUser user)
        {
            AfinaId = user.AfinaId;
            Birthday = user.Birthday;
            Email = user.Email;
            FirstName = user.FirstName;
            IsLocalUser = user.IsLocalUser;
            LastName = user.LastName;
            Login = user.Login;
            NewPassword = user.NewPassword;
            Password = user.Password;
            SecondName = user.SecondName;
            Sex = user.Sex;
            Status = user.Status;
            StudNumber = user.StudNumber;
            UserGroups = user.UserGroups;
            UserId = user.UserId;
            UserRole = user.UserRole;
        }

        public TestorCoreUser(TestorCoreUser user)
        {
            SetSettings(user);
        }
    }
}
