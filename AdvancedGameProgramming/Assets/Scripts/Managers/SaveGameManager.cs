using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class SaveGameManager : MonoBehaviour
{
    // INSTANCE INITIALIZATION
    public static SaveGameManager _Instance { get; private set; }

    // SERIALIZE FIELDS
    [SerializeField]
    private AreaDamageController areaDamage;

    // PUBLIC VARIABLES
    public bool saveGamePresent { get; set; }
    public string saveFilePath;
    public string settingsFilePath;
    private void OnEnable()
    {
        if (File.Exists(saveFilePath))
            saveGamePresent = true;
    }

    private void Awake()
    {
        if (_Instance != null && _Instance != this)
        {
            Debug.LogWarning("Extra Save Game Manager singleton destroyed");
            Destroy(this);
        }
        else
            _Instance = this;

        saveFilePath = Application.persistentDataPath + "/Amogus.dat";
        settingsFilePath = Application.persistentDataPath + "/Settings.dat";
    }

    public void SaveGame(string sceneName)
    {
        // Create binary formatter
        BinaryFormatter bf = new BinaryFormatter();
        Debug.Log("Save path " + Application.persistentDataPath);

        // File to create
        FileStream file = File.Create(saveFilePath);

        bf.Serialize(file, PackageSaveData(sceneName));
        file.Close();

        saveGamePresent = true;
    }

    public void LoadGame()
    {
        if (!File.Exists(saveFilePath)) return;
        saveGamePresent = true;

        BinaryFormatter bf = new BinaryFormatter();

        FileStream file = File.Open(saveFilePath, FileMode.Open);
        SaveGameData data = (SaveGameData) bf.Deserialize(file);
        
        file.Close();

        UnpackageSaveData(data);
    }

    public void ResetPlayer()
    {
        GameManager._Instance.levelToLoad = null;
        PlayerManager._Instance.Level = 0;
        GameCharacterStats._Instance.Xp = 0;
        GameCharacterStats._Instance.MaxXP = 1;
        GameCharacterStats._Instance.HP = 3;
        GameCharacterStats._Instance.MaxHp = 3;
        GameCharacterStats._Instance.XpBuff = 0;
        GameCharacterStats._Instance.XpMultiplier = 1;
        GameCharacterStats._Instance.BaseDamage = 1;
        GameCharacterStats._Instance.DamageMultiplier = 1;
        GameCharacterStats._Instance.UpgradeOptions = 2;
        GameCharacterStats._Instance.CakeSize = 0.5f;
        GameCharacterStats._Instance.AttackSizeScale = 1f;

        PlayerManager._Instance.RespawnPlayer();
        areaDamage.SetAreaDamageSize(new Vector3(1, 0, 1));
    }

    private void UnpackageSaveData(SaveGameData data)
    {
        GameCharacterStats GCS = GameCharacterStats._Instance;
        GameManager._Instance.levelToLoad               = data.currentGameLevelName;
        PlayerManager._Instance.Level                   = data.currentPlayerLevel;
        GCS.Xp                 = data.xp;
        GCS.MaxHp              = data.maxHp;
        GCS.HP                 = data.currentHp;
        GCS.MaxHp              = data.maxHp;
        GCS.XpBuff             = data.xpBuff;
        GCS.XpMultiplier       = data.xpMultiplier;
        GCS.BaseDamage         = data.baseDamage;
        GCS.DamageMultiplier   = data.damageMultiplier;
        GCS.AreaDamageScale    = new Vector3(data.areaDamageSize, 0, data.areaDamageSize);
        GCS.UpgradeOptions     = data.upgradeOptionAmount;
        GCS.CakeSize           = data.cakeSize;
        GCS.AttackSizeScale    = data.attackSizeScale;
    }

    private SaveGameData PackageSaveData(string sceneName)
    {
        GameCharacterStats GCS = GameCharacterStats._Instance;
        SaveGameData data = new SaveGameData();
        data.currentGameLevelName   = sceneName;
        data.currentPlayerLevel     = PlayerManager._Instance.Level;
        data.xp                     = GCS.Xp;
        data.maxHp                  = GCS.MaxHp;
        data.currentHp              = GCS.HP;
        data.maxHp                  = GCS.MaxHp;
        data.xpBuff                 = GCS.XpBuff;
        data.xpMultiplier           = GCS.XpMultiplier;
        data.baseDamage             = GCS.BaseDamage;
        data.damageMultiplier       = GCS.DamageMultiplier;
        data.areaDamageSize         = GCS.AreaDamageScale.x;
        data.upgradeOptionAmount    = GCS.UpgradeOptions;
        data.cakeSize               = GCS.CakeSize;
        data.attackSizeScale        = GCS.AttackSizeScale;

        return data;
    }

    public void LoadAreaDamage()
    {
        areaDamage.LoadOld();
    }
}

[Serializable]
class SaveGameData
{
    public string currentGameLevelName { get; set; }
    public int currentPlayerLevel { get; set; }
    public int xp { get; set; }
    public int maxXp { get; set; }
    public int currentHp { get; set; }
    public int maxHp { get; set; }
    public int xpBuff { get; set; }
    public int xpMultiplier { get; set; }
    public int baseDamage { get; set; }
    public int damageMultiplier { get; set; }
    public float areaDamageSize { get; set; }
    public int upgradeOptionAmount { get; set; }
    public float cakeSize { get; set; }
    public float attackSizeScale { get; set; }
}