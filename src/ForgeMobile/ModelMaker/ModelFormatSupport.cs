namespace ForgeMobile.ModelMaker;
public enum ModelFormatStatus{Implemented,Partial,ConversionRequired,NotImplemented}
public sealed record ModelFormat(string Extension,string Name,ModelFormatStatus Status,string Notes);
public static class ModelFormatSupport
{
 public static readonly IReadOnlyList<ModelFormat> Formats=new[]{
  new ModelFormat(".obj","Wavefront OBJ",ModelFormatStatus.Implemented,"Geometry import and OBJ export; UV/material import not included."),
  new ModelFormat(".stl","STL",ModelFormatStatus.Partial,"ASCII STL export; STL import and binary STL pending."),
  new ModelFormat(".gltf",".gltf",ModelFormatStatus.ConversionRequired,"Dedicated glTF parser pending; convert to OBJ for now."),
  new ModelFormat(".glb","Binary glTF",ModelFormatStatus.ConversionRequired,"Convert to OBJ; full binary glTF import pending."),
  new ModelFormat(".fbx","Autodesk FBX",ModelFormatStatus.NotImplemented,"Requires FBX SDK or a tested third-party parser."),
  new ModelFormat(".ply","Stanford PLY",ModelFormatStatus.NotImplemented,"Parser pending."),
  new ModelFormat(".dae","COLLADA",ModelFormatStatus.NotImplemented,"Parser pending."),
  new ModelFormat(".blend","Blender Project",ModelFormatStatus.ConversionRequired,"Open in Blender and export OBJ/glTF; .blend is not a plain interchange mesh."),
  new ModelFormat(".3ds","3D Studio",ModelFormatStatus.NotImplemented,"Parser pending."),
  new ModelFormat(".usd/.usdz","Universal Scene Description",ModelFormatStatus.NotImplemented,"Parser pending."),
  new ModelFormat(".step/.stp","CAD STEP",ModelFormatStatus.NotImplemented,"CAD tessellation pipeline pending.")
 };
}