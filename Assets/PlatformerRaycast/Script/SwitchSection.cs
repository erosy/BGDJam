using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSection : MonoBehaviour
{
    public GameObject virtualCam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") /*&& !collision.isTrigger*/)
        {
            //Debug.Log("Masuk");
            virtualCam.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") /*&& !collision.isTrigger*/)
        {
            //Debug.Log("Keluar");
            virtualCam.SetActive(false);
        }
    }


}
