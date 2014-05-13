using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

		public float keySpeed;
		public float touchSpeed;
		private int count;
		private bool isGameOver;
		public GUIText countText;

		void Start ()
		{
				count = 0;
				setCountText ();
				isGameOver = false;
		}

		void OnGUI ()
		{
				if (isGameOver) {
						// Make a group on the center of the screen
						GUI.BeginGroup (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 100));
						// All rectangles are now adjusted to the group. (0,0) is the topleft corner of the group.
					
						// We'll make a box so you can see where the group is on-screen.
						GUI.Box (new Rect (0, 0, 100, 100), "You Win!!");
					
						if (GUI.Button (new Rect (10, 40, 80, 30), "End Game")) {
								Application.Quit ();
					
						}
					
						// End the group we started above. This is very important to remember!
						GUI.EndGroup ();
				}
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
								isGameOver = true;
						}
				}
		}

		void setCountText ()
		{
				countText.text = "Count: " + count.ToString ();
		}
}
