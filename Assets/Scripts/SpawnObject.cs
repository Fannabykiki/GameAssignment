using System.Collections;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    private float TimeUpdate = 60;
    private float timeToSpawn = 2;
    public float speed = 10f;
    private float count;
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
            var check = Random.Range(1, 4);
            if (check == 1)
            {
                yield return StartCoroutine(SpawnEnemy1());

            }
            else if (check == 2)
            {
                yield return StartCoroutine(SpawnEnemy2());

            }
            else if (check == 3)
            {
                yield return StartCoroutine(SpawnEnemy3());
            }
        }
    }
    private IEnumerator SpawnEnemy1()
    {
        GameObject enemy1 = ObjectPool1.SharedInstance.GetPooledObject();
        if (enemy1 != null)
        {
            enemy1.transform.position = new Vector3(8.1f, -2f, -9f);
            enemy1.SetActive(true);
        }
        yield return new WaitForSeconds(timeToSpawn);
    }
    private IEnumerator SpawnEnemy2()
    {
        GameObject enemy2 = ObjectPool2.SharedInstance.GetPooledObject();
        if (enemy2 != null)
        {
            enemy2.transform.position = new Vector3(8.1f, -3.2f, -9f);
            enemy2.SetActive(true);
        }
        yield return new WaitForSeconds(timeToSpawn);
    }
    private IEnumerator SpawnEnemy3()
    {
        GameObject enemy = ObjectPool3.SharedInstance.GetPooledObject();
        if (enemy != null)
        {
            enemy.transform.position = new Vector3(8.1f, -3.2f, -9f);
            enemy.SetActive(true);
        }
        yield return new WaitForSeconds(timeToSpawn);
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
