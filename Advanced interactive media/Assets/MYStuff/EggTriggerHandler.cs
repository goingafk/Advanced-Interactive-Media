using UnityEngine;

public class EggTriggerHandler : MonoBehaviour
{
    private bool playerInTrigger = false;
    private PlayerEggStatus playerEggStatus;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;
            playerEggStatus = other.GetComponent<PlayerEggStatus>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
            playerEggStatus = null;
        }
    }

    private void Update()
    {
        if (playerInTrigger && playerEggStatus != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!playerEggStatus.FriedEgg)
                {
                    playerEggStatus.StartFryingEgg();
                }
                else
                {
                    playerEggStatus.FriedEgg = true;
                    playerEggStatus.hasEgg = false;
                    playerEggStatus.fryingPan.SetActive(false);
                    playerEggStatus.UpdateEggStatusText();
                }
            }
        }
    }
}
