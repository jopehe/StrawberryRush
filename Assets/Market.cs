using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Market : MonoBehaviour
{
    int maxItems = 10;
    int items = 3;



    public TextMeshPro text;
    public GameObject camear;

    GameObject player;
    Car playerClass;

    public GameObject textObject;
    float distance = 0;

    float berrySpawnTime = 3f;
    float time = 0;


    public bool canPickUp = false;

    public float distanceM;
    //State morning Stete
    ///Waits untill strawberries are brought to the market during morning
    ///If strawberries have not been brought to the market place untill morning is over, market will close.
    //State working state
    ///Adds removes one strawberrry every 30-60 seconds 
    //IF strawberries have been consumed, will wait for 60 seconds utill market is closed 
    //State ending State 
    ///At the evning market can be closed when it is fisited, where all reamining strawberries are picked up 
    ///If market has not been closed untill night arrives, strawberries will be lost and proffit will be lost 






    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerClass = player.GetComponent<Car>();
        camear = Camera.main.gameObject;
        UpdateText();
    }


    //Picks up one item
    public void PickUpItems() {
        if (items < maxItems && playerClass.strawberris > 0) {
            items++;
            Debug.Log("Add Berry!");
            playerClass.strawberris -= 1;
        }
        UpdateText();
      
    }


    //Gets distance 
    float Distance()
    {
        Vector3 dis = this.transform.position - player.transform.position;
        return  Mathf.Sqrt(Mathf.Pow(dis.x, 2) + Mathf.Pow(dis.y, 2) + Mathf.Pow(dis.z, 2));
    }



    //Updates the text object
    void UpdateText()
    {
        //text.text = "Distance = " + Distance();
        text.text = "Berries: " + items;

    }




    void DistanceCalculation() {
        if(distanceM <= 10) {
            canPickUp = true;
            //Can dropp of strawberries 
        }
        else {
            canPickUp = false;
        }
    }



    private void PlayerInput()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canPickUp)
        {
            PickUpItems();

        }
    }

    private void Update()
    {

        distanceM = Distance();
        PlayerInput();
        DistanceCalculation();
        UpdateText(); // REMOVE
    }
}
