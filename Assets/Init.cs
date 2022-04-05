using UnityEngine;
using UnityEngine.SceneManagement;

public class Init : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (FMODUnity.RuntimeManager.HasBankLoaded("Master"))
        {
            Debug.Log("Master Bank Loaded");
            SceneManager.LoadScene("Title", LoadSceneMode.Single);
        }
    }
}
