using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ScreenEffectManager : MonoBehaviour
{
    private Image effectImage;

    void Start(){
        effectImage = this.GetComponent<Image>();
    }

    public IEnumerator ShowDamageEffect(){
        Color color = effectImage.color;

        for(int i = 0; i < 10; i++){
            color.a = i * 0.1f;
            effectImage.color = color;

            yield return new WaitForSecondsRealtime(0.01f);
        }

        for(int i = 10; i >= 0; i--){
            color.a = i * 0.1f;
            effectImage.color = color;
            yield return new WaitForSecondsRealtime(0.01f);
        }
    }
}
