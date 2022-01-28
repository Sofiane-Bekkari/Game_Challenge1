using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float verticalInput;
    public float horizontalInput;
    public int score = 0;
    public int valueScore = 1; // value score
    public TextMeshProUGUI textScore; // DISPALY SCORE
    public TextMeshProUGUI textHighScore; // DISPALY SCORE
    public AudioSource enemySound;
    public AudioClip enemyHit;
    public AudioClip higherScore;
    // PARTICLE SYSTEM
    // Particle System
    public ParticleSystem enemyHitParticle;
    public ParticleSystem powerUpParticle;
    public Rigidbody player;
    public GameObject tripleplayer;
    public GameObject powerUps;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
        tripleplayer = GameObject.Find("Triple_Enemy");
        powerUps = GameObject.Find("PowerUp");
        // Get Component
        enemySound = GetComponent<AudioSource>();
        // GET Component
    }

    // Update is called once per frame
    void Update()
    {
        // MOVEING PLAYER
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.up * verticalInput *  speed * Time.deltaTime);
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

      
    }

    // ON COLLIDER
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("TripleEnemy") || collision.gameObject.CompareTag("TwiceEnemy") || collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("GAME OVER >>>" + collision.gameObject); // WHEN ENEMY TOUCH
            UpdateScore(-valueScore);
            enemySound.PlayOneShot(enemyHit); // playing sound
            enemyHitParticle.Play(); // EFFECT PARTICLE
        }
    }

    // POWER UP ON TRIGGER
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            UpdateScore(valueScore);
            powerUpParticle.Play(); // EFFECT 
            Debug.Log("POWER'UPs " + "SCORE: " + score );
        }
    }

    // UPDATE SCORE
    public void UpdateScore(int addScore)
    {   
        score += addScore; // ADD VALUE TO INITIAL SCORE
        textScore.text = "SCORE: " + score; // DISPLAY TO SCREEN
                                            // TEXT SCORE + VARIABLE SCORE
                                            // WHEN GAME GET 10 POINT SCORE
        if (score == 5)
        {
            textHighScore.gameObject.SetActive(true);
            enemySound.PlayOneShot(higherScore);
            //textGameOver.gameObject.SetActive(true); // DISPALY GAME OVER
        }
        else

            textHighScore.gameObject.SetActive(false);
    }
}
