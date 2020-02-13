using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace układ_słoneczny
{
    class NetGenerator
    {
        VertexPositionColor[] lineVertices;
        Vector2 startPosition;
        Vector2 endPosition;

        public NetGenerator(Vector2 startPosition, Vector2 endPosition)
        {
            this.startPosition = startPosition;
            this.endPosition = endPosition;
            lineVertices = GenerateLines();
        }

        public VertexPositionColor[] GetVertices()
        {
            return lineVertices;
        }

        public int GetVerticesLength()
        {
            return lineVertices.Length;
        }


        private VertexPositionColor[] GenerateLines()
        {
            List<VertexPositionColor> lines = new List<VertexPositionColor>();
            int count = (int)(endPosition.X - startPosition.X) / 40;
            for (int i = 0; i <= 40; i++)
            {
                lines.Add(new VertexPositionColor(new Vector3(startPosition.X, startPosition.Y + count * i, -4), Color.White));
                lines.Add(new VertexPositionColor(new Vector3(endPosition.X, startPosition.Y + count * i, -4), Color.White));
                lines.Add(new VertexPositionColor(new Vector3(startPosition.X + count * i, startPosition.Y, -4), Color.White));
                lines.Add(new VertexPositionColor(new Vector3(startPosition.X + count * i, endPosition.Y, -4), Color.White));
            }
            return lines.ToArray();
        }
    }
}
