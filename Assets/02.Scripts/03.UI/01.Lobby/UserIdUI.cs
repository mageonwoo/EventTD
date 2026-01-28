using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/// <summary>
/// 1. 로비에서 인풋필드에 이름을 직접 입력한다.
/// 2. 이름을 입력하지 않으면 Default로 Guest라는 이름을 저장한다.
/// 3. 글자수 한정은 v0.1.0에서 생각하지 않는다.
/// </summary>
public class UserIdUI : MonoBehaviour
{
    [SerializeField] TMP_InputField userID;

    public void OnClickConfirmID()
    {
        string id = "";
        if(userID != null)
            id = userID.text;

        if(string.IsNullOrWhiteSpace(id))
            id = "Guest";

        GameManager.Instance.ConfirmID(id);
    }
}
