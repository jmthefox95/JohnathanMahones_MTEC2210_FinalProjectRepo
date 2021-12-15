using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyFormation : MonoBehaviour
{
    public float speed = 2;
    public bool movingDown;
    public bool movingSide;
    public Vector3 destination;
    private float descendSpeed = 2;
    private float timeTillFire;
    private float fireDelay = 3;
    public GameObject enemyBullet;
    public GameManager gManager;
    
    private EnemyFormation formation;


    public AudioSource aSource;
    public AudioClip deathClip;
    // Start is called before the first frame update
    void Start()
    {
        movingSide = true;
        timeTillFire = fireDelay;
        
        formation = GetComponentInParent<EnemyFormation>();
        gManager = GameObject.Find("gameManager").GetComponent<GameManager>();
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

    public void SpawnNewWave()
    {
        int numberOfEnemies = GetComponentsInChildren<EnemyScript>().Length;
        int index = Random.Range(0, numberOfEnemies);
        var enemyArray = GetComponentsInChildren<EnemyScript>();

        
        Vector3 enemyPos = enemyArray[index].transform.position;

        if (numberOfEnemies <= 0)
        {
            Instantiate(enemyArray[index], enemyPos, Quaternion.identity);
        }

    
    public void EnemyShoot()
    {
        int numberOfEnemies = GetComponentsInChildren<EnemyScript>().Length;
        int index = Random.Range(0, numberOfEnemies);
        var enemyArray = GetComponentsInChildren<EnemyScript>();

        Vector3 bullPos = enemyArray[index].transform.position;
        Instantiate(enemyBullet, bullPos, Quaternion.identity);
    }

    public void SetDestinationAndMoveDown ()
    {
        destination = new Vector3 (transform.position.x, transform.position.y - 0.75f, transform.position.z);
        movingDown = true;
    }


    public void MoveDown()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * descendSpeed);

        if (transform.position == destination)
        {
  
            movingDown = false;
            speed *= -1;
            movingSide = true;
        }
    }


    public void MoveHorizontal()
    {
        transform.Translate (speed * Time.deltaTime , 0,0);
    }

}
