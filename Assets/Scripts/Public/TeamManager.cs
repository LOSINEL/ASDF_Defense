using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    public static TeamManager instance;

    const int teamSize = 8;
    [SerializeField] SerializableDictionary<Enums.CHAR_TYPE, CharacterData> charactersDatas = new();
    [SerializeField] CharacterData[] teamCharacters = new CharacterData[teamSize];

    public SerializableDictionary<Enums.CHAR_TYPE, CharacterData> CharacterDatas { get { return charactersDatas; } }
    public CharacterData[] TeamCharacters { get { return teamCharacters; } }

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

    public void ChangeCharacter(int _index, Enums.CHAR_TYPE _charType)
    {
        if (CheckDoubleCharacter(_charType))
        {
            teamCharacters[GetDoubleCharacterIndex(_charType)] = teamCharacters[_index];
            teamCharacters[_index] = charactersDatas.GetValue(_charType);
        }
        else
        {
            teamCharacters[_index] = charactersDatas.GetValue(_charType);
        }
    }

    bool CheckDoubleCharacter(Enums.CHAR_TYPE _charType)
    {
        for (int i = 0; i < teamSize; i++)
        {
            if (teamCharacters[i].CharType == _charType) return true;
        }
        return false;
    }

    int GetDoubleCharacterIndex(Enums.CHAR_TYPE _charType)
    {
        for (int i = 0; i < teamSize; i++)
        {
            if (teamCharacters[i].CharType == _charType) return i;
        }
        return -1;
    }
}