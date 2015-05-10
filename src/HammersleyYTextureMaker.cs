﻿using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace UE4IBLLookUpTextureGen
{
    /// <summary>
    /// Hammersley 座標のY座標値を格納したテクスチャを生成する静的クラス。
    /// </summary>
    internal static class HammersleyYTextureMaker
    {
        /// <summary>
        /// テクスチャイメージを生成する。
        /// </summary>
        /// <param name="sampleCount">
        /// Hammersley 座標の総サンプリング数。 1 以上。
        /// </param>
        /// <returns>生成されたテクスチャイメージ。</returns>
        public static BitmapSource Make(int sampleCount)
        {
            Util.ValidateRange(sampleCount, 1, int.MaxValue, "sampleCount");

            // 浮動小数ピクセル配列作成
            var pixels = new float[sampleCount];
            for (int hi = 0; hi < sampleCount; ++hi)
            {
                pixels[hi] = (float)Util.Hammersley(hi, sampleCount).Y;
            }

            // イメージ作成
            var bmp =
                new WriteableBitmap(
                    sampleCount,
                    1,
                    96,
                    96,
                    PixelFormats.Gray32Float,
                    null);
            bmp.WritePixels(
                new Int32Rect(0, 0, bmp.PixelWidth, bmp.PixelHeight),
                pixels,
                sampleCount * sizeof(float),
                0);

            return bmp;
        }
    }
}