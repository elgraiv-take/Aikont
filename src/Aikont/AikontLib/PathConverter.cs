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

        private float ConvertY(float y, bool relative = false)
        {
            return -y * Scale + (relative ? 0.0f : YOffset);
        }
        private float ConvertX(float x)
        {
            return x * Scale;
        }

        private Point ConvertXY(Point p, bool relative = false)
        {
            return new Point() { X = p.X * Scale, Y = -p.Y * Scale + (relative ? 0.0f : YOffset) };
        }
        private struct Point
        {
            public float X { get; set; }
            public float Y { get; set; }

            public static Point operator -(Point a, Point b)
            {
                return new Point { X = a.X - b.X, Y = a.Y - b.Y };
            }
            public static Point operator +(Point a, Point b)
            {
                return new Point { X = a.X + b.X, Y = a.Y + b.Y };
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
                    case 'H':
                        ConvertHorizontalLineTo(o);
                        break;
                    case 'V':
                        ConvertVerticalLineTo(o);
                        break;

                    case 'm':
                        ConvertRelativeMoveTo(o);
                        break;
                    case 'l':
                        ConvertRelativeLineTo(o);
                        break;
                    case 'c':
                        ConvertRelativeCurveTo(o);
                        break;
                    case 'h':
                        ConvertRelativeHorizontalLineTo(o);
                        break;
                    case 'v':
                        ConvertRelativeVerticalLineTo(o);
                        break;

                    default:
                        throw new NotSupportedException(o);
                }
            }
            _cffCommands.Add("endchar");

            var result = string.Empty;
            foreach (var o in _cffCommands)
            {
                result += o + "\n";
            }
            return result;
        }

        private void ConvertVerticalLineTo(string operation)
        {
            var op = operation.Substring(1);
            var yCoords = ToFloats(op).ToArray();
            var command = string.Empty;
            foreach (var y in yCoords)
            {
                var pointY = ConvertY(y);
                var delta = pointY - _currentPoint.Y;
                command += $"{delta} ";
                _currentPoint.Y = pointY;
            }
            command += "vlineto";
            _cffCommands.Add(command);
        }
        private void ConvertRelativeVerticalLineTo(string operation)
        {
            var op = operation.Substring(1);
            var yCoords = ToFloats(op).ToArray();
            var command = string.Empty;
            foreach (var y in yCoords)
            {
                var delta = ConvertY(y, true);
                command += $"{delta} ";
                _currentPoint.Y += delta;
            }
            command += "vlineto";
            _cffCommands.Add(command);
        }

        private void ConvertHorizontalLineTo(string operation)
        {
            var op = operation.Substring(1);
            var xCoords = ToFloats(op).ToArray();
            var command = string.Empty;
            foreach (var x in xCoords)
            {
                var pointX = ConvertX(x);
                var delta = pointX - _currentPoint.X;
                command += $"{delta} ";
                _currentPoint.X = pointX;
            }
            command += "hlineto";
            _cffCommands.Add(command);
        }
        private void ConvertRelativeHorizontalLineTo(string operation)
        {
            var op = operation.Substring(1);
            var xCoords = ToFloats(op).ToArray();
            var command = string.Empty;
            foreach (var x in xCoords)
            {
                var delta = ConvertX(x);
                command += $"{delta} ";
                _currentPoint.X += delta;
            }
            command += "hlineto";
            _cffCommands.Add(command);
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
            foreach (var p in points)
            {
                var point = ConvertXY(p);
                var delta = point - _currentPoint;
                command += $"{delta.X} {delta.Y} ";
                _currentPoint = point;
            }
            command += "rlineto";
            _cffCommands.Add(command);
        }
        private void ConvertRelativeLineTo(string operation)
        {
            var op = operation.Substring(1);
            var points = ToPoints(op);
            var command = string.Empty;
            var tempCurrent = new Point();
            foreach (var p in points)
            {
                var point = ConvertXY(p, true);
                var delta = point - tempCurrent;
                command += $"{delta.X} {delta.Y} ";
                tempCurrent = point;
            }
            _currentPoint += tempCurrent;
            command += "rlineto";
            _cffCommands.Add(command);
        }

        private void ConvertMoveTo(string operation)
        {
            var op = operation.Substring(1);
            var points = ToPoints(op);
            var firstPoint = points.First();
            firstPoint = ConvertXY(firstPoint);
            var delta = firstPoint - _currentPoint;
            var command = $"{delta.X} {delta.Y} rmoveto";
            _cffCommands.Add(command);

            _currentPoint = firstPoint;
            _startPoint = firstPoint;
        }
        private void ConvertRelativeMoveTo(string operation)
        {
            if (!_cffCommands.Any())
            {
                ConvertMoveTo(operation);
                return;
            }
            var op = operation.Substring(1);
            var points = ToPoints(op);
            var firstPoint = points.First();
            var delta = ConvertXY(firstPoint, true);
            var command = $"{delta.X} {delta.Y} rmoveto";
            _cffCommands.Add(command);

            _currentPoint = firstPoint + delta;
            _startPoint = _currentPoint;
        }
        private void ConvertCurveTo(string operation)
        {
            var op = operation.Substring(1);
            var points = ToPoints(op);
            var command = string.Empty;
            foreach (var p in points)
            {
                var point = ConvertXY(p);
                var delta = point - _currentPoint;
                command += $"{delta.X} {delta.Y} ";
                _currentPoint = point;
            }
            command += "rrcurveto";
            _cffCommands.Add(command);
        }
        private void ConvertRelativeCurveTo(string operation)
        {
            var op = operation.Substring(1);
            var points = ToPoints(op).ToArray();
            var command = string.Empty;
            for (int curveIndex = 0, i = 0; curveIndex < points.Length / 3; curveIndex++)
            {
                var tempCurrent = new Point();
                for (var p = 0; p < 3; p++, i++)
                {
                    var point = ConvertXY(points[i], true);
                    var delta = point - tempCurrent;
                    command += $"{delta.X} {delta.Y} ";
                    tempCurrent = point;
                }
                _currentPoint += tempCurrent;
            }

            command += "rrcurveto";
            _cffCommands.Add(command);
        }

        private List<Point> ToPoints(string op)
        {
            var floats = ToFloats(op).ToArray();
            var points = new List<Point>();
            for (var i = 0; i < floats.Length - 1; i += 2)
            {
                points.Add(new Point() { X = floats[i], Y = floats[i + 1] });
            }
            return points;
        }

        private IEnumerable<float> ToFloats(string op)
        {
            return op.Split(',', '\t', ' ').Where(s => !string.IsNullOrWhiteSpace(s)).Select(s => float.Parse(s));
        }

    }
}
