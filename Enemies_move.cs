using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies_move : MonoBehaviour
{
    private GameObject enemy;
    public float speed = 5f;
    public GameObject tripleEnemy;
    public GameObject twiceEnemy;
    // Start is called before the first frame update
    void Start()
    {

        tripleEnemy = GameObject.Find("Triple_Enemy");
        twiceEnemy = GameObject.Find("Twice_Enemy");
      

    }

    // Update is called once per frame
    void Update()
    {
        // MOVE FORWARD
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < -30)
        {
            Destroy(gameObject);
            Destroy(tripleEnemy);
            Destroy(twiceEnemy);
        }
        
    }

    // ON COLLISION OUTSIDE

}
