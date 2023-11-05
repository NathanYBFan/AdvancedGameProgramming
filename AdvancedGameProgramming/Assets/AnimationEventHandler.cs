using UnityEngine;

public class AnimationEventHandler : MonoBehaviour
{
    [SerializeField]
    GameObject enemyOrigin;

    [SerializeField]
    EnemyController enemyController;
    public void DestroyEnemy()
    {
        Destroy(enemyOrigin);
    }

    public void YellFinished()
    {
        enemyController.screamFinished = true;
    }
}
