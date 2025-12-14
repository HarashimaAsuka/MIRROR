using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UnityChanController : MonoBehaviour
{
    public float walkSpeed = 3.0f;
    public float runSpeed = 5.0f;
    public int invisibleTime = 60;
    public string gameOverTag = "Floor";
    public GameObject gameOverCanvas;
    public string gameCrlearTag = "Flag";
    public GameObject gameClrearCanvas;
    public Text clrearScoreText;

    private CharacterController characterController;
    private Animator animator;
    private Camera cam;
    private int restInvisibleTime = 0;

    [SerializeField] Image DamageImg;

    private void Start(){
        this.characterController = this.GetComponent<CharacterController>();
        this.animator = this.GetComponent<Animator>();
        this.cam = Camera.main;
    }

    private void Update(){
        if(Time.timeScale <= 0){
            return;
        }
        AnimatorStateInfo animStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
        if(animStateInfo.IsName("DAMAGE"))
            return;

        if(this.restInvisibleTime > 0)
            this.restInvisibleTime--;    

        if(!Input.GetButton("Vertical") && !Input.GetButton("Horizontal")){
            this.animator.SetFloat("Speed",0);
            this.characterController.SimpleMove(Vector3.zero);
            return;
        }

        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        Vector3 forward = this.cam.transform.forward;
        forward.y = 0;
        forward = forward.normalized;

        Vector3 right = this.cam.transform.right;
        right.y = 0;
        right = right.normalized;

        Vector3 direct = forward * v + right * h;

        direct = direct.normalized;

        Vector3 walkDirect = direct * this.walkSpeed;

        if(Input.GetButton("RunTrigger")){
            walkDirect = direct * this.runSpeed;
        }

        this.characterController.SimpleMove(walkDirect);

        this.transform.rotation = Quaternion.LookRotation(direct);

        float speed = walkDirect.magnitude;
        this.animator.SetFloat("Speed",speed);
    }

    private void OnTriggerEnter(Collider other){
        if(other.tag == "Enemy" && this.restInvisibleTime <= 0){
            Debug.Log("Collision with Enemy detected");
            
            this.animator.SetBool("IsDamage",true);
            this.restInvisibleTime = this.invisibleTime;

            ScreenEffectManager sem = GameObject.FindObjectOfType<ScreenEffectManager>();
            if(sem){
                StartCoroutine(sem.ShowDamageEffect());
            }
        }
        
        if(other.tag == gameOverTag){
            Debug.Log("Game over triggered by touching the floor");
            gameOverCanvas.SetActive(true);
            Time.timeScale = 0f;
        }

        if(other.tag == gameCrlearTag){
            gameClrearCanvas.SetActive(true);    
            clrearScoreText.gameObject.SetActive(true);//0721
            ScoreManager.Instance.compareHighScore();
            clrearScoreText.text = "High Score:" + ScoreManager.Instance.getHighScore();
            Time.timeScale = 0f;
        }
    }

    private IEnumerator ResetDamageFlagAfterdelay(float delay){
        yield return new WaitForSeconds(delay);
        this.animator.SetBool("IsDamage" , false);
    }

    public void ComebackEvent(){
        this.animator.SetBool("IsDamage",false);
    }
}
