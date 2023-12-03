using UnityEngine;

public class LevelTransitions : MonoBehaviour
{
    [SerializeField]
    private string sceneNameToLoad = "MainMenu";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            other.transform.position = Vector3.zero;
            if (sceneNameToLoad == null) return;
            GameManager._Instance.StartLoadLevel(sceneNameToLoad);
            
            SaveGameManager._Instance.SaveGame(sceneNameToLoad);
        }
    }
}
