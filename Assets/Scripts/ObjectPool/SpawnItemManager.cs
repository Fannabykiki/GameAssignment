using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnItemManager : MonoBehaviour
{
    public CollectableItem[] items;

    private void Spawn()
    {
        if (items == null || items.Length <= 0) return;
        //Tao ra ti le spawn ngau nhien
        float spawnRate = Random.Range(0f, 1f);
        Debug.Log(spawnRate);
        //tim ra tat ca cac item co ti le spawn <= ti le spawn ngua nhien da tao ra
        var finders = items.Where(x=> x.rate >= spawnRate).ToArray();

        if (finders == null & finders.Length <= 0) return;
        //Lay ra ngau nhien mot item trong mang cac item thoai man ti le spawn
        int randItemIdx = Random.Range(0, finders.Length);

        var randItem = items[randItemIdx];
        //tao ra item o tren scene tai vi tri pos
        Instantiate(randItem.prefab,new Vector3(10.02f, -3.6f, -9f), Quaternion.identity);

    }
}

[System.Serializable]
public class CollectableItem
{
    [Range(0f, 1f)]
    public float rate;
    public GameObject prefab;
}