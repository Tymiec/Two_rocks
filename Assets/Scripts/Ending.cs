using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class Ending : MonoBehaviour
{
    [SerializeField] private Volume globalVolume;
    [SerializeField] private GameObject endText;
    private Vignette vignette;
    private Coroutine coroutine;

    private void Start()
    {
        if (globalVolume.profile.TryGet<Vignette>(out vignette))
        {
            Debug.Log("Retrieved vignette");
        }
        else
        {
            Debug.LogError("Vignette is not found on the global volume.");
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (coroutine == null) {
            coroutine = StartCoroutine(EEnd());
        }
    }

    IEnumerator EEnd() {
        // Initially, apply the vignette effect gradually for 10 seconds
        yield return new WaitForSeconds(10f);
        for (float t = 0; t < 1f; t += Time.deltaTime / 10f) // Duration of 10 seconds
        {
            vignette.intensity.value = Mathf.Lerp(0f, 1f, t);
            yield return null;
        }

        yield return new WaitForSeconds(8f);
        
        // Activate the end text
        endText.SetActive(true);
        
        // Start scaling from 0 to 4.5 over 2 seconds
        Vector3 startScale = Vector3.zero; // Starting scale from 0
        Vector3 endScale = new Vector3(4.5f, 4.5f, 4.5f);
        float scaleDuration = 6f; // Duration to scale from 0 to 4.5
        for (float t = 0; t < 1f; t += Time.deltaTime / scaleDuration)
        {
            endText.transform.localScale = Vector3.Lerp(startScale, endScale, t);
            yield return null;
        }

        // Ensure the final scale is set to 4.5 after interpolation
        endText.transform.localScale = endScale;

        // Optionally wait for some time here if you need a delay before quitting
        yield return new WaitForSeconds(2f);
        Debug.Log("Application quit");
        Application.Quit();
    }
}
