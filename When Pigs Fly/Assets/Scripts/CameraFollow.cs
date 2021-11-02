using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    private float m_MaxPlayerHeight = 0f;
    

    // Start is called before the first frame update
    void Start()
    {
        m_MaxPlayerHeight = player.position.y + 10;
    }

    // Update is called once per frame
    void Update()
    {
        //position = Vector2.Lerp(player.position, new Vector2(m_MousePosition.x, player.position.y), moveSpeed);
        if(player.position.y > m_MaxPlayerHeight)
        {
            m_MaxPlayerHeight = player.position.y;
            //cameraTransform.position = Vector2.Lerp(cameraTransform.position, new Vector2(cameraTransform.position.x, m_MaxPlayerHeight), moveSpeed);
            transform.position = new Vector3(transform.position.x, m_MaxPlayerHeight, transform.position.z);
        }
        
    }
}
