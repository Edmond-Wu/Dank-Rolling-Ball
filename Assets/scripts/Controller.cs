using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Controller : MonoBehaviour {

	public float speed;
	private int count;
	private Rigidbody rb;
	public Text scoreText;
	public Text victoryText;

	void Start() {
		rb = GetComponent<Rigidbody> ();
		count = 0;
		setScoreText ();
		victoryText.text = "";
	}

	void FixedUpdate() {
		float move_horizontal = Input.GetAxis ("Horizontal");
		float move_vertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (move_horizontal, 0.0f, move_vertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Coin")) {
			other.gameObject.SetActive (false);
			count++;
			setScoreText();
		}
	}

	void setScoreText() {
		scoreText.text = "Score: " + count.ToString ();
		if (count >= 14) {
			victoryText.text = "DANKEST VICTORY!";
		}
	}
}
