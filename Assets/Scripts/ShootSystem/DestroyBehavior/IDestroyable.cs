using UnityEngine;
using System.Collections;

public interface IDestroyable {

	int GetHealth();
	void TakeDamage(int damage);
	void Destroy();
}
