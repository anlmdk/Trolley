using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySystem : MonoBehaviour
{
    public GameManager gameManager;
    public SwerveMovement player;
    public Transform playerPosition;
    public Animator anim;
    NavMeshAgent agent;

    [SerializeField] public float moveSpeed = 5f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if(gameManager.gameStarted == true)
        {
            Movement();
        }
    }
    public void Movement()
    {
        transform.Translate(0,0, moveSpeed * Time.deltaTime);
        anim.SetBool("isRunning", true);
        if (playerPosition.position.z > transform.position.z)
        {
            agent.SetDestination(playerPosition.position);
            transform.LookAt(playerPosition.position);
            if (player.moveSpeed == 0)
            {
                anim.SetBool("isRunning", false);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.HitEnemy();
        }
        else if (collision.gameObject.CompareTag("Collectible"))
        {
            Destroy(gameObject);
        }
    }
}
