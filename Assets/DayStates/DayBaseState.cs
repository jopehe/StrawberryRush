using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DayBaseState 
{

    public abstract void Awake(DayStateManager manager);


    public abstract void Update(DayStateManager manager);


    public abstract void OnCollisionEnter(DayStateManager manager, Collider collider);






}
