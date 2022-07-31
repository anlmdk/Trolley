using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    [SerializeField] private float distanceBetweenObjects;
    [SerializeField] private Transform prevObject;
    [SerializeField] private Transform parentObject;

    void Start()
    {
        distanceBetweenObjects = prevObject.localScale.z *3;
    }
    public void Stack(GameObject stackObject, bool needTag =false, string tag = null, bool downOrUp = true)
    {
        if (needTag)
        {
            stackObject.tag = tag;
        }
        stackObject.transform.parent = parentObject;
        Vector3 desPos = prevObject.localPosition;
        desPos.z += downOrUp ? distanceBetweenObjects : -distanceBetweenObjects;

        stackObject.transform.localPosition = desPos;
        prevObject = stackObject.transform;
        prevObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            GameManager.instance.HitCollectible();
            Stack(other.gameObject, true, "Untagged");
        }
    }
}
