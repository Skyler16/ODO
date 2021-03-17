using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject pickupUI;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            LevelManager.instance.ItemPickedUp(gameObject);

            gameObject.SetActive(false);
            pickupUI.SetActive(true);
            Camera.instance.GetComponent<Camera>().changeCamera();
        }
        

    }
}
