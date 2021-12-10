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

    // Start is called before the first frame update
    void Start()
    {
        gManager = GameObject.Find("gameManager").GetComponent<gameManager>();
        formation = GameObject.Find("EnemyFormation").GetComponent<EnemyFormation>();

        if (isPlayerBullet)
        {
            mod = 1;
        }
        else
        {
            mod = -1;
        }

        mod = isPlayerBullet = true?1 : -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerBullet)
        {
            speed = speed;
        }

        transform.Translate(0, speed * Time.deltaTime * mod, 0);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && isPlayerBullet)
        {
            var enemy = collision.GameObject.GetComponent<EnemyScript>();
            enemy.aSource.PlayOneShot(enemy.deathClip);
            Destroy(collision.gameObject);
            gManager.IncreaseScore(collision.gameObject.GetComponent<EnemyScript>().scoreValue);
        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            gManager.RestartGame();
        }

        Destroy(gameObject);
    }

}
