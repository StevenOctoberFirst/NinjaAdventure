using System;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] LayerMask enemyMask;

    Camera mainCamera;

    public static event Action<EnemyBrain> OnEnemySelected;
    public static event Action OnNoSelection;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        SelectEnemy();
    }

    private void SelectEnemy()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            RaycastHit2D hit = Physics2D.Raycast(mainCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, enemyMask);

            if (hit.collider != null)
            {
                EnemyBrain enemy = hit.collider.GetComponent<EnemyBrain>();

                if (enemy != null)
                {
                    OnEnemySelected?.Invoke(enemy);
                }
            }
            else
                OnNoSelection?.Invoke();
        }
    }
}
