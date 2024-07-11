using UnityEngine;
using DialogueEditor;

public class UnhideObjectOnDialogueEnd : MonoBehaviour
{
    // Reference to the object to unhide
    public GameObject objectToUnhide;
    public GameObject objectToHide;

    void Start()
    {
        // Ensure the object is initially hidden
        if (objectToUnhide != null)
        {
            objectToUnhide.SetActive(false);
        }
        if (objectToUnhide != null)
        {
            objectToHide.SetActive(true);
        }

        // Subscribe to the dialogue end event
        ConversationManager.OnConversationEnded += HandleDialogueEnd;
    }

    // Handle the dialogue end event
    void HandleDialogueEnd()
    {
        // Unhide the object
        if (objectToUnhide != null)
        {
            objectToUnhide.SetActive(true);
        }

        if (objectToHide != null)
        {
            objectToHide.SetActive(false);
        }
        // Unsubscribe from the event to prevent memory leaks
        ConversationManager.OnConversationEnded -= HandleDialogueEnd;
    }

    // Ensure to unsubscribe from the event when the object is destroyed
    void OnDestroy()
    {
        if (ConversationManager.OnConversationEnded != null)
        {
            ConversationManager.OnConversationEnded -= HandleDialogueEnd;
        }
    }
}
