using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody targetRb;
    private GameManager gameManagersc;
    public int pointValue;
    public ParticleSystem targetExplosion;
    

    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(Vector3.up * Random.Range(5, 14), ForceMode.Impulse);
        targetRb.AddTorque(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
        transform.position = new Vector3(Random.Range(-4.3f, 4.3f), 1);
        gameManagersc = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (gameManagersc.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(targetExplosion, transform.position, targetExplosion.transform.rotation);
            gameManagersc.updateScore(pointValue);
            if (!gameObject.CompareTag("Good"))
            {
                gameManagersc.GameOver();
            }
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManagersc.livesLeft -= 1;
            gameManagersc.lives.text = "LIVES : " + gameManagersc.livesLeft;
            if (gameManagersc.livesLeft == 0)
            {
                gameManagersc.GameOver();
            }
        
        }

        
    }


}
