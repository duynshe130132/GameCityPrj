using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public Camera[] camera;
    public bool isSwich = false;

    private PlayerController playerController;
    private CarController CarController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        CarController = GetComponent<CarController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isSwich)
        {
            camera[0].gameObject.SetActive(false);
            camera[1].gameObject.SetActive(true);
        }
        else
        {
            camera[0].gameObject.SetActive(true);
            camera[1].gameObject.SetActive(false);
        }
    }
}
