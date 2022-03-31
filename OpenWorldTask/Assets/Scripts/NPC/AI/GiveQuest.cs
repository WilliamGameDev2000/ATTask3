using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveQuest : MonoBehaviour
{
    QuestSO questToStart;
    Quest thisQuest;

    public void SetQuest(QuestSO questSO)
    {
        questToStart = questSO;
    }

    public void giveQuest()
    {
        if (questToStart != null)
        {
            thisQuest = new Quest(questToStart);
            thisQuest.StartQuest();
            questToStart = null;
        }
        else if(thisQuest != null)
        {
            if (thisQuest.CanComplete())
            {
                thisQuest.CompleteQuest();
                thisQuest = null;
            }
            else
            {
                Dialogue.instance.SetLines(thisQuest.Base.PendingDialogue);
            }
        }
    }
}
