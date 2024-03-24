using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    private CarController carController;

    private float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        carController = GameObject.Find("Car").GetComponent<CarController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(carController.isRacing)
        {
            speed = Random.Range(15, 30);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            if (transform.position.z > 14.5)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 14.5f);
            }
            else if (transform.position.z < 5)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 5);
            }

            if(transform.position.x < -320)
            {
                Destroy(gameObject);
            }
        }   
    }
}
