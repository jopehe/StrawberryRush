using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{

    static float MAXSPEED = 30f;
    static float MAXFUEL = 100f;

    public TextMeshProUGUI berryCounter;


    public Slider fuelSlider;
    public RectTransform warningImage;
    
    
    private Material mirrorMaterial;


    public Slider SpeedMeter;
    public TextMeshProUGUI SpeedValue;



    public Image sliderImage;

    public Car player;

    private Color startingColor;

    private float fuelVal;
    private int berryCount;


    bool warningLight = true;


    [Header("Speed Idicator!")]

    float minRotation = -90f;
    float maxRotation = 180f;

    float minFRotation = 15f;
    float maxFRotation = 165f;



    public Image _speedIndicator;
    public Image _fuelIndicator;


    public float currentSpeed = 0f;
    public float currentFuel = 100f;

    private void Start() {
        //startingColor = sliderImage.color;
    }

    

    private void FuelBarCollor() { 
        if(fuelSlider.value <= 0.25f) {
            sliderImage.color = Color.red;
            warningLight = true;
        }
        else {
            sliderImage.color = startingColor;
            warningLight = false;
        }
    }

    private void UpdateUI()
    {
        berryCounter.text = "Berries: " + berryCount;
        fuelSlider.value = fuelVal;
    }

    private void WarningLigt()
    {
        if (warningLight)
        {
            WarningLightZoom();
        }
    } 

    private void WarningLightZoom()
    {


        
        if(warningImage.localScale.x >= 0.1f)
        {
            warningImage.localScale -= new Vector3(0.01f, 0.01f, 0.01f * Time.deltaTime);
        }
        else
        {
            Debug.Log("Zoom in");
            warningLight = false;
        }

    }

  //      WarningLigt();
  //      FuelBarCollor();
  //      UpdateUI();


    private void Update()
    {

        SpeedingIndicator();
    }



    //When activated pulls up a text box looking like peace of paper
    //There is text saying that player was speeding 
    //Text shows cost and 

    


    //Set message active 
    //Set message value 

    //Animate message coming to view 

    //Timer to show the message 

    //Retract the message back 
    //Turn message inactive 





    //gets current fuel from the player car gameobject 
    //If fuel is lower than 20-30 % start warninglight fashing function
    //Fuel Dial value depends on player fuel ammount 



    void UpdateFuel()
    {


    }



    float CheckIFValueISValid(float max, float val)
    {
        if (val > max)
        {
            return max;
        }
        else if (val < 0)
        {
            return 0;
        }
        return val;
    }
    Quaternion GetSpeedDialHandRotation(float speed)
    {
        speed = CheckIFValueISValid(MAXSPEED, speed);

        float newAngle = -90 + (speed * 9);

        return Quaternion.Euler(0f, 0f, newAngle);
    }

    Quaternion GetFuelDialHandRotation(float val)
    {
        //165 - 15 = 150 / 100 = 1.5
        val = CheckIFValueISValid(MAXFUEL, val);

        float newAngle = maxRotation - (val * 1.5f);

        return Quaternion.Euler(0f, 0f, newAngle);
    }


    Quaternion GetDialRotation(float speed, float maxValue, float startRotation, float angleval)
    {
        //165 - 15 = 150 / 100 = 1.5
        speed = CheckIFValueISValid(maxValue, speed);

        float newAngle = startRotation + (speed * angleval);

        return Quaternion.Euler(0f, 0f, newAngle);
    }
    void SpeedingIndicator()
    {
        _speedIndicator.transform.rotation = GetSpeedDialHandRotation(currentSpeed);
        _fuelIndicator.transform.rotation = GetFuelDialHandRotation(currentFuel);


        //_speedIndicator.transform.rotation = GetSpeedDialHandRotation(currentSpeed);
        //_fuelIndicator.transform.rotation = GetFuelDialHandRotation(currentFuel);
    }
}
