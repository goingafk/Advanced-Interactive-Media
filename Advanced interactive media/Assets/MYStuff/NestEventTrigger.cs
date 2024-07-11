
using UnityEngine;

public class EggTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger has the tag "Player"
        if (other.CompareTag("Player"))
        {
            // Try to get the PlayerEggStatus component from the player object
            PlayerEggStatus playerEggStatus = other.GetComponent<PlayerEggStatus>();

            if (playerEggStatus != null)
            {
                // Set the hasEgg bool to true
                playerEggStatus.hasEgg = true;

                // Update the egg status text
                playerEggStatus.UpdateEggStatusText();

                Debug.Log("Player has an egg now.");
            }
            else
            {
                Debug.LogWarning("Player object does not have a PlayerEggStatus component.");
            }
        }
    }
}
