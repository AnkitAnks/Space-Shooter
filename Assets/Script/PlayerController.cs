using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    float xInput;
    float yInput;

    private Health health;

    // Contains referennce of explosion particle prefab
    public ParticleSystem explosion;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
    }

    private void FixedUpdate()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        transform.Translate(xInput*speed*Time.deltaTime,yInput*speed*Time.deltaTime,0);
    }

    // Check and update the player health when a bullet hits.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            health.DamagePlayer(10);
            Destroy(collision.gameObject);
            if (health.curHealth <= 0)
            {
                Destroy(gameObject);
                Instantiate(explosion, transform.position, Quaternion.identity);
                SceneManager.LoadScene("SampleScene");
            }

        }

        else if(collision.gameObject.tag == "EnemyShip")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
            SceneManager.LoadScene("SampleScene");
            
        }
    }
}
