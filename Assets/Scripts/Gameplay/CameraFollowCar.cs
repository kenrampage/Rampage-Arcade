using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowCar : MonoBehaviour
{

    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 rotationOffset;
    [SerializeField] private Transform target;
    [SerializeField] private float translateSpeed;
    [SerializeField] private float rotationSpeed;

    private GameManager1 gameManager1;

    private void Start()
    {

        gameManager1 = GameManager1.Instance;
        target = gameManager1.player.transform;

    }

    private void Update()
    {
        // target = gameManager1.player.transform;
        // HandleTranslation();
        // HandleRotation();
    }

    private void FixedUpdate()
    {
        HandleTranslation();
        HandleRotation();
    }


    void HandleTranslation()
    {
        var targetPosition = target.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, translateSpeed * Time.deltaTime);

    }

    void HandleRotation()
    {
        var direction = (target.position - rotationOffset) - transform.position;
        var rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
