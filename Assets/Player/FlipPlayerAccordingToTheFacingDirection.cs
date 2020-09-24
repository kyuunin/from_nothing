using UnityEngine;

public class FlipPlayerAccordingToTheFacingDirection : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.flipX = !ValuesStore.CommonValues.DannyDirection;
    }
}
