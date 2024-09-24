using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***
 *  GameAssets contains assets needed to be changed on runtime.
 *  It is a component of an object in the scene, and the object MUST be a prefab.
    Also, the prefab MUST be saved in the following path: Assets/Resources, otherwise it won't work.
 */
public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;

    public static GameAssets i
    {
        get
        {
            if (_i == null) _i = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            return _i;
        }
    }

    #region Card
    //Card prefab used in UI
    public GameObject CardPrefabUI;
    public GameObject CardHover;
    #endregion
}
