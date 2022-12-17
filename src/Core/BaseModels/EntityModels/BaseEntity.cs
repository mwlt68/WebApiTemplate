
namespace Core.BaseModels.EntityModels
{
    public abstract class BaseEntity : BaseModel, IBaseEntity
    {
        public int Id { get; set; }
    }
}
