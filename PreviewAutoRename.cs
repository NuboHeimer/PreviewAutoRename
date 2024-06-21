///----------------------------------------------------------------------------
///   Module:       Preview autorename
///   Author:       NuboHeimer (https://vkplay.live/nuboheimer)
///   Email:        nuboheimer@yandex.ru
///   Telegram:     t.me/nuboheimer
///   Version:      1.0.2
///----------------------------------------------------------------------------

using System;
using System.IO;
using System.Text.RegularExpressions;

public class CPHInline
{
    public bool Execute()
    {
        string game = Regex.Replace(args["game"].ToString(), @"[^\w\s]", ""); // вытаскиваем название игры и чистим его от спец.символов.
        CPH.LogInfo(game);
        string pathToPreviewFolder = args["pathToPreviewFolder"].ToString(); // путь до директории с заставками.
        string filename = pathToPreviewFolder + game + ".png";
        string newname = pathToPreviewFolder + "Preview.png";
        if (File.Exists(newname))
        {
            File.Delete(newname);
        }

        File.Copy(filename, newname);
        return true;
    }
}