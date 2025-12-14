using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    private ParticleSystem[] particleSystems;

    void Start(){
        particleSystems = GetComponentsInChildren<ParticleSystem>();
    }

    void Update(){
        bool isAlive = false;
        foreach (ParticleSystem ps in particleSystems){
            if (ps.IsAlive()){
                isAlive = true;
                break;
            }      
        }

        if(!isAlive){
            Destroy(gameObject);
        }
    }
}
