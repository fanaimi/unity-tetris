using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private GameObject[] m_allTetramins;

    private GameObject m_firstPiece;
    private GameObject m_nextPiece;
    
    private Vector3 m_nextPiecePosition = new Vector3(10, 25, 0);
    
    // Start is called before the first frame update
    void Start()
    {
        GetNextPiece();
        SpawnPiece();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GetNextPiece()
    {
        if (m_nextPiece != null)
        {
            Destroy(m_nextPiece);
            m_nextPiece = null;
        }

        int m_randomIndex = Random.Range(0, m_allTetramins.Length);
        m_nextPiece= m_allTetramins[m_randomIndex];
        PreviewNextPiece();
    } // GetNextPiece

    public void SpawnPiece()
    {
        Instantiate(m_nextPiece, transform.position, transform.rotation);
    } //  SpawnPiece
    
    

    private void PreviewNextPiece()
    {
        
        Instantiate(m_nextPiece, m_nextPiecePosition, transform.rotation);
        m_nextPiece.isStatic = true;
    } // m_nextPiece



}
