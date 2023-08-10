

using System.Collections.Generic;
using System;
using DataLayer.Entities;

namespace BusinessLayer.Dtos.Admin
{
    public class UserListViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string UserAvatar { get; set; }

        public DateTime RegisterDate { get; set; }
        public List<UserRole> UserRoles { get; set; }
    
}
}
