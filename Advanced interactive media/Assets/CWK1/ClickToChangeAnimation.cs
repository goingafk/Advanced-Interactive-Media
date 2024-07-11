using UnityEngine;

public class ClickToChangeAnimation : MonoBehaviour
{
    // Raycast variables
    private Camera mainCamera;
    private RaycastHit hitInfo;

    void Start()
    {
        // Get main camera reference
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Check for mouse button down (left click)
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray from the mouse cursor position
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            // Perform raycast to detect collisions with objects
            if (Physics.Raycast(ray, out hitInfo))
            {
                // Check if the clicked object has an Animator component
                Animator animator = hitInfo.collider.GetComponent<Animator>();
                if (animator != null)
                {
                    // Change animation state (example: trigger "ChangeState")
                    animator.SetTrigger("Mia Stand Talk 1c");
                }
            }
        }
    }
}
