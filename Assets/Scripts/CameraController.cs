using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform LookPoint;

    public float yRot = 0;
    public float cameraDistance = 5.0f;
    public float cameraHeight = 5.0f;

    private void Update(){
        if(this.LookPoint){
            this.transform.position = this.LookPoint.position;

            this.transform.localEulerAngles = new Vector3 (0,this.yRot,0);

            this.transform.Translate(0,this.cameraHeight,this.cameraDistance);

            this.transform.LookAt(this.LookPoint);
        }
    }
}
