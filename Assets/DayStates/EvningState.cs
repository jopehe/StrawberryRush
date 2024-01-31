using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvningState : DayBaseState
{
    Vector3 targetRot = new Vector3(160f, 0, 0);

    Quaternion newRot;
    Quaternion startRot;
    
    public override void Awake(DayStateManager manager)
    {

        startRot = manager.worldLight.transform.rotation;
        newRot = Quaternion.Euler(targetRot);

        manager.ammount = 0;
        manager.time = 0;

        //manager.worldLight.transform.rotation = Quaternion.Euler(150f, 0f, 0f);
        //manager.worldLight.GetComponent<Light>().intensity = 0.25f;
    }


    public override void Update(DayStateManager manager)
    {

        manager.worldLight.transform.rotation = Quaternion.Lerp(startRot, newRot, manager.dayRotationSpeed * manager.ammount);

        manager.ammount += Time.deltaTime;


        if (manager.light.intensity >= 0.5)
        {
            manager.light.intensity -= manager.lightChangeSpeed * Time.deltaTime;
        }




        manager.time += Time.deltaTime;

        if (manager.time >= manager.eveningTime)
        {
            manager.SetState(manager.nightState);
            Debug.Log("Change state to Night state! ");

        }
    }


    public override void OnCollisionEnter(DayStateManager manager, Collider collider)
    {

    }

}
