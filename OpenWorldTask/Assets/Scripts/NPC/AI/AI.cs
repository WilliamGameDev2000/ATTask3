using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(DialogueLines))]
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
            //Debug.Log(Vector3.Distance(agent.transform.position, target.position));
            //Debug.Log(agent.stoppingDistance);
            if (Dialogue.instance.GetInRange() && !Dialogue.instance.GetInDialogue())
            {
                Dialogue.instance.SetInDialogue(true);
                Dialogue.instance.StartDialogue();
            }

            if (Vector3.Distance(agent.transform.position, target.position) < agent.stoppingDistance + 2f)
            {
                Dialogue.instance.SetInRange(true);
                Dialogue.instance.SetLines(this.GetComponent<DialogueLines>());
            }
            else
            {
                Dialogue.instance.SetInRange(false);
            }
        }

        if (!Dialogue.instance.GetInRange())
            Dialogue.instance.SetInDialogue(false);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(agent.transform.position, lookRadius);
    }
}
