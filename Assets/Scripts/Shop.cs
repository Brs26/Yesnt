using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public KeyCode interactKey;
    public Canvas ShopUI;
    bool inRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inRange)
        {
            if(Input.GetKeyDown(interactKey))
            {
                Debug.Log("asd");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        inRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inRange = false;
    }
}
