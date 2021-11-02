using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Camera mainCamera;
    public Transform player;
    private Vector2 screenBounds;

    void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        Vector3 position = new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z);
        screenBounds = mainCamera.ScreenToWorldPoint(position);
    }

    void Update()
    {
        if (player.position.y < transform.position.y - screenBounds.y)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("GAME OVER!!!");
    }
}
