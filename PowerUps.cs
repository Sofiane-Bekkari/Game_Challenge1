using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public GameObject player;
    [SerializeField] float moveSpeed = 0.3f;
    public AudioSource powerUpSound;
    public AudioClip powerUpFx;
    public ParticleSystem playerGetParticle;
    private float currentPos;
    private bool moveUp = true;
    public int score = 0;
    public int valueScore = 1;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        currentPos = transform.position.y;
        powerUpSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // ANIMATION MOVE UP/DOWN
        if (moveUp)
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        else
            transform.Translate(-Vector2.up * moveSpeed * Time.deltaTime);

        if (transform.position.y >= currentPos)
        {
            moveUp = false;
            Debug.Log("DOWN>>>>");
        }
        if (transform.position.y <= currentPos -0.5f)
        {
            moveUp = true;
            Debug.Log("UP>>>>");
        }
    }
    // UP/DOWN POWER'UP   DOSEN'T WORKS AS EXPECTED
   
    // COROUTIEN TIMER WHEN DESTROY
    IEnumerator DestroyPowerUps()
    {
            // RETURN YIELD 
            yield return new WaitForSeconds(0.5f); // THIS MIGHT CHANGE ON EACH DIFFICULTY
            Destroy(gameObject);
    }

    // TRIGGER THE PLAYER
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            powerUpSound.PlayOneShot(powerUpFx); // PLAY SOUND FX
            playerGetParticle.Play(); // PLAY FX
            //Destroy(gameObject);
            StartCoroutine(DestroyPowerUps()); // USE COROUTIANE
            Debug.Log("TRIGGER POWER'UP SHOULD PLAY SOUND >>>");
        }
    }
}
