using UnityEngine;
using System.Collections;
using System.IO;
namespace Controller 
{
	public class CreatItemsForListView : MonoBehaviour
	{



		public GameObject itemPrefub;


		// Use this for initialization
		void Start ()
		{
			createItems ();
		}



		private void createItems ()
		{
			GameObject itemInstance;
			Target.Container targetsContainer = new Target.Container ();
			targetsContainer.createItemsForLevel1();

			Debug.Log ("Turgets Size: " + targetsContainer.targets.Count);
			for (int i = 0; i < targetsContainer.targets.Count; i++) {
				itemInstance = (GameObject)Instantiate (itemPrefub, transform);
				Item item = itemInstance.GetComponent<Item> ();
				item.itemIndex = i;
			}
		}
	}


	public class Player : MonoBehaviour
	{

		private int lastKilledTargetType;
		private GameObject currentTarget;
		private int playerScores = 0;
		private Target.Container targetsContainer;
		private float time = 0.0f;

		public void Start ()
		{
			targetsContainer = Target.Container.Load (Path.Combine (Application.dataPath, Target.Container.FILE_NAME));
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
					playerScores += getPointsFromTarget (target.getType());
					lastKilledTargetType = target.getType ();
					Debug.Log ("Score: " + playerScores);

				}
			}

		}



		private int getPointsFromTarget (int type)
		{
			int points = 0;
			for (int i = 0; i < targetsContainer.targets.Count; i++) {
				if (targetsContainer.targets [i].typeofTarget == type) {
					points = targetsContainer.targets [i].pointValue;

				} 
			}
			return points;
		}


	}

}

