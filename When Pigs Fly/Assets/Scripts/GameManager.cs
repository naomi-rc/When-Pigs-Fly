using UnityEngine;

public class GameManager : MonoBehaviour
{    
    public Transform player;
    public float offset = 10f;

    private Vector2 screenBounds;
    private AudioSource pigCry;    
    private Camera mainCamera;
    private bool gameOver = false;

    void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        Vector3 position = new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z);
        screenBounds = mainCamera.ScreenToWorldPoint(position);
        pigCry = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!gameOver && player.position.y < transform.position.y - screenBounds.y)
        {
            gameOver = true;
            GameOver();
        }
    }

    void GameOver()
    {
        pigCry.Play();
        Debug.Log("GAME OVER!!!");
    }

    void Restart()
    {

    }
}
