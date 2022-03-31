using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textComponent;
    [SerializeField] float textSpeed;
    AI dialogueSource;

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
        Cursor.lockState = CursorLockMode.Confined;
        index = 0;
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        StartCoroutine("TypeLine");
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && inRange)
        {
            if (textComponent.text == dialogueSource.transform.parent.GetComponent<NPCSpawner>().lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = dialogueSource.transform.parent.GetComponent<NPCSpawner>().lines[index];
            }
        }

        if(!inRange)
        {
            EndDialogue();
        }
    }

    IEnumerator TypeLine()
    {
        foreach (char c in dialogueSource.transform.parent.GetComponent<NPCSpawner>().lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < dialogueSource.transform.parent.GetComponent<NPCSpawner>().lines.Count - 1)
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

    public void SetInDialogue(bool talking, AI sourceDialogue)
    {
        dialogueSource = sourceDialogue;
        isTalking = talking;   
    }

    public void SetLines(List<string> newLines)
    {
        dialogueSource.transform.parent.GetComponent<NPCSpawner>().lines = newLines;
    }

    void EndDialogue()
    {
        Cursor.lockState = CursorLockMode.Locked;
        gameObject.GetComponent<RectTransform>().localScale = new Vector3( 0,0,0);
        textComponent.text = string.Empty;
    }
}
