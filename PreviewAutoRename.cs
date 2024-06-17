using System;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

///----------------------------------------------------------------------------
///   Module:       Preview autorename
///   Author:       NuboHeimer (https://vkplay.live/nuboheimer)
///   Email:        nuboheimer@yandex.ru
///   Telegram:     t.me/nuboheimer
///   Version:      1.0.0
///----------------------------------------------------------------------------

public class CPHInline
{
    public bool Execute()
    {
        string pathToAlertText = args["pathToAlertText"].ToString(); // путь до файла с текстом алёрта о старте стрима. Оттуда берётся название картинки для превью.
        string alertData = File.ReadAllText(pathToAlertText);
        var data = JsonConvert.DeserializeObject<AlertData>(alertData);
        string game = Regex.Replace(data.Game, @"[^\w\s]", ""); // вытаскиваем название игры и чистим его от спец.символов.
        string pathToPreviewFolder = args["pathToPreviewFolder"].ToString(); // путь до директории с заставками.
        string filename = pathToPreviewFolder + game;
        string newname = pathToPreviewFolder + "Prewiev.png";
        if (File.Exists(newname))
        {
            File.Delete(newname);
        }

        File.Copy(filename, newname);
        return true;
    }

    public class AlertData
    {
        public string Game { get; set; }
    }
}