public enum StatType
{
    Damage_Mult,
    ShootCooldown_Mult,
    Projectile_Count,
    Bounce_Count,
    Boss_Mult
}

[System.Serializable]
public class UpgradeData
{
    public int ID;
    public string Name;
    public string Tier;
    public StatType StatType;
    public float Value;
    public string Description;
}