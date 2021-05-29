using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMouseHover : MonoBehaviour
{
    public static Pet CheckPetHover()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector2 mousePosition = new Vector2(mousePos.x, mousePos.y);

        RaycastHit[] hits = Physics.RaycastAll(GetMouseRay(mousePosition));
        foreach (RaycastHit hit in hits)
        {
            Pet target = hit.transform.GetComponent<Pet>();
            if (target == null) continue;

            //if (!GetComponent<Fighter>().IsTargetAlive(target.gameObject)) continue;

            return target;
        }
        return null;
    }

    private static Ray GetMouseRay(Vector2 mousePosition)
    {
        return Camera.main.ScreenPointToRay(mousePosition);
    }
}
