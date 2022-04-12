using UnityEngine;
using UnityEngine.SceneManagement;

public class NounSceneHandler : MonoBehaviour
{
    public void GoBack() {
        SoundManager.instance.Play("Bloop 1");
        SceneManager.LoadScene("TopicsMenu");
    }
}
