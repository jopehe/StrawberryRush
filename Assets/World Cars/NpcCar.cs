using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcCar : MonoBehaviour
{
    // Start is called before the first frame update



    public List<Transform> carPath;

    float targetDis = 2f;
    int index = 0;

    Vector3 target;

    public Transform targetTransform;

    bool routeOk = false;


    public void SetValue(List<Transform> path)
    {
        carPath = path;
        routeOk = true;
    }

    void SetTarget(int index)
    {
        target = carPath[index].position;
    }


    void GetNextPoint()
    {
        index++;
        if (index < carPath.Count)
        {
            SetTarget(index);
        }
        else
        {
            index = 0;
            SetTarget(index);
        }
    }


    float Distance(Vector3 position, Vector3 target)
    {
        float xVal = position.x - target.x;
        float yVal = position.y - target.y;
        float zVal = position.z - target.z;

        return Mathf.Sqrt((xVal * xVal) + (yVal * yVal) + (zVal * zVal));
    }


    bool IfArrived { get { return (Distance(transform.position, target) <= targetDis); } }

    void CheckTarget()
    {
        if (IfArrived)
        {
            GetNextPoint();
        }
    }

    Vector3 GetDirection(Vector3 pos1, Vector3 pos2)
    {
        pos2 -= pos1;
        return pos2.normalized;

    }

    Vector3 AddSpeed(Vector3 direction, float speed)
    {
        return (direction * speed) * Time.deltaTime;
    }


    Vector3 MovementTowardsTarget { get { return AddSpeed(GetDirection(transform.position, target), 20f); } }

    void MoveTowardsTarget()
    {
        transform.position += MovementTowardsTarget;
    }



    void LookAtTarget()
    {
        //Debug.Log("Target: " + target);

        Quaternion quad = Quaternion.LookRotation(Vector3.up, target);


        transform.rotation = quad;


        /*
        float angle = Vector3.Angle(Vector3.forward, GetDirection(transform.position, target));
        Vector3 cross = Vector3.Cross(transform.forward, GetDirection(transform.position, target));

        if (cross.y < 0)
        {
            angle = -angle;
        }
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        */    
    }

    // Update is called once per frame
    void Update()
    {

        if(routeOk == true)
        {

            CheckTarget();
            MoveTowardsTarget();
            LookAtTarget();
        }
        else{

            RotateAngleLerp(targetTransform.position);

        }
    }


    void RorateTowards(Vector3 target)
    {
        Vector3 dif = target - transform.position;


        Quaternion lookrotation = Quaternion.LookRotation(dif, Vector3.up);

        transform.rotation = lookrotation;

    }


    void RotateAngle(Vector3 target)
    {
        Vector3 dif = target - transform.position;


        float angle = Mathf.Atan2(dif.x, dif.z) * Mathf.Rad2Deg;


        transform.rotation = Quaternion.Euler(0f, angle, 0f);

    }


    void RotateAngleLerp(Vector3 target)
    {
        Vector3 dif = target - transform.position;


        float angle = Mathf.Atan2(dif.x, dif.z) * Mathf.Rad2Deg;


        Quaternion targetRot = Quaternion.Euler(0f, angle, 0f);


        transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, 2f * Time.deltaTime);

    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collison: " + collision.gameObject.name);




    }
}
