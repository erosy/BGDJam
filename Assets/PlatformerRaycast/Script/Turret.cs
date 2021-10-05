using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private GameObject firePoint;
    [SerializeField] private float buttonShotDelay;
    private float buttonShotTimer;
   
    // Start is called before the first frame update
    void Start()
    {
        buttonShotTimer = buttonShotDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if(buttonShotTimer <= 0)
        {
            GameObject bullet = ObjectPool.instance.GetPooledObject();
            if(bullet != null)
            {
                bullet.transform.position = firePoint.transform.position;
                bullet.SetActive(true);
            }

            else
            {
                bullet = Instantiate(ObjectPool.instance.bulletPrefab, ObjectPool.instance.transform);
                bullet.transform.position = firePoint.transform.position;
                ObjectPool.instance.AddObjectToList(bullet);
            }
            buttonShotTimer = buttonShotDelay;
        }
        else
        {
            buttonShotTimer -= Time.deltaTime;
        }
            //shot
    }
}
