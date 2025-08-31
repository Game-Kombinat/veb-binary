using System;
using System.Globalization;
using System.Text;

namespace DataKombinat.Binary.Tags {
    /// <summary> A tag containing a single bool. </summary>
    public class NbtBool : NbtTag {
        /// <summary> Type of this tag (Bool). </summary>
        public override NbtTagType TagType => NbtTagType.Bool;

        /// <summary> Value/payload of this tag (a single bool). </summary>
        public bool Value { get; set; }

        /// <summary>
        /// Bit of a hack.
        /// When it comes to read/write, bool not always supported
        /// </summary>
        public byte InternalByteValue {
            get => (byte)(Value ? 1 : 0); 
            set => Value = value == 1;
        }


        /// <summary> Creates an unnamed NbtByte tag with the default value of 0. </summary>
        public NbtBool() { }


        /// <summary> Creates an unnamed NbtByte tag with the given value. </summary>
        /// <param name="value"> Value to assign to this tag. </param>
        public NbtBool(bool value)
            : this(null, value) { }


        /// <summary> Creates an NbtByte tag with the given name and the default value of 0. </summary>
        /// <param name="tagName"> Name to assign to this tag. May be <c>null</c>. </param>
        public NbtBool(string tagName)
            : this(tagName, false) { }


        /// <summary> Creates an NbtByte tag with the given name and value. </summary>
        /// <param name="tagName"> Name to assign to this tag. May be <c>null</c>. </param>
        /// <param name="value"> Value to assign to this tag. </param>
        public NbtBool(string tagName, bool value) {
            name = tagName;
            Value = value;
        }


        /// <summary> Creates a copy of given NbtByte tag. </summary>
        /// <param name="other"> Tag to copy. May not be <c>null</c>. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="other"/> is <c>null</c>. </exception>
        public NbtBool(NbtBool other) {
            if (other == null) throw new ArgumentNullException(nameof(other));
            name = other.name;
            Value = other.Value;
        }


        public override bool ReadTag(NbtBinaryReader readStream) {
            if (readStream.Selector != null && !readStream.Selector(this)) {
                readStream.ReadByte();
                return false;
            }
            Value = readStream.ReadBoolean();
            return true;
        }


        public override void SkipTag(NbtBinaryReader readStream) {
            readStream.ReadBoolean();
        }


        public override void WriteTag(NbtBinaryWriter writeStream) {
            writeStream.Write(NbtTagType.Bool);
            if (Name == null) throw new NbtFormatException("Name is null");
            writeStream.Write(Name);
            writeStream.Write(Value);
        }


        public override void WriteData(NbtBinaryWriter writeStream) {
            writeStream.Write(Value);
        }


        /// <inheritdoc />
        public override object Clone() {
            return new NbtBool(this);
        }


        internal override void PrettyPrint(StringBuilder sb, string indentString, int indentLevel) {
            for (int i = 0; i < indentLevel; i++) {
                sb.Append(indentString);
            }
            sb.Append("TAG_Bool");
            if (!String.IsNullOrEmpty(Name)) {
                sb.AppendFormat(CultureInfo.InvariantCulture, "(\"{0}\")", Name);
            }
            sb.Append(": ");
            sb.Append(Value);
        }
    }
}
