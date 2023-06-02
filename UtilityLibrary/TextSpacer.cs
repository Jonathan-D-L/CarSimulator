using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityLibrary
{
    public static class TextSpacer
    {
        public static string SpaceText(int spaceAmount, string subtractAmount)
        {
            var spacing = new List<string>();
            for (int i = 0; i < spaceAmount; i++)
            {
                spacing.Add(" ");
            }
            for (int i = 0; i < subtractAmount.Length; i++)
            {
                spacing = spacing.Take(spacing.Count() - 1).ToList();
            }

            var space = "";
            foreach (var s in spacing)
            {
                space += s;
            }

            return space;
        }
    }
}
