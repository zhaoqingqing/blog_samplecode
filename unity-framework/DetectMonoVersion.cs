using UnityEngine;
using System;
using System.Reflection;

//show what unity use mono vertion
public class DetectMonoVersion : MonoBehaviour {
	void Start()
	{
		Type type = Type.GetType("Mono.Runtime");
		if (type != null)
		{
			MethodInfo info = type.GetMethod("GetDisplayName", BindingFlags.NonPublic | BindingFlags.Static);
			
			if (info != null)
				Debug.Log(info.Invoke(null, null));
		}
      //Debug.Log(System.Enviroment.Version);//net version?
	}
}