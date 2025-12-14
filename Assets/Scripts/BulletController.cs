using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour {
    public float life = 120;
    public float speed = 3.0f;
    private Rigidbody rigid;

    void OnEnable () {
        this.rigid = this.GetComponent<Rigidbody> ();
        if (this.rigid == null) {
            Debug.LogError("Rigidbody component is missing on BulletController");
        }
    }

    private void Update () {
        this.life--;
        if (this.life < 0) {
            Destroy (this.gameObject);
        }
    }

    public void Shot (Vector3 direct) {
        if (this.rigid != null) {
            this.rigid.velocity = direct * this.speed;
        }
    }

    private void OnTriggerEnter (Collider other) {
        if (other.gameObject.tag == "Enemy") {
            ZombieController zombie = other.GetComponent<ZombieController>();
            if (zombie != null) {
                ScoreManager.Instance.addScore(zombie.point);

                GameObject scoreObject = GameObject.Find("Score");
                if (scoreObject != null) {
                    Text pointText = scoreObject.GetComponent<Text>();
                    if (pointText != null) {
                        pointText.text = "Point:" + ScoreManager.Instance.getCurrentScore();
                    } else {
                        Debug.LogError("Score text component not found");
                    }
                } else {
                    Debug.LogError("Score game object not found");
                }

                zombie.ZombieDestroy();
                Destroy(other.gameObject);
                Destroy(this.gameObject);
            } else {
                Debug.LogError("ZombieController component not found on Enemy");
            }
        }
    }
}


















// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class BulletController : MonoBehaviour {
//     public float life = 120;
//     public float speed = 3.0f;
//     private Rigidbody rigid;

//     void OnEnable () {
//         this.rigid = this.GetComponent<Rigidbody> ();
//         if (this.rigid == null) {
//             Debug.LogError("Rigidbody component is missing on BulletController");
//         }
//     }

//     private void Update () {
//         this.life--;
//         if (this.life < 0) {
//             Destroy (this.gameObject);
//         }
//     }

//     public void Shot (Vector3 direct) {
//         if (this.rigid != null) {
//             this.rigid.velocity = direct * this.speed;
//         }
//     }

//     private void OnTriggerEnter (Collider other) {
//         if (other.gameObject.tag == "Enemy"){
//             ZombieController zombie = other.GetComponent<ZombieController>();
//             if(zombie != null){
//                 ScoreManager.Instance.addScore(zombie.point);

//                 Text pointText = GameObject.Find("Score").GetComponent<Text>();
//                 if (pointText != null) {
//                     pointText.text = "Point:" + ScoreManager.Instance.getCurrentScore();
//                 } else {
//                     Debug.LogError("Score text component not found");
//                 }

//                 zombie.ZombieDestroy();
//                 Destroy(other.gameObject);
//                 Destroy(this.gameObject);
//             } else {
//                 Debug.LogError("ZombieController component not found on Enemy");
//             }
//         }
//     }
// }








// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class BulletController : MonoBehaviour {
//     public float life = 120;
//     public float speed = 3.0f;
//     private Rigidbody rigid;

//     void OnEnable () {
//         this.rigid = this.GetComponent<Rigidbody> ();
//     }

//     private void Update () {
//         this.life--;
//         if (this.life < 0)
//             Destroy (this.gameObject);
//     }

//     public void Shot (Vector3 direct) {
//         this.rigid.velocity = direct * this.speed;
//     }

//     private void OnTriggerEnter (Collider other) {
//         if (other.gameObject.tag == "Enemy"){
//             ZombieController zombie = other.GetComponent<ZombieController>();
//             if(zombie){
//                 ScoreManager.Instance.addScore(zombie.point);
//                 Text pointText = GameObject.Find("Score").GetComponent<Text>();
//                 pointText.text = "Point:" + ScoreManager.Instance.getCurrentScore();
//                 zombie.ZombieDestroy();
//             }
//             Destroy(other.gameObject);
//             Destroy(this.gameObject);
//         }
//     }
// }