using UnityEngine;
using System.Collections.Generic;

public class QuestManager : MonoBehaviour
{
    private List<Quest> activeQuests = new List<Quest>();

    public void StartQuest(Quest quest)
    {
        activeQuests.Add(quest);
        Debug.Log("Quest Started: " + quest.questName);
    }

    public void CompleteQuest(Quest quest)
    {
        if (activeQuests.Contains(quest))
        {
            quest.CompleteQuest();
            activeQuests.Remove(quest);
        }
    }
}
