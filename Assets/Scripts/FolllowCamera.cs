using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolllowCamera : MonoBehaviour
{
   [SerializeField] private GameObject player;
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + new Vector3(0,0,-10);
    }
}
