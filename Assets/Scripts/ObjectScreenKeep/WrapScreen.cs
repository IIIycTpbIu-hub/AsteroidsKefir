using UnityEngine;

namespace Asteroids {
	public class WrapScreen : TransformOffscreen
	{
		private void OnBecameInvisible() 
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
