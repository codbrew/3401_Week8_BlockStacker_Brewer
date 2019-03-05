using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDropper : MonoBehaviour
{
    public GameObject blockPrefab;
    //position from the floor value
    public CameraBehaviour cameraBehaviour;
    public float blockFloatHeight = 2;
    //value of floor base height
    float _spawnYpos = 1;
    Transform _currentBlock;
    Transform _previousBlock;
    float _currentBlockWidth = 4.3f;
  
    void Start()
    {
        SpawnNewBlock();
    }

  
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DropCurrentBlock();
        }
    }

    void SpawnNewBlock()
    {
        //check to see if currentBlock is null
        if(_currentBlock != null)
            _previousBlock = _currentBlock;

        _currentBlock = Instantiate(blockPrefab).transform;

        //set block position floor plus float height
        _currentBlock.position = new Vector3(0, _spawnYpos + blockFloatHeight, 0);
        //set the scale of current block
        _currentBlock.localScale = new Vector3(_currentBlockWidth, _currentBlock.localScale.y, _currentBlock.localScale.z);

    }
    //function that spawns new piece and gives position
    void DropCurrentBlock()
    {
        //destroys the script BlockBehavior 

        Destroy(_currentBlock.GetComponent<BlockBehavior>());
        _currentBlock.position = new Vector3( _currentBlock.position.x, _spawnYpos, 0);
        _spawnYpos += 1;
        cameraBehaviour.OnBlockDrop();

        //chop the new block before spawn
        //check to see if we have a previous block
        if (_previousBlock != null)
        {
            ChopDroppedBlock();
        }

        //spawn the new block
        SpawnNewBlock();

    }

    void ChopDroppedBlock()
    {
        //get difference between x of two blocks
        float blockOffset = _currentBlock.position.x - _previousBlock.position.x;
        //take the absolute value of blockOffset
        float amountToChop = Mathf.Abs(blockOffset);
        _currentBlockWidth = _currentBlockWidth - amountToChop;
        if (_currentBlockWidth <= 0)
        {
            Debug.Log("You Lose");
        }
        else
        {
            _currentBlock.localScale = new Vector3(_currentBlock.localScale.x - amountToChop, _currentBlock.localScale.y, _currentBlock.localScale.z);
        }
    }

}
