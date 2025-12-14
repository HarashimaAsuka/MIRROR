using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public int minInterval = 60;
    public int maxInterval = 180;
    private int restSpawnFrame = 0;
    public int maxSceneAppearance = 10;
    public GameObject spawnObject;
    public Transform targetTransform;

    int collectZombieCount(){
        GameObject[] zombies = GameObject.FindGameObjectsWithTag("Enemy");
        return zombies.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale <= 0){
            return;
        }
        this.restSpawnFrame--;
        if(this.restSpawnFrame < 0 && this.collectZombieCount() < this.maxSceneAppearance){
            this.restSpawnFrame = (int)Random.Range(this.minInterval,this.maxInterval);
            GameObject tmpObj = Instantiate(spawnObject,this.transform.position,Quaternion.identity);
            ZombieController zombie = tmpObj.GetComponent<ZombieController>();
            zombie.target = this.targetTransform;
        }
        
    }
}
