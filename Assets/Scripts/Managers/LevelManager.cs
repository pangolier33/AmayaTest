using Core;
using Data;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private LevelData[] _levelData;
        [SerializeField] private GridLayoutGroup _grid;
        [SerializeField] private AddNewCard _addNewCard;
        [SerializeField] private RestartGame _restartGame;

        private int _levelId;
    
        private void Awake()
        {
            EventManager.OnLevelChanged?.AddListener(() =>
            {
                StartLevel();
            });
        
            EventManager.OnLevelChanged?.Invoke();
        }

        private void StartLevel()
        {
            if (_levelId == _levelData.Length)
            {
                _restartGame.Restart();
            }
            else
            {
                SetLevel(_levelData[_levelId]);
            }
        }
    
        public void SetLevel(LevelData levelData)
        {
            _levelId++;
            ChangeGrid(levelData);
            _addNewCard.StartSpawn(levelData);
        }
    
        private void ChangeGrid(LevelData levelData)
        {
            _grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            _grid.constraintCount = levelData.LevelColumns;
        
            _grid.constraint = GridLayoutGroup.Constraint.FixedRowCount;
            _grid.constraintCount = levelData.LevelRows;
        }
    }
}
