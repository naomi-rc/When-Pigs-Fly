using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public GameObject[] backgroundObjects;
    private Camera mainCamera;
    private Vector2 screenBounds;
   
    void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        Vector3 position = new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z);
        screenBounds = mainCamera.ScreenToWorldPoint(position);
        Debug.Log(position);
        Debug.Log(screenBounds);

        foreach(GameObject obj in backgroundObjects)
        {
            LoadChildObjects(obj);
        }
    }

    void LoadChildObjects(GameObject obj)
    {
        //Height of current sprite
        float objectHeight = obj.GetComponent<SpriteRenderer>().bounds.size.y;
        //Number of clones needed to fill width of screen
        int childrenNeeded = (int)Mathf.Ceil(screenBounds.y * 2 / objectHeight);
        //Clone objects for mold as reference
        GameObject clone = Instantiate(obj) as GameObject;
        for(int i = 0; i <= childrenNeeded; i++)
        {
            GameObject c = Instantiate(clone) as GameObject;
            c.transform.SetParent(obj.transform);
            float x_position = obj.transform.position.x;
           /* if (obj.CompareTag("clouds"))
            {
                x_position = Random.Range(-15, 5);
            }*/
            c.transform.position = new Vector3(x_position, objectHeight * i, obj.transform.position.z);
            c.name = obj.name + i;
        }
        Destroy(clone);
        Destroy(obj.GetComponent<SpriteRenderer>());

    }

    void RepositionChildObjects(GameObject obj)
    {
        Transform[] children = obj.GetComponentsInChildren<Transform>();
        if(children.Length > 1)
        {
            GameObject firstChild = children[1].gameObject;
            GameObject lastChild = children[children.Length - 1].gameObject;
            float halfObjectHeight = lastChild.GetComponent<SpriteRenderer>().bounds.extents.y;
            if(transform.position.y + screenBounds.y > lastChild.transform.position.y + halfObjectHeight)
            {
                firstChild.transform.SetAsLastSibling();
                firstChild.transform.position = new Vector3(lastChild.transform.position.x, lastChild.transform.position.y + halfObjectHeight * 2, lastChild.transform.position.z);
            }
            else if(transform.position.y - screenBounds.y < firstChild.transform.position.y - halfObjectHeight)
            {
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position = new Vector3(firstChild.transform.position.x, firstChild.transform.position.y - halfObjectHeight * 2, firstChild.transform.position.z);
            }
        }
    }

    void LateUpdate()
    {
        foreach(GameObject obj in backgroundObjects)
        {
            RepositionChildObjects(obj);
        }
    }
}
