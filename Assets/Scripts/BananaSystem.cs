using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BananaSystem : MonoBehaviour
{
    public Transform target;
    public GameObject targetObject;

    void Start()
    {
        DOTween.Init();
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            GameManager.instance.HitCollectible();
            transform.localScale = Vector3.one;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            transform.DOJump(target.transform.localPosition, 1f, 1, 0.5f);
            this.gameObject.transform.parent = targetObject.transform;
        }
    }
}
