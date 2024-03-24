using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CarController : MonoBehaviour
{
    private SwitchCamera swCam;
    private PlayerController playerController;
    private SpawnCar spawnCar;

    public bool isRacing = false;
    private float horizontal;
    private float speedRotate = 10f;

    private AudioSource playMusic;
    public AudioClip soundCoin, soundAttrack;

    private Rigidbody carRb;
    // Start is called before the first frame update
    void Start()
    {
        carRb = GetComponent<Rigidbody>();
        playMusic = GetComponent<AudioSource>();

        spawnCar = GameObject.Find("SpawnCar").GetComponent<SpawnCar>();
        swCam = GameObject.Find("SwitchCamera").GetComponent<SwitchCamera>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isRacing)
        {
            playMusic.enabled = true;
            horizontal = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * speedRotate * horizontal * Time.deltaTime);

            if (transform.position.z > 14.5)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 14.5f);
            }
            else if (transform.position.z < 5)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 5);
            }
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            playMusic.PlayOneShot(soundAttrack);
            swCam.isSwich = false;
            isRacing = false;
            playerController.transform.gameObject.SetActive(true);
            playerController.transform.position = transform.position - new Vector3(0, 0, 2);
            playerController.transform.LookAt(transform.position);
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            playMusic.PlayOneShot(soundCoin);
            spawnCar.score++;
            if (spawnCar.score > spawnCar.highscore)
            {
                spawnCar.highscore = spawnCar.score;
                PlayerPrefs.SetInt("Highscore", spawnCar.highscore);
            }
            
            Destroy(collision.gameObject);

        }
    }
}
