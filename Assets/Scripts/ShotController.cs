using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    public int shotInterval = 10;
    private int restShotTime = 0;
    public GameObject bullet;
    public Transform shotPoint;

    void Start()
    {
        this.animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale <= 0){
            return;
        }
        AnimatorStateInfo animStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);

        if(animStateInfo.IsName("DAMAGE")){
            this.animator.SetLayerWeight(1,0.0f);
            return;
        }

        if(Input.GetKey("j")){
            this.animator.SetLayerWeight(1,1.0f);
            this.restShotTime--;
            if(this.restShotTime <= 0){
                this.restShotTime = this.shotInterval;
                GameObject tmpBullet = Instantiate(this.bullet);
                tmpBullet.transform.position = this.shotPoint.position;
                BulletController bCon = tmpBullet.GetComponent<BulletController>();
                if(bCon){
                    bCon.Shot(this.transform.forward);
                }
                StartBulletController bStartCon = tmpBullet.GetComponent<StartBulletController>();
                if(bStartCon){
                    bStartCon.Shot(this.transform.forward);
                }
            }
        }

        else{
            this.animator.SetLayerWeight(1,0.0f);
        }
    }
}
