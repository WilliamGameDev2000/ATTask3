using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCSpawner : MonoBehaviour
{
    //[SerializeField] GameObject ObjectPrefab;
    [SerializeField] AI NPCSPrefab;
    public bool hasQuest;
    public QuestSO _quest;
    public List<string> lines;
    [SerializeField] int movementSpeed = 15;

    public void SpawnNPC()
    {
        GameObject npc = Instantiate(NPCSPrefab.gameObject, transform.position, Quaternion.identity);
        npc.transform.parent = transform;
        npc.GetComponent<NavMeshAgent>().speed = movementSpeed;
        if(hasQuest)
        {
            npc.AddComponent<GiveQuest>().SetQuest(_quest);
        }
    }
    //get QuestSO and check if this npc has a quest;

    private void OnEnable()
    {
        SpawnNPC();
    }
}
