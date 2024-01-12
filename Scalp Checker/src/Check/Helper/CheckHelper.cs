﻿using Microsoft.Scripting.Hosting;
using Microsoft.Win32;
using Python.Runtime;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace Scalp_Checker.src.Check.Helper
{
    class CheckHelper
    {
        private int exitCode = 0;
        private bool gpuCompatibility = false;
        public void createProperties(string types, string img_dir, string id, string modelType)
        {
            string options = "";
            options += id + ";";
            options += types + ";";
            options += img_dir + ";";
            options += modelType + ";";

            string path_Options = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ScalpChecker\TEMP\Properties.txt";
            using (StreamWriter sw = File.CreateText(path_Options))
            {
                sw.WriteLine(options);
            }
        }

        public Task CheckGPUCompatibility()
        {
            Process process = new Process();

            process.StartInfo = new ProcessStartInfo(@"C:\Program Files\ScalpChecker\GPUCompatibility\main.exe");
            process.StartInfo.CreateNoWindow= true;
            process.StartInfo.UseShellExecute= false;
            process.StartInfo.RedirectStandardOutput= true;
            process.Start();

            var tcs = new TaskCompletionSource<object>();
            process.EnableRaisingEvents = true;
            process.Exited += new EventHandler(capabilityProcess_Exited);
            process.Exited += (sender, args) => tcs.TrySetResult(null);

            return process.HasExited ? Task.CompletedTask : tcs.Task;
        }

        public bool getGPUCompatibility()
        {
            return gpuCompatibility;
        }

        public Task Check()
        {
            Process process = new Process();

            process.StartInfo = new ProcessStartInfo(@"C:\Program Files\ScalpChecker\include\main.exe");
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();

            if (process.HasExited)
            {
                exitCode = process.ExitCode;
                return Task.CompletedTask;
            }

            var tcs = new TaskCompletionSource<object>();
            process.EnableRaisingEvents= true;
            process.Exited += new EventHandler(process_Exited);
            process.Exited += (sender, args) => tcs.TrySetResult(null);

            return process.HasExited ? Task.CompletedTask : tcs.Task;
        }

        private void process_Exited(object sender, EventArgs e)
        {
            Process p = (Process)sender;
            exitCode = p.ExitCode;
        }

        private void capabilityProcess_Exited(object sender, EventArgs e)
        {
            string line = "";

            Process process = (Process)sender;

            while (!process.StandardOutput.EndOfStream)
            {
                line += process.StandardOutput.ReadLine();
                Console.WriteLine(line);
            }

            if (line.Contains("InCompatible"))
            {
                this.gpuCompatibility = false;
            }
            else
            {
                this.gpuCompatibility = true;
            }

        }

        public int getExitCode()
        {
            Console.WriteLine(exitCode);
            return exitCode;
        }

        public void createModelsRoot(string modelType)
        {
            string MODEL_DIR_BIDUM = @"C:\Program Files\ScalpChecker\Models\BIDUM.h5";
            string MODEL_DIR_FIJI = @"C:\Program Files\ScalpChecker\Models\FIJI.h5";
            string MODEL_DIR_HONGBAN = @"C:\Program Files\ScalpChecker\Models\HONGBAN.h5";
            string MODEL_DIR_MISE = @"C:\Program Files\ScalpChecker\Models\MISE.h5";
            string MODEL_DIR_NONGPO = @"C:\Program Files\ScalpChecker\Models\NONGPO.h5";
            string MODEL_DIR_TALMO = @"C:\Program Files\ScalpChecker\Models\TALMO.h5";

            string MODEL_DIR_BIDUM_ViT = @"C:\Program Files\ScalpChecker\Models\BIDUM_ViT.h5";
            string MODEL_DIR_FIJI_ViT = @"C:\Program Files\ScalpChecker\Models\FIJI_ViT.h5";
            string MODEL_DIR_HONGBAN_ViT = @"C:\Program Files\ScalpChecker\Models\HONGBAN_ViT.h5";
            string MODEL_DIR_MISE_ViT = @"C:\Program Files\ScalpChecker\Models\MISE_ViT.h5";
            string MODEL_DIR_NONGPO_ViT = @"C:\Program Files\ScalpChecker\Models\NONGPO_ViT.h5";
            string MODEL_DIR_TALMO_ViT = @"C:\Program Files\ScalpChecker\Models\TALMO_ViT.h5";

            string rootDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ScalpChecker";
            string TEMPDir = rootDir + @"\TEMP";
            string ModelsDir = TEMPDir + @"\Models";

            if (!Directory.Exists(rootDir))
            {
                Directory.CreateDirectory(rootDir);
            }

            if (!Directory.Exists(TEMPDir))
            {
                Directory.CreateDirectory(TEMPDir);
            }

            if (!Directory.Exists(ModelsDir))
            {
                Directory.CreateDirectory(ModelsDir);
            }

            string path_BIDUM = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ScalpChecker\TEMP\Models\ModelDir_BIDUM.txt";

            if(modelType == "ViT")
            {
                using (StreamWriter sw = File.CreateText(path_BIDUM))
                {
                    sw.WriteLine(MODEL_DIR_BIDUM_ViT);
                }

                string path_FIJI = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ScalpChecker\TEMP\Models\ModelDir_FIJI.txt";
                using (StreamWriter sw = File.CreateText(path_FIJI))
                {
                    sw.WriteLine(MODEL_DIR_FIJI_ViT);
                }

                string path_HONGBAN = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ScalpChecker\TEMP\Models\ModelDir_HONGBAN.txt";
                using (StreamWriter sw = File.CreateText(path_HONGBAN))
                {
                    sw.WriteLine(MODEL_DIR_HONGBAN_ViT);
                }

                string path_MISE = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ScalpChecker\TEMP\Models\ModelDir_MISE.txt";
                using (StreamWriter sw = File.CreateText(path_MISE))
                {
                    sw.WriteLine(MODEL_DIR_MISE_ViT);
                }

                string path_NONGPO = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ScalpChecker\TEMP\Models\ModelDir_NONGPO.txt";
                using (StreamWriter sw = File.CreateText(path_NONGPO))
                {
                    sw.WriteLine(MODEL_DIR_NONGPO_ViT);
                }

                string path_TALMO = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ScalpChecker\TEMP\Models\ModelDir_TALMO.txt";
                using (StreamWriter sw = File.CreateText(path_TALMO))
                {
                    sw.WriteLine(MODEL_DIR_TALMO_ViT);
                }
            } else if(modelType == "Keras")
            {
                using (StreamWriter sw = File.CreateText(path_BIDUM))
                {
                    sw.WriteLine(MODEL_DIR_BIDUM);
                }

                string path_FIJI = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ScalpChecker\TEMP\Models\ModelDir_FIJI.txt";
                using (StreamWriter sw = File.CreateText(path_FIJI))
                {
                    sw.WriteLine(MODEL_DIR_FIJI);
                }

                string path_HONGBAN = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ScalpChecker\TEMP\Models\ModelDir_HONGBAN.txt";
                using (StreamWriter sw = File.CreateText(path_HONGBAN))
                {
                    sw.WriteLine(MODEL_DIR_HONGBAN);
                }

                string path_MISE = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ScalpChecker\TEMP\Models\ModelDir_MISE.txt";
                using (StreamWriter sw = File.CreateText(path_MISE))
                {
                    sw.WriteLine(MODEL_DIR_MISE);
                }

                string path_NONGPO = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ScalpChecker\TEMP\Models\ModelDir_NONGPO.txt";
                using (StreamWriter sw = File.CreateText(path_NONGPO))
                {
                    sw.WriteLine(MODEL_DIR_NONGPO);
                }

                string path_TALMO = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ScalpChecker\TEMP\Models\ModelDir_TALMO.txt";
                using (StreamWriter sw = File.CreateText(path_TALMO))
                {
                    sw.WriteLine(MODEL_DIR_TALMO);
                }
            }


        }


    }
}