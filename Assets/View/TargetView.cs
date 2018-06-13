using UnityEngine;
using System.Collections;

public abstract class TargetView : MonoBehaviour
{
	public abstract void setColor (Color color);

	public abstract void setPointValue (int pointValue);

	public abstract int getPointValue ();

	public abstract int getType ();

	public abstract GameObject spawnPrefub ();

	public abstract void playAnimation ();

	public abstract void AnimFinish (GameObject target);

	public abstract void playParticle ();



	void OnDestroy(){
		playParticle ();
	}




}

