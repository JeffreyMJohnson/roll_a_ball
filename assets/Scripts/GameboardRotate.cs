using UnityEngine;
using System.Collections;

public class GameboardRotate : MonoBehaviour
{

		public float step;
		public float rotXLimit;

		private float limitXMin, limitXMax;
		
		private float epsilon;

		void Start ()
		{
				epsilon = .0001f;
				limitXMin = rotXLimit;
				limitXMax = 360 - rotXLimit;
		}

	
		// Update is called once per frame
		void Update ()
		{
				float rotX = transform.rotation.eulerAngles.x;
				
				if (Mathf.Abs (limitXMin - rotX) <= epsilon || Mathf.Abs (limitXMax - rotX) <= epsilon) {
						step *= -1;
						Debug.Log ("hit limit");
				}
				transform.Rotate (new Vector3 (1, 0, 0) * step);
		}
}
