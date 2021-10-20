using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private GameObject firePoint;
    [SerializeField] private GameObject turretSprite;
    [SerializeField] private float buttonShotDelay;
    public float range;
    private float buttonShotTimer;
    public bool playerDetected;
    public Transform target;
    public Transform fireRange;
    public Transform turretBarrel;
    public LayerMask whatIsPlayer;
    Vector2 direction;
    Vector2 directionTemp;
   
    // Start is called before the first frame update
    void Start()
    {
        buttonShotTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = target.position;
        direction = targetPos - (Vector2)transform.position; 
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position,direction, range, whatIsPlayer);
        if (rayInfo)
        {
            //if (rayInfo.collider.gameObject.CompareTag("Player"))
            //{
                if(!playerDetected)
                    playerDetected = true;
                
           // }     
      
        }
        else
        {
            /*if(playerDetected)*/
               playerDetected = false;
            //Debug.Log("Aw hell naw");
        }

        if (playerDetected)
        {
            turretBarrel.transform.up = direction;
            directionTemp = turretBarrel.transform.up;
            buttonShotTimer -= Time.deltaTime;

            if (buttonShotTimer <= 0)
            {
                GameObject bullet = ObjectPool.instance.GetPooledObject();
                if (bullet != null)
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
                bullet.GetComponent<Bullet>().shootingDirection = direction;
                buttonShotTimer = buttonShotDelay;
            }

        }
        else
        {
            turretBarrel.transform.up = Vector3.zero;
            
        }
            



        //shot
    }

   
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.DrawLine(transform.position, direction);
    }

}
