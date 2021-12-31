using System;

namespace FruitTest
{
    internal static class Validator
    {
        public static (bool b, double d) IsValid( string txt )
        {
            bool b = double.TryParse( txt, out double d );
            if ( d > 0.0 )
                return (b, d);
            else
                return (false, -1.0);
        }
    }
}
