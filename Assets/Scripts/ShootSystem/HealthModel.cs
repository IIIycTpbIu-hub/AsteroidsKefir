/// <summary>
/// Модель здоровья.
/// </summary>
public class HealthModel {
	
	public bool SetDamage(int damage, IDestroyable victim)
	{
		victim.TakeDamage (damage);
		if (victim.GetHealth () <= 0) {
			return true;
		}
		return false;
	}
}
