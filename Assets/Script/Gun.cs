using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
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
        shoot = Input.GetButtonDown("Fire1");
        if(shoot)
        {
            shoot = false;
            Shoot();
        }
    }

    public void Shoot()
    {
        GameObject go = Instantiate(bullet,transform.position,Quaternion.identity);
    }
}
