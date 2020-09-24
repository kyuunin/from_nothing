using UnityEngine;

public class Orbscript : MonoBehaviour
{
    public string ScriptType;

    // Start is called before the first frame update
    void Start()
    {
        ((MonoBehaviour)ValuesStore.Player.GetComponent(ScriptType)).enabled=false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ((MonoBehaviour)ValuesStore.Player.GetComponent(ScriptType)).enabled = true;
        Destroy(gameObject);
        Debug.Log("got destroyes");
    }
}
