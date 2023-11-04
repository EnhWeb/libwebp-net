# libwebp wrapper for .NET   适用于 .NET 的 libwebp 包装器
>  支持 .net framework，.net 标准版，.net core 的 windows 平台，linux 平台需下载 so 的库

分支“master”的生成状态：![build status](http://img.shields.io/appveyor/ci/imazen/libwebp-net.svg)
构建状态 Last nuget release：Nuget 发布版本  ![Nuget release version](http://img.shields.io/nuget/v/Imazen.WebP.svg)

Build status for branch 'master': ![build status](http://img.shields.io/appveyor/ci/imazen/libwebp-net.svg)
Last nuget release: ![Nuget release version](http://img.shields.io/nuget/v/Imazen.WebP.svg)

此库在 Nuget 上以 Imazen.WebP 的形式提供 [Imazen.WebP](http://nuget.org/packages/Imazen.WebP)。

This library is available on Nuget as [Imazen.WebP](http://nuget.org/packages/Imazen.WebP).

该库为 webp/decode.h 和 webp/encode.h 提供 P/Invoke 公开，但不提供 demux.h 和 mux.h。

This library offers P/Invoke exposure for webp/decode.h and webp/encode.h, but not demux.h and mux.h.

## Key APIs （关键 API）

> * `new Imazen.WebP.SimpleDecoder().DecodeFromBytes(byte[] data, long length)` -> `System.Drawing.Bitmap`
> * `new Imazen.WebP.SimpleEncoder().Encode(Bitmap from, Stream to, float quality)`\
> * `Imazen.WebP.SimpleEncoder.GetEncoderVersion() -> String`, `Imazen.WebP.SimpleDecoder.GetDecoderVersion() -> String`

## Improvements we're very interested in （我们非常感兴趣的改进）
* 公开 Imazen.WebP.Extern.WebPConfig 和 Imazen.WebP.Extern.WebPPreset 的强大功能，以便更好地编码。
* Expose the power of Imazen.WebP.Extern.WebPConfig and Imazen.WebP.Extern.WebPPreset for better encoding. 
* 请考虑使用 WebPDecode 来更好地解码错误详细信息。
* Consider using WebPDecode for better decode error details. 
* 动画支持
* Animation support
* 使 LoadLibrary 跨平台（尽管这不是绝对必要的）
* Make LoadLibrary cross-platform (although it is not strictly neccessary)
* 添加 .NET Core 支持。这可能需要引入一个 PixelBuffer{width， height， ptr， stride} 接口，该接口可以通过适配器包装 System.Drawing.Bitmap。System.Drawing.Bitmap 目前由 and 类直接使用，但这些类总共< 200 行代码。或者，将核心 API 保留为仅 P/Invoke。libwebp 根本没有糟糕的 API。SimpleDecoderSimpleEncoder
* Add .NET Core support. This will likely require introducing a PixelBuffer{width, height, ptr, stride} interface that can wrap System.Drawing.Bitmap via adapter. System.Drawing.Bitmap is currently directly used by the `SimpleDecoder` and `SimpleEncoder` classes, but these total < 200 lines of code. Or, leave the core API as P/Invoke only. libwebp doesn't have a bad API at all. 

## Windows builds of libwebp 0.5.2 can be found here:（libwebp 0.5.2 的 Windows 版本可以在这里找到：）

https://s3.amazonaws.com/resizer-dynamic-downloads/webp/0.5.2/x86_64/libwebp.dll
https://s3.amazonaws.com/resizer-dynamic-downloads/webp/0.5.2/x86/libwebp.dll

https://s3.amazonaws.com/resizer-dynamic-downloads/webp/0.6.0/x86_64/libwebp.dll
https://s3.amazonaws.com/resizer-dynamic-downloads/webp/0.6.0/x86/libwebp.dll

可能需要 vcruntime14 （VS 2015 C++ Redistributable） 

You may need vcruntime14 (VS 2015 C++ Redistributable)

https://www.microsoft.com/zh-cn/download/details.aspx?id=48145
https://www.microsoft.com/en-us/download/details.aspx?id=48145

该库与 libwebp 的原样 NMake 版本二进制兼容（无自定义 C/C++）。

This library is binary compatible with as-is NMake builds of libwebp (no custom C/C++).

## License（许可证）

该软件在 MIT 许可下发布：

This software is released under the MIT license:

版权所有 （c） 2012 Imazen

Copyright (c) 2012 Imazen

特此免费授予获得本软件和相关文档文件（以下简称“软件”）副本的任何人不受限制地处理本软件的许可，包括但不限于使用、复制、修改、合并、发布、分发、再许可和/或出售本软件副本的权利，并允许获得本软件的人员这样做， 须符合以下条件：

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

上述版权声明和本许可声明应包含在本软件的所有副本或大部分内容中。

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

本软件按“原样”提供，不作任何明示或暗示的保证，包括但不限于适销性、特定用途适用性和不侵权的保证。在任何情况下，作者或版权所有者均不对因本软件或本软件的使用或其他交易而引起或与之相关的任何索赔、损害或其他责任负责，无论是在合同诉讼、侵权行为还是其他诉讼中。

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.