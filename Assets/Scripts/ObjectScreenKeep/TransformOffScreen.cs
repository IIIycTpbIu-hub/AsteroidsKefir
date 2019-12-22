using UnityEngine;

namespace Asteroids {

	public class TransformOffscreen : MonoBehaviour {

		[SerializeField]
		private float padding = 0.1f;

		protected bool isOffscreen;
		protected Vector3 viewportPos;

		private float top;
		private float bottom;
		private float left;
		private float right;

		public virtual void Awake() {
			// top = 0.0f - padding;
			// bottom = 1.0f + padding;
			// left = 0.0f - padding;
			// right = 1.0f + padding;
			top = 0.0f;
			bottom = 1.0f;
			left = 0.0f;
			right = 1.0f;
		}

		public void CheckCoordinates() {
			// convert transform position to viewport position.
			viewportPos = Camera.main.WorldToViewportPoint( transform.position );
			isOffscreen = false;

			// check x
			if( viewportPos.x < left ) {
				viewportPos.x = right + padding;
				isOffscreen = true;
			} else if( viewportPos.x > right ) {
				viewportPos.x = left - padding;
				isOffscreen = true;
			}

			// check y
			if( viewportPos.y < top ) {
				viewportPos.y = bottom + padding;
				isOffscreen = true;
			} else if( viewportPos.y > bottom ) {
				viewportPos.y = top - padding;
				isOffscreen = true;
			}
		}
	}
	

}
