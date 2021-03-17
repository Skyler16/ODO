using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScene : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject lastScene;

    //public GameObject oldCamera;
    //public GameObject newCamera;
    //public GameObject boundingBox;
    //public GameObject newBoundingBox;
    //public Transform playerStartPosition;
    //public float moveSpeed = 5f;
    public float cameraMoveSpeed = 5f;

    private bool nextScene = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (nextScene)
        {
            mainCamera.transform.localPosition = Vector3.MoveTowards(mainCamera.transform.localPosition, new Vector3(8, 0, 0), cameraMoveSpeed * Time.deltaTime);
            if (mainCamera.transform.localPosition.x == 8)
            {
                gameObject.SetActive(false);
                lastScene.SetActive(true);
            }
            
        }
            
    }
            

    private void OnTriggerEnter(Collider other)
    {
        nextScene = true;
        
        //boundingBox.SetActive(false);

        //oldCamera.SetActive(false);
        //newCamera.SetActive(true);

        //Player.instance.transform.position = playerStartPosition.position;

        //newBoundingBox.SetActive(true);

        //LevelManager.instance.SaveState();

        //Destroy(gameObject);

    }

    
}
