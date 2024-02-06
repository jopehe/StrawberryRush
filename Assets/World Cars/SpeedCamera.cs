using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedCamera : MonoBehaviour
{
    private float HighSpeed = 5f;

    public Light pointLight;


    public GameObject player;


    private float _curTime;
    private float _flashTimer = 3f;


    private bool _flashCheck;


    private float _PlayerSpeed = 0;

    public Vector3 _playerLastPos = new Vector3(0, 0, 0);


    public Rigidbody rb;




    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = player.GetComponent<Rigidbody>();
        pointLight = GetComponentInChildren<Light>();

        pointLight.gameObject.SetActive(false);
        _playerLastPos = player.transform.position;
        _curTime = _flashTimer;
        _flashCheck = true;

    }







    private void OnTriggerStay(Collider other)
    {
        // && PlayerIsSpeeding
        if (other.gameObject.tag == "Player" && PlayerIsSpeeding)// && PlayerIsSpeeding)
        {
            Flash();
            Debug.Log("Trigger Player Collision!");
        }

    }



    float PlayerSpeed()
    {
        //Vector3 dif = player.transform.position - _playerLastPos;

        //float time = Time.deltaTime - _deltaTime;
        //float speed = dif.magnitude / time;

        //return speed;

        return rb.velocity.magnitude;
    }


    bool PlayerIsSpeeding { get { return (_PlayerSpeed > HighSpeed);  } }


    IEnumerator FlashEffect()
    {
        _flashCheck = false;
        pointLight.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);

        pointLight.gameObject.SetActive(false);
        
        yield return new WaitForSeconds(3f);
        _flashCheck = true;

    }



   

    void Flash()
    {

        _curTime += Time.deltaTime;

        if(_flashCheck == true)
        {
            StartCoroutine(FlashEffect());
            Debug.Log("OVERSPEED FINE");
        }
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(FlashEffect());


        }

        _playerLastPos = player.transform.position;
        //_deltaTime += Time.deltaTime;

        _PlayerSpeed = PlayerSpeed();
        //Debug.Log("Speed: " + _PlayerSpeed);
    }
}
