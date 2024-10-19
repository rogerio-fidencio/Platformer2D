using UnityEngine;

public class PauseScreenButton : MonoBehaviour
{

    [SerializeField] private GameObject pauseScreen;

    public void Open()
    {
        pauseScreen.SetActive(true);
    }

    public void Close()
    {
        pauseScreen.SetActive(false);
    }
}
