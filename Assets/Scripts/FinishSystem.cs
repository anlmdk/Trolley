using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishSystem : MonoBehaviour
{

    public SwerveMovement player;

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            StartCoroutine(WaitForFinish());
        }
    }
    public IEnumerator WaitForFinish()
    {
        yield return new WaitForSeconds(1f);
        player.anim.SetBool("isWalking", false);
        player.moveSpeed = 0f;
    }
}
