using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PageController : MonoBehaviour
{
   public string sceneName;

   public void GoToNextScene(){
        SceneManager.LoadScene(sceneName);
    }

    public void GoToNextSceneWithDelay(float delay){
        StartCoroutine(LoadSceneAfterDelay(delay));
    }

    private IEnumerator LoadSceneAfterDelay(float delay){
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
