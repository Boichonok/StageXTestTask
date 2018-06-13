using UnityEngine;
using System.Collections;

public class TargetFactory : MonoBehaviour
{
	

	public static TargetView getTarget (int type)
	{
		if (Target.Pojo.TargetType.CUBE == type) {
			return new CubeTarget ();
		} else if (Target.Pojo.TargetType.SPHERE == type) {
			return new SphereTarget ();
		} else if (Target.Pojo.TargetType.CAPSULE == type) {
			return new CapsuleTarget ();
		} else
			return null;
	}
}

