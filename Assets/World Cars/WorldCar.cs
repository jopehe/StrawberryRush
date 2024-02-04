using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCar : MonoBehaviour
{
    public List<Transform> carPath;

 

    public GameObject car;


    string prefabName = "CarPrefab";

    private void Start()
    {
        GameObject carOb = Resources.Load<GameObject>(prefabName);


        if(car != null)
        {
            InstantiateCar();
        }

    }

    void InstantiateCar()
    {
        car = Instantiate(car, carPath[0].position, Quaternion.identity);
        car.GetComponent<NpcCar>().SetValue(carPath);
    }


    private void Update()
    {
        GetButtonDown();
    }

    void GetButtonDown()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {

            InstantiateCar();


        }
    }
}
