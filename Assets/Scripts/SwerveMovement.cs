using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveMovement : MonoBehaviour
{
    private SwerveInputSystem swerveInputSystem;
    public Transform stack;
    public Animator anim;

    //Shoot
    [SerializeField] private float shootPower = 450f;

    //Movement
    [SerializeField] private float swipeSpeed = 0.5f;
    [SerializeField] private float minSwipeAmount = -1f;
    [SerializeField] private float maxSwipeAmount= 1f;
    [SerializeField] private float minXAmount = -2.5f;
    [SerializeField] private float maxXAmount = 2.5f;
    [SerializeField] public float moveSpeed = 5f;

    void Start()
    {
        swerveInputSystem = GetComponent<SwerveInputSystem>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (GameManager.instance.gameStarted == true)
        {
            Movement();
            SwerveSwipe();
        }
    }
    public void Movement()
    {
        transform.Translate(0, 0, moveSpeed * Time.deltaTime);
        float xVector = transform.position.x;
        xVector = Mathf.Clamp(transform.position.x, minXAmount, maxXAmount);
        transform.position = new Vector3(xVector, transform.position.y, transform.position.z);
        anim.SetBool("isWalking", true);
        if(moveSpeed == 0)
        {
            anim.SetBool("isWalking", false);
        }
    }
    public void SwerveSwipe()
    {
        float swerveAmountX = swerveInputSystem.DirectionX * swipeSpeed * Time.deltaTime;
        swerveAmountX = Mathf.Clamp(swerveAmountX, minSwipeAmount,maxSwipeAmount);
        transform.Translate(swerveAmountX, 0, 0);
    }
    public void Shoot()
    {
        float swerveAmountY = swerveInputSystem.DirectionY * swipeSpeed * Time.deltaTime;
        //swerveAmountY = Mathf.Clamp(swerveAmountY, minSwipeAmount, maxSwipeAmount);
        stack.transform.GetChild(stack.transform.childCount - 1).gameObject.GetComponent<Rigidbody>().isKinematic = false;
        stack.transform.GetChild(stack.transform.childCount - 1).gameObject.GetComponent<Rigidbody>().useGravity = true;
        stack.transform.GetChild(stack.transform.childCount - 1).gameObject.GetComponent<BoxCollider>().isTrigger = false;
        stack.transform.GetChild(stack.transform.childCount - 1).gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1 * swerveAmountY, 0.5f * swerveAmountY) * shootPower);
    }
}
