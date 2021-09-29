using UnityEngine;

public class FollowTargetWithOffset : MonoBehaviour
{
    [SerializeField] private Transform followTarget;
    [SerializeField] private Vector3 offset;
    [SerializeField] private bool matchTargetRotation;

    private void Update()
    {
        FollowTarget();

        if(matchTargetRotation)
        {
            MatchRotation();
        }
    }

    private void FollowTarget()
    {
        transform.position = (new Vector3(followTarget.position.x + offset.x, followTarget.position.y + offset.y, followTarget.position.z + offset.z));
    }

    private void MatchRotation()
    {
        transform.rotation = followTarget.rotation;
    }


}
