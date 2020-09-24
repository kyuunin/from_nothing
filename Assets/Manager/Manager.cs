using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private GameObject Saved;
    private GameObject Active;
    // Start is called before the first frame update
    void Start()
    {
        Saved = GameObject.Find("Saved");
        print(Saved);
        Saved.SetActive(true);
        Active = Instantiate(Saved);
        Saved.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }else
        if (Input.GetKeyDown(KeyCode.C))
        {
            Create();
        }
    }
    public void Create() {

        Destroy(Saved);
        Saved = Instantiate(Active);
        Saved.SetActive(false);
    }
    public void Reload() {
        Destroy(Active);
        Saved.SetActive(true);
        Active = Instantiate(Saved);
        Saved.SetActive(false);
    }
}
