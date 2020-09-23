using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbscript : MonoBehaviour
{
    public string ScriptType;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        ((MonoBehaviour)Player.GetComponent(ScriptType)).enabled=false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        ((MonoBehaviour)Player.GetComponent(ScriptType)).enabled = true;
        Destroy(gameObject);
        Debug.Log("got destroyes");
    }
}
