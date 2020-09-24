using UnityEngine;

public class Orbscript : MonoBehaviour
{
    public string ScriptType;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ((MonoBehaviour)ValuesStore.Player.GetComponent(ScriptType)).enabled = true;
        Destroy(gameObject);
        Debug.Log("got destroyes");
    }
}
