using Core.BaseModels.EntityModels;

namespace DataAccess.Entities
{
    public partial class User : BaseEntity
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
