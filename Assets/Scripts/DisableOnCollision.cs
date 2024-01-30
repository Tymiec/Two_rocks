using UnityEngine;

public class DisableOnCollision : MonoBehaviour
{
    [SerializeField] private GameObject targetGameObject; 

    void OnTriggerEnter(Collider other)
    {
        if (targetGameObject != null)
        {
            // Get all MonoBehaviour scripts attached to the target GameObject
            MonoBehaviour[] scripts = targetGameObject.GetComponents<MonoBehaviour>();

            if (scripts.Length > 0)
            {
                foreach (MonoBehaviour script in scripts)
                {
                    // Debug.Log(script);
                    // Disable each script
                    script.enabled = false;
                }
                // Debug.Log("Disabled all scripts on the target GameObject.");
                Destroy(gameObject);
            }
            else
            {
                Debug.LogError("No scripts found on the assigned GameObject.");
            }
        }
        else
        {
            Debug.LogError("Target GameObject is not assigned.");
        }
    }
}