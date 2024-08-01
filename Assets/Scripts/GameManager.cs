using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    [Header("Player")]
    public GameObject playerPrefab;

    [Header("Enemies")]
    public GameObject[] enemyPrefab;

    [Header("References")]
    public Transform playerSpawnPoint;

    private GameObject _currentPlayer;


    private void Start()
    {
        //SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        _currentPlayer = Instantiate(playerPrefab);
        _currentPlayer.transform.position = playerSpawnPoint.position;
    }


    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
