using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipGun : MonoBehaviour
{
    public GameObject bullet;
    private bool shoot = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!shoot)
        {
            shoot = true;
            int numberOfBulletToShoot = Random.Range(1, 5);
            StartCoroutine("FireBullet", numberOfBulletToShoot);
        }
    }

    IEnumerator FireBullet(int bulletCount)
    {
        for (int i = 0; i < bulletCount; i++)
        {
            Shoot();
            yield return new WaitForSeconds(Random.Range(0.5f, 1f));
        }

        float timeToWait = Random.Range(2f, 5f);
        yield return new WaitForSeconds(timeToWait);
        shoot = false;
    }

        public void Shoot()
    {
        GameObject go = Instantiate(bullet,transform.position,Quaternion.identity);
    }
}
