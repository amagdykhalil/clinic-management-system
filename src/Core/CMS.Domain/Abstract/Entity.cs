using CMS.Domain.Interfaces;

namespace CMS.Domain.Abstract
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}



