using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapGestures : MonoBehaviour
{
    public GameObject objectOne, objectTwo;
    private bool go;
    // Start is called before the first frame update
    void Start()
    {
        go = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (go == false)
        {
            objectOne.SetActive(true);
            objectTwo.SetActive(false);
        }
        if (go == true)
        {
            objectOne.SetActive(false);
            objectTwo.SetActive(true);
        }
    }

    public void Swap()
    {
        go = !go;
    }
}
