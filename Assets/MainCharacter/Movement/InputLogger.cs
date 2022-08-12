using System.Collections.Generic;
using UnityEngine;

namespace MainCharacter.Movement
{
    public class InputLogger : MonoBehaviour
    {
        #region Initialization

        private List<Vector2> _inputHistory;

        #endregion

        #region SubStateMethods

        private void Awake()
        {
            _inputHistory = new List<Vector2>();
        }

        private void Update()
        {
            Debug.Log(_inputHistory);
        }

        #endregion

        #region PublicMethods

        public void ResetLog() => _inputHistory.Clear();
        public void AddLog(Vector2 vector2) => _inputHistory.Add(vector2);

        #endregion
    }
}
