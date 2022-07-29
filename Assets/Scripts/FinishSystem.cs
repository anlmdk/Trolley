using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishSystem : MonoBehaviour
{
    public SwerveMovement player;
    public EnemySystem enemy;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(WaitForFinish());
            GameManager.instance.GameWin();
        }
    }
    public IEnumerator WaitForFinish()
    {
        yield return new WaitForSeconds(0.5f);
        player.moveSpeed = 0;
        enemy.moveSpeed = 0;
    }
}
