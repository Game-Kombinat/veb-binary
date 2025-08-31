namespace DataKombinat.Binary {
    // Represents state of a node in the NBT file tree, used by NbtReader
    public class NbtReaderNode {
        public string? ParentName;
        public NbtTagType ParentTagType;
        public NbtTagType ListType;
        public int ParentTagLength;
        public int ListIndex;
    }
}
