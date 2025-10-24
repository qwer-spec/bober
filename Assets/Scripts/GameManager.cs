using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager ST { get; private set; }

    public Dictionary<GameObject, Health> healthContainer;


    private void Awake()
    {
        ST = this;
        healthContainer = new Dictionary<GameObject, Health>();
    }


}
