using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    public QuestSO Base {get; private set; }
    public QuestStatus status { get; private set; }

    public Quest(QuestSO _base)
    {
        Base = _base;
    }

    public void StartQuest()
    {
        status = QuestStatus.STARTED;

        Dialogue.instance.SetLines(Base.StartDialogue);
    }

    public void CompleteQuest()
    {
        status = QuestStatus.COMPLETED;

        Dialogue.instance.SetLines(Base.CompleteDialogue);
    }

    public bool CanComplete()
    {
        return Base.HasItem;
    }
}

public enum QuestStatus
{
    NONE,
    STARTED,
    COMPLETED
}
