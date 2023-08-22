

using System.Collections.Generic;
using System;
using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

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

    public class InsertUserViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        [DataType(DataType.Upload)]
        [FromForm(Name = "UserAvatar")]
        [FileExtensions(Extensions = "jpg,png,gif,jpeg,bmp,svg")]
        public IFormFile UserAvatar { get; set; }
        public string UserImageName { get; set; }

        public List<RoleViewModel> RoleList { get; set; }

    }

    public class RoleViewModel
    {
        public string Name { set; get; }
        public int Id { set; get; }
        public bool IsSelected { set; get; }
    }
}
