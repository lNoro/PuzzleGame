using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    public Text dialogueText;
    
    public string[] sentence;

    public GameObject NextScene;
    // Start is called before the first frame update
    void Start()
    {
        StartDialogue();
    }

    public void StartDialogue()
    {
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence(string[] sentences)
    {
        yield return new WaitForSeconds(1f);
        foreach (var sentence in sentences)
        {
            dialogueText.text = "";
            foreach(char letter in sentence.ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(.03f);
            }
            yield return new WaitForSeconds(3f);
        }
        dialogueText.text = "";
        NextScene.GetComponent<SceneChanger>().LoadLevel();
    }
}
