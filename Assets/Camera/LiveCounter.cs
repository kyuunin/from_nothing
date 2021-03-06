﻿using System.Linq;
using UnityEngine;

public class LiveCounter : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Hearts;

    // Update is called once per frame
    private void Update()
    {
        var activeHearts = Hearts
            .Select((x, i) => new { Heart = x, Index = i })
            .Where(x => x.Index < ValuesStore.CommonValues.LivesOfPlayer)
            .ToList();

        activeHearts
            .ForEach(x => x.Heart.SetActive(true));

        var inactiveHearts = Hearts
            .Select((x, i) => new { Heart = x, Index = i })
            .Where(x => x.Index >= ValuesStore.CommonValues.LivesOfPlayer)
            .ToList();

        inactiveHearts
            .ForEach(x => x.Heart.SetActive(false));
    }
}
