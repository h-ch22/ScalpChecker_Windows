<img src="/README/ScalpChecker_mockup.png"/><br>
Scalp Checker
=============
> Check your Scalp Health with Scalp Checker

[Ha, Changjin, Taesik Go, and Woorak Choi. "Intelligent Healthcare Platform for Diagnosis of Scalp and Hair Disorders." Applied Sciences 14.5 (2024): 1734.](https://www.mdpi.com/2076-3417/14/5/1734)<br>

* How to Use
  + Download&Build Project
  + Download Project : [Scalp Checker Python Project](https://github.com/h-ch22/ScalpChecker_PYTHON)
  + Download Project : [Scalp Checker GPU Compatibility](https://github.com/h-ch22/ScalpChecker_GPUCompatibility)
  + Build Python Project as exe (<span style="color:gray">*For me, I've been used PyInstaller*)
  + Move exe, dll and another build files into
    + Python Project : C:\Program Files\ScalpChecker\include
    + GPU Compatibility : C:\Program Files\ScalpChecker\GPUCompatibility
    + h5 Models : C:\Program Files\ScalpChecker\Models

* Features
> <img src="/README/Screenshot_Dashboard.png"/>
> Dashboard : Statistics of your inspection results.
> <img src="/README/Screenshot_Inspection.png"/>
> Inspection : Inspect your Scalp using our EfficientNet or ViT Model, and you can select your inspection parts
> <img src="/README/Screenshot_Inspection_Result.png"/>
> Inspection : Check your Result with Grad-CAM (EfficientNet) or Attention HeatMap(ViT)
> <img src="/README/Screenshot_History_Date.png"/>
> History : Review your Inspection Result, Control with date.
> <img src="/README/Screenshot_History.png"/>
> History

* Build&Test Environment
  > Microsoft Windows 11 Pro<br/>
  > Intel Core i7-12700K<br/>
  > 32GB RAM<br/>
  > Python 3.9.13<br/>
  > Microsoft Visual Studio 2022<br/>
  > PyCharm 2022.3.1<br/>
  > Tensorflow 2.10.1<br/>

* System Requirements
  > CPU : Intel Core i5-7500 or up<br/>
  > RAM : 4GB or up<br/>
  > OS : Microsoft Windows 8.1 (x64) or up<br/>
  > Disk Space : 6GB or up<br/>
  > GPU : N/A (NVIDIA GPU Recommend.)<br/>
  > Others : .NET Framework 4.8 Required.<br/>
  > if GPU Available, Please install CUDA + cuDNN + NVIDIA Geforce Driver for your GPU<br/>