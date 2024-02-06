using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcCar : MonoBehaviour
{
    // Start is called before the first frame update



    public AudioClip crash;
    public AudioClip horn;

    private AudioSource audioS;
    private Rigidbody rb;

    public List<Transform> carPath;

    float targetDis = 2f;
    int index = 0;

    Vector3 target;

    public Transform targetTransform;

    bool routeOk = false;


    float crashDistance = 5f;

    float hornDistance = 15f;



    float currentSpeed;


    float normalSpeed = 15f;
    float slowSpeed = 5f;
    float stopSpeed = 0.1f;


    static float HORNMAXTIME = 4f;
    float hornTime = 0;

    public Transform rayCastPoint;

    private void Start()
    {
        audioS = GetComponent<AudioSource>();
        rb = this.GetComponent<Rigidbody>();
        rayCastPoint = transform.GetChild(0);
        currentSpeed = normalSpeed;

    }

    public void SetValue(List<Transform> path)
    {
        carPath = path;
        routeOk = true;
    }

    void SetTarget(int index)
    {
        target = carPath[index].position;
    }




    bool RayCheckDistance(float distance, Color color)
    {
        Ray ray = new Ray(rayCastPoint.position, rayCastPoint.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance, color);
        if (Physics.Raycast(ray, distance))
        {
            return true;
        }
        return false;
    }
    bool HornDistance()
    {
        if (RayCheckDistance(hornDistance, Color.green))
        {
            currentSpeed = slowSpeed;
            CarHornTimer();
            return true;
        }
        return false;
    }

    bool CrashDistance()
    {
        if (RayCheckDistance(crashDistance, Color.red))
        {
            currentSpeed = stopSpeed;
            CarHornTimer();
            return true;
        }
        return false;
    }
    void CarHornTimer()
    {
        hornTime += Time.deltaTime;

        if(hornTime >= HORNMAXTIME)
        {
            hornTime = 0;
            audioS.PlayOneShot(horn);
        }
    }
    void SpeedCalculation()
    {
        HornDistance();
        CrashDistance();
        if(!CrashDistance() && !HornDistance())
        {
            currentSpeed = normalSpeed;
        }
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

    Vector3 MovementTowardsTarget { get { return AddSpeed(GetDirection(transform.position, target), currentSpeed); } }

    void MoveTowardsTarget()
    {
        transform.position += MovementTowardsTarget;
    }
    // Update is called once per frame
    void Update()
    {
        SpeedCalculation();
        if (routeOk == true)
        {

            CheckTarget();
            MoveTowardsTarget();
            RotateAngleLerp(target);
        }
        else{

            RotateAngleLerp(target);

        }
    }
    void RotateAngleLerp(Vector3 target)
    {
        Vector3 dif = target - transform.position;
        float angle = Mathf.Atan2(dif.x, dif.z) * Mathf.Rad2Deg;
        Quaternion targetRot = Quaternion.Euler(0f, angle, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, 9f * Time.deltaTime);

    }
    void CarCrash(Collision col)
    {
        Debug.Log("Collison: " + col.gameObject.name);

        rb.isKinematic = false;
        rb.useGravity = true;
        Destroy(this);

        audioS.PlayOneShot(crash);
    
    }
    private void OnCollisionEnter(Collision collision)
    {


        if(collision.gameObject.layer == 6)
        {
            CarCrash(collision);
        }
    }
}
