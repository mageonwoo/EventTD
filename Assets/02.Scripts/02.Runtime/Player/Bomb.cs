using UnityEngine;
/// <summary>
/// 1. TowerShooter에서 적을 감지해 가장 가까운 적의 위치를 파악하면 날아간다.
/// </summary>
public class Bomb : MonoBehaviour
{
    [SerializeField] float bombLife = 2.0f;
    // [SerializeField] TowerShooter towerShooter;
    [SerializeField] Transform targetPos;

    float t;
    public float speed = 3f;

    // void Start()
    // {
    //     towerShooter = FindFirstObjectByType<TowerShooter>();
    // }

    void OnEnable()
    {
        t = 0f;
    }
    /// <summary>
    /// GameObject.activeInHierarchy: 오브젝트가 씬에서 활성화 되어있는지를 나타내는 boolean
    /// </summary>
    void Update()
    {
        t += Time.deltaTime;

        // targetPos = towerShooter.enemyPos;
        if (t <= 0f) return;

        if (targetPos == null || !targetPos.gameObject.activeInHierarchy)
            gameObject.SetActive(false);
        else
            this.gameObject.transform.position
            = Vector3.MoveTowards(this.gameObject.transform.position, targetPos.transform.position, speed * Time.deltaTime);

        if (t >= bombLife)
        {
            gameObject.SetActive(false);
        }
    }

    public void SetTarget(Transform target)
    {
        targetPos = target;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Enemy")) return;

        Debug.Log($"{other.name}과 충돌, 폭탄 삭제");

        gameObject.SetActive(false);
    }


}