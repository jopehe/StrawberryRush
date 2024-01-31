using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayState : DayBaseState
{

    Vector3 targetRot = new Vector3(90f, 0f, 0f);

    Quaternion newRot;
    Quaternion startRot;


    public override void Awake(DayStateManager manager)
    {


        manager.StartSettings();

        startRot = manager.worldLight.transform.rotation;
        newRot = Quaternion.Euler(targetRot);
        manager.time = 0;
    }



    public override void Update(DayStateManager manager)
    {

        manager.worldLight.transform.rotation = Quaternion.Lerp(startRot, newRot, manager.dayRotationSpeed * manager.ammount);

        manager.ammount += Time.deltaTime;


        LerpWorldLights(manager);

        manager.time += Time.deltaTime;

        if (manager.time >= manager.dayTime)
        {
            manager.SetState(manager.evningState);
            Debug.Log("Cahnge state to evning state! ");
        }
    }


   
    void LerpWorldLights(DayStateManager manager)
    {
        if(manager.light.intensity <= 1)
        {
            manager.light.intensity += manager.lightChangeSpeed * Time.deltaTime;
        }



        Quaternion newRot = Quaternion.Euler(targetRot);
       manager.transform.rotation = Quaternion.Lerp(manager.transform.rotation, newRot, 3f);

    }

    public override void OnCollisionEnter(DayStateManager manager, Collider collider)
    {

    }
}
