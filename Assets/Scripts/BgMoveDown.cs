using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMoveDown : MonoBehaviour
{
    //public bool isMove = false;

    CarController carController;
    private float speedMove = 6f;

    // Start is called before the first frame update
    void Start()
    {
        carController = GameObject.Find("Car").GetComponent<CarController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (carController.isRacing)
        {
            transform.Translate(Vector3.right * speedMove * Time.deltaTime);
        }
    }
}
