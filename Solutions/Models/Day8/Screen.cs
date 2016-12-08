using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions.Models.Day8
{
    public class Screen
    {
        private const int Width = 50;

        private const int Height = 6;
        
        private Dictionary<int, Dictionary<int, bool>> Grid = new Dictionary<int, Dictionary<int, bool>>();

        public Screen()
        {
            for(var h = 0; h < Height; h++)
            {
                for(var w = 0; w < Width; w++)
                {
                    if(!Grid.ContainsKey(h))
                    {
                        Grid.Add(h, new Dictionary<int, bool>{ { w, false } });
                    }
                    else
                    {
                        Grid[h].Add(w, false);
                    }
                    
                }                
            }
        }

        public void ParseInput(string input)
        {
            var splitInput = input.Split(' ');

            switch(splitInput[0])
            {
                case "rect":
                {
                    ActivateRect(string.Join("", splitInput.Skip(1)));
                } break;
                case "rotate":
                {
                    RotateRow(string.Join("", splitInput.Skip(1)));
                } break;
                default :
                {
                    throw new InvalidOperationException();
                }
            }
            
            DrawScreen();
        }

        public void ActivateRect(string input)
        {
            var splitInput = input.Split('x');
            
            var width = int.Parse(splitInput[0].ToString());

            var height = int.Parse(splitInput[1].ToString());

            for(var h = 0; h < height; h++)
            {
                for(var w = 0; w < width; w++)
                {
                    Grid[h][w] = true;
                }
            }            
        }

        public void RotateRow(string input)
        {
            
        }

        private void DrawScreen()
        {
            var consolePos = Console.CursorTop;

            for(var height = 0; height < Height; height++)
            {
                for(var width = 0; width < Width; width++)
                {
                    Console.SetCursorPosition(width, consolePos + height);
                    Console.Write(".");
                }
            }
        }
    }   
}