using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

		public float keySpeed;
		public float touchSpeed;
		private int count;
		public GUIText countText;
		public GUIText winText;

		void Start ()
		{
				count = 0;
				setCountText ();
				winText.text = "";
		}

		void Update ()
		{
//				if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
//						speed = 100.0f;
//						Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;
//						Vector3 movement = new Vector3 (touchDeltaPosition.x, 0.0f, touchDeltaPosition.y);
//						rigidbody.AddForce (movement * speed * Time.deltaTime);
//				}

				float x = Input.GetAxis ("Mouse X");
				float y = Input.GetAxis ("Mouse Y");
				rigidbody.AddForce (new Vector3 (x, 0.0f, y) * touchSpeed);


		}
	
		void FixedUpdate ()
		{
				float moveHorizontal = Input.GetAxis ("Horizontal");
				float moveVertical = Input.GetAxis ("Vertical");

				Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

				rigidbody.AddForce (movement * keySpeed * Time.deltaTime);

		}

		void OnTriggerEnter (Collider other)
		{
				if (other.gameObject.tag == "Pickup") {
						other.gameObject.SetActive (false);
						count++;
						setCountText ();

						if (count == 14) {
								winText.text = "You Win!";
						}
				}
		}

		void setCountText ()
		{
				countText.text = "Count: " + count.ToString ();
		}
}
