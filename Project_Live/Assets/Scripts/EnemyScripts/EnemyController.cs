using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float detectionRange = 10f;
    public float attackRange = 2f;
    public float moveSpeed = 3f;
    public float rotateSpeed;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("LookPoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= attackRange)
        {
            Attack();
        }
        else if (distance <= detectionRange)
        {
            MoveTowardsPlayer();  
           
        }
      
    }
    void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        
        transform.position += direction * moveSpeed * Time.deltaTime;
        LookPlayer();
    }
    void Attack()
    {
        //Debug.Log("UŒ‚III");
    }
    void LookPlayer()//YŽ²‚¾‚¯•Ï‚¦‚é
    {
      Vector3 target=player.transform.position;
        target.y = transform.position.y;
       Vector3 direction=(target-transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
    }
}
