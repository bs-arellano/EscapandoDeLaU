using UnityEngine;

public class TimeReducer : MonoBehaviour, Interactive
{
    bool available;
    public int amount = 300;
    bool Interactive.active
    {
        get
        {
            return available;
        }
    }
    public TimeManager timeManager;
    void Start()
    {
        available = true;
        timeManager = GameObject.FindWithTag("Player").GetComponent<TimeManager>();
    }
    public void Interact()
    {
        timeManager.ReduceTime(amount);
        available = false;
        Destroy(gameObject);
    }
}
