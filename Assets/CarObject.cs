using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarObject : MonoBehaviour
{
    public Transform target;

    public float force = 1;

    Rigidbody rb;

    public List<Transform> route;
    int routePoint = 0;
    public Transform targetPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        if(route.Count > 0) { 
            targetPoint = route[0];
        }

    }


    bool CheckIfDistanceIsClose(Transform targetpoint, Transform currentPos, float maxDist)
    {

        float distace = Mathf.Sqrt(Mathf.Pow(targetPoint.position.x - currentPos.position.x, 2) + Mathf.Pow(targetPoint.position.y - currentPos.position.y, 2));
        //Debug.Log("Dis: " + distace);

        //float distance = Vector3.Distance(targetPoint.position, currentPos.position);

        if(distace < maxDist)
        {
            return true;
        }

        return false;
    }



    // Update is called once per frame
    void Update()
    {


        if(CheckIfDistanceIsClose(targetPoint, this.transform, 0.5f)) {
            
            if(routePoint >= route.Count - 1 ) {
                routePoint = 0;
            }
            else
            {
            routePoint++;
            }

            targetPoint = route[routePoint];

        }


        //Rotate towards camera 
        //transform.LookAt(targetPoint);
        //RotateTowards();

        RotateTowards();

        MoveToward();
    }


    void RotateTowards()
    {
        Vector3 dir = (targetPoint.transform.position - transform.position).normalized;

        Quaternion quaternion = Quaternion.Euler(dir);
        quaternion.x = 0;
        quaternion.z = 0;

        transform.rotation = quaternion;

    }

    void MoveToward()
    {
        rb.AddForce((targetPoint.position - transform.position).normalized * force, ForceMode.Force);
    }
}
