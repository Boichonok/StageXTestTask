using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

public class PojoOld
{

	public static class TargetType
	{
		public const int CUBE = 0;
		public const int SPHERE = 1;
		public const int CAPSULE = 2;
	}


	[XmlAttribute ("iconTypePth")]
	public string iconTypePath;
	[XmlElement ("typeofTarget")]
	public int typeofTarget;
	[XmlElement ("color")]
	public float[] color = new float[3];
	[XmlElement]
	public int pointValue;



}
