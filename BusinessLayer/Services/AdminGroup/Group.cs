

using BusinessLayer.Dtos.Group;
using BusinessLayer.Services.InterFace;
using DataLayer.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Services.AdminGroup
{
   
    public class Group : IAdminGroup
    {
        private readonly BigStoreContext _context;

        public Group(BigStoreContext context)
        {
            _context = context;
        }

        public void AddGroup(AddGroupViewModel addGroupViewModel)
        {
            DataLayer.Entities.Course.Group group = new DataLayer.Entities.Course.Group();
            group.Title = addGroupViewModel.TiTle;
            if(addGroupViewModel.ParentId != null)
            {
                group.ParentId = addGroupViewModel.ParentId;
            }
            _context.groups.Add(group);
            _context.SaveChanges();
           
        }


        public List<SelectListItem> GroupList()
        {
            SelectListItem ss = new SelectListItem();
            ss.Text = "انتخاب کنید";
            ss.Value = "0";
    
           var GroupList= _context.groups.Select(x => new SelectListItem() { Text = x.Title, Value = x.GroupId.ToString() }).ToList();
            GroupList.Insert(0,ss);
            return GroupList;
        }
        public List<GroupListViewModel> GetAllGroups()
        {
            return _context.groups.Select(c => new GroupListViewModel() {
            
            TiTle=c.Title,
            GroupId=c.GroupId,
            ParentId=c.ParentId
            }).ToList();

        }

    }
}
