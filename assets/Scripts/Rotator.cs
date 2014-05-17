using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{
		public GameObject gameBoard;

		void Update ()
		{
				transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
		}
}
