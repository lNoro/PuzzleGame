using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string NextLevel;
    public Animator Transition;
    public void LoadLevel()
    {
        StartCoroutine(LoadLevelWithTrans(NextLevel));
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator LoadLevelWithTrans(string sceneName)
    {
        Transition.SetTrigger("StartTransition");
        
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(sceneName);
    }
}
