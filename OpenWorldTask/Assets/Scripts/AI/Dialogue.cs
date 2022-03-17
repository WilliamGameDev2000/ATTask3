using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textComponent;
    [SerializeField] string[] lines;
    [SerializeField] float textSpeed;

    private bool inRange = false;
    private bool isTalking = false;

    public static Dialogue instance;

    private int index;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        textComponent.text = string.Empty;
    }

    public void StartDialogue()
    {
        index = 0;

        StartCoroutine("TypeLine");
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && inRange)
        {
            if(textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine("TypeLine");
        }
        else
        {
            if(!inRange)
                SetInDialogue(false);
            
            gameObject.SetActive(false);
        }
    }

    public void SetInRange(bool range)
    {
        inRange = range;
    }

    public bool GetInRange()
    {
        return inRange;
    }

    public bool GetInDialogue()
    {
        return isTalking;
    }

    public void SetInDialogue(bool talking)
    {
        gameObject.SetActive(true);
        isTalking = talking;
    }
}
