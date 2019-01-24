
namespace UnityEngine.Experimental.Rendering.HDPipeline
{
    [GenerateHLSL(needAccessors = false, omitStructDeclaration = true)]
    public unsafe struct ShaderVariablesSubsurfaceScattering
    {
        // Use float4 to avoid any packing issue between compute and pixel shaders
        [HLSLArray(16, typeof(Vector4))]
        public fixed float _ThicknessRemaps[16 * 4];   // R: start, G = end - start, BA unused
        [HLSLArray(16, typeof(Vector4))]
        public fixed float _ShapeParams[16 * 4];        // RGB = S = 1 / D, A = filter radius
        [HLSLArray(16, typeof(Vector4))]
        public fixed float _TransmissionTintsAndFresnel0[16 * 4];  // RGB = 1/4 * color, A = fresnel0
        [HLSLArray(16, typeof(Vector4))]
        public fixed float _WorldScales[16 * 4];        // X = meters per world unit; Y = world units per meter
        [HLSLArray(16, typeof(float))]
        public fixed float _DiffusionProfileHashTable[16]; // TODO: constant

        // Warning: Unity is not able to losslessly transfer integers larger than 2^24 to the shader system.
        // Therefore, we bitcast uint to float in C#, and bitcast back to uint in the shader.
        public uint   _EnableSubsurfaceScattering; // Globally toggles subsurface and transmission scattering on/off
        public float  _TexturingModeFlags;         // 1 bit/profile; 0 = PreAndPostScatter, 1 = PostScatter
        public float  _TransmissionFlags;          // 1 bit/profile; 0 = regular, 1 = thin
        public uint   _DiffusionProfileCount;
    }
}
