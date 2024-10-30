using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaManager : MonoBehaviour
{

    private static MusicaManager instance;

    void Start()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        else
        {
            Destroy(this.gameObject);
        }

    }

}
