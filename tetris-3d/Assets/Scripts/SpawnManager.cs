using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private GameObject[] m_allTetramins;
    [SerializeField] private GameObject[] m_allStaticTetramins;

    private int m_nextPieceIndex;
    private GameObject m_nextPiece;
    private GameObject m_nextPiecePreview;
    
    private Vector3 m_previewPosition; 
    
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
        if (m_nextPiecePreview != null)
        {
            Destroy(m_nextPiecePreview.gameObject);
            m_nextPiecePreview = null;
        }

        m_nextPieceIndex = Random.Range(0, m_allTetramins.Length);
        m_nextPiece = m_allTetramins[m_nextPieceIndex];
        m_nextPiecePreview = m_allStaticTetramins[m_nextPieceIndex];
        PreviewNextPiece();
    } // GetNextPiece

    public void SpawnPiece()
    {
        Instantiate(m_nextPiece, transform.position, transform.rotation);
        GetNextPiece();
    } //  SpawnPiece
    
    

    private void PreviewNextPiece()
    {
        /*if (m_nextPieceIndex == 0 || m_nextPieceIndex == 3)
        {
            m_previewPosition.x = 9.5f;
            m_previewPosition.y = 22.5f;
        }
        else
        {
            m_previewPosition.x = 9.5f;
            m_previewPosition.y = 22.25f;
        }*/

        m_previewPosition =
            (m_nextPieceIndex == 0 || m_nextPieceIndex == 3)
                ? new Vector3(9.5f, 22.5f, 0.2f)
                : new Vector3(9.5f, 22.25f, 0.2f);

        m_nextPiecePreview = Instantiate(m_allStaticTetramins[m_nextPieceIndex], m_previewPosition, transform.rotation);
    } // m_nextPiece



}
