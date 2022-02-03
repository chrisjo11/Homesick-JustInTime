using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDestructionBehavoiur : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
