using UnityEngine;
using System.Collections;

public class MoveTowardsCommand : ICommand
{
	PlayerMovementModel _model;

	public MoveTowardsCommand(PlayerMovementModel model)
	{
		_model = model;
	}

	public void Execute()
	{
		_model.MoveTowards ();
	}
}
