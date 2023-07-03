using UnityEngine;

public class EnemyFactory3 : AbstractEnemyFactory
{
    public override GameObject CreateEnemy()
    {
        return ObjectPool3.SharedInstance.GetPooledObject();
    }
}
