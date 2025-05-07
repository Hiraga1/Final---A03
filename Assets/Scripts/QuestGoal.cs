using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestGoal
{
    public GoalTypes GoalType;

    public GameObject player;

    public GameObject goal; 

    public bool isReached;
    public enum GoalTypes
    {
        Moving,
        Surviving
    }

    public void DestinationReached()
    {
        OnTriggerEnter.Equals(goal, player);
    }
}
