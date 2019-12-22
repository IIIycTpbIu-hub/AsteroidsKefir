using UnityEngine;
using System.Collections;

namespace Asteroids {

	public class WrapScreen : TransformOffscreen {

		private void Update()
		{
			CheckCoordinates();
			if(isOffscreen)
			{
				transform.position = Camera.main.ViewportToWorldPoint( viewportPos );
			}
		}


	}
}
