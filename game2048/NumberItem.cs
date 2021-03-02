using System;
using System.Collections.Generic;
using System.Text;

namespace game2048
{
    class NumberItem
    {
        private int value = 2;
        private int colorId;
        private int bgColorId;

        public int Value
        {
            get {
                return value;
            }
        }

        public void incincreaseLevel() {
            value *= 2;
        }
    }
}
