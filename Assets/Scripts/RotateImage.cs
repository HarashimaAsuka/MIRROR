using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateImage : MonoBehaviour
{
    public Image targetImage;
    public float rotationDuration = 0.5f;
    public float waitTime = 3.0f;

    private void Start(){
        if(targetImage == null){
            targetImage = GetComponent<Image>();
        }

        StartCoroutine(RotateCoroutine());
    }

    private IEnumerator RotateCoroutine(){
        while(true){
            yield return StartCoroutine(RotateImageCoroutine(180f));

            yield return new WaitForSeconds(waitTime);

            yield return StartCoroutine(RotateImageCoroutine(180f));

            yield return new WaitForSeconds(waitTime);
        }
    }

    private IEnumerator RotateImageCoroutine(float angle){
        float elapsed = 0.0f;
        Quaternion initialRotation = targetImage.rectTransform.rotation;
        Quaternion targetRotation = initialRotation * Quaternion.Euler(0,0,angle);

        while(elapsed < rotationDuration){
            targetImage.rectTransform.rotation = Quaternion.Slerp(initialRotation, targetRotation, elapsed / rotationDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        targetImage.rectTransform.rotation = targetRotation;
    }
}
