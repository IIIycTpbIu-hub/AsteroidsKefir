/// <summary>
/// Команда поворота влево
/// </summary>
public class RotateLeftCommand : ICommand
{
	PlayerMovementModel _model;

	public RotateLeftCommand(PlayerMovementModel model)
	{
		_model = model;
	}

	public void Execute()
	{
		_model.RotateLeft ();
	}
}
