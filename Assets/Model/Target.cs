using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

/*

*/
namespace Target {

	public class Pojo
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
	[XmlRoot("TargetsCOllection")]
	public class Container {
		public const string FILE_NAME = "Targets.xml";



		public void createItemsForLevel1(){
			createCube();
			creatCapsule();
			creatSphere();
		}

		[XmlArray("Targets"),XmlArrayItem("Target")]
		public List<Target.Pojo> targets = new List<Target.Pojo> ();


		private void createCube(){
			Target.Pojo cube = new Target.Pojo ();
			cube.iconTypePath = "cube";
			cube.typeofTarget = Target.Pojo.TargetType.CUBE;
			cube.color[0] = Color.green.r;
			cube.color [1] = Color.green.g;
			cube.color [2] = Color.green.b;
			cube.pointValue = 50;
			targets.Add (cube);
			Save (Path.Combine(Application.dataPath, FILE_NAME));
		}

		private void creatSphere(){
			Target.Pojo sphere = new Target.Pojo ();
			sphere.iconTypePath = "sphere";
			sphere.typeofTarget = Target.Pojo.TargetType.SPHERE;
			sphere.pointValue = 70;
			sphere.color[0] = Color.red.r;
			sphere.color [1] = Color.red.g;
			sphere.color [2] = Color.red.b;
			targets.Add (sphere);
			Save (Path.Combine (Application.dataPath, FILE_NAME));
		}

		private void creatCapsule(){
			Target.Pojo capsule = new Target.Pojo ();
			capsule.iconTypePath = "capsule";
			capsule.typeofTarget = Target.Pojo.TargetType.CAPSULE;
			capsule.pointValue = 30;
			capsule.color[0] = Color.blue.r;
			capsule.color [1] = Color.blue.g;
			capsule.color [2] = Color.blue.b;
			targets.Add (capsule);
			Save (Path.Combine (Application.dataPath, FILE_NAME));
		}



		public void Save(string path)
		{
			var serializer = new XmlSerializer(typeof(Target.Container));
			using(var stream = new FileStream(path, FileMode.Create))
			{
				serializer.Serialize(stream, this);
			}
		}

		public static Target.Container Load(string path)
		{
			var serializer = new XmlSerializer(typeof(Target.Container));
			using(var stream = new FileStream(path, FileMode.Open))
			{
				return serializer.Deserialize(stream) as Target.Container;
			}
		}
	}
}

