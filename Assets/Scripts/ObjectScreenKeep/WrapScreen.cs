using UnityEngine;
using System.Collections;

namespace Asteroids {

	public class WrapScreen : TransformOffscreen {

		//===================================================
		// UNITY METHODS
		//===================================================

		/// <summary>
		/// Update. Check if transform is outside the offscreen positions and if so move to the opposite.
		/// </summary>


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
