using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFormation : MonoBehaviour
{
    public float speed = 2;
    public bool movingDown;
    public bool movingSide;
    public Vector3 destination;
    private float descendSpeed;
    private float timeTillFire;
    private float fireDelay = 3;
    private EnemyScript [] enemies;
    public GameObject enemyBullet;

    public AudioSource aSource;
    public AudioClip deathClip;
    // Start is called before the first frame update
    void Start()
    {
        movingSide = true;
        timeTillFire = fireDelay;
        enemies = GetComponentsInChildren<EnemyScript>().gameObject;
    }

    public void PlayEnemyDeathAudio()
    {
        aSource.PlayOneShot(deathClip);
    }

    // Update is called once per frame
    void Update()
    {
        if (movingSide)
        {
            MoveHorizontal();
        }

        if (movingDown)
        {
            MoveDown();
        }

        if (timeTillFire > 0)
        {
        timeTillFire -= Time.deltaTime;
        }
        else
        {
            EnemyShoot();
            timeTillFire = fireDelay;
        }
    }

    
    public void EnemyShoot()
    {
        int numberOfEnemies = GetComponentsInChildren<EnemyScript>().Length;
        
        if (numberOfEnemies <= 0) return;

        int index = Random.Range(0, numberOfEnemies);
        var enemyArray = GetComponentsInChildren<EnemyScript>();

        Vector3 bullPos = enemyArray[index].transform.position;
        Instantiate(enemyBullet, Vector3.zero, Quaternion.identity);
    }

    public void SetDestinationAndMoveDown ()
    {
        destination = new Vector3 (transform.position.x, transform.position.y - 0.75f, transform.position.z);
        movingDown = true;
    }


    public void MoveDown()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * speed);

        if (transform.position == destination)
        {
            movingDown = false;
            speed * -1;
            movingSide = true;
        }
    }


    public void MoveHorizontal()
    {
        transform.Translate (speed * Time.deltaTime * 0 , 0);
    }
}
