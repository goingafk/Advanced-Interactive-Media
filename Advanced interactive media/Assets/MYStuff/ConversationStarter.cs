using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class ConversationStarter : MonoBehaviour
{
    private PlayerEggStatus playerEggStatus;
    [SerializeField] private NPCConversation myConverstation;
    [SerializeField] private KeyCode interactionKey = KeyCode.F; // Key to trigger interaction

    private bool canInteract = false; // Flag to check if interaction is allowed

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Enable interaction when player enters the trigger
            canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Disable interaction when player exits the trigger
            canInteract = false;

        }
    }

    [System.Obsolete]
    private void Update()
    {
        // Check if player can interact and if the interaction key is pressed
        if (canInteract && Input.GetKeyDown(interactionKey))
        {
            // Get the PlayerEggStatus component from the player object
            PlayerEggStatus playerEggStatus = FindObjectOfType<PlayerEggStatus>(); // You can use FindObjectOfType if there's only one PlayerEggStatus in the scene

            if (playerEggStatus != null)
            {
                // Start the conversation and set the ConversationManager variables based on player's egg status
                ConversationManager.Instance.StartConversation(myConverstation);
                ConversationManager.Instance.SetBool("eggScrambled", playerEggStatus.ScrambledEgg);
                ConversationManager.Instance.SetBool("eggFried", playerEggStatus.FriedEgg);

                // Subscribe to the static OnConversationEnded event
                ConversationManager.OnConversationEnded += OnConversationEndedHandler;
            }
        }
    }

    [System.Obsolete]
    private void OnConversationEndedHandler()
    {
        // Get the PlayerEggStatus component from the player object
        PlayerEggStatus playerEggStatus = FindObjectOfType<PlayerEggStatus>();

        if (playerEggStatus != null)
        {
            // Reset all the player's egg status variables to false
            playerEggStatus.FriedEgg = false;
            playerEggStatus.ScrambledEgg = false;
            playerEggStatus.hasEgg = false;

            // Update the egg status text
            playerEggStatus.UpdateEggStatusText();
        }

        // Unsubscribe from the static OnConversationEnded event to prevent memory leaks
        ConversationManager.OnConversationEnded -= OnConversationEndedHandler;
    }
}
