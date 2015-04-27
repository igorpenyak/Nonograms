using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nonograms.GameEngine
{
    public class MarginCell
    {
        #region Variables

        private int _color;
        private int _number;

        #endregion


        #region Properties

        public int Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }

        #endregion

        #region Constructors

        public MarginCell(int number, int color)
        {
            Color = color;
            Number = number;
        }

        #endregion

        
    }
}
