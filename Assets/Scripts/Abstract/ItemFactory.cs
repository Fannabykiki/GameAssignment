using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory : AbstractEnemyFactory
{
    public override GameObject CreateEnemy()
    {
        return SpawnItemManager.SharedInstance.Spawn();
    }
}
