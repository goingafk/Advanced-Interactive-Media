using UnityEngine;
using DialogueEditor;

public class GiveItemEvent : MonoBehaviour
{
    [SerializeField] private PlayerEggStatus playerEggStatus; // Reference to PlayerEggStatus script

    public void GiveEgg()
    {
        if (playerEggStatus != null)
        {
            // Change hasEgg to true
            playerEggStatus.hasEgg = true;
        }
        else
        {
            Debug.LogWarning("PlayerEggStatus reference not set in GiveItemEvent.");
        }
    }
}
