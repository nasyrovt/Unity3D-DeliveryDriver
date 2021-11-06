using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    //Camera and car position should be the same
    [SerializeField] GameObject carToFollow;
    void LateUpdate()
    {
        transform.position = carToFollow.transform.position + new Vector3(0, 0, -10);
    }
}
