using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI berryCounter;
    public Slider fuelSlider;
    public Material mirrorMaterial;


    public RectTransform warningImage;


    public Image sliderImage;

    public Car player;

    private Color startingColor;

    private float fuelVal;
    private int berryCount;


    bool reverse = false;


    bool warningLight = true;

    private void Start() {
        startingColor = sliderImage.color;
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

  

    private void ZoomTo(float size, float speed, bool dir)
    {

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



    private void Update()
    {
        WarningLigt();
        FuelBarCollor();
        UpdateUI();
    }

}
