using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace DesignLibrary
{
    internal class SplitConfigs
    {


    static void Main()
    {
        int error = 0;
        int war = 0;

        ModelDoc2 swModel;

        Console.WriteLine("Введите путь к папке:");
        string pathtofile = Console.ReadLine();
        string[] pathtofiles;
        pathtofiles = Directory.GetFiles(pathtofile);

        SldWorks swApp = (SldWorks)Marshal.GetActiveObject("SldWorks.Application");

        swApp.DocumentVisible(false, (int)swDocumentTypes_e.swDocPART);

        for (int q = 0; q < pathtofiles.Length; q++)
        {
            Console.WriteLine(pathtofiles[q]);
            if (pathtofiles[q].ToUpper().Contains(".SLDPRT"))
            {
                swModel = swApp.OpenDoc6(pathtofiles[q], (int)swDocumentTypes_e.swDocPART, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", ref error, ref war);
            }
            else
            {
                continue;
            }
            if (error != 0)
            {
                Console.WriteLine(error.ToString());
            }

            string pathModel = Path.GetDirectoryName(swModel.GetPathName()) + @"\";

            IModelDocExtension extension = swModel.Extension;
            string[] configurations = swModel.GetConfigurationNames();
            List<string> paths = new List<string>();
            int ConfigCount = configurations.Length;
            Console.WriteLine("всего конфигураций: " + ConfigCount);
            int x = 1;

            for (int i = 0; i < configurations.Length; i++)
            {
                Console.WriteLine("Сохранение конфигурации файла " + swModel.GetTitle() + ": " + x++ + " из " + ConfigCount);
                Configuration swConf = swModel.GetConfigurationByName(configurations[i]);
                CustomPropertyManager swCustPrpMgr = swModel.Extension.CustomPropertyManager[configurations[i]];

                swModel.ShowConfiguration2(swConf.Name);
                Console.WriteLine("Удаление свойств");
                swCustPrpMgr.Delete2("Внешний ключ изделия");
                swCustPrpMgr.Delete2("Масса");
                swCustPrpMgr.Delete2("ERP code");

                string path = pathModel + swConf.Name + ".SLDPRT";

                extension.SaveAs(path, (int)swSaveAsVersion_e.swSaveAsCurrentVersion, (int)swSaveAsOptions_e.swSaveAsOptions_Silent, null, error, war);
                paths.Add(path);
            }


            GetPart(swApp, paths);
            swApp.CloseDoc(pathtofile);
            //swApp.Visible = true;
        }
        swApp.DocumentVisible(true, (int)swDocumentTypes_e.swDocPART);
        Console.WriteLine("Завершено, нажмите любую кнопку....!");
        Console.ReadKey();
    }

    private static void GetPart(SldWorks swApp, List<string> paths)
    {
        int error = 0;
        int war = 0;
        int y = 1;

        foreach (string path in paths)
        {
            IModelDoc2 swModel = swApp.OpenDoc6(path, (int)swDocumentTypes_e.swDocPART, 0, string.Empty, ref error, ref war);
            IModelDocExtension extension = swModel.Extension;
            string[] configurations = swModel.GetConfigurationNames();

            Console.WriteLine(swModel.GetTitle() + "\t" + "\t" + " Всего: " + y++ + " из " + paths.Count);

            for (int i = 0; i < configurations.Length; i++)
            {
                swModel.DeleteConfiguration2(configurations[i]);
            }
            bool saveIs = swModel.Save3((int)swSaveAsOptions_e.swSaveAsOptions_Silent, error, war);
            if (!saveIs)
            {
                Console.WriteLine("Ошибка сохранения " + swModel.GetTitle());
            }
            swApp.CloseDoc(path);
        }
    }
    }
}
