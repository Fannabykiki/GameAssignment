using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory1 : AbstractEnemyFactory
{
    public override GameObject CreateEnemy()
    {
        return ObjectPool1.SharedInstance.GetPooledObject();
    }

}
