using UnityEngine;

public class InvisiblePotion : MonoBehaviour, Interactive
{
    public EffectManager effectManager;
    bool available;
    bool Interactive.active
    {
        get
        {
            return available;
        }
    }
    void Start()
    {
        effectManager = GameObject.FindWithTag("Player").GetComponent<EffectManager>();
        available = true;
    }
    public void Interact()
    {
        effectManager.ApplyInvisibility();
        available = false;
        Destroy(gameObject);
    }
}
