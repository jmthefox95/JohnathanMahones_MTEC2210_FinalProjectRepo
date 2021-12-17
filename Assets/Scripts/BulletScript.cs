using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public bool isPlayerBullet;
    public float speed;
    private GameManager gManager;
    private float mod;
    private EnemyFormation formation;
    public AudioSource aSource;
    private AudioClip LifeLost;

    // Start is called before the first frame update
    void Start()
    {
        gManager = GameObject.Find("gameManager").GetComponent<GameManager>();
        formation = GameObject.Find("EnemyFormation").GetComponent<EnemyFormation>();

        if (isPlayerBullet)
        {
            mod = 1;
        }
        else
        {
            mod = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerBullet)
        {
            speed = GetSpeed();
        }

        transform.Translate(0, speed * Time.deltaTime * mod, 0);
    }

    private float GetSpeed()
    {
        return speed;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && isPlayerBullet)
        {
            var enemy = collision.gameObject.GetComponent<EnemyScript>();
            enemy.aSource.PlayOneShot(enemy.deathClip);
            gManager.IncreaseScore(enemy.scoreValue);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            gManager.RestartGameOnPlayerDeath();
        }

        Destroy(gameObject);
    }

}
