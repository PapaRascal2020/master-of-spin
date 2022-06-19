using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public GameObject[] targets;
    int selected;

    private void Start()
    {
        PickTarget();
    }

    void PickTarget()
    {
        targets[selected].GetComponent<SpriteRenderer>().color = Color.white;
        targets[selected].tag = "Spinner";

        selected = Random.Range(0, targets.Length - 1);

        targets[selected].GetComponent<SpriteRenderer>().color = Color.green;
        targets[selected].tag = "Enemy";

        Invoke("PickTarget", 4.0f);
    }
}
