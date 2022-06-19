using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public Transform target;
    float speed = 70.0f;
    Vector3 zRotation;

    public bool reverse;


    private void Update()
    {
        if(reverse)
        {
            zRotation = new Vector3(0, 0, 2);
        }
        else
        {
            zRotation = new Vector3(0, 0, -2);
        }
        
        transform.RotateAround(target.position, zRotation, speed * Time.deltaTime);
    }

}
