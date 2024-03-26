using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public static DamageManager i;
    [SerializeField] DamagePopup damagePopupPrefab;

    private void Awake()
    {
        i = this;
    }

    public void showDamageText(Transform parent, float damageAmount)
    {
        DamagePopup go = Instantiate(damagePopupPrefab, parent);
        go.transform.position += Vector3.up * 0.5f;
        go.SetDamageText(damageAmount);
    }
}
