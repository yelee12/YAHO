// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: mediapipe/calculators/util/packet_frequency_calculator.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Mediapipe {

  /// <summary>Holder for reflection information generated from mediapipe/calculators/util/packet_frequency_calculator.proto</summary>
  public static partial class PacketFrequencyCalculatorReflection {

    #region Descriptor
    /// <summary>File descriptor for mediapipe/calculators/util/packet_frequency_calculator.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static PacketFrequencyCalculatorReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CjxtZWRpYXBpcGUvY2FsY3VsYXRvcnMvdXRpbC9wYWNrZXRfZnJlcXVlbmN5",
            "X2NhbGN1bGF0b3IucHJvdG8SCW1lZGlhcGlwZRokbWVkaWFwaXBlL2ZyYW1l",
            "d29yay9jYWxjdWxhdG9yLnByb3RvIqgBCiBQYWNrZXRGcmVxdWVuY3lDYWxj",
            "dWxhdG9yT3B0aW9ucxIaCg90aW1lX3dpbmRvd19zZWMYASABKAE6ATMSDQoF",
            "bGFiZWwYAiADKAkyWQoDZXh0EhwubWVkaWFwaXBlLkNhbGN1bGF0b3JPcHRp",
            "b25zGLbDqlAgASgLMisubWVkaWFwaXBlLlBhY2tldEZyZXF1ZW5jeUNhbGN1",
            "bGF0b3JPcHRpb25z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Mediapipe.CalculatorReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Mediapipe.PacketFrequencyCalculatorOptions), global::Mediapipe.PacketFrequencyCalculatorOptions.Parser, new[]{ "TimeWindowSec", "Label" }, null, null, new pb::Extension[] { global::Mediapipe.PacketFrequencyCalculatorOptions.Extensions.Ext }, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// Options for PacketFrequencyCalculator.
  /// </summary>
  public sealed partial class PacketFrequencyCalculatorOptions : pb::IMessage<PacketFrequencyCalculatorOptions>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<PacketFrequencyCalculatorOptions> _parser = new pb::MessageParser<PacketFrequencyCalculatorOptions>(() => new PacketFrequencyCalculatorOptions());
    private pb::UnknownFieldSet _unknownFields;
    private int _hasBits0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<PacketFrequencyCalculatorOptions> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Mediapipe.PacketFrequencyCalculatorReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public PacketFrequencyCalculatorOptions() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public PacketFrequencyCalculatorOptions(PacketFrequencyCalculatorOptions other) : this() {
      _hasBits0 = other._hasBits0;
      timeWindowSec_ = other.timeWindowSec_;
      label_ = other.label_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public PacketFrequencyCalculatorOptions Clone() {
      return new PacketFrequencyCalculatorOptions(this);
    }

    /// <summary>Field number for the "time_window_sec" field.</summary>
    public const int TimeWindowSecFieldNumber = 1;
    private readonly static double TimeWindowSecDefaultValue = 3D;

    private double timeWindowSec_;
    /// <summary>
    /// Time window (in seconds) over which the packet frequency is computed. Must
    /// be greater than 0 and less than 100 seconds (in order to limit memory
    /// usage).
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public double TimeWindowSec {
      get { if ((_hasBits0 & 1) != 0) { return timeWindowSec_; } else { return TimeWindowSecDefaultValue; } }
      set {
        _hasBits0 |= 1;
        timeWindowSec_ = value;
      }
    }
    /// <summary>Gets whether the "time_window_sec" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasTimeWindowSec {
      get { return (_hasBits0 & 1) != 0; }
    }
    /// <summary>Clears the value of the "time_window_sec" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearTimeWindowSec() {
      _hasBits0 &= ~1;
    }

    /// <summary>Field number for the "label" field.</summary>
    public const int LabelFieldNumber = 2;
    private static readonly pb::FieldCodec<string> _repeated_label_codec
        = pb::FieldCodec.ForString(18);
    private readonly pbc::RepeatedField<string> label_ = new pbc::RepeatedField<string>();
    /// <summary>
    /// Text identifiers for the input streams.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<string> Label {
      get { return label_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as PacketFrequencyCalculatorOptions);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(PacketFrequencyCalculatorOptions other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(TimeWindowSec, other.TimeWindowSec)) return false;
      if(!label_.Equals(other.label_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (HasTimeWindowSec) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(TimeWindowSec);
      hash ^= label_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (HasTimeWindowSec) {
        output.WriteRawTag(9);
        output.WriteDouble(TimeWindowSec);
      }
      label_.WriteTo(output, _repeated_label_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (HasTimeWindowSec) {
        output.WriteRawTag(9);
        output.WriteDouble(TimeWindowSec);
      }
      label_.WriteTo(ref output, _repeated_label_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (HasTimeWindowSec) {
        size += 1 + 8;
      }
      size += label_.CalculateSize(_repeated_label_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(PacketFrequencyCalculatorOptions other) {
      if (other == null) {
        return;
      }
      if (other.HasTimeWindowSec) {
        TimeWindowSec = other.TimeWindowSec;
      }
      label_.Add(other.label_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 9: {
            TimeWindowSec = input.ReadDouble();
            break;
          }
          case 18: {
            label_.AddEntriesFrom(input, _repeated_label_codec);
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 9: {
            TimeWindowSec = input.ReadDouble();
            break;
          }
          case 18: {
            label_.AddEntriesFrom(ref input, _repeated_label_codec);
            break;
          }
        }
      }
    }
    #endif

    #region Extensions
    /// <summary>Container for extensions for other messages declared in the PacketFrequencyCalculatorOptions message type.</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static partial class Extensions {
      public static readonly pb::Extension<global::Mediapipe.CalculatorOptions, global::Mediapipe.PacketFrequencyCalculatorOptions> Ext =
        new pb::Extension<global::Mediapipe.CalculatorOptions, global::Mediapipe.PacketFrequencyCalculatorOptions>(168468918, pb::FieldCodec.ForMessage(1347751346, global::Mediapipe.PacketFrequencyCalculatorOptions.Parser));
    }
    #endregion

  }

  #endregion

}

#endregion Designer generated code
