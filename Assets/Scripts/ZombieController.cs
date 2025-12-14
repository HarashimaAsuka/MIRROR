using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;
    public GameObject explosion;
    public int point;

    void Start(){
        agent = this.GetComponent<NavMeshAgent>();
    }

    void Update(){
        agent.SetDestination(this.target.position);
    }

    public void ZombieDestroy(){
        Instantiate(explosion,this.transform.position,Quaternion.identity);
    }

    // private void OnDestroy(){
    //     Instantiate(explosion,this.transform.position,Quaternion.identity);
    // }
}