/// <summary>
/// Интерфейс уничтожаемого объекта.
/// </summary>
public interface IDestroyable {

	int GetHealth();
	void TakeDamage(int damage);
	void Destroy();
}
