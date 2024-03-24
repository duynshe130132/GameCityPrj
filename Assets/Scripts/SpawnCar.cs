using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SpawnCar : MonoBehaviour
{
    public GameObject[] carPrefabs;
    public TMP_Text textScore;
    public int score, highscore;

    private CarController carController;
    private float startDelay = 2f, repeatTime = 2f;
    private float zPos,yPos, xPos;
    private float index;
    private Vector3 vector3;
    // Start is called before the first frame update
    void Start()
    {
        
        carController = GameObject.Find("Car").GetComponent<CarController>();
        yPos = carController.transform.position.y;
        InvokeRepeating("GenereCar", startDelay, repeatTime);
        InvokeRepeating("GenereCoin", startDelay, 0.5f);

        highscore = PlayerPrefs.GetInt("Highscore");
    }

    void Update()
    {
        if (carController.isRacing)
        {
            textScore.text = "Score: " + score + "\nHighscore: " + highscore;
        }
        else
        {
            score = 0;
        }

    }
    // Update is called once per frame
    private void GenereCar()
    {
        if(carController.isRacing)
        {

            int index = Random.Range(0, carPrefabs.Length - 1);
            zPos = Random.Range(5, 15);
            xPos = Random.Range(-270, -230);
            vector3 = new Vector3(xPos, yPos, zPos);

            Instantiate(carPrefabs[index], vector3, carPrefabs[index].transform.rotation);
        }
       
    }

    private void GenereCoin()
    {
        if (carController.isRacing)
        {
            int index = carPrefabs.Length - 1;
            zPos = Random.Range(5, 15);
            xPos = Random.Range(-300, -280);
            vector3 = new Vector3(xPos, yPos, zPos);

            Instantiate(carPrefabs[index], vector3, carPrefabs[index].transform.rotation);
        }
    }
}
