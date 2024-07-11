using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
public class DialogueManager : MonoBehaviour
{
    public NPCConversation conversation;
    public Inventory playerInventory;

    void Start()
    {
        ConversationManager.Instance.StartConversation(conversation);
    }

    public bool CheckForItem(string itemName)
    {
        return playerInventory.HasItem(itemName);
    }
}
