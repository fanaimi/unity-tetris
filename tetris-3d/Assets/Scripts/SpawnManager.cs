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
        m_firstPiece = SelectRandomPiece();
        SpawnPiece();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject SelectRandomPiece()
    {
        int m_randomIndex = Random.Range(0, m_allTetramins.Length);
        GameObject m_random = m_allTetramins[m_randomIndex];
        return m_random;
    } // SelectRandomPiece


    public void SpawnRandomPiece()
    {
        /*int m_randomIndex = Random.Range(0, m_allTetramins.Length);
        GameObject m_tetramin = m_allTetramins[m_randomIndex];*/
        
        // Transform c = m_tetramin.transform.GetChild(0);
        if (m_nextPiece != null)
        {
            Destroy(m_nextPiece);
            m_nextPiece = null;
        }

        m_nextPiece = SelectRandomPiece();
        PreviewNextPiece();

        Instantiate(m_tetramin, transform.position, transform.rotation);
    } // SpawnRandomPiece

    private void PreviewNextPiece()
    {
        
        Instantiate(m_nextPiece, m_nextPiecePosition, transform.rotation);
        m_nextPiece.isStatic = true;
    } // m_nextPiece



}
