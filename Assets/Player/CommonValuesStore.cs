using UnityEngine;

public class CommonValuesStore : MonoBehaviour
{
    public static CommonValues CommonValues { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        CommonValues = GetComponent<CommonValues>();
    }
}
