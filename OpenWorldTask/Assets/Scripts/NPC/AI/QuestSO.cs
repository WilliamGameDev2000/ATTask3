using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu( menuName = "Quests/Create New")]
public class QuestSO : ScriptableObject
{
    [SerializeField] string name;
    [SerializeField] string description;

    [SerializeField] List<string> startDialogue;
    [SerializeField] List<string> pendingDialogue;
    [SerializeField] List<string> completeDialogue;
    [SerializeField] GameObject requiredItem;

    [SerializeField] bool hasItem;
    public void SetHasItem(bool itemStatus)
    {
        hasItem = itemStatus;
    }
    public string Name => name;

    public string Description => description;

    public List<string> StartDialogue => startDialogue;

    public List<string> PendingDialogue => pendingDialogue?.Count > 0 ? pendingDialogue : startDialogue;

    public List<string> CompleteDialogue => completeDialogue;

    public bool HasItem => hasItem;

    public GameObject RequiredItem => requiredItem;
}

