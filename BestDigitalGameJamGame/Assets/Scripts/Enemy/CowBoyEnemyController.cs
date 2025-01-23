using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;


public class CowBoyEnemyController : MonoBehaviour
{
    public enum ShootingTarget//TODO Going to add functionality for retaliation
    {
        Player,
        Enemy,
        Null
    }

    [SerializeField] private int Health = 100;
    public NavMeshAgent agent;
    private ShootingTarget currentTarget = ShootingTarget.Null;
    private GameObject targetGameObject = null;
    public GameObject BulletPrefab;
    public Transform ShootPos;

    private void Start()
    {
        SetRandomDestination();
    }

    void Update()
    {
        if (agent.remainingDistance <= 1f)
        {
            //reached Destination
            SetRandomDestination();
        }

        if (currentTarget != ShootingTarget.Null)
        {
            
        }

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void SetRandomDestination()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-100f, 100f), 0f, Random.Range(-100f, 100f));
        while (!NavMesh.SamplePosition(randomPosition,out NavMeshHit TempHit, 1f, NavMesh.AllAreas))
        {
            randomPosition = new Vector3(Random.Range(-100f, 100f), 0f, Random.Range(-100f, 100f));
        }
        agent.SetDestination(randomPosition);
    }

    public void FoundPlayer(GameObject Player)
    {
        //Player entered vision cone and was in direct line of sight
        //TODO Probably should add range to Raycast
        if (currentTarget == ShootingTarget.Null)
        {
            currentTarget = ShootingTarget.Player;
            targetGameObject = Player;
        }
    }

    public void LoseHat(Vector3 HatPosition)
    {
        agent.SetDestination(HatPosition);
        //Set searching for hat and add pickup
        currentTarget = ShootingTarget.Null;
        targetGameObject = null;
        if (agent.isPathStale)
        {
            BecomeSad();
        }
    }

    void FoundHat()
    {
        
    }

    private void BecomeSad()//Cant get its hat back
    {
        //TODO Lie down
        //TODO Disable Targeting
    }

    private void Shoot()
    {
        Instantiate(BulletPrefab, ShootPos.position, transform.rotation);//ToDo Rotation is 90 Degrees off. Im going to bed
    }
}
