using UnityEngine;

public class TowerStats : MonoBehaviour
{
    [Header("타워 공격력")]
    public float damageMult = 1f;
    [Header("타워 공격속도")]
    public float shootCooldownMult = 1f;
    [Header("투사체 개수")]
    public int projectileCnt = 1;
    [Header("도탄")]
    public int bounceCnt = 0;
    [Header("보스 공격력")]
    public float bossMult = 1f;

    public void ApplyUpgrade(UpgradeData data)
    {
        switch (data.StatType)
        {
            case StatType.Damage_Mult:
                damageMult *= data.Value;
                break;
            case StatType.ShootCooldown_Mult:
                shootCooldownMult *= data.Value;
                break;
            case StatType.Projectile_Count:
                projectileCnt += (int)data.Value;
                break;
            case StatType.Bounce_Count:
                bounceCnt += (int)data.Value;
                break;
            case StatType.Boss_Mult:
                bossMult *= data.Value;
                break;
        }
    }

    public void ResetUpgrade()
    {
        damageMult = 1f;
        shootCooldownMult = 1f;
        projectileCnt = 1;
        bounceCnt = 0;
        bossMult = 1f;
    }
}