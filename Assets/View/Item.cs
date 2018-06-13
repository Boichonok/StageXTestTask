using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
	Target.Container targetContainer;
	// Use this for initialization




	private GameObject[] spawnPoints;

	[HideInInspector]
	public int itemIndex;

	public 
	void Start ()
	{
		targetContainer = Target.Container.Load (Path.Combine (Application.dataPath, Target.Container.FILE_NAME));
		spawnPoints = GameObject.FindGameObjectsWithTag ("SpawnPoint");
		Debug.Log ("Icon name: " + this.transform.GetChild (0).name);

		this.transform.GetChild (0).GetComponent<Image> ().overrideSprite = Resources.Load (targetContainer.targets [itemIndex].iconTypePath, typeof(Sprite)) as Sprite;
		this.transform.GetChild(1).GetComponent<Text>().text = targetContainer.targets [itemIndex].pointValue.ToString ();




	}



	public void setTargetSpawn ()
	{
		//targetContainer.targets [itemIndex].typeofTarget
		Debug.Log("Called: " + itemIndex);
		switch (targetContainer.targets [itemIndex].typeofTarget) {
		case Target.Pojo.TargetType.CUBE:
			{
				GameObject cubeTarget = Instantiate (TargetFactory.getTarget(Target.Pojo.TargetType.CUBE).spawnPrefub(), spawnPoints [Random.Range (0, spawnPoints.Length)].transform);
				Color color = new Color ();
				color.r = targetContainer.targets [itemIndex].color [0];
				color.g = targetContainer.targets [itemIndex].color [1];
				color.b = targetContainer.targets [itemIndex].color [2];
				cubeTarget.transform.GetChild(0).gameObject.AddComponent<CubeTarget> ().setColor(color);
				cubeTarget.transform.GetChild (0).gameObject.GetComponent<CubeTarget> ().setPointValue (targetContainer.targets [itemIndex].pointValue);

			}
			break;
		case Target.Pojo.TargetType.SPHERE:
			{
				GameObject sphere = Instantiate (TargetFactory.getTarget(Target.Pojo.TargetType.SPHERE).spawnPrefub(), spawnPoints [Random.Range (0, spawnPoints.Length)].transform);
				Color color = new Color ();
				color.r = targetContainer.targets [itemIndex].color [0];
				color.g = targetContainer.targets [itemIndex].color [1];
				color.b = targetContainer.targets [itemIndex].color [2];
				sphere.transform.GetChild(0).gameObject.AddComponent<SphereTarget> ().setColor (color);
				sphere.transform.GetChild (0).gameObject.GetComponent<SphereTarget> ().setPointValue (targetContainer.targets [itemIndex].pointValue);
			}
			break;
		case Target.Pojo.TargetType.CAPSULE:
			{
				GameObject capsule = Instantiate (TargetFactory.getTarget(Target.Pojo.TargetType.CAPSULE).spawnPrefub(), spawnPoints [Random.Range (0, spawnPoints.Length)].transform);
				Color color = new Color ();
				color.r = targetContainer.targets [itemIndex].color [0];
				color.g = targetContainer.targets [itemIndex].color [1];
				color.b = targetContainer.targets [itemIndex].color [2];
				capsule.transform.GetChild(0).gameObject.AddComponent<CapsuleTarget> ().setColor (color);
				capsule.transform.GetChild (0).gameObject.GetComponent<CapsuleTarget> ().setPointValue (targetContainer.targets [itemIndex].pointValue);
			}
			break;
		}
	}


}
