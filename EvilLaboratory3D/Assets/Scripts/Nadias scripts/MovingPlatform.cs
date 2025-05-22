using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private WaypointPath waypointPath;
    [SerializeField] private float speed = 2f;

    private int targetWaypointIndex;
    private Transform previousWaypoint;
    private Transform targetWaypoint;

    private float timeToWaypoint;
    private float elapsedTime;

    public Vector3 DeltaMovement { get; private set; }
    private Vector3 lastPosition;

    void Start()
    {
        lastPosition = transform.position;

        if (waypointPath == null || waypointPath.GetWaypointCount() < 2)
        {
            Debug.LogError("WaypointPath is not properly set up.");
            enabled = false;
            return;
        }

        targetWaypointIndex = 0;
        previousWaypoint = waypointPath.GetWaypoint(targetWaypointIndex);
        targetWaypointIndex = waypointPath.GetNextWaypointIndex(targetWaypointIndex);
        targetWaypoint = waypointPath.GetWaypoint(targetWaypointIndex);

        SetupWaypointMovement();
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        float elapsedPercentage = Mathf.Clamp01(elapsedTime / timeToWaypoint);
        transform.position = Vector3.Lerp(previousWaypoint.position, targetWaypoint.position, elapsedPercentage);

        if (elapsedPercentage >= 1f)
        {
            TargetNextWaypoint();
        }
    }

    void LateUpdate()
    {
        DeltaMovement = transform.position - lastPosition;
        lastPosition = transform.position;
    }

    private void TargetNextWaypoint()
    {
        previousWaypoint = targetWaypoint;
        targetWaypointIndex = waypointPath.GetNextWaypointIndex(targetWaypointIndex);
        targetWaypoint = waypointPath.GetWaypoint(targetWaypointIndex);

        SetupWaypointMovement();
    }

    private void SetupWaypointMovement()
    {
        elapsedTime = 0f;
        float distance = Vector3.Distance(previousWaypoint.position, targetWaypoint.position);
        timeToWaypoint = distance / speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                // Check if player is standing on top of the platform
                if (Vector3.Dot(contact.normal, Vector3.up) > 0.5f)
                {
                    transform.SetParent(collision.transform);
                    break;
                }
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            transform.SetParent(null);
        }
    }
}
