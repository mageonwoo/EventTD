[Title] Project Rule
(26.01.22 기록)
- 한 번의 프로그램 실행 시 플레이 제한 수는 3번으로 제한한다.
    - 게임스타트 UI를 Input하면 코스트가 한 번 줄어들게 되며,\
    이는 플레이동안 계속 UI를 통해 브리핑 된다.
---
- 하나의 플레이 플로우 내에서 웨이브는 총 3개로 제한한다.
    - 하나의 웨이브는 30초의 시간을 가진다.
    - 처음 15초 동안 초당 1개체의 적을 스폰한다.
    - 30초가 지나면 다음 단계의 웨이브로 넘어간다.
---
- Enemy의 기준상태는 **EnemyTypeSO.cs**에서 SO로 관리한다.
    - EnemyTypeSO.cs는 maxHP와 Prefab만 가지고 있다.
    - Enemy의 이동속도는 Wave단계와 상관없이 모두 같다.
    - 실질적인 난이도는 EnemyTypeSO의 maxHP로만 조절한다.
        * Wave3에 출현하는 Enemy만 maxHP를 2로 상승시킨다.\
        나머지 Wave의 Enemy는 maxHP가 1이다.
---
- **Enemy 전체를 컨트롤하는 컴포넌트는 EnemyContext.cs이다.**
    - Enemy의 상태는 HP와 이동속도만 존재한다.
    - EnemyContext는 EnemyHP와 EnemyMove, EnemyState를 관리한다.
    - SpawnPoint는 EnemyContext에서 관리하는 것이 아니다.

데이터 보관 > 전달 > 실행