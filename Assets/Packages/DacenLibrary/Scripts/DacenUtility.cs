using UnityEngine;

namespace Dacen.Utility
{
    public static class DacenUtility
    {
        /// <summary>
        /// Converts an integer to a string with a zero before the number, if it's less than 10.
        /// </summary>
        /// <param name="number">The number to convert</param>
        /// <returns></returns>
        public static string ConvertToTwoDigits(int number)
        {
            return number < 10 ? "0" + number : number.ToString();
        }

        /// <summary>
        /// Converts an integer to a string that displays this number in a digital format (mm:ss).
        /// </summary>
        /// <param name="time">The number to convert</param>
        /// <returns></returns>
        public static string ConvertToMinutesAndSeconds(int time)
        {
            return ConvertToTwoDigits(Mathf.FloorToInt(time / 60)) + ":" + ConvertToTwoDigits(time % 60);
        }
    }
}
