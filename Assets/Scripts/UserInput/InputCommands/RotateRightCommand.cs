/// <summary>
/// Команда попорота вправо
/// </summary>
public class RotateRightCommand : ICommand
{
	PlayerMovementModel _model;
	
	public RotateRightCommand(PlayerMovementModel model)
	{
		_model = model;
	}
	
	public void Execute()
	{
		_model.RotateRight ();
	}
}
