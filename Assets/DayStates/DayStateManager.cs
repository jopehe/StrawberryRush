using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayStateManager : MonoBehaviour
{
    public GameObject worldLight;
    public WorldObjectManager manager;

    [Header("Day Stage Settings")]
    [Header("Morning")]
    public float morningTime = 10f;
    public Color morningColor;
    [Header("Day")]
    public float dayTime = 10f;
    public Color dayColor;
    [Header("Evening")]
    public float eveningTime = 10f;
    public Color eveningColor;
    [Header("Night")]
    public float nightTime = 10f;
    public Color nightColor;





    Color start;


    [Space(10)]


    public float lightChangeSpeed = 0.1f;
    public float dayRotationSpeed = 0.2f;


    public float ammount = 0;

    public float time;

    public Light light;

    DayBaseState currentState;

    public MorningState monringState = new MorningState();
    public DayState dayState = new DayState();
    public EvningState evningState = new EvningState();
    public NightState nightState = new NightState();


    Collider col;


    private void Start()
    {
        manager = GameObject.Find("World Object Manager").GetComponent<WorldObjectManager>();

        start = light.color;
        col = GetComponent<Collider>();
        currentState = monringState;
        SetState(currentState);
        Debug.Log("Change state to morning state! ");
        ammount = 0;
    }

    private void Update()
    {

        light = worldLight.GetComponent<Light>();
        currentState.Update(this);
    }



    public void StartSettings()
    {
        light.color = start;
        ammount = 0;
    }


    private void OnTriggerEnter(Collider other)
    {
        currentState.OnCollisionEnter(this, other);
    }



    public void SetState(DayBaseState state)
    {
        currentState = state;
        currentState.Awake(this);

    }
}
