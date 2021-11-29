using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetramin : MonoBehaviour
{


    [SerializeField] private int m_fallTime = 1;
    private float m_countTime = 0f;
    private bool m_accelerating = false;

    // static vars are shared across all instances
    private static int m_width = 10;
    private static int m_height = 20;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ListenKeyboard();
        
        MovePieceDown();
    } // update


    private void ListenKeyboard()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right, Space.World);    
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left, Space.World);
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            
            transform.Rotate(Vector3.forward, 90);
        }

        m_accelerating = Input.GetKeyDown(KeyCode.DownArrow);

    } // ListenKeyboard

    private void MovePieceDown()
    {
        m_countTime += Time.deltaTime ;

        if (m_countTime >= (m_accelerating ? m_fallTime / 30 : m_fallTime) )
        {
            transform.Translate(Vector3.down, Space.World);
            m_countTime = 0f;
        }
    } // MovePieceDown


    private bool IsAvalidMove()
    {
        foreach (Transform child in transform)
        {
            int m_roundedX = Mathf.FloorToInt(child.transform.position.x);
            int m_roundedY = Mathf.FloorToInt(child.transform.position.y);


            if (
                m_roundedX < 0 || 
                m_roundedX >= m_width ||
                m_roundedY < 0 ||
                m_roundedY > m_height
            )
            {
                return false;
            }
            else
            {
                return true;
            }
        } // foreach
    } // IsAvalidMove


} // Tetramin
