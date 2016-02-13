using UnityEngine;
using System.Collections;

public class cameramove : MonoBehaviour
{
    public GameObject player;
    Vector3 target;

    // Use this for initialization
    void Start()
    {
        //player = GameObject.Find;
    }

    // Update is called once per frame
    void Update()
    {
        target = new Vector3(player.transform.position.x, player.transform.position.y+4  , -10f);

        transform.position = Vector3.Lerp(transform.position, target, 1);

    }
}
