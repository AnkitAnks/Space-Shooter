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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            health.DamagePlayer(10);
            Destroy(collision.gameObject);
            if (health.curHealth <= 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene("SampleScene");
            }

        }

        else if(collision.gameObject.tag == "EnemyShip")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            SceneManager.LoadScene("SampleScene");
            
        }
    }
}
