using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public Camera cam;               // Посилання на камеру
    public GameObject towerPrefab;   // Посиланян на вежу
    public GameObject previewPrefab; // Посилання на прев'ю(напівпрозору)
    public LayerMask groudLayer;     // Шар землі на якому розміщуємо вежі

    private GameObject preview; 
    private bool building;

    private void Update()
    {
        if (!building) return;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 1000f, groudLayer))
        {
            preview.transform.position = hit.point;

            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(towerPrefab, hit.point, Quaternion.identity);
                CancelBuild();
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            CancelBuild();
        }
    }
    public void StartBuild()
    {
        building = true;
        preview = Instantiate(previewPrefab);
        UI_Controler.Instance.ClosePanels();
    }
    public void CancelBuild()
    {
        building = false;
        if (preview != null)
        {
            Destroy(preview);
        }
    }
}
