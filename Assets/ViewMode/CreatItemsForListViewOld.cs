using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatItemsForListViewOld : MonoBehaviour
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
