using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    public ParticleSystem explosion;
    private GameManager gameManager;
    public int score;
    
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRb.AddForce(randomForce(), ForceMode.Impulse);
        targetRb.AddTorque(randomTorque(), randomTorque(), randomTorque(), ForceMode.Impulse);
        transform.position = randomSpawn();
    }

    Vector3 randomForce()
    {
        return Vector3.up * Random.Range(10, 15);
    }
    float randomTorque()
    {
        return Random.Range(-10, 10);
    }
    Vector3 randomSpawn()
    {
        return new Vector3(Random.Range(-4, 4), -1);
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            if (gameManager.lives <= 1 && gameManager.gameActive && !gameManager.ispaused)
            {
                Destroy(gameObject);
                gameManager.livesFunction();
                gameManager.gameOver();
            }
            else if (gameManager.lives > 1 && gameManager.gameActive && !gameManager.ispaused)
            {
                gameManager.livesFunction();
            }
        }
    }
    public void destroyTarget()
    {
        if (gameManager.gameActive && !gameManager.ispaused)
        {
            Destroy(gameObject);
            gameManager.updateScore(score);
            Instantiate(explosion, transform.position, explosion.transform.rotation);
        }
    }
}
