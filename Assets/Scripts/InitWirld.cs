using UnityEngine;

public class InitWirld : MonoBehaviour
{
    public Object[] prefabs;

    private void Awake()
    {
        foreach (Object obj in prefabs)
        {
            Instantiate(obj);
        }
    }
}