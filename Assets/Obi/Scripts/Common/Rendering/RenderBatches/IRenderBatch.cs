using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Rendering;

namespace Obi
{
    public interface IRenderBatch : IComparable<IRenderBatch>
    {
        bool TryMergeWith(IRenderBatch other);
    }

    [Serializable]
    public struct RenderBatchParams
    {
        public LightProbeUsage lightProbeUsage;
        public ReflectionProbeUsage reflectionProbeUsage;
        public ShadowCastingMode shadowCastingMode;
        public bool receiveShadows;
        public MotionVectorGenerationMode motionVectors;
        public uint renderingLayerMask;

        public RenderBatchParams(bool receiveShadow)
        {
            lightProbeUsage = LightProbeUsage.BlendProbes;
            reflectionProbeUsage = ReflectionProbeUsage.BlendProbes;
            shadowCastingMode = ShadowCastingMode.On;
            receiveShadows = receiveShadow;
            motionVectors = MotionVectorGenerationMode.Camera;
            renderingLayerMask = 0xffffffff;
        }

        public RenderBatchParams(Renderer renderer)
        {
            this.lightProbeUsage = renderer.lightProbeUsage;
            this.reflectionProbeUsage = renderer.reflectionProbeUsage;
            this.shadowCastingMode = renderer.shadowCastingMode;
            this.receiveShadows = renderer.receiveShadows;
            this.motionVectors = renderer.motionVectorGenerationMode;
            this.renderingLayerMask = renderer.renderingLayerMask;
        }

        public int GetSortingID()
        {
            int id = (int)lightProbeUsage;
            id |= ((int)reflectionProbeUsage) << 4;
            id |= ((int)shadowCastingMode) << 8;
            id |= (receiveShadows ? 1 : 0) << 12;
            id |= ((int)motionVectors) << 13;
            id |= ((int)renderingLayerMask) << 17;
            return id;
        }

        public RenderParams ToRenderParams()
        {
            var renderParams = new RenderParams();

            // URP and HDRP don't work without this line.
            renderParams.renderingLayerMask = GraphicsSettings.defaultRenderingLayerMask;

            renderParams.lightProbeUsage = lightProbeUsage;
            renderParams.reflectionProbeUsage = reflectionProbeUsage;
            renderParams.shadowCastingMode = shadowCastingMode;
            renderParams.receiveShadows = receiveShadows;
            renderParams.motionVectorMode = motionVectors;
            renderParams.renderingLayerMask = renderingLayerMask;
            return renderParams;
        }
    }
}