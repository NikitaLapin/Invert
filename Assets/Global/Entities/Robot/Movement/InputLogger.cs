using System.Collections.Generic;
using UnityEngine;

namespace Global.Entities.Robot.Movement
{
    public class InputLogger : MonoBehaviour
    {
        #region Initialization

        private List<AddLogger> _inputHistory;

        #endregion

        #region SubStateMethods

        private void Awake() => _inputHistory = new List<AddLogger>();
        
        #endregion

        #region PublicMethods

        public void ResetLog() => _inputHistory.Clear();

        public void AddLog(Vector2 vector2)
        {
            AddLogger log = new AddLogger();
            log.Input = vector2;
            
            _inputHistory.Add(log);
        }

        public bool GetFirstLog(out Vector2 vector2, out float time)
        {
            vector2 = Vector2.zero;
            time = 0f;

            if (_inputHistory.Count != 0)
            {
                vector2 = _inputHistory[0].Input;
                time = _inputHistory[0].Timer;
            }
            return vector2 != Vector2.zero;
        }
        
        public void DeleteFirstLog() => _inputHistory.RemoveAt(0);

        #endregion

        #region Structs

        private struct AddLogger
        {
            public float Timer { get; set; }
            public Vector2 Input { get; set; }
        }

        #endregion
    }
}
