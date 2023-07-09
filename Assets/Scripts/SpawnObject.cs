using System.Collections;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    private float TimeUpdate = 60;
    private float timeToSpawn = 2;
    public float speed = 10f;
    private float count;
    int randomNumber;
    // Start is called before the first frame update
    void Start()
    {
        IncreaseSpeed();
        StartCoroutine(SpawnEnemy());
    }
    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            AbstractEnemyFactory factory = GetRandomFactory();
            GameObject enemy = factory.CreateEnemy();
            if (enemy != null)
            {
                if(randomNumber == 1)
                {
                    enemy.transform.position = new Vector3(8.1f, -2f, -9f);
                    enemy.SetActive(true);
                }
                else if(randomNumber == 2)
                {
                    enemy.transform.position = new Vector3(10f, Random.Range(-3.6f,-2.5f), -9f);
                    enemy.SetActive(true);
                }
                else
                {
                    enemy.transform.position = new Vector3(10.02f, -3.6f, -9f);
                    enemy.SetActive(true);
                }
            }
            yield return new WaitForSeconds(timeToSpawn);
        }
    }
    private AbstractEnemyFactory GetRandomFactory()
    {
         randomNumber = Random.Range(1, 4);
        if (randomNumber == 1)
        {
            randomNumber = 1;
            return new EnemyFactory1();
        }
        else if (randomNumber == 2)
        {
            randomNumber = 2;
            return new EnemyFactory2();
        }
        else
        {
            randomNumber = 3;
            return new EnemyFactory3();
        }
    }

    // Update is called once per frame
    void Update()
    {
        IncreaseSpeed();
        TimeUpdate -= Time.deltaTime;
        if (TimeUpdate < 0)
        {
            timeToSpawn = 3;
        }
    }
    public float IncreaseSpeed()
    {
        count += Time.deltaTime;
        if (count > 3)
        {
            speed += 0.3f;
            count = 0;
        }
        return speed;
    }
}
