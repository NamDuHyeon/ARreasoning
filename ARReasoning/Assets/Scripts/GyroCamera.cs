using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroCamera : MonoBehaviour {

    private Gyroscope gyro;
    private bool gyroSupported;
    private Quaternion rotFix;

	// Use this for initialization
	void Start () {
        gyroSupported = SystemInfo.supportsGyroscope;

        GameObject camParent = new GameObject("CamParent");
        camParent.transform.position = transform.position;
        transform.parent = camParent.transform;

        if (gyroSupported)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            camParent.transform.rotation = Quaternion.Euler(90f, 180f, 0f);
            rotFix = new Quaternion(0, 0, 1, 0);
        }
	}
	
	// Update is called once per frame
	void Update () {
        transform.localRotation = gyro.attitude * rotFix;
	}
}
