using UnityEngine;

public class SideWalls : MonoBehaviour
{
    void OnTriggerEnter(Collider info)
    {
        if (info.name == "Ball")
        {
            string wallName = transform.name;
            GameMaster.Score(wallName);
            info.gameObject.SendMessage("GameReset", null, SendMessageOptions.RequireReceiver);
        }
    }
}