namespace CHSNS.Models
{
    public class Category
    {
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }

        public virtual byte Type { get; set; }

        public virtual long Count { get; set; }

        public virtual long? UserId { get; set; }
    }
}