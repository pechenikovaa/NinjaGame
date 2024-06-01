using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject platformPrefab;
    public int maxPlatforms = 10;
    public Transform deadZone; // ������ �� ������ DeadZone

    private List<GameObject> platforms = new List<GameObject>();

    void Start()
    {
        GeneratePlatforms();

        // ���������� ��������� ��������� DeadZone ������������ ���������
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            float deadZoneYOffset = -15.0f; // ���������� ���������� ��� ����������
            deadZone.position = new Vector2(player.transform.position.x, player.transform.position.y + deadZoneYOffset);
        }
    }

    void GeneratePlatforms()
    {
        Vector3 spawnPosition = new Vector3();

        for (int i = 0; i < maxPlatforms; i++)
        {
            spawnPosition.x = Random.Range(-1.7f, 1.7f);
            spawnPosition.y += Random.Range(1f, 3f); // ��������� �������� ������

            GameObject newPlatform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            platforms.Add(newPlatform);
        }
    }

    void Update()
    {
        // ��������� ������� ������ � deadZone
        GameObject player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Player not found!");
            return;
        }
        if (deadZone == null)
        {
            Debug.LogError("DeadZone not found!");
            return;
        }

        // ���������� DeadZone ������ � ����������
        Transform playerTransform = player.transform;
        float deadZoneYOffset = -10.0f; // ���������� ���������� ��� ����������
        deadZone.position = new Vector2(deadZone.position.x, playerTransform.position.y + deadZoneYOffset);

        // �������� ������� DeadZone � ��������
        Debug.Log("DeadZone position: " + deadZone.position.y);
        for (int i = 0; i < platforms.Count; i++)
        {
            Debug.Log("Platform position: " + platforms[i].transform.position.y);

            if (platforms[i].transform.position.y < deadZone.position.y)
            {
                Debug.Log("Deleting platform at position: " + platforms[i].transform.position.y);
                Destroy(platforms[i]);
                platforms.RemoveAt(i);
                i--; // ��������� ������, ����� �� ���������� ��������� ��������� ����� ��������
            }
        }

        // ���������� ����� ���������, ���� �� �������
        while (platforms.Count < maxPlatforms)
        {
            Vector3 spawnPosition = new Vector3();
            spawnPosition.x = Random.Range(-1.7f, 1.7f);
            spawnPosition.y = platforms.Count > 0 ? platforms[platforms.Count - 1].transform.position.y + Random.Range(1f, 3f) : 0;

            GameObject newPlatform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            platforms.Add(newPlatform);
        }
    }
}
