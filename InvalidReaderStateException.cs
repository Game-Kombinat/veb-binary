using System;

namespace DataKombinat.Binary {
    /// <summary> Exception thrown when an operation is attempted on an NbtReader that
    /// cannot recover from a previous parsing error. </summary>
    [Serializable]
    public class InvalidReaderStateException : InvalidOperationException {
        internal InvalidReaderStateException(string message)
            : base(message) { }
    }
}
