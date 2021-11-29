using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private GameObject[] m_allTetramins;
    
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnRandomPiece();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SpawnRandomPiece()
    {
        int m_randomIndex = Random.Range(0, m_allTetramins.Length);
        GameObject m_tetramin = m_allTetramins[m_randomIndex];

        Transform c = m_tetramin.transform.GetChild(0);


        Instantiate(m_tetramin, transform.position, transform.rotation);
    } // SpawnRandomPiece



}
