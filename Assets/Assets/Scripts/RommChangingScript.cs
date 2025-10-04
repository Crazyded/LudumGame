using UnityEngine;
using TMPro;

public class RoomTransition : MonoBehaviour
{
    public GameObject targetRoom; // �������, � ������� ���������

    public void OnPointerClick()
    {
        if (targetRoom != null)
        {
            RoomManager.Instance.ChangeRoom(targetRoom);
        }
    }
}