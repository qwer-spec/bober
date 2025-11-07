using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    private void Update()
    {
        if (Player.ST)
        {
             Vector3 playerPosistion = Player.ST.transform.position;
             transform.position = new Vector3(playerPosistion.x, playerPosistion.y, transform.position.z);
        }
        
    }
}
