using UnityEngine;
using System.Collections;

public class ViewModelDelegate : MonoBehaviour
{
	public delegate void OnShootingDelegate ();

	public static event OnShootingDelegate shootingDelegate;







	public static void onShooting ()
	{
		if (shootingDelegate != null)
			shootingDelegate ();
		
	}



}

