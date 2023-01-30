using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    public static TeamManager instance;
    [SerializeField] CharacterData[] charactersDatas;
    [SerializeField] CharacterData[] teamCharacters = new CharacterData[8];

    public CharacterData[] CharacterDatas { get { return charactersDatas; } }

    private void Awake()
    {
        if (instance == null)
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