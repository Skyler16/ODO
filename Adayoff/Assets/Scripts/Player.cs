using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (gameObject.transform.localPosition.x >= 24.3f)
            SceneManager.LoadScene("End");
        else if (gameObject.transform.localPosition.x >= 16 && gameObject.transform.localPosition.x < 24.3f)
            mainCamera.transform.localPosition = Vector3.MoveTowards(mainCamera.transform.localPosition, new Vector3(18, -2.5f, -1), cameraMoveSpeed * Time.deltaTime);
        else if (gameObject.transform.localPosition.x >= 11.5 && gameObject.transform.localPosition.x < 16)
            mainCamera.transform.localPosition = Vector3.MoveTowards(mainCamera.transform.localPosition, new Vector3(14, 0, -1), cameraMoveSpeed * Time.deltaTime);
        else if (gameObject.transform.localPosition.x >= 4.5f && gameObject.transform.localPosition.x < 11.5)
            mainCamera.transform.localPosition = Vector3.MoveTowards(mainCamera.transform.localPosition, new Vector3(8, 0, -1), cameraMoveSpeed * Time.deltaTime);
        else
            mainCamera.transform.localPosition = Vector3.MoveTowards(mainCamera.transform.localPosition, new Vector3(-2, 0, -1), cameraMoveSpeed * Time.deltaTime);


        //分身
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(son);
            son = Instantiate(son, new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y + 0.5f, gameObject.transform.localPosition.z), Quaternion.identity);
        }
            
    }

}
