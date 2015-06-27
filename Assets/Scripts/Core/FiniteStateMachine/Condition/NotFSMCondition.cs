


public class NotFSMCondition<T> : IFSMCondition<T>
{
	protected IFSMCondition<T> internalCondition;

	public NotFSMCondition(IFSMCondition<T> condition)
	{
		internalCondition = condition;
	}

	public virtual bool IsTriggered(T entity)
	{
		return !internalCondition.IsTriggered(entity);
	}
}