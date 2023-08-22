


namespace BusinessLayer.Dtos.Group
{
    public class AddGroupViewModel
    {
        public string TiTle { get; set; }
        public int? ParentId { get; set; }
    }
    public class GroupListViewModel
    {
        public int GroupId { get; set; }
        public string TiTle { get; set; }
        public int? ParentId { get; set; }
    }
}
