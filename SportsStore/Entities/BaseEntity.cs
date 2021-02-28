using System.ComponentModel.DataAnnotations;

namespace SportsStore.Entities
{
    public abstract class BaseEntity<TKey> : IBaseEntity<TKey>
    {
        [Key]
        public TKey Id { get; set; }
    }
}