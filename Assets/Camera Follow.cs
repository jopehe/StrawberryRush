using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Camera cameraMain;


    public Transform target;

    public Vector3 difference;

    private void Start()
    {
        cameraMain = this.gameObject.GetComponent<Camera>();
        cameraMain.transform.position = target.transform.position + difference;
    }


    private void Update()
    {

        cameraMain.transform.position = target.transform.position + difference;



    }




}
