using System.Linq;
using UnityEngine;

public class LifeCounter : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Hearts;

    // Update is called once per frame
    private void Update()
    {
        var activeHearts = Hearts
            .Select((x, i) => new { Heart = x, Index = i })
            .Where(x => x.Index < DamageValues.LivesOfPlayer)
            .ToList();

        activeHearts
            .ForEach(x => x.Heart.SetActive(true));

        var inactiveHearts = Hearts
            .Select((x, i) => new { Heart = x, Index = i })
            .Where(x => x.Index >= DamageValues.LivesOfPlayer)
            .ToList();

        inactiveHearts
            .ForEach(x => x.Heart.SetActive(false));
    }
}
