using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
		public float keySpeed;
		public float touchSpeed;
		public GUIText countText;
		public Font timerFont;
		public GUIText timerText;

		private int count;
		private System.DateTime startTime;
		private bool isGameOver;
	
		void Start ()
		{
				count = 0;
				setCountText ();
				isGameOver = false;
				startTime = System.DateTime.Now;
				Debug.Log (startTime.ToString ());

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
				System.TimeSpan elapsedTime = System.DateTime.Now.Subtract (startTime);
				Debug.Log ("time: " + elapsedTime);
				string timerString = string.Format ("Time {0:D2}:{1:D2}", elapsedTime.Minutes, elapsedTime.Seconds);
				timerText.text = timerString;
				if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
						Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;
						Vector3 movement = new Vector3 (touchDeltaPosition.x, 0.0f, touchDeltaPosition.y);
						rigidbody.AddForce (movement * touchSpeed * Time.deltaTime);
				}


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
