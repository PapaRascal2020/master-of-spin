using UnityEngine;
using UnityEngine.UI;

public class KeyManager : MonoBehaviour
{
    public GameObject finish;
    public Text keysLeft;
    public int NumberOfKeys;
    // Start is called before the first frame update
    void Start()
    {
        NumberOfKeys = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        NumberOfKeys = transform.childCount;
        keysLeft.text = "Keys Left: " + NumberOfKeys.ToString();
        if (NumberOfKeys == 0)
        {
            keysLeft.text = "Blue Portal Opened";
            finish.SetActive(true);
        }
    }
}
