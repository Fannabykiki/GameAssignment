using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory2 : AbstractEnemyFactory
{
    public override GameObject CreateEnemy()
    {
        return ObjectPool2.SharedInstance.GetPooledObject();
    }
}
