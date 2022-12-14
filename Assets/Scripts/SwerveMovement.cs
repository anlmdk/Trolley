using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveMovement : MonoBehaviour
{
    private SwerveInputSystem swerveInputSystem;
    public GameManager gameManager;
    public Animator anim;

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
        if (gameManager.gameStarted == true)
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
        float swerveAmount = swerveInputSystem.Direction * swipeSpeed * Time.deltaTime;
        swerveAmount = Mathf.Clamp(swerveAmount, minSwipeAmount,maxSwipeAmount);
        transform.Translate(swerveAmount, 0, 0);
    }
}
