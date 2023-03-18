namespace Core.BaseModels.DtoModels
{
    public abstract class IdenticalBaseDto : BaseDto, IIdenticalModel
    {
        public int Id { get; set; }
    }
}
