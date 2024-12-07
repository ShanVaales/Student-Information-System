namespace SIS.Model.BaseModel
{
    public class TimeEntity
    {
        public int Id { get; set; }
        public string? CreatedId { get; set; }
        public DateTime? CreatedTime { get; set; } = DateTime.UtcNow;
        public bool? IsDeleted { get; set; }
        public DateTime? DeletedTime { get; set; }
        public string? DeletedId { get; set; }
        public string UserId { get; set; }
    }
}
