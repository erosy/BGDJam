using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : RaycastController
{
    public LayerMask passengerMask;
    public Vector2 move;

    [Range(0,2)]
    public float easeAmount;
    public float waitTime;
    public float speed;
    public bool cyclic;
    float percentBetweenWaypoints;
    float nextMoveTime;
    public int fromWaypointIndex;
    [SerializeField] Vector3[] localWaypoints;
    Vector3[] globalWaypoints;

    List<PassengerMovement> passengerMovements;
    Dictionary<Transform, Controller2D> passengerDicitionary = new Dictionary<Transform, Controller2D>();
    
    public override void Start()
    {
        base.Start();
        globalWaypoints = new Vector3[localWaypoints.Length];
        for(int i = 0; i < localWaypoints.Length; i++)
            globalWaypoints[i] = localWaypoints[i] + transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        UpdateRaycastOrigins();
        Vector2 velocity = CalculatePlatformMovement();
        CalculatePassengerMovements(velocity);
        MovePassengers(true);
        transform.Translate(velocity);
        MovePassengers(false);
    }

    Vector2 CalculatePlatformMovement()
    {
        if (Time.time < nextMoveTime)
            return Vector2.zero;
        fromWaypointIndex %= globalWaypoints.Length;
        int toWaypointIndex = (fromWaypointIndex + 1) % globalWaypoints.Length;
        float distanceBetweenWaypoints = Vector2.Distance(globalWaypoints[fromWaypointIndex], globalWaypoints[toWaypointIndex]);
        percentBetweenWaypoints += Time.deltaTime * speed/distanceBetweenWaypoints;
        percentBetweenWaypoints = Mathf.Clamp01(percentBetweenWaypoints);
        float easePercentBetweenWaypoint = Ease(percentBetweenWaypoints);

        Vector3 newPos = Vector3.Lerp(globalWaypoints[fromWaypointIndex], globalWaypoints[toWaypointIndex], easePercentBetweenWaypoint);

        if (percentBetweenWaypoints >= 1)
        {
            percentBetweenWaypoints = 0;
            fromWaypointIndex++;

            if (!cyclic)
            {
                if (fromWaypointIndex >= globalWaypoints.Length - 1)
                {
                    fromWaypointIndex = 0;
                    System.Array.Reverse(globalWaypoints); //jika sudah mentok maka arraynya dibalikin biar platformnya bisa gerak balik
                }
            }

            nextMoveTime = Time.time + waitTime;
        }
            
        return newPos - transform.position;
    }

    float Ease(float x)
    {
        float a = easeAmount + 1;
        return Mathf.Pow(x, a) / (Mathf.Pow(x, a) + Mathf.Pow(1-x, a));
    }
    void MovePassengers(bool beforeMovePlatform)
    {
        foreach (PassengerMovement passenger in passengerMovements)
        {
            if (!passengerDicitionary.ContainsKey(passenger.transform))
                passengerDicitionary.Add(passenger.transform, passenger.transform.GetComponent<Controller2D>()); // cara ngakalin supaya ga manggil getcomponent controller 2d tiap frame, yang bisa makan performa.
            if (passenger.moveBeforePlatform == beforeMovePlatform)
                passengerDicitionary[passenger.transform].Move(passenger.velocity, passenger.standingOnPlatform);
        }
    }

    void CalculatePassengerMovements(Vector2 velocity)
    {
        //Daftar semua objek yang injak platform bergerak. Pake Hash set karena performanya lebih cepat dalam menambahkan item dan cek jika ada item dalam list tsb.
        HashSet<Transform> movedPassengers = new HashSet<Transform>();
        passengerMovements = new List<PassengerMovement>();

        float directionX = Mathf.Sign(velocity.x);
        float directionY = Mathf.Sign(velocity.y);

        //Vertically moving platform
        if(velocity.y != 0)
        {
            float rayLength = Mathf.Abs(velocity.y) + skinWidth;
            for (int i = 0; i < verticalRayCount; i++)
            {
                Vector2 rayOrigin = (directionY == -1) ? raycastOrigins.bottomLeft : raycastOrigins.topLeft;
                rayOrigin += Vector2.right * (verticalRaySpacing * i);
                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, passengerMask);

                if (hit)
                {
                    if (!movedPassengers.Contains(hit.transform) /* detect posisi player */)
                    {
                        movedPassengers.Add(hit.transform); /* Posisi player dimasukkan ke list sebagai bagian dari platform supaya player dapat bergerak sesuai arah platform */
                        float pushX = (directionY == 1) ? velocity.x : 0; //velocity x yang digunakan untuk menggerakkan player horizontally, berpengaruh jika platformnya ada bergerak secara diagonal.
                        /* karena bergerak secara vertical maka velocity x yg diberikan sebagai berikut: 
                            Player baru mengikuti velocity x dari platform jika player berada di atas platform.
                            Selain itu player tidak mengikuti velocity x dari platform.
                         */
                        float pushY = velocity.y - (hit.distance - skinWidth) * directionY;

                        passengerMovements.Add(new PassengerMovement(hit.transform, new Vector2(pushX, pushY), directionY == 1, true));
                    }
                    
                }
            }
        }

        //Horizontally moving platform, dan player tidak nginjak platform alias ketabrak dari samping
        if (velocity.x != 0)
        {
            float rayLength = Mathf.Abs(velocity.x) + skinWidth;
            for (int i = 0; i < horizontalRayCount; i++)
            {
                Vector2 rayOrigin = (directionX == -1) ? raycastOrigins.bottomLeft : raycastOrigins.bottomRight;
                rayOrigin += Vector2.up * (horizontalRaySpacing * i);
                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, passengerMask);

                if (hit)
                {
                    if (!movedPassengers.Contains(hit.transform))
                    {
                        movedPassengers.Add(hit.transform);
                        float pushX = velocity.x - (hit.distance - skinWidth) * directionX; //jika player berada disamping platform, maka player akan bergeser searah platform yang berjalan
                        float pushY = -skinWidth;

                        passengerMovements.Add(new PassengerMovement(hit.transform, new Vector2(pushX, pushY), false, true));
                    }

                }
            }
        }

        //Passenger is on top of horizontally moving platform or downward moving platform
        if(directionY == -1 || velocity.y == 0 && velocity.x != 0)
        {
            float rayLength = skinWidth * 2;
            for (int i = 0; i < verticalRayCount; i++)
            {
                Vector2 rayOrigin = raycastOrigins.topLeft + Vector2.right * (verticalRaySpacing * i); ;
                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up, rayLength, passengerMask);

                if (hit)
                {
                    if (!movedPassengers.Contains(hit.transform))
                    {
                        movedPassengers.Add(hit.transform);
                        float pushX = velocity.x;
                        float pushY = velocity.y;

                        passengerMovements.Add(new PassengerMovement(hit.transform, new Vector2(pushX, pushY), true, false));
                    }

                }
            }
        }
    }

    //store konfigurasi platform bergerak, platform akan digerakkan dan dieksekusi berdasarkan konfigurasi yang diberikan di struct ini.
    struct PassengerMovement
    {
        public Transform transform;
        public Vector2 velocity;
        public bool standingOnPlatform;
        public bool moveBeforePlatform;

        public PassengerMovement(Transform _transform, Vector2 _velocity, bool _standingOnPlatform, bool _moveBeforePlatform )
        {
            transform = _transform;
            velocity = _velocity;
            standingOnPlatform = _standingOnPlatform;
            moveBeforePlatform = _moveBeforePlatform;
        }
    }

    private void OnDrawGizmos()
    {
        if(localWaypoints != null)
        {
            Gizmos.color = Color.red;
            float size = .3f;

            for(int i = 0; i < localWaypoints.Length; i++)
            {
               /*  Jika ga sedang dalam game, maka gizmo bakal ngikut objek utama, sebaliknya jika dalam gameplay, maka posisi untuk gizmo akan mengikuti
                posisi dari variabel utama global way points */ 
                Vector2 globalWaypointPos = (Application.isPlaying)?globalWaypoints[i]:localWaypoints[i] + transform.position;
                Gizmos.DrawLine(globalWaypointPos - Vector2.up * size, globalWaypointPos + Vector2.up * size);

                Gizmos.DrawLine(globalWaypointPos - Vector2.left * size, globalWaypointPos + Vector2.left * size);
            }
        }
    }
}
