using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    float horizontal;
    float vertical;








    //gets the rotation of the gameobject 
    Quaternion GetRotation() {
        return transform.rotation;
    }
    //gets position of the gameobject
    Vector3 GetPosition() {
        return transform.position;
    }

    //Get mouses position in the world
    Vector3 MouseWorldPos(Camera camera)
    {
        Vector3 pos = Input.mousePosition;
        return camera.ScreenToWorldPoint(pos);
    }

    void Directions()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }


    // Update is called once per frame
    void Update()
    {
        Directions();
    }



    public float DistanceToPlayer(Vector3 target)
    {    
         Vector3 dis = this.transform.position - target;
         return Mathf.Sqrt(Mathf.Pow(dis.x, 2) + Mathf.Pow(dis.y, 2) + Mathf.Pow(dis.z, 2));
        
    }

    public bool GetShift()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            return true;
        }
        return false;
    }

    public bool GetSpace()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return true;
        }
        return false;
    }
}
