namespace Movies.API.Utils
{
    public class MathUtils
    {
        public static bool IsSquare(int number)
        {
            var _number = number;

            while (_number > 2)
            {
                _number = _number / 2;
            }

            return _number == 2;
        }
    }
}
