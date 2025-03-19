namespace Basket.Host.Domain
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }
        public bool IsDelete { get; set; }
    }
}
