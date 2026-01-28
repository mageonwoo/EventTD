using UnityEngine;
/// <summary>
/// 1. TowerShooter에서 적을 감지해 가장 가까운 적의 위치를 파악하면 날아간다.
/// </summary>
public class Bomb : MonoBehaviour
{
    [SerializeField] float bombLife = 2.0f;
    [SerializeField] TowerShooter towerShooter;
    [SerializeField] Transform targetPos;

    float t;
    public float speed = 3f;

    void Start()
    {
        towerShooter = FindFirstObjectByType<TowerShooter>();
    }

    void OnEnable()
    {
        t = 0f;
    }

    void Update()
    {
        targetPos = towerShooter.enemyPos;

        if (targetPos == null)
            gameObject.SetActive(false);
        else

            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, targetPos.transform.position, speed * Time.deltaTime);

        t += Time.deltaTime;
        if (t >= bombLife)
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Enemy")) return;

        gameObject.SetActive(false);
    }


}