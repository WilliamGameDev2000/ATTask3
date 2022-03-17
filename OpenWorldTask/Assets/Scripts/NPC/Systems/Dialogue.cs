using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textComponent;
    [SerializeField] float textSpeed;

    ///choose a line in coming from the npc you're near
    DialogueLines Lines;

    private bool inRange = false;
    private bool isTalking = false;

    public static Dialogue instance;

    private int index;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    void Start()
    {
        textComponent = GameObject.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
        textComponent.text = string.Empty;
    }

    public void StartDialogue()
    {
        index = 0;
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        StartCoroutine("TypeLine");
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && inRange)
        {
            if(textComponent.text == Lines.text[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = Lines.text[index];
            }
        }

        if(!inRange)
        {
            EndDialogue();
        }
    }

    IEnumerator TypeLine()
    {
        foreach(char c in Lines.text[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if(index < Lines.text.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine("TypeLine");
        }
        else
        {

            EndDialogue();
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
        isTalking = talking;
    }

    public void SetLines(DialogueLines newLines)
    {
        Lines = newLines;
    }

    void EndDialogue()
    {
        gameObject.GetComponent<RectTransform>().localScale = new Vector3( 0,0,0);
        textComponent.text = string.Empty;
    }
}
