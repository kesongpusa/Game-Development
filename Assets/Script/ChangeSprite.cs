using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    public Sprite defaultSprite;
    public Sprite noAcceptSprite;
    public Sprite newSprite;
    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        sr.sprite = defaultSprite;
    }

    public void HighlightSprite()
    {
        if (sr != null && newSprite != null)
        {
            sr.sprite = newSprite;
            Debug.Log("Highlight applied to: " + sr.gameObject.name);
        }
    }

    public void noAcceptItemSprite()
    {
        if (sr != null && noAcceptSprite != null)
        {
            sr.sprite = noAcceptSprite;
            Debug.Log("Highlight applied to: " + sr.gameObject.name);
        }
    }

    public void ResetSprite()
    {
        if (sr != null && defaultSprite != null)
        {
            sr.sprite = defaultSprite;
            Debug.Log("Sprite reset to default!");
        }
    }
}
