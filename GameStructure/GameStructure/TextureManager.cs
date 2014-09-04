using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.DevIl;
using Tao.OpenGl;

namespace GameStructure
{
    public struct Texture
    {
        public int Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Texture(int id, int width, int height)
            : this()
        {
            Id = id;
            Width = width;
            Height = height;
        }
    }

    class TextureManager : IDisposable
    {
        Dictionary<string, Texture> _textureDatabase = new Dictionary<string, Texture>();

        public Texture Get(string textureId)
        {
            return _textureDatabase[textureId];
        }
        #region IDisposable Members

        public void Dispose()
        {
            foreach (Texture t in _textureDatabase.Values)
            {
                Gl.glDeleteTextures(1, new int[] { t.Id });
            }
        }
        #endregion

        public void LoadTexture(string textureId, string path)
        {
            int devilId = 0;
            Il.ilGenImages(1, out devilId);
            Il.ilBindImage(devilId); //Set as the active texture.

            if (!Il.ilLoadImage(path)) {
                System.Diagnostics.Debug.Assert(false, "Could not open file,[" + path + "].");
            }
            //The files we'll be using need to be flipped before passing to OpenGL
            Ilu.iluFlipImage();
            int width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
            int height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);
            int openGLId = Ilut.ilutGLBindTexImage();

            System.Diagnostics.Debug.Assert(openGLId != 0);
            Il.ilDeleteImages(1,ref devilId);

            _textureDatabase.Add(textureId,new Texture(openGLId,width,height));
        }
    }
}
