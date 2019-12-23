using UnityEngine;

namespace Asteroids {
	/// <summary>
	/// Выполняет проверку и пересчет координат объекта, в случае, если он вылетел за камеру
	/// </summary>
	public class WrapScreen : TransformOffscreen
	{
		private void Update() 
		{
			if(gameObject.activeInHierarchy)
			{
				CheckCoordinates();
				if(isOffscreen)
				{
					transform.position = Camera.main.ViewportToWorldPoint( viewportPos );
				}
			}
			
		}
	}
}
