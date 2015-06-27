

public interface IFSMCondition<T>
{
	bool IsTriggered(T entity);
}