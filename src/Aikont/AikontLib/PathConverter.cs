using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Elgraiv.Aikont
{
    public class PathConverter
    {
        private static readonly Regex s_regex = new Regex(@"([MmZzLlHhVvCcSs][^MmZzLlHhVvCcSs]*)");

        private struct Point
        {
            public float X { get; set; }
            public float Y { get; set; }

            public static Point operator-(Point a,Point b)
            {
                return new Point { X = a.X - b.X, Y = a.Y - b.Y };
            }
            public Point ConvertSpace(float scale, float yOffset)
            {
                return new Point() { X = X * scale, Y = -Y * scale + yOffset };
            }

        }

        private Point _currentPoint;
        private Point _startPoint;
        private List<string> _cffCommands;
        public float YOffset { get; set; }
        public float Scale { get; set; }

        private void Reset()
        {
            _currentPoint = new Point()
            {
                X = 0.0f,
                Y = 0.0f
            };
            
            _cffCommands = new List<string>();
        }

        public string Convert(string path)
        {
            Reset();

            var match = s_regex.Match(path);
            var operations = new List<string>();
            for (var m = match; m.Success; m = m.NextMatch())
            {
                operations.Add(m.Value);
            }
            
            foreach (var o in operations)
            {
                if (string.IsNullOrWhiteSpace(o))
                {
                    continue;
                }
                switch (o[0])
                {
                    case 'Z':
                    case 'z':
                        break;
                    case 'M':
                        ConvertMoveTo(o);
                        break;
                    case 'L':
                        ConvertLineTo(o);
                        break;
                    case 'C':
                        ConvertCurveTo(o);
                        break;
                    default:
                        throw new NotSupportedException(o);
                }
            }
            _cffCommands.Add("endchar");

            var result = string.Empty;
            foreach(var o in _cffCommands)
            {
                result += o + "\n";
            }
            return result;
        }

        private void ConvertPathClose()
        {
            var delta = _startPoint - _currentPoint;
            var command = $"{delta.X} {delta.Y} rlineto";
        }

        private void ConvertLineTo(string operation)
        {
            var op = operation.Substring(1);
            var points = ToPoints(op);
            var command = string.Empty;
            foreach(var p in points)
            {
                var delta = p - _currentPoint;
                command += $"{delta.X} {delta.Y} ";
                _currentPoint = p;
            }
            command += "rlineto";
            _cffCommands.Add(command);
        }

        private void ConvertMoveTo(string operation)
        {
            var op = operation.Substring(1);
            var points = ToPoints(op);
            var firstPoint = points.First();
            var delta = firstPoint - _currentPoint;
            var command = $"{delta.X} {delta.Y} rmoveto";
            _cffCommands.Add(command);

            _currentPoint = firstPoint;
            _startPoint = firstPoint;
        }
        private void ConvertCurveTo(string operation)
        {
            var op = operation.Substring(1);
            var points = ToPoints(op);
            var command = string.Empty;
            foreach (var p in points)
            {
                var delta = p - _currentPoint;
                command += $"{delta.X} {delta.Y} ";
                _currentPoint = p;
            }
            command += "rrcurveto";
            _cffCommands.Add(command);
        }

        private List<Point> ToPoints(string op)
        {
            var floats = ToFloats(op).ToArray();
            var points = new List<Point>();
            for(var i = 0; i < floats.Length-1; i += 2)
            {
                points.Add((new Point() { X = floats[i], Y = floats[i + 1] }).ConvertSpace(Scale, YOffset));
            }
            return points;
        }

        private IEnumerable<float> ToFloats(string op)
        {
            return op.Split(',', '\t', ' ').Where(s => !string.IsNullOrWhiteSpace(s)).Select(s => float.Parse(s));
        }
        
    }
}
