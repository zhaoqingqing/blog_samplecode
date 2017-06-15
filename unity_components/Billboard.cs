using UnityEngine;
using System.Collections;

/// <summary>
/// 公告板，始终朝向镜头方向
/// </summary>
public class Billboard : MonoBehaviour {
	
    private Transform cameraToLookAt;
    private Transform tran;
	
	// Use this for initialization
	void Start () {
        cameraToLookAt = Camera.main.transform;
        tran = transform;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 vec = cameraToLookAt.position - tran.position;
        vec.x = vec.z = 0.0f;
        tran.LookAt(cameraToLookAt.position - vec);
	}
}
