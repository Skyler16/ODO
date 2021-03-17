using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public float moveSpeed = 5f;
    public Rigidbody rb;
    private Vector3 moveDir;
    
    public bool useKeyboard;

    public GameObject mainCamera;
    public float cameraMoveSpeed = 5f;

    [HideInInspector]
    public bool canMove = true;

    public GameObject son;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove)
        {
            if (!Camera.instance.is3DCamera())
            {
                rb.constraints = RigidbodyConstraints.FreezePositionZ;
            }
            else
            {
                rb.constraints = RigidbodyConstraints.None;
            }

            if (useKeyboard)
            {
                moveDir.x = Input.GetAxis("Horizontal");
                moveDir.z = Input.GetAxis("Vertical");
            }
            else
            {
                moveDir.x = Input.acceleration.x;
                moveDir.z = Input.acceleration.y;
            }

            rb.AddForce(moveDir * moveSpeed);
        }

        //摄像机的移动
        if (gameObject.transform.localPosition.x >= 15)
            mainCamera.transform.localPosition = Vector3.MoveTowards(mainCamera.transform.localPosition, new Vector3(19, -2, 0), cameraMoveSpeed * Time.deltaTime);
        else if (gameObject.transform.localPosition.x >= 9 && gameObject.transform.localPosition.x < 15)
            mainCamera.transform.localPosition = Vector3.MoveTowards(mainCamera.transform.localPosition, new Vector3(13, 0, 0), cameraMoveSpeed * Time.deltaTime);
        else if (gameObject.transform.localPosition.x >= 3.5f && gameObject.transform.localPosition.x < 9)
            mainCamera.transform.localPosition = Vector3.MoveTowards(mainCamera.transform.localPosition, new Vector3(8, 0, 0), cameraMoveSpeed * Time.deltaTime);
        else
            mainCamera.transform.localPosition = Vector3.MoveTowards(mainCamera.transform.localPosition, new Vector3(0, 0, 0), cameraMoveSpeed * Time.deltaTime);


        //分身
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(son);
            son = Instantiate(son, gameObject.transform.localPosition, Quaternion.identity);
        }
            
    }

}
