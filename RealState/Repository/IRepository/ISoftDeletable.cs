namespace RealState.Repository.IRepository;

public interface ISoftDeletable
{
    bool IsDeleted { get; set; }
}
