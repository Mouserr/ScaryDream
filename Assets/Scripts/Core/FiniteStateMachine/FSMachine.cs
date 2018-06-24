using System.Collections.Generic;


public class FSMachine<T>
{
	private T owner;
	private IFSMState<T> currentState;
	private Dictionary<IFSMState<T>, List<FSMStateTransition<T>>> statesGraph;

	public void Awake()
	{
		currentState = null;
	}

	public void Configure(T owner, Dictionary<IFSMState<T>, List<FSMStateTransition<T>>> statesGraph, IFSMState<T> InitialState)
	{
		this.statesGraph = statesGraph;
		this.owner = owner;
		ChangeState(InitialState);
	}

	public void Update()
	{
		if (currentState != null)
		{
			List<FSMStateTransition<T>> graphEdges;
			if (statesGraph.TryGetValue(currentState, out graphEdges))
			{
				for (int i = 0; i < graphEdges.Count; i++)
				{
					if (graphEdges[i].Condition.IsTriggered(owner))
					{
						ChangeState(graphEdges[i].NextState);
						break;
					}
				}
			}
			currentState.Execute(owner);
		}
	}

	private void ChangeState(IFSMState<T> NewState)
	{
		if (currentState != null)
		{
			currentState.Exit(owner);
		}
		currentState = NewState;
		if (currentState != null)
		{
			currentState.Enter(owner);
		}
	}
}
