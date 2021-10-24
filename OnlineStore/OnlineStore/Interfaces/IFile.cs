using System.Collections.Generic;

namespace OnlineStore.Interfaces
{
    public interface IFile
    {
        public void Write(IEnumerable<object> items,
            string fileName);

        public void Read(string fileName);

        public void ReadProduct(string fileName);

        public void ReadHistoryBuy(string fileName);

        public string ReadTextFromFile(string filename);

    }
}
