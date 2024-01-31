using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorningState : DayBaseState
{



    Vector3 targetRot = new Vector3(25, 0, 0);

    Quaternion newRot;
    Quaternion startRot;


  
    public override void Awake(DayStateManager manager)
    {

        manager.ammount = 0;

        startRot = manager.transform.rotation;
        newRot = Quaternion.Euler(targetRot);

        manager.time = 0;
        manager.worldLight.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        manager.worldLight.GetComponent<Light>().intensity = 0.01f;
    }


    public override void Update(DayStateManager manager)
    {
        UpdateVariables(manager);

    }


    public void UpdateVariables(DayStateManager manager)
    {

    

        manager.worldLight.transform.rotation = Quaternion.Lerp(startRot, newRot, manager.dayRotationSpeed * manager.ammount);
       
        manager.time += Time.deltaTime;

        if (manager.light.intensity <= 0.25) {
            manager.light.intensity += manager.morningTime * Time.deltaTime;
        }


        manager.ammount += Time.deltaTime;

        if (manager.time >= manager.morningTime) {
            Debug.Log("Change state to day state! ");
            manager.SetState(manager.dayState);
        }


    }

    public override void OnCollisionEnter(DayStateManager manager, Collider collider)
    {

    }

}
