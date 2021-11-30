using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetramin : MonoBehaviour
{
    [SerializeField] private int m_fallTime = 1;
    [SerializeField] private Vector3 m_spawnOffset;
    
    private float m_countTime = 0f;
    private bool m_accelerating = false;

    // static vars are shared across all instances
    private static int m_width = 10;
    private static int m_height = 20;

    private Bounds m_bounds;

    private static Transform[,] m_grid = new Transform[m_width, m_height];

    
    // Start is called before the first frame update
    void Start()
    {
        transform.position += m_spawnOffset;
    }

    // Update is called once per frame
    void Update()
    {
        ListenKeyboard();
        
        MoveDownControl();
    } // update


    private void ListenKeyboard()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right, Space.World);  
            if (!IsAvalidMove())
            {
                transform.Translate(Vector3.left, Space.World);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left, Space.World);
            if (!IsAvalidMove())
            {
                transform.Translate(Vector3.right, Space.World);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            
            transform.Rotate(Vector3.forward, 90);
        }
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {

            DropPiece();
        }
    } // ListenKeyboard


    private void DropPiece()
    {
        while (IsAvalidMove())
        {
            transform.Translate(Vector3.down, Space.World);
        }
        transform.Translate(Vector3.up, Space.World);
        FindObjectOfType<AudioManager>().Play("drop");
    } // DropPiece



    private void MoveDownControl()
    {
        m_accelerating = Input.GetKeyDown(KeyCode.DownArrow);
        m_countTime += Time.deltaTime ;

        if (m_countTime >= (m_accelerating ? m_fallTime / 300 : m_fallTime) )
        {
            transform.Translate(Vector3.down, Space.World);

            if (!IsAvalidMove())
            {
                transform.Translate(Vector3.up, Space.World);
                AddToGrid();
                ProcessLines();
                this.enabled = false;

                FindObjectOfType<SpawnManager>().SpawnRandomPiece();
            }
            
            
            m_countTime = 0f;
        }
    } // MoveDownControl


    private bool IsAvalidMove()
    {
        foreach (Transform child in transform)
        {
            int m_roundedX = Mathf.FloorToInt(child.transform.position.x);
            int m_roundedY = Mathf.FloorToInt(child.transform.position.y);


            if (
                m_roundedX < 0 || 
                m_roundedX >= m_width ||
                m_roundedY < 0 /*||
                m_roundedY > m_height*/
            )
            {
                return false;
            }


            if (m_grid[m_roundedX, m_roundedY] != null)
            {
                return false;
            }
        } // foreach
        return true;
    } // IsAvalidMove
    
    
    
    private void AddToGrid()
    {
        foreach (Transform child in transform)
        {
            int m_roundedX = Mathf.FloorToInt(child.position.x);
            int m_roundedY = Mathf.FloorToInt(child.position.y);

            m_grid[m_roundedX, m_roundedY] = child;

        }
    } // AddToGrid
    
    
    
    private void ProcessLines()
    {
        for (int row = m_height - 1; row >= 0; row--)
        {
            if (IsLineFull(row))
            {
                DeleteLine(row);
                MoveRowDown(row);
            }
        }
    } // ProcessLines
    
    private void MoveRowDown(int row)
    {
        for (int y = row; y < m_height; y++)
        {
            for (int x = 0; x < m_width; x++)
            {
                if (m_grid[x, y] != null)
                {
                    m_grid[x, y - 1] = m_grid[x, y];
                    m_grid[x, y] = null;
                    m_grid[x, y - 1].transform.Translate(Vector3.down, Space.World);

                }
            }
        }
        FindObjectOfType<AudioManager>().Play("line");
    } // MoveRowDown
    
    private void DeleteLine(int row)
    {
        for (int m_column = 0; m_column < m_width; m_column++)
        {
            Destroy(m_grid[m_column, row].gameObject);
            m_grid[m_column, row] = null;
        }
        
    } // DeleteLine
    
    private bool IsLineFull(int row)
    {

        for (int m_column = 0; m_column < m_width; m_column++)
        {

            if (m_grid[m_column, row] == null)
            {
                return false;
            }
        }

        return true;
    } // IsLineFull



} // Tetramin
