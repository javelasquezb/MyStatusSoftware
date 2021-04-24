﻿namespace MyStatusSoftware.WebAdministrator.Models.Users
{
    public class CurrentUserViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserType { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
