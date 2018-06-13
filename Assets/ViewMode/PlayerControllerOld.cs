using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class PlayerControllerOld : MonoBehaviour
{
	
	private int lastKilledTargetType;
	private GameObject currentTarget;
	private int playerScores = 0;

	private float time = 0.0f;

	private Text scoreText;

	public void Start ()
	{
		scoreText = GameObject.FindGameObjectWithTag ("scoreTextUI").GetComponent<Text> ();
	}
	public void Update(){
		if (Input.GetButtonDown ("Fire1")) {
			ViewModelDelegate.onShooting();
		}

		if (time > 0.0f) {
			time -= 1 * Time.deltaTime;
			Debug.Log ("Time: " + time);
		} else {
			Destroy (currentTarget);
		}

		scoreText.text = "Score: " + playerScores.ToString ();
	}
	void OnEnable ()
	{
		ViewModelDelegate.shootingDelegate += shoot;
		//ViewModelDelegate.shootingDelegate += shootAudio;
	}


	void OnDisable ()
	{
		ViewModelDelegate.shootingDelegate -= shoot;
		//ViewModelDelegate.shootingDelegate -= shootAudio;

	}

	void shootAudio(){
		this.GetComponent<AudioSource> ().Play();
	}


	void shoot ()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit)) {
			if (hit.collider != null) {
				TargetView target = hit.collider.GetComponent<TargetView> ();
				shootAudio ();
				if (target.getType () == lastKilledTargetType) {
					Destroy (target.gameObject);
				} else {
					time = 2f;
					target.playAnimation ();
				}
				currentTarget = target.gameObject;
				playerScores += target.getPointValue ();
				lastKilledTargetType = target.getType ();
				Debug.Log ("Score: " + playerScores);

			}
		}

	}






}

