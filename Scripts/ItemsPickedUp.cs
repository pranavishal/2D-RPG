using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsPickedUp : MonoBehaviour
{
    public List<PickupItem> items = new List<PickupItem>();
    public bool[] beenPicked;

    public static ItemsPickedUp instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        beenPicked = new bool[items.Count];
       
    }

    // Update is called once per frame
    void Update()
    {
    }
}

