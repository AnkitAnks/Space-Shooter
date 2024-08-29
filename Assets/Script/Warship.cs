using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Warship : MonoBehaviour
{
    public GameObject enemyShip;

    public bool isEnemyShipActivated = false;

    public int enemyShipNum = 0;

    public TMP_Text score;

    public int destoryedShipCount = 0;

    private void Start()
    {
        score.text = "Score: " + destoryedShipCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isEnemyShipActivated && enemyShipNum<=99)
        {
            isEnemyShipActivated = true;
            StartCoroutine("GenerateEnemy");
        }
    }

    IEnumerator GenerateEnemy()
    {
        GenerateEnemyShip(enemyShipNum);
        enemyShipNum++;
        float timeToWait = Random.Range(2f, 7f);
        yield return new WaitForSeconds(timeToWait);
        isEnemyShipActivated = false;
    }

    private void GenerateEnemyShip(int i)
    {
        float xPos = Random.Range(-10.0f, 10.0f);
        Vector3 shipPos = new Vector3(xPos, transform.position.y, transform.position.z);
        GameObject go = Instantiate(enemyShip, shipPos ,Quaternion.identity);
        Destroy(go,25);
    }

    public void UpdateScore()
    {
        destoryedShipCount++;
        score.text = "Score: " + destoryedShipCount.ToString();
    }


}
