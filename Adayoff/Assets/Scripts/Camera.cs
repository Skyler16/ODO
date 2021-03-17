using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
public class Camera : MonoBehaviour
{
    //如果需要在其他地方调用Camera类，可以直接用Camera.instance.变量或函数名，不用获取Camera Object
    public static Camera instance;

    public bool debug;
    // Start is called before the first frame update
    public GameObject camera2d;
    public GameObject camera3d;
    public bool is3d;
    public GameObject fall;
    public GameObject hidden;

    private float playerPosition3dZ;
    private float playerPosition2dZ;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if(is3d)
        {
            camera3d.SetActive(true);
            camera2d.SetActive(false);
            hidden.SetActive(false);
        }
        else
        {
            camera3d.SetActive(false);
            camera2d.SetActive(true);
            hidden.SetActive(true);
        }

        playerPosition3dZ = Player.instance.transform.position.z;
        playerPosition2dZ = playerPosition3dZ;
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(!debug)
        //{
        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {
        //        changeCamera();
        //    }
        //}
        
        
        
    }

    public bool is3DCamera()
    {
        return is3d;
    }

    public void changeCamera()
    {
        
        if (!is3d)
        {
            camera2d.SetActive(false);
            camera3d.SetActive(true);
            hidden.SetActive(false);
            is3d = true;

            Player.instance.transform.position = new Vector3(Player.instance.transform.position.x, Player.instance.transform.position.y, playerPosition3dZ);
            fall.transform.position = new Vector3(fall.transform.position.x, fall.transform.position.y, 52.32f);
        }
        else
        {
            camera2d.SetActive(true);
            camera3d.SetActive(false);
            hidden.SetActive(true);
            is3d = false;

            playerPosition3dZ = Player.instance.transform.position.z;
            Player.instance.transform.position = new Vector3(Player.instance.transform.position.x, Player.instance.transform.position.y, playerPosition2dZ);
            fall.transform.position = new Vector3(fall.transform.position.x, fall.transform.position.y, 50);
        }
    }
}
