using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;


public class EnemyLogic : MonoBehaviour
{
    public GameObject player;
    NavMeshAgent zombie;
    public float discoverTimer;
    float attackCooldown;

    float health = 4;

    bool hasSpotted;


    void Start()
    {
        zombie = GetComponent<NavMeshAgent>();
        
    }

    void Update()
    {
        Die();
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            StartCoroutine(TakeDamage());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(DiscoverPlayer());
            if (hasSpotted)
            {
                zombie.destination = player.gameObject.transform.position;

            }
        }
    }

    void Die()
    {
        if (health <= 0f)
        {
            Destroy(this.gameObject);
        }
    }

    private IEnumerator DiscoverPlayer()
    {
        hasSpotted = false;
        Debug.Log("Started");
        yield return new WaitForSeconds(discoverTimer);
        hasSpotted = true;
        Debug.Log("Ended");
    }

    private IEnumerator TakeDamage()
    {
        health -= 1;
        yield return new WaitForSeconds(0.1f);
    }
}
