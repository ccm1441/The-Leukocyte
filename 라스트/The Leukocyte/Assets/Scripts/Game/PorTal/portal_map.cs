
using UnityEngine;

public class portal_map : MonoBehaviour
{

    public string map_name;

    void Start()
    {
        if (this.CompareTag("PortalToLeft"))
        {
            map_.left_map = map_name;
            map_.portal_position_left = this.transform.position.x;
        }
        else if (this.CompareTag("PortalToRight"))
        {
            map_.right_map = map_name;
            map_.portal_position_right = this.transform.position.x;
        }
        else if (this.CompareTag("PortalToUp"))
        {
            map_.up_map = map_name;
            map_.portal_position_up = this.transform.position.y;
        }
        else if (this.CompareTag("PortalToDown"))
        {
            map_.down_map = map_name;
            map_.portal_position_down = this.transform.position.y;
        }
        else if (this.CompareTag("PortalToHidden"))
        {
            map_.hidden_map = map_name;
            map_.portal_position_down = this.transform.position.y-3.5f;
        }

    }

}
