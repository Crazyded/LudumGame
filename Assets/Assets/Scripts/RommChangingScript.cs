using UnityEngine;
using TMPro;

public class RoomTransition : MonoBehaviour
{
    public GameObject targetRoom; // Комната, в которую переходим

    public void OnPointerClick()
    {
        if (targetRoom != null)
        {
            RoomManager.Instance.ChangeRoom(targetRoom);
        }
    }
}