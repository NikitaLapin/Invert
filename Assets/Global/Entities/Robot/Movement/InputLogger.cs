using System.Collections.Generic;
using UnityEngine;

namespace Global.Entities.Robot.Movement
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

        #endregion

        #region PublicMethods

        public void ResetLog() => _inputHistory.Clear();
        public void AddLog(Vector2 vector2) => _inputHistory.Add(vector2);
        public Vector2 GetFirstLog()
        {
            return _inputHistory[0];
        }
        public void DeleteFirstLog() => _inputHistory.RemoveAt(0);

        #endregion
    }
}
