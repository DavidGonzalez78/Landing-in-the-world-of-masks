
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Vector3 offsetPosition = new Vector3(0, 20, -20);
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offsetPosition;
    }
}
