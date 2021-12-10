using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public float playerSpeed;
    public float speed = 1f;
    
    public GameObject playerBullet;

    public AudioSource aSource;
    public AudioClip shootClip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        transform.Translate(xMove, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
     Vector3 offset = new Vector3(0, 0.5f, 0);
     aSource.PlayOneShot(shootClip);
     GameObject bullet = Instantiate(playerBullet, transform.position + offset, Quaternion.identity);   
    }
}
