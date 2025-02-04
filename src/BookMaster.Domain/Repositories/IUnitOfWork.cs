namespace BookMaster.Domain.Repositories;
public interface IUnitOfWork
{
    Task Commit();
}
