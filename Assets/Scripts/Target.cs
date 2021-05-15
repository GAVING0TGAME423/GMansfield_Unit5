using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{
    private Rigidbody targetRB;
    private const float minforce = 10;
    private const float maxforce = 15;
    private const float minTorque = -10;
    private const float maxTorque = 10;
    private const float minxpos = -3;
    private const float maxxpos = 3;
    private const float yspawnpos = -2;
    private GameManager gameManager;

    public int pointvalue;
    public ParticleSystem explosion;

    void Start()
    {
        targetRB = GetComponent<Rigidbody>();
        RandomForce();
        RandomTorque();
        RandomSpawnPosition();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void RandomForce()
    {
        targetRB.AddForce(Vector3.up * Random.Range(minforce, maxforce), ForceMode.Impulse);
    }
   
    void RandomTorque()
    {
        targetRB.AddTorque(Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque),
            Random.Range(minTorque, maxTorque), ForceMode.Impulse);
    }

    void RandomSpawnPosition()
    {
        transform.position = new Vector3(Random.Range(minxpos, maxxpos), yspawnpos);
    }

    private void OnMouseDown()
    {
        if (gameManager.gameactive)
        {
            gameManager.UpdateScore(pointvalue);
            Destroy(gameObject);
            Instantiate(explosion, transform.position, explosion.transform.rotation);
        }
               
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if (!gameObject.CompareTag("Bomb"))
        {
            gameManager.GameOver();
        }
    }
   
}

