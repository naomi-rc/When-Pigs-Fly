using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D rb;
    public GameObject curledTail;
    public GameObject uncurledTail;
    public float moveSpeed = 0.1f;
    public float uncurlTailDelay = 0.02f;


    Vector2 m_MousePosition;
    float m_LeftBound = -25f;
    float m_RightBound = 25f;
    float m_UpperBound = 25f;
    float m_LowerBound = 25f;
    
    public float m_VerticalForce = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //player.position = new Vector3(Input.mousePosition.x, player.position.y, player.position.z);

        m_MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(m_MousePosition.x > m_LeftBound && m_MousePosition.x < m_RightBound)
        {
            player.position = Vector2.Lerp(player.position, new Vector2(m_MousePosition.x, player.position.y), moveSpeed);
        }
        /* if(player.position.y < m_LowerBound)
         {
             player.position = Vector2.Lerp(player.position, new Vector2(m_MousePosition.x, m_LowerBound), moveSpeed);
         }*/
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("surface"))
        {            
            rb.AddForce(new Vector2(0, m_VerticalForce), ForceMode2D.Impulse);
            curledTail.SetActive(true);
            uncurledTail.SetActive(false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Invoke("UncurlTail", uncurlTailDelay);
    }

    private void UncurlTail()
    {
        curledTail.SetActive(false);
        uncurledTail.SetActive(true);
    }


}
