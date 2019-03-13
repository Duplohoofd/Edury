using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Vernietig niet de audiogameobject maar zorg er ook voor dat deze niet dubbel wordt aangeroepen. (zodat je twee keer muziek hoort).

public class DontDestroyAudio : MonoBehaviour
{
    private static DontDestroyAudio _instance;
    void Awake()
    {
        //Asl we nog niet een [_instance] hebben
        if (!_instance)
            _instance = this;
        //Anders als we er wel eentje hebben, vernietigen!
        else
            Destroy(this.gameObject);


        DontDestroyOnLoad(this.gameObject);
    }
}
