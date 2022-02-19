using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChessGameController : MonoBehaviour
{
    public GameObject Board;
    public GameObject WhitePieces;
    public GameObject BlackPieces;
    public GameObject SelectedPiece;
    public bool WhiteTurn = true;

    public Text DebugList;

    // Use this for initialization
    void Start()
    {
        DebugList.text += ("  >> GAME STARTED <<  ");
        DebugList.text += ($"\n\\");
    }

    private int seconds;

    public IEnumerator TimeCounter()
    {
        yield return new WaitForSeconds(1);
        seconds += 1;

        if(seconds == 60)
        {
            DebugList.text += ("|-(one minute passed)-|");
        }
        else if (seconds == 120)
        {
            DebugList.text += ("|-(two minutes passed)-|");
        }
        else if (seconds == 180)
        {
            DebugList.text += ("|-(three minutes passed)-|");
        }
        else if (seconds == 240)
        {
            DebugList.text += ("|-(four minutes passed)-|");
        }
        else if (seconds == 300)
        {
            DebugList.text += ("|-(five minutes passed)-|");
        }
        else if (seconds == 360)
        {
            DebugList.text += ("|-(six minutes passed)-|");
        }
        else if (seconds == 420)
        {
            DebugList.text += ("|-(seven minutes passed)-|");
        }
        else if (seconds == 480)
        {
            DebugList.text += ("|-(eight minutes passed)-|");
        }
        else if (seconds == 540)
        {
            DebugList.text += ("|-(nine minutes passed)-|");
        }
        else if (seconds == 600)
        {
            DebugList.text += ("|-(ten minutes passed)-|");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectPiece(GameObject piece)
    {
        if (piece.tag == "White" && WhiteTurn == true || piece.tag == "Black" && WhiteTurn == false)
        {
            DeselectPiece();
            SelectedPiece = piece;

            // Highlight
            SelectedPiece.GetComponent<SpriteRenderer>().color = Color.yellow;

            // Put above other pieces
            Vector3 newPosition = SelectedPiece.transform.position;
            newPosition.z = -1;
            SelectedPiece.transform.SetPositionAndRotation(newPosition, SelectedPiece.transform.rotation);
        }
    }

    public void DeselectPiece()
    {
        if (SelectedPiece != null)
        {
            // Remove highlight
            SelectedPiece.GetComponent<SpriteRenderer>().color = Color.white;

            // Put back on the same level as other pieces
            Vector3 newPosition = SelectedPiece.transform.position;
            newPosition.z = 0;
            SelectedPiece.transform.SetPositionAndRotation(newPosition, SelectedPiece.transform.rotation);

            SelectedPiece = null;
        }
    }

    public void EndTurn()
    {
        bool kingIsInCheck = false;
        bool hasValidMoves = false;

        WhiteTurn = !WhiteTurn;

        if (WhiteTurn)
        {
            foreach (Transform piece in WhitePieces.transform)
            {
                if (hasValidMoves == false && HasValidMoves(piece.gameObject))
                {
                    hasValidMoves = true;
                }

                if (piece.name.Contains("Pawn"))
                {
                    piece.GetComponent<PieceController>().DoubleStep = false;
                }
                else if (piece.name.Contains("King"))
                {
                    kingIsInCheck = piece.GetComponent<PieceController>().IsInCheck(piece.position);
                }
            }
        }
        else
        {
            foreach (Transform piece in BlackPieces.transform)
            {
                if (hasValidMoves == false && HasValidMoves(piece.gameObject))
                {
                    hasValidMoves = true;
                }

                if (piece.name.Contains("Pawn"))
                {
                    piece.GetComponent<PieceController>().DoubleStep = false;
                }
                else if (piece.name.Contains("King"))
                {
                    kingIsInCheck = piece.GetComponent<PieceController>().IsInCheck(piece.position);
                }
            }
        }

        if (hasValidMoves == false)
        {
            if (kingIsInCheck == false)
            {
                Stalemate();
            }
            else
            {
                Checkmate();
            }
        }
    }

    bool HasValidMoves(GameObject piece)
    {
        PieceController pieceController = piece.GetComponent<PieceController>();
        GameObject encounteredEnemy;

        foreach (Transform square in Board.transform)
        {
            if (pieceController.ValidateMovement(piece.transform.position, new Vector3(square.position.x, square.position.y, piece.transform.position.z), out encounteredEnemy))
            {
                DebugList.text += (", " + piece.name + "->" + square);
                Debug.Log(piece + " on " + square);
                return true;
            }
        }
        return false;
    }

    public void CloseGame()
    {
        SceneManager.LoadScene("LB95");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Stalemate()
    {
        Debug.Log("Stalemate!");
        DebugList.text += ("  >> STALEMATE <<  ");
    }

    void Checkmate()
    {
        Debug.Log("Checkmate!");
        DebugList.text += ("  >> CHECKMATE <<  ");
    }
}
