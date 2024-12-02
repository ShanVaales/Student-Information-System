namespace SIS.Model.BaseModel
{
    public class TimeEntity
    {
        public string CreatedId { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedTime { get; set; }
        public string DeletedId { get; set; }
    }
}
