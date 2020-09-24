using UnityEngine;

public class Manager : MonoBehaviour
{
    private GameObject _active;

    private GameObject _saved;

    public void Create()
    {
        Destroy(_saved);
        _saved = Instantiate(_active);
        _saved.SetActive(false);
    }
    public void Reload()
    {
        Destroy(_active);
        _saved.SetActive(true);
        _active = Instantiate(_saved);
        _saved.SetActive(false);

        UpdateValuesStore();
    }

    // Start is called before the first frame update
    private void Start()
    {
        ValuesStore.Manager = this;

        _saved = GameObject.Find("Saved");
        print(_saved);
        _saved.SetActive(true);
        _active = Instantiate(_saved);
        _saved.SetActive(false);

        UpdateValuesStore();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            Create();
        }
    }

    private void UpdateValuesStore()
    {
        ValuesStore.CommonValues = _active.GetComponentInChildren<CommonValues>();
        ValuesStore.Player = ValuesStore.CommonValues.gameObject;
    }
}
