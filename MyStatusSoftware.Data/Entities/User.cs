using MyStatusSoftware.Common.Enums;
using System;
using System.Linq;

namespace MyStatusSoftware.Data.Entities
{
    public class User : IEntity
    {
        private string _email;
        public User()
        {
            CreationDate = DateTime.Now;
            IsEnable = true;
        }
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreationUser { get; set; }
        public bool IsEnable { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email 
        {
            get => _email; 
            set 
            {
                _email = value;
                UserName = !string.IsNullOrEmpty(_email) ? _email.Split("@").FirstOrDefault() : _email;
            } 
        }
        public string Password { get; set; }
        public UserType UserType { get; set; }
        public string UserName { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUser { get; set; }
        public DateTime DateOrdering { get; set; }
    }
}
