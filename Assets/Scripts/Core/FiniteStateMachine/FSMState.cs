

public interface IFSMState<T>
{
	void Enter(T entity);	
	void Execute(T entity);
	void Exit(T entity);
}