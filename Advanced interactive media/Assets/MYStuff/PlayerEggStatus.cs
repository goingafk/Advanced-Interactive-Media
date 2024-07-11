using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerEggStatus : MonoBehaviour
{
    public bool FriedEgg;
    public bool ScrambledEgg;
    public bool hasEgg;
    public Text eggStatusText;
    public GameObject fryingPan;

    private void Start()
    {
        UpdateEggStatusText();
        fryingPan.SetActive(false); // Ensure the frying pan is inactive initially
    }

    // Method to set the FriedEgg status after 5 seconds
    public void StartFryingEgg()
    {
        if (hasEgg)
        {
            StartCoroutine(FryEggCoroutine());
        }
        else
        {
            UpdateEggStatusText("No egg to fry!");
        }
    }

    private IEnumerator FryEggCoroutine()
    {
        UpdateEggStatusText("Frying...");
        fryingPan.SetActive(true); // Show the frying pan
        yield return new WaitForSeconds(5); // Wait for 5 seconds
        FriedEgg = true;
        UpdateEggStatusText("Fried egg is ready! Press E to collect.");
    }

    public void UpdateEggStatusText(string status = "")
    {
        if (!string.IsNullOrEmpty(status))
        {
            eggStatusText.text = status;
        }
        else if (FriedEgg)
        {
            eggStatusText.text = "Fried Egg";
        }
        else if (ScrambledEgg)
        {
            eggStatusText.text = "Scrambled";
        }
        else if (hasEgg)
        {
            eggStatusText.text = "Egg";
        }
        else
        {
            eggStatusText.text = "No Egg";
        }
    }
}
