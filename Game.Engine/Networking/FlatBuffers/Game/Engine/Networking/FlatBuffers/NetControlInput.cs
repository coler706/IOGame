// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace Game.Engine.Networking.FlatBuffers
{

using global::System;
using global::Google.FlatBuffers;

public struct NetControlInput : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static NetControlInput GetRootAsNetControlInput(ByteBuffer _bb) { return GetRootAsNetControlInput(_bb, new NetControlInput()); }
  public static NetControlInput GetRootAsNetControlInput(ByteBuffer _bb, NetControlInput obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public NetControlInput __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public float Angle { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetFloat(o + __p.bb_pos) : (float)0.0f; } }
  public bool Boost { get { int o = __p.__offset(6); return o != 0 ? 0!=__p.bb.Get(o + __p.bb_pos) : (bool)false; } }
  public bool Shoot { get { int o = __p.__offset(8); return o != 0 ? 0!=__p.bb.Get(o + __p.bb_pos) : (bool)false; } }

  public static Offset<NetControlInput> CreateNetControlInput(FlatBufferBuilder builder,
      float angle = 0.0f,
      bool boost = false,
      bool shoot = false) {
    builder.StartObject(3);
    NetControlInput.AddAngle(builder, angle);
    NetControlInput.AddShoot(builder, shoot);
    NetControlInput.AddBoost(builder, boost);
    return NetControlInput.EndNetControlInput(builder);
  }

  public static void StartNetControlInput(FlatBufferBuilder builder) { builder.StartObject(3); }
  public static void AddAngle(FlatBufferBuilder builder, float angle) { builder.AddFloat(0, angle, 0.0f); }
  public static void AddBoost(FlatBufferBuilder builder, bool boost) { builder.AddBool(1, boost, false); }
  public static void AddShoot(FlatBufferBuilder builder, bool shoot) { builder.AddBool(2, shoot, false); }
  public static Offset<NetControlInput> EndNetControlInput(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<NetControlInput>(o);
  }
};


}
