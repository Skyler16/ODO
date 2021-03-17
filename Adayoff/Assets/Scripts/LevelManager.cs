using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public List<GameObject> scene1;
    public List<GameObject> scene2;
    private int numChangeCamera;

    private int numItemsSaved;
    private bool is3dCamera;

    public GameObject UIButtonChangeCamera;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        numChangeCamera = 0;
        numItemsSaved = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UIButtonChangeCamera.SetActive(false);
    }

    public void ItemPickedUp(GameObject item)
    {
        if(item.tag == "ChangeCamera")
        {
            ++numChangeCamera;
        }
    }

    public void LevelWin()
    {
        Debug.Log("Win!");
    }

    public void UseItemChangeCamera()
    {
        if (numChangeCamera > 0)
        {
            Camera.instance.GetComponent<Camera>().changeCamera();
            --numChangeCamera;
            if (numChangeCamera == 0)
                UIButtonChangeCamera.SetActive(false);
        }
    } 
    
    public void SaveState()
    {
        numItemsSaved = numChangeCamera;
        is3dCamera = Camera.instance.is3DCamera();
    }

    public void BackToScene()
    {
        if(numChangeCamera > numItemsSaved)
        {
            numChangeCamera = numItemsSaved;
            if (numChangeCamera == 0)
                UIButtonChangeCamera.SetActive(false);
        }
        foreach(GameObject item in scene2)
        {
            item.SetActive(true);
        }

        if(Camera.instance.is3DCamera() != is3dCamera)
        {
            Camera.instance.changeCamera();
        }
    }
}
