using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightState : DayBaseState
{
    Vector3 targetRot = new Vector3(170, 0, 0);

    Quaternion newRot;
    Quaternion startRot;


    public override void Awake(DayStateManager manager)
    {
        startRot = manager.worldLight.transform.rotation;
        newRot = Quaternion.Euler(targetRot);
;

        manager.ammount = 0;

        manager.time = 0;
        //manager.worldLight.transform.rotation = Quaternion.Euler(180f, 0f, 0f);
        //manager.worldLight.GetComponent<Light>().intensity = 0.10f;
    }


    public override void Update(DayStateManager manager)
    {
        manager.worldLight.transform.rotation = Quaternion.Lerp(startRot, newRot, manager.dayRotationSpeed * manager.ammount);

        manager.ammount += Time.deltaTime;

        if (manager.light.intensity >= 0.01)
        {
            manager.light.intensity -= manager.lightChangeSpeed * Time.deltaTime;
        }


        manager.time += Time.deltaTime;

        if (manager.time >= manager.nightTime)
        {
            manager.SetState(manager.monringState);
            Debug.Log("Change state to morning state!");
        }

    }

   

    public override void OnCollisionEnter(DayStateManager manager, Collider collider)
    {

    }

}
