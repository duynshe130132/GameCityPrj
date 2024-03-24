using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private SwitchCamera swCam;
    private CarController carController;

    private Rigidbody rb;

    private float horizontal, vertical;
    private float fwSpeed = 5f, rotaSpeed = 50f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= 2f;

        swCam = GameObject.Find("SwitchCamera").GetComponent<SwitchCamera>();
        carController = GameObject.Find("Car").GetComponent<CarController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * fwSpeed * vertical * Time.deltaTime);
        transform.Rotate(Vector3.up * rotaSpeed * horizontal * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            swCam.isSwich = true;
            carController.isRacing = true;
            transform.gameObject.SetActive(false);
        }
    }
}
