using UnityEngine;

public class EndScreenTrigger : MonoBehaviour
{

    [SerializeField] private GameObject endScreen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OpenEndScreen();
        }
    }



    public void OpenEndScreen()
    {
        endScreen.SetActive(true);
    }
}
