using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBulletController : MonoBehaviour
{
   
    public string SceneName;
    public float life = 120;
    public float speed = 3.0f;
    private Rigidbody rigid;

    void OnEnable () {
        this.rigid = this.GetComponent<Rigidbody> ();
    }

    private void Update () {
        this.life--;
        if (this.life < 0)
            Destroy (this.gameObject);
    }

    public void Shot (Vector3 direct) {
        this.rigid.velocity = direct * this.speed;
    }

    private void OnTriggerEnter (Collider other) {
        if (other.gameObject.tag == "Enemy"){
            ZombieController zombie = other.GetComponent<ZombieController>();
            if(zombie){
                ScoreManager.Instance.addScore(zombie.point);
                zombie.ZombieDestroy();
            }
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            SceneManager.LoadScene(SceneName);
        }
    }
}

