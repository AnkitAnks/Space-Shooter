using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyController : MonoBehaviour
{
    public Vector2 direction = new Vector2(0, -1);

    public float speed = 2;

    public Vector2 velocity;

    private int hitPoint = 3;

    public Warship warship;

    private void Start()
    {
        warship = GameObject.FindGameObjectWithTag("WarShip").GetComponent<Warship>();
    }


    // Update is called once per frame
    void Update()
    {
        velocity = direction * speed;
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos += velocity * Time.fixedDeltaTime;

        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag =="Bullet")
        {
            hitPoint--;
            Destroy(collision.gameObject);
            if(hitPoint <= 0)
            {
                Destroy(gameObject);
                warship.UpdateScore();
            }

        }
    }
}
