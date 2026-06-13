using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvL_Gen : MonoBehaviour
{
    [Header("������� ����")]
    public GameObject pipesPrefab; // ������ ���� (������������ ������)
    public List<GameObject> listOfAnotherPrefabs; // ���� �������

    [Header("������� ������������")]
    [Range(0f, 5f)] public float heightRange; // ������� ������ ����
    [Range(0.1f, 5f)] public float spawnInterval; // �������� ���������
    public int cycleCounter = 3; // ��������� ����

    private int listCounter = 0; // ���'��� ��� ����� ���������� �������

    private IEnumerator SpawnPipes()
    {
        Vector3 pos = transform.position;
        float height = 0f;
        float currentCycleNum = 0f;

        while (true)
        {
            pos.y = Random.Range(-heightRange, heightRange);

            if (currentCycleNum > cycleCounter)
            {
                Instantiate( // �������� ��'���
                listOfAnotherPrefabs[listCounter], // ������ ��'����
                pos, // ���������
                Quaternion.identity); // ���������

                currentCycleNum = 0;
                listCounter++;
                if (listCounter >= listOfAnotherPrefabs.Count)
                {
                    listCounter = 0;
                }
            }
            else
            {
                Instantiate( // �������� ��'���
               pipesPrefab, // ������ ��'����
               pos, // ���������
               Quaternion.identity); // ���������

                currentCycleNum++;
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    private void Start()
    {
        StartCoroutine(SpawnPipes()); 
    }
}
