using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    float lookRadius = 50f;

    Transform target;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        target = PlayerInstance.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(agent.transform.position, target.position) < lookRadius)
        {
            agent.SetDestination(target.position);

            if (Vector3.Distance(agent.transform.position, target.position) < agent.stoppingDistance + 2f)
            {
                Dialogue.instance.SetInRange(true);
                if (Dialogue.instance.GetInDialogue())
                {
                    if (transform.parent.GetComponent<NPCSpawner>().hasQuest)
                    {
                        gameObject.GetComponent<GiveQuest>().giveQuest();
                    }
                    else
                    {
                        Dialogue.instance.SetLines(gameObject.transform.parent.GetComponent<NPCSpawner>().lines);
                    }
                }

            }
            else
            {
                Dialogue.instance.SetInRange(false);
            }

            if (Dialogue.instance.GetInRange() && !Dialogue.instance.GetInDialogue())
            {
                Dialogue.instance.SetInDialogue(true, this);
                Dialogue.instance.StartDialogue();
            }
        }

        if (!Dialogue.instance.GetInRange())
        {
            if (transform.parent.GetComponent<NPCSpawner>()._quest != null)
            {
                transform.parent.GetComponent<NPCSpawner>()._quest.SetHasItem(PlayerInstance.instance.player.GetComponent<PseudoInventory>().CheckInventory(transform.parent.GetComponent<NPCSpawner>()._quest.RequiredItem.gameObject));
            }
            
            Dialogue.instance.SetInDialogue(false, null);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(agent.transform.position, lookRadius);
    }
}
