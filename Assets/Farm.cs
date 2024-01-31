using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Farm : MonoBehaviour
{
    int maxItems = 10;
    int items = 0;



    public GameObject dayStateMashine;

    public TextMeshPro text;
    public GameObject main;
    GameObject player;
    Car playerClass;


    public bool canCollect = false;


    public GameObject textObject;
    public float distance = 0;

    float berrySpawnTime = 3f;
    float time = 0;

    //State morning Stete
    ///Waits untill all workers are added to the farm 
    ///Untill time is done 
    //State working state
    ///Adds every x seconds one strawberry box, depending on how many workers are 
    ///Max speed is one every 10 seconds at the max and every 60 seconds when one worker is present. 
    //State ending State 
    ///When ending state is on player must transport all the workers to the home. 



    private void Start()
    {
        dayStateMashine = GameObject.FindWithTag("DSM");
        player = GameObject.FindGameObjectWithTag("Player");
        playerClass = player.GetComponent<Car>();
        main = Camera.main.gameObject;
        UpdateText();
    }


    //Pick up items, can be done so long untill no tiems exist
    public void PickUpItems() {
        if (0 < items) {
            Debug.Log("Collect berry!");
            playerClass.strawberris += 1;
            items -= 1;
        }
        else
        {
            Debug.Log("Could not collect berry!");
        }
        UpdateText();
    }


    //Timer on how strawberries are generated on 
    void StrawberryTimer()
    {
        time += Time.deltaTime;
        if (time >= berrySpawnTime && items <= maxItems)
        {
            items++;
            UpdateText();
            time = 0;
        }
    }


    //Gets distance 
    float Distance()
    {
        Vector3 dis = this.transform.position - player.transform.position;
        return  Mathf.Sqrt(Mathf.Pow(dis.x, 2) + Mathf.Pow(dis.y, 2) + Mathf.Pow(dis.z, 2));
    }



    void UpdateText() { 
        //text.text = "Distance = " + Distance();
        text.text = "Berries: " + items;
    }


    //Rotates ui towards to the player 
    void RotateTowardsCamera()
    {
        Vector3 direction = this.transform.position - main.transform.position;
        direction.x = 0;
        direction.z = 0;
    }


    //Distance on how far distance is to the player
    void PickUpDistance() {
        if (distance <= 10) {
            canCollect = true;
        }
        else {
            canCollect = false;
        }
    }

    private void CollectItems() {
    
        if (Input.GetKeyDown(KeyCode.Space) && canCollect) {
            Debug.Log("Collect!");
            PickUpItems();
        }
    }



    private void Update()
    {

        distance = Distance();

        PickUpDistance();
        CollectItems();

        StrawberryTimer();
    }
}
