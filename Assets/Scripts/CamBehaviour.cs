using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamBehaviour : MonoBehaviour
{
    public Transform targetPlayer;

    private float CamPosXOffset;
    private const int CAM_POS_Y = 0;
    private const int CAM_POS_Z = -10;

    // Start is called before the first frame update
    void Start()
    {
        CamPosXOffset = targetPlayer.position.x - transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(targetPlayer.position.x - CamPosXOffset, CAM_POS_Y, CAM_POS_Z);
    }
}
