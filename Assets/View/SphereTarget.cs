using UnityEngine;
using System.Collections;

public class SphereTarget : TargetView
{
	private Color color;
	private ParticleSystem boomParticle;
	Animator animator;
	AnimatorStateInfo currentStateInfo;
	private int pointValue;
	//public GameObject spawnPrefubSphere;
	// Use this for initialization
	void Start ()
	{
		if (this.gameObject != null) {
			this.GetComponent<Renderer> ().material.color = this.color;
			animator = this.GetComponent<Animator> ();
			boomParticle = this.GetComponentInParent<ParticleSystem> ();
			boomParticle.Stop ();

		}
	}

	void Update ()
	{
		currentStateInfo = animator.GetCurrentAnimatorStateInfo (0);

	}

	#region implemented abstract members of TargetView

	public override void setPointValue (int pointValue)
	{
		this.pointValue = pointValue;
	}

	public override int getPointValue ()
	{
		return this.pointValue;
	}

	#endregion

	#region implemented abstract members of TargetView


	public override void playParticle ()
	{
		boomParticle.Play ();

	}


	#endregion

	#region implemented abstract members of TargetView
	public override void playAnimation ()
	{
		Debug.Log ("Start Play Animation");
		

		if (currentStateInfo.nameHash == Animator.StringToHash ("Base Layer.Idle")) {
			animator.SetTrigger ("SphereTrigger");
		} 
	}
	#endregion

	#region implemented abstract members of TargetView

	public override void AnimFinish (GameObject target)
	{
		if (currentStateInfo.nameHash == Animator.StringToHash ("Base Layer.SphereAnimator")) {
			Destroy (target);
		} 
	}

	#endregion



	#region implemented abstract members of TargetView

	public override int getType ()
	{
		return Target.Pojo.TargetType.SPHERE;
	}

	#endregion

	#region implemented abstract members of TargetView

	public override GameObject spawnPrefub ()
	{
		return Resources.Load ("SphereContainer", typeof(GameObject)) as GameObject;
	}

	#endregion




	#region implemented abstract members of TargetView

	public override void setColor (Color color)
	{
		this.color = color;
	}

	#endregion
}

