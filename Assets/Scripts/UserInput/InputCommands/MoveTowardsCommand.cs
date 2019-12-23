/// <summary>
/// Команда полета прямо
/// </summary>
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
