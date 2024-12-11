using System.Collections.Generic;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "EnemyConfigsContainer", menuName = "SO/EnemyConfigsContainer", order = 0)]
    public class EnemyConfigsContainer : ScriptableObject
    {
        [SerializeField] private List<EnemyConfig> _enemyConfigs;
        public EnemyConfig GetRandomEnemyConfig()
        {
            EnemyConfig enemyConfig;
            if (_enemyConfigs.Count > 1)
            {
                System.Random random = new System.Random();
                int index = random.Next(0, _enemyConfigs.Count);
                enemyConfig = _enemyConfigs[index];
            }
            else
            {
                enemyConfig = _enemyConfigs[0];
            }

            return enemyConfig;
        }
    }
}
