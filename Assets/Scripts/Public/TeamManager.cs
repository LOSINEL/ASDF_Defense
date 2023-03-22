using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    public static TeamManager instance;

    const int teamSize = 8;
    [SerializeField] SerializableDictionary<Enums.CHAR_TYPE, CharacterData> charactersDatas = new();
    [SerializeField] CharacterData[] teamCharacters = new CharacterData[teamSize];
    [SerializeField] Color[] portraitBackgroundColors = new Color[5];

    int selectedCastleCharacter;

    public SerializableDictionary<Enums.CHAR_TYPE, CharacterData> CharacterDatas { get { return charactersDatas; } }
    public CharacterData[] TeamCharacters { get { return teamCharacters; } }
    public Color[] PortraitBackgroundColors { get { return portraitBackgroundColors; } }

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

    private void Start()
    {
        for (int i = 0; i < teamSize; i++)
        {
            if (SaveManager.instance.CheckHasKey($"Team{i.ToString()}"))
            {
                teamCharacters[i] = CharacterDatas.GetValue((Enums.CHAR_TYPE)SaveManager.instance.LoadDataInt($"Team{i.ToString()}"));
            }
        }
    }

    public void SelectCastleCharacter(int _charType)
    {
        selectedCastleCharacter = _charType;
    }

    public void ChangeCharacter(int _index)
    {
        Enums.CHAR_TYPE charType = (Enums.CHAR_TYPE)selectedCastleCharacter;
        teamCharacters[_index] = charactersDatas.GetValue(charType);
        SaveManager.instance.SetData($"Team{_index.ToString()}", (int)charType);
    }
}